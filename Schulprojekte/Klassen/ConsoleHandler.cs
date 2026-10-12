using System.Collections;

public class ConsoleHandler
{
    public string selectOption(string[] options)
    {
        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            for (int i = 0; i < options.Length; i++)
            {
                if(i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;
            if(key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if(selectedIndex < 0)
                {
                    selectedIndex = options.Length - 1;
                }
            } else if(key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if(selectedIndex >= options.Length)
                {
                    selectedIndex = 0;
                }
            }
        } while (key != ConsoleKey.Enter);
        
        return options[selectedIndex];
    }

    public ArrayList mehrereEingaben(ArrayList fragen)
    {
        String eingabe;
        ArrayList eingaben = [];
        for (int i = 0; i < fragen.Count; i++)
        {
            Console.WriteLine(fragen[i]);

            eingabe = Console.ReadLine() ?? "";
            
            if(eingabe == "stop")
            {
                eingaben.Add("Stop");
                return eingaben;
            }

            eingaben.Add(eingabe);
        }

        return eingaben;
    }

    public ArrayList eingabenWiederholung(String frage)
    {
        String eingabe = "";
        ArrayList eingaben = [];
        
        do {
            Console.WriteLine(frage);

            eingabe = Console.ReadLine() ?? "";

            if(eingabe == "stop")
            {
                eingaben.Add("Stop");
                return eingaben;
            }

            if(eingabe == "end")
            {
                eingaben.Add("End");
                break;
            }

            eingaben.Add(eingabe);
        } while (eingabe != "end");

        return eingaben;
    }

}