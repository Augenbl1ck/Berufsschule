public class Datum
{
    private int[] datum;

    public Datum()
    {
        DateTime heute = DateTime.Today;
        datum = [heute.Day, heute.Month, heute.Year];
    }

    public Datum(int tag, int monat, int jahr)
    {
        datum = [tag, monat, jahr];
    } 

    public int Tag
    {
        get { return datum[0]; }
    }

    public int Monat
    {
        get { return datum[1]; }
    }

    public int Jahr
    {
        get { return datum[2]; }
    }

    public void setDatum(int tag, int monat, int jahr)
    {
        if (tag < 0 || monat < 0 || jahr < 0) throw new ArgumentException("Bitte gebe keine negativen Werte ein!", nameof(datum));
        datum = [tag, monat, jahr];
    } 

    public int[] getDatum()
    {
        return datum;
    }

    public override string ToString()
    {
        return $"{Tag}.{Monat}.{Jahr}";
    }

    public bool isSchaltjahr(int jahr)
    {
        if (jahr < 1) throw new ArgumentException("Das Jahr muss größer als 0 sein!", nameof(jahr));
        return (jahr % 400 == 0) || ((jahr % 4 == 0) && (jahr % 100 != 0));
    }

    public int tageDesMonats()
    {
        return tageImMonat(Monat);
    }

    public int TagDesJahres()
    {
        if (Monat < 1 || Monat > 12) throw new ArgumentException("Der Monat muss zwischen 1 und 12 liegen!");
        return Tag + summeVorherigerMonate();
    }

    private int summeVorherigerMonate()
    {
        int summe = 0;
        for (int monat = 1; monat < Monat; monat++) summe += tageImMonat(monat);
        
        return summe;
    }

    private int tageImMonat(int monat)
    {
        return tageImMonat(monat, Jahr);
    }

    private int tageImMonat(int monat, int jahr)
    {
        if (monat < 1 || monat > 12) throw new ArgumentException("Der Monat muss zwischen 1 und 12 liegen!");

        return monat switch
        {
            2 => isSchaltjahr(jahr) ? 29 : 28,
            4 or 6 or 9 or 11 => 30,
            _ => 31
        };
    }

    public void add(int tage)
    {
        int tag = Tag + tage;
        int monat = Monat;
        int jahr = Jahr;

        while (tag > tageImMonat(monat, jahr))
        {
            tag -= tageImMonat(monat, jahr);
            monat++;

            if (monat > 12)
            {
                monat = 1;
                jahr++;
            }
        }

        setDatum(tag, monat, jahr);
    }

    public void remove(int tage)
    {
        int tag = Tag - tage;
        int monat = Monat;
        int jahr = Jahr;

        while (tag < 1)
        {
            monat--;

            if (monat < 1)
            {
                monat = 12;
                jahr--;
            }

            tag += tageImMonat(monat, jahr);
        }

        setDatum(tag, monat, jahr);
    }
}