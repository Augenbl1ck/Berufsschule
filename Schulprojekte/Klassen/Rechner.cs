public class Rechner
{
    private int zahl1, zahl2;
    private String eingabe = ""; 

    private bool LeseZahl(string prompt, out int zahl)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fehler: Eingabe darf nicht leer sein!");
            Console.ResetColor();
            zahl = 0;
            return false;
        }

        if (!int.TryParse(input, out zahl))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Fehler: '{input}' ist keine gültige Ganzzahl!");
            Console.ResetColor();
            return false;
        }

        return true;
    }

    public void start()
    {
        Console.WriteLine("Was? ('+', '-', '*', '/' oder 'stop' eingeben)");
        eingabe = Console.ReadLine() ?? "";
        while (eingabe != "stop")
        {
            try
            {
                switch (eingabe)
                {
                    case "+":
                        if (LeseZahl("Bitte die erste Zahl eingeben: ", out zahl1) && 
                            LeseZahl("Bitte die zweite Zahl eingeben: ", out zahl2))
                        {
                            Console.WriteLine(zahl1 + " + " + zahl2 + " = " + (zahl1 + zahl2));
                        }
                        break;
                    case "-":
                        if (LeseZahl("Bitte die erste Zahl eingeben: ", out zahl1) && 
                            LeseZahl("Bitte die zweite Zahl eingeben: ", out zahl2))
                        {
                            Console.WriteLine(zahl1 + " - " + zahl2 + " = " + (zahl1 - zahl2));
                        }
                        break;
                    case "*":
                        if (LeseZahl("Bitte die erste Zahl eingeben: ", out zahl1) && 
                            LeseZahl("Bitte die zweite Zahl eingeben: ", out zahl2))
                        {
                            Console.WriteLine(zahl1 + " * " + zahl2 + " = " + (zahl1 * zahl2));
                        }
                        break;
                    case "/":
                        if (LeseZahl("Bitte die erste Zahl eingeben: ", out zahl1) && 
                            LeseZahl("Bitte die zweite Zahl eingeben: ", out zahl2))
                        {
                            if (zahl2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Fehler: Division durch Null ist nicht erlaubt!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine(zahl1 + " : " + zahl2 + " = " + (zahl1 / zahl2) + " Rest " + (zahl1 % zahl2));
                            }
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Unbekannte Operation. Bitte '+', '-', '*', '/' oder 'stop' eingeben.");
                        Console.ResetColor();
                        Console.Write("Press any key to continue . . . ");
                        Console.ReadKey(true);
                        break;
                }  
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
                Console.ResetColor();
            }
            
            Console.WriteLine("Was?");
            eingabe = Console.ReadLine() ?? "";
        }
    }
}