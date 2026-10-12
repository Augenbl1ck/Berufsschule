public class Schaltjahrrechner
{
    public bool isSchaltjahr(int jahr)
    {
        if (jahr < 1)
        {
            throw new ArgumentException("Das Jahr muss größer als 0 sein!", nameof(jahr));
        }

        if((jahr % 400) == 0)
        {
            return true;
        } else if((jahr % 4) == 0 && (jahr % 100) != 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}