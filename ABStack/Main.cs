public sealed class App {

    static void Main()
    {
        Stack myStack = new();

        myStack.push(5);
        myStack.push(8);
        myStack.push(3);
        myStack.swap();
        Console.WriteLine(myStack);

        Forth forth = new Forth();
        Stack ergebnis = forth.eval("5   3 4 DUP * SWAP DUP * +");

        Console.WriteLine(ergebnis);
    }
}