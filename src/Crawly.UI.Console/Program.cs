// See https://aka.ms/new-console-template for more information

using Crawly.Core.Domain;
using Crawly.Infrastructure.Extensions;


//Console.WriteLine("Hello, World!");

//var crawlingOptions = new CrawlingOptions(@"C:\\webseiten\\shawna");
//crawlingOptions.CrawlRecursivly = true;
//crawlingOptions.CrawlImages = true;
//crawlingOptions.CrawlStylesheets = true;
//crawlingOptions.DownloadHtml = true;
//crawlingOptions.DowloadStylesheets = true;
//crawlingOptions.DownloadImages = true;
//var crawlingService = new CrawlingService("https://www.shawna.ch/", crawlingOptions);
//crawlingService.StartCrawling();

MainMenu();

void Header()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("#################################");
    Console.WriteLine("### Crawl the Web with Crawly ###");
    Console.WriteLine("#################################\n");
    Console.ResetColor();
}

void MainMenu()
{
    Header();
    Console.WriteLine("    Hauptmenü:");
    Console.WriteLine("-------------------------------------------------------------------------");
    Console.WriteLine("    1 Webseite herunterladen"); 
    Console.WriteLine("    2 Webseiten statistiken ");
    Console.WriteLine("    3 Crawly beenden");
    Console.Write("    Bitte wählen Sie den gewünschten Menupunkt (1-3): ");
    var userInput = Console.ReadLine();

    bool userInputIsNumber = int.TryParse(userInput, out int menuPoint);
    if (userInputIsNumber && menuPoint == 1)
    {
        DownloadMenu();
    }
    else if (userInputIsNumber && menuPoint == 2)
    {
        StatisticsMenu();
    }
    else if (userInputIsNumber && menuPoint == 3)
    {
        CloseCrawly();
    }
    else
    {
        InvalidInput("Bitte geben Sie eine Nummer von 1-3 an.");
        MainMenu();
    }
}

void DownloadMenu()
{
    Header();
    Console.WriteLine("    Download Menü:");
    Console.WriteLine("-------------------------------------------------------------------------");
    Console.WriteLine("    1 Komplette Webseite herunterladen (rekursiv)");
    Console.WriteLine("    2 Einzelne Seite herunterladen\n");
    Console.WriteLine("    3 Alle Bilder einer Webseite herunterladen (rekursiv)");
    Console.WriteLine("    4 Bilder einer einzelnen Seite herunterladen\n");
    Console.WriteLine("    5 Konfigurieren [-r, -html, -img, -css] (Bsp.: 5 -r -img -css):");
    Console.WriteLine("    6 Zrück zum Hauptmenü");
    Console.Write("    Bitte wählen Sie den gewünschten Menupunkt (1-6): ");
    var userInput = Console.ReadLine();

    if(!int.TryParse(userInput, out int menuPoint) || menuPoint > 6)
    {
        InvalidInput("Bitte geben Sie eine Nummer von 1-6 an");
        DownloadMenu();
        return;
    }
    CrawlingUrl(menuPoint);

}

void StatisticsMenu()
{
    Console.Clear();
    Console.WriteLine("    Statistik Menü:");
    Console.WriteLine("-------------------------------------------------------------------------");
    Console.WriteLine("    1 Externe Links anzeigen");
    Console.WriteLine("    2 Externe Links exportieren");
    Console.WriteLine("    3 Zrück zum Hauptmenü");
    Console.Write("    Bitte wählen Sie den gewünschten Menupunkt (1-3):");
    var userInput = Console.ReadLine();
}

void CloseCrawly()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    Vielen Dank, dass Sie Crawly verwendet haben!");
    Console.WriteLine("    Hoffentlich bis bald.");
    ShowSpinner();
    Console.ResetColor();
}

void InvalidInput(string errorMessage)
{ 
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("    Ungültige Eingabe!");
    Console.Write("    " + errorMessage + " ");
    ShowSpinner();
    Console.ResetColor();
}

void CrawlingUrl(int menuPoint)
{
    Header();
    Console.WriteLine("    Sie haben Menupunkt: " + menuPoint + " ausgewählt.");
    Console.WriteLine("    (Mit der Eingabe 'X' gelangen Sie zurück zum Menu.)");
    Console.WriteLine("-------------------------------------------------------");
    Console.Write("    Bitte geben Sie die gewünschte URL an: ");
    var url = Console.ReadLine();

    try
    {
        UriHelper.CreateBaseUri(url ?? string.Empty);
    }
    catch
    {
        InvalidInput("Bitte geben Sie eine gülte URL im Format (Format: [protokoll]://[domain].[extension])");
        CrawlingUrl(menuPoint);
    }

}

void ShowSpinner()
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