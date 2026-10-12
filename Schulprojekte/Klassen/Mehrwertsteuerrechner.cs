public class Mehrwertsteuerrechner
{
    private double nettoPreis, mehrwertsteuerbetrag, bruttoEinzelpreis, bruttoGesamtpreis;
    private int warenAnzahl;

    public double[] rechneBrutto(double netto, int warenAnzahl)
    {
        if (netto < 0)
        {
            throw new ArgumentException("Der Nettopreis darf nicht negativ sein!", nameof(netto));
        }

        if (warenAnzahl <= 0)
        {
            throw new ArgumentException("Die Warenanzahl muss größer als 0 sein!", nameof(warenAnzahl));
        }

        nettoPreis = netto;
        this.warenAnzahl = warenAnzahl;

        mehrwertsteuerbetrag = nettoPreis * 0.19;

        bruttoEinzelpreis = nettoPreis + mehrwertsteuerbetrag;
        bruttoGesamtpreis = (nettoPreis + mehrwertsteuerbetrag) * warenAnzahl;
        return [nettoPreis, mehrwertsteuerbetrag, bruttoEinzelpreis, bruttoGesamtpreis];
    }

    public void toString()
    {
        Console.WriteLine(nettoPreis);
        Console.WriteLine(mehrwertsteuerbetrag);
        Console.WriteLine(bruttoEinzelpreis);
        Console.WriteLine(bruttoGesamtpreis);
        Console.WriteLine(warenAnzahl);
    }
}