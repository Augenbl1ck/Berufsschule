using System.Dynamic;

public class ISBNRechner
{
    public int Pruefziffer(String ziffer)
    {
        int rückgabe = 0;
        for (int i = 0; i < ziffer.Length; i++)
        {
            rückgabe += (int)char.GetNumericValue(ziffer[i]) * (i + 1);
        }
        
        return rückgabe % 11;
    }
}