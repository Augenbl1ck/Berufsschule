using System.Collections;
using System.Threading;
using System.Threading.Tasks;

public sealed class App {
    static ConsoleHandler consoleHandler = new();

    static void Main()
    {
        try
        {
            
            Console.ResetColor();
            Console.WriteLine("\n\nWas möchtest du ausführen?");
            String[] options = [
                                "Mehrwertsteuerrechner", 
                                "Rechner", 
                                "Rabattrechner", 
                                "Schaltjahrrechner",
                                "Urlaubsanspruch", 
                                "Tagesumsatzrechner", 
                                "Dezimalzahl -> Binärzahl", 
                                "Binärzahl -> Dezimalzahl", 
                                "Dezimalzahl -> Oktalzahl", 
                                "Dezimalzahl -> Hexadezimalzahl", 
                                "UhrzeitProtokollWrite", 
                                "UhrzeitWrite", 
                                "UhrzeitSave", 
                                "UhrzeitProtokollRead", 
                                "UhrzeitProtokollReadDatum", 
                                "ArrayAufgabe",
                                "Prüfziffer berechnen",
                                "Programm stoppen"
                            ];
            String eingabe = consoleHandler.selectOption(options);
            while (eingabe != "Programm stoppen")
        {
            Console.Clear();
            try {
                switch (eingabe)
                {
                    case "Mehrwertsteuerrechner":
                        MehrwertsteuerrechnerM();
                        break;
                    case "Rechner":
                        new Rechner().start();
                        break;
                    case "Rabattrechner":
                        RabattrechnerM();
                        break;
                    case "Schaltjahrrechner":
                        SchaltjahrrechnerM();
                        break;
                    case "Urlaubsanspruch":
                        UrlaubsanspruchM();
                        break;
                    case "Tagesumsatzrechner":
                        TagesumsatzrechnerM();
                        break;
                    case "Dezimalzahl -> Binärzahl":
                        DezimalBinärM();
                        break;
                    case "Binärzahl -> Dezimalzahl":
                        BinärDezimalM();
                        break;
                    case "Dezimalzahl -> Oktalzahl":
                        DezimalOktalM();
                        break;
                    case "Dezimalzahl -> Hexadezimalzahl":
                        DezimalHexadezimalM();
                        break;
                    case "UhrzeitProtokollWrite":
                        UhrzeitProtokollWriteM();
                        break;
                    case "UhrzeitWrite":
                        UhrzeitWriteM();
                        break;
                    case "UhrzeitProtokollRead":
                        UhrzeitProtokollReadM();
                        break;
                    case "UhrzeitProtokollReadDatum":
                        UhrzeitProtokollReadDatumM();
                        break;
                    case "ArrayAufgabe":
                        ArrayAufgabeM();
                        break;
                    case "Prüfziffer berechnen":    
                        PruefzifferM();
                        break;
                    default:
                        Console.WriteLine("Keine zulässige Eingabe/Eingabe wurde keiner Methode zugeordnet");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fehler: Ungültige Eingabe! Bitte geben Sie gültige Zahlen ein.");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fehler: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
                Console.ResetColor();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n> Drücke Enter um zum Hauptmenu zu gelangen");
            Console.ResetColor();
            try
            {
                Console.ReadLine();
            }
            catch
            {
                Console.ResetColor();
            }

            Console.WriteLine("\n\nWas möchtest du ausführen?");
            eingabe = consoleHandler.selectOption(options);
        }
        }
        catch (Exception ex)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nFataler Fehler: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            Console.ResetColor();
        }
    }



    private static void MehrwertsteuerrechnerM()
    {
        var test = new Mehrwertsteuerrechner();
        ArrayList mwstEingaben = new();
        for (int i = 0; i < 2; i++)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Wie hoch ist der Einzelpreis?");
                    break;
                case 1:
                    Console.WriteLine("Wie viel Stück haben Sie davon gekauft?");
                    break;
                default:
                    break;
            }

            string mwstInput = Console.ReadLine() ?? "";
            
            if(mwstInput == "stop")
            {
                return;
            }

            mwstEingaben.Add(mwstInput);
        }
        var ergebnis = test.rechneBrutto(Convert.ToDouble(mwstEingaben[0]), Convert.ToInt32(mwstEingaben[1]));
        Console.WriteLine($"Mehrwertsteuerbetrag pro Stück: {ergebnis[1]:f2}, Bruttoeinzelpreis: {ergebnis[2]:f2}, Bruttogesamtpreis: {ergebnis[3]:f2}");
    }

    private static void RabattrechnerM()
    {
        ArrayList rabattEingaben = consoleHandler.mehrereEingaben(["Wie hoch ist der Einzelpreis?", "Wie viel Stück haben Sie davon gekauft?", "Wie viel Rabatt wollen Sie gewähren?"]);
                        
        if (rabattEingaben.Contains("Stop"))
        {
            return;
        }

        double rabattErgebnis = new Rabattrechner().rechneRabatt(Convert.ToDouble(rabattEingaben[0]), Convert.ToInt32(rabattEingaben[1]), Convert.ToDouble(rabattEingaben[2]));
        
        Console.Clear();
        Console.WriteLine($"Für das Produkt ergibt sich folgende Berechnung mit einem Rabattsatz von {rabattEingaben[2]}%: \nStück: {rabattEingaben[1]}\nGesamtpreis ohne Rabatt {Convert.ToDouble(rabattEingaben[0]) * Convert.ToInt32(rabattEingaben[1]):f2}\nGesamtpreis nach Rabattabzug: {rabattErgebnis:f2}");
    }

    private static void SchaltjahrrechnerM()
    {
        Console.WriteLine("Gebe das Jahr ein");

        string jahrInput = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(jahrInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fehler: Eingabe darf nicht leer sein!");
            Console.ResetColor();
            return;
        }

        bool schaltjahrErgebnis = new Schaltjahrrechner().isSchaltjahr(Convert.ToInt32(jahrInput));
        Console.WriteLine($"Das Jahr {jahrInput} ist {(schaltjahrErgebnis ? "" : "k")}ein Schaltjahr");
    }

    private static void UrlaubsanspruchM()
    {
        ArrayList urlaubEingaben = consoleHandler.mehrereEingaben(["Alter des Beschäftigten?", "Beschäftigungsstart (Monat 1-12)?", "Beschäftigungsende?", "Grad der Behinderung in Prozent"]);
                        
        if (urlaubEingaben.Contains("Stop"))
        {
            return;
        }

        int urlaubErgebnis = new Urlaubsanspruchrechner().getUrlaub(Convert.ToInt32(urlaubEingaben[0]), Convert.ToInt32(urlaubEingaben[1]), Convert.ToInt32(urlaubEingaben[2]), Convert.ToInt32(urlaubEingaben[3]));
        
        Console.Clear();
        Console.WriteLine($"Der Urlaubsanspruch beträgt {urlaubErgebnis} {(urlaubErgebnis == 1 ? "Tag" : "Tage")}");
    }

    private static void TagesumsatzrechnerM()
    {
        String vertreterID = "";
        int gesamtUmsatz = 0;
        
        while(true){
            Console.WriteLine("Bitte Vertreter-Nr. eingeben (Ende der Eingabe = end):");

            vertreterID = Console.ReadLine() ?? ""; 

            if (vertreterID == "Stop")
            {
                return;
            }

            if (vertreterID == "end")
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Gesamtumme für Vertreter: {gesamtUmsatz}");
                break;
            }

            if (!Microsoft.VisualBasic.Information.IsNumeric(vertreterID))
            {
                throw new ArgumentException("Die Vertreter-Nr. muss eine Zahl sein", nameof(vertreterID));
            }

            Console.WriteLine("\n");
            ArrayList umsatz = consoleHandler.eingabenWiederholung($"Bitte Umsatz für Vertreter {vertreterID} eingeben (Ende der Eingabe = end): ");
        
            if (umsatz.Contains("Stop"))
            {
                return;
            }

            if (umsatz.Contains("End"))
            {
                int summe = 0;

                foreach(String i in umsatz)
                {
                    if(i != "End"){
                        if (!Microsoft.VisualBasic.Information.IsNumeric(i))
                        {
                            throw new ArgumentException("Die Umsätze müssen Zahlen sein", nameof(i));
                        }
                        
                        summe += Convert.ToInt32(i);
                    }
                }

                gesamtUmsatz += summe;
                Console.WriteLine($"Summe für Vertreter {vertreterID}: {summe}");
            }

            Console.WriteLine("\n\n");
        };
    }

    private static void DezimalBinärM()
    {
        Console.WriteLine("Gebe eine Dezimalzahl ein");

        String dezBinEingabe = Console.ReadLine() ?? "";
        
        if (dezBinEingabe.Contains("Stop"))
        {
            return;
        }

        String binErgebnis = new ZahlsystemUmrechner().dezimalBinär(Convert.ToInt32(dezBinEingabe));

        Console.Clear();
        Console.WriteLine($"Dezimal -> Binär\n{dezBinEingabe} -> {binErgebnis}"); 
    }

    private static void BinärDezimalM()
    {
        Console.WriteLine("Gebe eine Binrzahl ein");

        String binDezEingabe = Console.ReadLine() ?? "";
        
        if (binDezEingabe.Contains("Stop"))
        {
            return;
        }

        int dezErgebnis = new ZahlsystemUmrechner().binärDezimal(binDezEingabe);

        Console.Clear();
        Console.WriteLine($"Binärzahl -> Dezimalzahl\n{binDezEingabe} -> {dezErgebnis}"); 
    }

    private static void DezimalOktalM()
    {
        Console.WriteLine("Gebe eine Dezimalzahl ein");

        String dezOktEingabe = Console.ReadLine() ?? "";
        
        if (dezOktEingabe.Contains("Stop"))
        {
            return;
        }

        String oktErgebnis = new ZahlsystemUmrechner().dezimalOkt(Convert.ToInt32(dezOktEingabe));

        Console.Clear();
        Console.WriteLine($"Dezimalzahl -> Oktalzahl\n{dezOktEingabe} -> {oktErgebnis}"); 
    }

    private static void DezimalHexadezimalM()
    {
        Console.WriteLine("Gebe eine Dezimalzahl ein");

        String dezHexEingabe = Console.ReadLine() ?? "";
        
        if (dezHexEingabe.Contains("Stop"))
        {
            return;
        }

        String hexErgebnis = new ZahlsystemUmrechner().dezimalHex(Convert.ToInt32(dezHexEingabe));

        Console.Clear();
        Console.WriteLine($"Dezimal -> Hexadezimalzahl\n{dezHexEingabe} -> {hexErgebnis}");     
    }

    private static void UhrzeitProtokollWriteM()
    {
        Console.WriteLine("Uhrzeitprotokoll gestartet");
        String pfad = @"H:\vscode_projects\Schulprojekte\Logs\log.txt";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\n> Drücke Enter um das Protokoll zu stoppen");
        Console.ResetColor();

        TxTWriter txtWriter = new TxTWriter();
        txtWriter.writeTxt(pfad, [$"Datum Uhrzeit - Text"]);
        
        bool enterPressed = false;
        Task.Run(() =>
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Enter)
                {
                    enterPressed = true;
                    break;
                }
            }
        });

        Task.Run(() =>
        {
            while (!enterPressed)
            {
                txtWriter.writeTxt(pfad, [$"{DateTime.Now} - text"]);
                Thread.Sleep(60000);
            }
        });

        while(!enterPressed){}
    }

    private static void UhrzeitWriteM()
    {
        String pfad4 = @"H:\vscode_projects\Schulprojekte\Logs\log.txt";

        ArrayList potokollEingaben = consoleHandler.mehrereEingaben(["Zimmernummer?", "Zimmerpreis?", "Name?"]);
        
        if (potokollEingaben.Contains("Stop"))
        {
            return;
        }

        TxTWriter txtWriter3 = new TxTWriter();
        txtWriter3.writeTxt(pfad4, [$"Datum Uhrzeit - Zimmernummer - Zimmerpreis - Name"]);
        txtWriter3.writeTxt(pfad4, [$"{DateTime.Now} - {potokollEingaben[0]} - {potokollEingaben[1]} - {potokollEingaben[2]}"]);
    }

    private static void UhrzeitProtokollReadM()
    {
        String pfad2 = @"H:\vscode_projects\Schulprojekte\Logs\log.txt";

        TxTReader txtReader = new TxTReader();
        
        Console.WriteLine(txtReader.readTxt(pfad2));  
    }

    private static void UhrzeitProtokollReadDatumM()
    {
        String pfad3 = @"H:\vscode_projects\Schulprojekte\Logs\log.txt";
                        
        Console.WriteLine("Gebe ein Datum ein");

        String datumEingabe = Console.ReadLine() ?? "";
        
        if (datumEingabe.Contains("Stop"))
        {
            return;
        }
        

        TxTReader txtReader2 = new TxTReader();
        
        Console.WriteLine(txtReader2.readTxt(pfad3, datumEingabe));
    }

    private static void ArrayAufgabeM()
    {
        string[] Artikel = ["Mountainbike TRACK", "Mountainbike EXTREME", "Tandem", "Puky", "Croozer", "Radset", "Sattel"];
        
        for(int i = 0; i < Artikel.Length; i++){
            Console.WriteLine(i + ": " + Artikel[i]);
        }
    }

    private static void PruefzifferM()
    {
        Console.WriteLine("Gebe eine ISBN ein");

        String isbnEingabe = Console.ReadLine() ?? "";
        
        if (isbnEingabe.Contains("Stop"))
        {
            return;
        }

        ISBNRechner iSBNRechner = new();

        Console.WriteLine(iSBNRechner.Pruefziffer(isbnEingabe));
    }
}
