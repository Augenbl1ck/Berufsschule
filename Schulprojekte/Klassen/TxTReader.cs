using System;
using System.IO;

public class TxTReader
{
    public String readTxt (string pfad)
    {
        String txt = "";
        using(StreamReader sr = new StreamReader(pfad, true))
        {
            while (!sr.EndOfStream)
            {
                txt += "\n" + sr.ReadLine();
            }
        }

        return txt;
    }

    public String readTxt(string pfad, string datum)
    {
        String txt = "";
        using(StreamReader sr = new StreamReader(pfad, true))
        {
            while (!sr.EndOfStream)
            {
                String zeile = sr.ReadLine() ?? "";
                if (zeile.Contains(datum))
                {
                    txt += "\n" + zeile;
                }
                
            }
        }

        return txt == "" ? $"Keine Protokolleinträge für den {datum} vorhanden.": txt;
    }
}