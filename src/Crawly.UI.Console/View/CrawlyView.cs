namespace Crawly.UI.CommandLine.View
{
    public static class CrawlyView
    {
        public static string GetMainMenuInput()
        {
            DisplayHeader();
            Console.WriteLine("    Hauptmenü:");
            Console.WriteLine("    ---------------------------------------------------------------------");
            Console.WriteLine("    1 Herunterladen Webseite");
            Console.WriteLine("    2 Statistiken Webseite \n");
            Console.WriteLine("    3 Crawly beenden\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-3): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetDownloadMenuInput()
        {
            DisplayHeader();
            Console.WriteLine("    Download Menü:");
            Console.WriteLine("    ---------------------------------------------------------------------");
            Console.WriteLine("    1 Komplette Webseite herunterladen (rekursiv). !Hohe Belastung für Server möglich!");
            Console.WriteLine("    2 Nur HTML-Dateien einer Webseite herunterladen (rekursiv)");
            Console.WriteLine("    3 Einzelne Seite komplett herunterladen");
            Console.WriteLine("    4 Bilder einer einzelnen Seite herunterladen");
            Console.WriteLine("    5 CSS einer einzelnen Seite herunterladen");
            Console.WriteLine("    6 Zrück zum Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-6): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetStatisticsMenuInput()
        {
            DisplayHeader();
            Console.WriteLine("    Statistik Menü:");
            Console.WriteLine("    ----------------------------------------------------------------------");
            Console.WriteLine("    1 Statistik der Webseite als TXT-Datei exportieren");
            Console.WriteLine("    2 Externe Links als TXT-Datei exportieren\n");
            Console.WriteLine("    3 Zurück zum Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-3): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetCrawlingUrl(int menuPoint)
        {
            DisplayHeader();
            Console.WriteLine("    Du hast den Menupunkt: " + menuPoint + " ausgewählt.");
            Console.WriteLine("    (Mit der Eingabe 'X' gelangen Sie zurück zum Hauptmenü.)");
            Console.WriteLine("    -----------------------------------------------------");
            Console.Write("    Bitte gib die gewünschte URL an (Format: https://domain.ch): ");

            return Console.ReadLine() ?? string.Empty;

        }

        public static string GetTargetDirectory(int menuPoint)
        {
            DisplayHeader();
            Console.WriteLine("    Du hast den Menupunkt: " + menuPoint + " ausgewählt.");
            Console.WriteLine("    (Mit der Eingabe 'X' gelangst du zurück zum Hauptmenü.)");
            Console.WriteLine("    -----------------------------------------------------");
            Console.Write("    Bitte gib den gewünschten Speicherort an (Format: [Laufwerkbuchstabe]:/mein/pfad): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static void DisplayCrawlingScreen()
        {
            DisplayHeader();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    Das Crawling wurde nun gestartet.");
            Console.WriteLine("    Dieser Vorgang kann einige Zeit in Anspruch nehemen.");
            Console.WriteLine("    Vielen Dank für Deine Geduld!\n");
            Console.ResetColor();
        }

        public static void DisplayClosingScreen()
        {
            DisplayHeader();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Vielen Dank, dass Du Crawly verwendet hast!");
            Console.Write("    Hoffentlich bis bald. ");
            ShowSpinner();
            Console.ResetColor();
        }

        public static void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    Ungültige Eingabe!");
            Console.Write("    " + errorMessage + " ");
            ShowSpinner();
            Console.ResetColor();
        }

        public static void DisplaySuccessMessage(string successMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    Der Vorgang war Erfolgreich!");
            Console.Write("    " + successMessage + " ");
            Console.ResetColor();
            Console.ReadLine();
        }

        private static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("    #################################");
            Console.WriteLine("    ### Crawl the web with Crawly ###");
            Console.WriteLine("    #################################\n");
            Console.WriteLine("    Crawly ist ein freundliches Tool. Bitte crawle nur Webseiten, welche es explizit erlauben!");
            Console.WriteLine("    Überprüfe vor jedem Crawling-Vorgang, ob in der Robots.txt Datei (meistens im Root-Ordner der Webseite)");
            Console.WriteLine("    crawling zugelassen wird. Respektiere den Wunsch der Betreiber. Danke.\n");
            Console.WriteLine("    ###########################################################################################################\n");
            Console.ResetColor();
        }

        private static void ShowSpinner()
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                switch (counter % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                counter++;
                Thread.Sleep(100);
            }
        }
    }
}
