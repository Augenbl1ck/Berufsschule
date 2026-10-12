using System;
using System.IO;

public class TxTWriter
{
    public void writeTxt (string pfad, string[] txt)
    {
        using(StreamWriter sw = new StreamWriter(pfad, true))
        {
            for (int i = 0; i < txt.Length; i++)
            {
                sw.WriteLine(txt[i]);
            }
        }
    }
}