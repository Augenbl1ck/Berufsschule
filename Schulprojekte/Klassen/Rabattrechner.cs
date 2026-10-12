public class Rabattrechner
{
    public double rechneRabatt(double preis, int anzahl, double rabatt)
    {
        if (preis < 0)
        {
            throw new ArgumentException("Der Preis darf nicht negativ sein!", nameof(preis));
        }

        if (anzahl <= 0)
        {
            throw new ArgumentException("Die Anzahl muss größer als 0 sein!", nameof(anzahl));
        }

        if (rabatt < 0 || rabatt > 100)
        {
            throw new ArgumentException("Der Rabatt muss zwischen 0 und 100 Prozent liegen!", nameof(rabatt));
        }

        return preis * anzahl * (rabatt / 100);
    }
}