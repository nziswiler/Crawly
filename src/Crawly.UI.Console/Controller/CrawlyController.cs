using Crawly.Core.Domain;
using Crawly.Infrastructure.Extensions;
using Crawly.Infrastructure.Services;
using Crawly.UI.CommandLine.View;

namespace Crawly.UI.CommandLine.Controller
{
    public class CrawlyController
    {
        private Uri? uri;
        private CrawlingOptions? crawlingOptions;

        public CrawlyController()
        {
            this.MainMenuScreen();
        }

        public void StartCrawling()
        {
            if (this.uri != null && this.crawlingOptions != null)
            {
                CrawlyView.DisplayCrawlingScreen();
                var crawlingService = new CrawlingService(this.uri, this.crawlingOptions);
                crawlingService.StartCrawling();
                DisplaySuccessMessage("Der Vorgang wurde erfolgreich abgeschlossen. Drücken Sie Enter um zum Hauptmenü zurückzukehren...");
            }
            else
            {
                ErrorMessage("Etwas ist bei der Konfiguration schief gegangen. Versuchen Sie es erneuts.");
            }

            this.MainMenuScreen();
        }

        private void MainMenuScreen()
        {
            var userInput = CrawlyView.GetMainMenuInput();
            bool userInputIsNumber = int.TryParse(userInput, out int menuPoint);
            if (userInputIsNumber && menuPoint == 1)
            {
                DownloadMenuScreen();
            }
            else if (userInputIsNumber && menuPoint == 2)
            {
                StatisticsMenuScreen();
            }
            else if (userInputIsNumber && menuPoint == 3)
            {
                CloseCrawly();
            }
            else
            {
                ErrorMessage("Bitte geben Sie eine Nummer von 1-3 an.");
                MainMenuScreen();
            }
        }

        public void DownloadMenuScreen()
        {
            var userInput = CrawlyView.GetDownloadMenuInput();
            if (!int.TryParse(userInput, out int menuPoint) || menuPoint > 6)
            {
                ErrorMessage("Bitte geben Sie eine Nummer von 1-6 an");
                DownloadMenuScreen();
                return;
            }

            if (menuPoint == 6)
            {
                MainMenuScreen();
                return;
            }

            CrawlingUrlScreen(menuPoint);
            TargetDirectoryScreen(menuPoint);

            if (menuPoint == 1)
            {
                crawlingOptions?.DowloadFullPageRecusivly();
            }
            else if (menuPoint == 2)
            {
                crawlingOptions?.DowonloadHtmlFilesRecursivly();
            }
            else if (menuPoint == 3)
            {
                crawlingOptions?.DowloadFullPageSingle();
            }
            else if (menuPoint == 4)
            {
                crawlingOptions?.DownloadImagesSingle();
            }

            this.StartCrawling();
        }

        private void CrawlingUrlScreen(int parentMenuPoint)
        {
            var userInput = CrawlyView.GetCrawlingUrl(parentMenuPoint);
            try
            {
                if (userInput.ToLower().Equals("x"))
                {
                    DownloadMenuScreen();
                    return;
                }

                this.uri = UriHelper.CreateBaseUri(userInput ?? string.Empty);
            }
            catch
            {
                ErrorMessage("Bitte geben Sie eine gülte URL im Format (Format: https://domain.ch) an");
                CrawlingUrlScreen(parentMenuPoint);
            }
        }

        private void TargetDirectoryScreen(int parentMenuPoint)
        {
            var userInput = CrawlyView.GetTargetDirectory(parentMenuPoint);
            try
            {
                if (userInput.ToLower().Equals("x"))
                {
                    DownloadMenuScreen();
                    return;
                }

                if (!Path.IsPathFullyQualified(userInput) && Directory.Exists(Path.GetPathRoot(userInput)))
                {
                    throw new NotSupportedException();
                }

                crawlingOptions = new CrawlingOptions(userInput);
            }
            catch
            {
                ErrorMessage("Bitte geben Sie einen gülten Pfad im Format [Laufwerkbuchstabe]:/pfad/zum/ordner an)");
                TargetDirectoryScreen(parentMenuPoint);
            }
        }

        public void StatisticsMenuScreen()
        {
            var userInput = CrawlyView.GetStatisticsMenuInput();
        }

        private static void ErrorMessage(string message)
        {
            CrawlyView.DisplayErrorMessage(message);
        }

        private static void DisplaySuccessMessage(string message)
        {
            CrawlyView.DisplaySuccessMessage(message);
        }

        private static void CloseCrawly()
        {
            CrawlyView.DisplayClosingScreen();
            Environment.Exit(0);
        }
    }
}
