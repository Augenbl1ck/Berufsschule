public sealed class App
{
    static void Main()
    {
        try
        {
            Datum test = new(1, 2, 2006);
            test.setDatum(2,2,2006);
            Console.WriteLine($"{test} ist der {test.TagDesJahres()}. Tag im Jahr.");

            test.add(10);
            Console.WriteLine(test.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nFataler Fehler: {ex.Message}");
        }
    }
}
