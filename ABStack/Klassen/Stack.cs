public class Stack
{
    double[] myStack;
    int anzahl = 0;
    
    public Stack()
    {
        myStack = new double[50];
    }

    public double push(int v)
    {
        myStack[anzahl] = v;
        anzahl++;
        return myStack[anzahl - 1];
    }

    public double pop()
    {
        if (anzahl == 0)
            throw new InvalidOperationException("Stack ist leer.");

        anzahl--;
        return myStack[anzahl];
    }

    public void add()
    {
        anzahl--;
        myStack[anzahl - 1] = myStack[anzahl - 1] + myStack[anzahl];
    }

    public void mul()
    {
        anzahl--;
        myStack[anzahl - 1] = myStack[anzahl - 1] * myStack[anzahl];
    }

    public void sub()
    {
        anzahl--;
        myStack[anzahl - 1] = myStack[anzahl - 1] - myStack[anzahl];
    }

    public void div()
    {
        anzahl--;
        myStack[anzahl - 1] = myStack[anzahl - 1] / myStack[anzahl];
    }

    public double dup()
    {
        myStack[anzahl] = myStack[anzahl - 1];
        anzahl++;
        return myStack[anzahl];
    }

    public void swap()
    {
        double letzterWert = myStack[anzahl - 2]; 
        myStack[anzahl - 2] = myStack[anzahl - 1];
        myStack[anzahl - 1] = letzterWert;
    }

    public override string ToString()
    {
        string stringStack = string.Join(" ", myStack.Take(anzahl).Where(x => x != 0));
        return stringStack;
    }
}