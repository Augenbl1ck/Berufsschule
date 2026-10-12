public class Urlaubsanspruchrechner
{
    public int getUrlaub(int alter, int arbeitsstart, int arbeitsende, int gradBehinderung)
    {
        if (alter < 0 || alter > 120)
        {
            throw new ArgumentException("Das Alter muss zwischen 0 und 120 liegen!", nameof(alter));
        }

        if (arbeitsstart < 1 || arbeitsstart > 12)
        {
            throw new ArgumentException("Der Arbeitsstart muss zwischen 1 und 12 liegen!", nameof(arbeitsstart));
        }

        if (arbeitsende < 1 || arbeitsende > 12)
        {
            throw new ArgumentException("Das Arbeitsende muss zwischen 1 und 12 liegen!", nameof(arbeitsende));
        }

        if (gradBehinderung < 0 || gradBehinderung > 100)
        {
            throw new ArgumentException("Der Grad der Behinderung muss zwischen 0 und 100 liegen!", nameof(gradBehinderung));
        }

        int urlaub = 24;
        int anzahlArbeitsMonate = arbeitsende - arbeitsstart + 1;

        if (anzahlArbeitsMonate <= 0)
        {
            anzahlArbeitsMonate += 12; // Falls Ende im nächsten Jahr
        }

        if(alter >= 55)
        {
            urlaub += 2;
        }

        if(alter < 18)
        {
            urlaub += 6;
        }

        if(gradBehinderung >= 50)
        {
            urlaub += 5;
        }

        return urlaub / 12 * anzahlArbeitsMonate;
    }
}