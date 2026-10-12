public class ZahlsystemUmrechner
{
    public double dezDualZahl(int dezimalZahl)
    {
        return dezimalZahl * 1.0;
    }

    public String dezimalBinär(int dezimalZahl)
    {   
        if (dezimalZahl < 0)
        {
            throw new ArgumentException("Das Alter muss über 0 liegen!", nameof(dezimalZahl));
        }

        if (dezimalZahl == 0) return "0";

        string backBin = "";

        while (dezimalZahl > 0)
        {
            int rest = dezimalZahl % 2;
            backBin = rest + backBin;
            dezimalZahl /= 2;              
        }

        return backBin;
    }

    public int binärDezimal(String binärZahl)
    {
        if (binärZahl == "")
        {
            throw new ArgumentException("Bitte gebe eine Binärzahl an", nameof(binärZahl));
        }

        for (int i = 0; i < binärZahl.Length; i++)
        {
          if(binärZahl.ElementAt(i) == 0 || binärZahl.ElementAt(i) == 1)
            {
                throw new ArgumentException("Bitte gebe nur 0 oder 1 an", nameof(binärZahl));
            }  
        }

        if(binärZahl == "0") return 0;

        int backDez = 0;
        int stellenWert = 1;

        for (int i = 1; i < binärZahl.Length + 1; i++)
        {
            backDez += Convert.ToInt32(binärZahl.ElementAt(binärZahl.Length - i).ToString()) * stellenWert;
            stellenWert *= 2;
        }

        return backDez;
    }

    public String dezimalOkt(int dezimalZahl)
    {   
        if (dezimalZahl < 0)
        {
            throw new ArgumentException("Das Alter muss über 0 liegen!", nameof(dezimalZahl));
        }

        if (dezimalZahl == 0) return "0";

        string backOkt = "";

        while (dezimalZahl > 0)
        {
            int rest = dezimalZahl % 8;
            backOkt = convertNumToHexChar(rest)  + backOkt;
            dezimalZahl /= 8;              
        }

        return backOkt;
    }
    
    public String dezimalHex(int dezimalZahl)
    {   
        if (dezimalZahl < 0)
        {
            throw new ArgumentException("Das Alter muss über 0 liegen!", nameof(dezimalZahl));
        }

        if (dezimalZahl == 0) return "0";

        string backHex = "";

        while (dezimalZahl > 0)
        {
            int rest = dezimalZahl % 16;
            backHex = convertNumToHexChar(rest)  + backHex;
            dezimalZahl /= 16;              
        }

        return backHex;
    }

    private String convertNumToHexChar(int number)
    {
        switch (number)
        {
            case 10:
                return "A";
            case 11:
                return "B";
            case 12:
                return "C";
            case 13:
                return "D";
            case 14:
                return "E";
            case 15:
                return "F";
            default:
                return number.ToString();
        }
    }
}