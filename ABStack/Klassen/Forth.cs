public class Forth
{
    private Stack stack = new();

    public Stack eval(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Eingabe darf nicht leer sein.");

        string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //RemoveEmptyEntries -> Leerzeichen z.B. dazwische entfernen, TrimEntries -> Leerzeichn am ANfang und Ende vom Token entfernen

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double zahl))
            {
                stack.push((int)zahl);
                continue;
            }

            switch (token.ToUpperInvariant())
            {
                case "DUP":
                    stack.dup();
                    break;

                case "SWAP":
                    stack.swap();
                    break;

                case "+":
                    stack.add();
                    break;

                case "*":
                    stack.mul();
                    break;

                case "-":
                    stack.sub();
                    break;

                case "/":
                    stack.div();
                    break;

                default:
                    throw new InvalidOperationException($"Unbekanntes Token: {token}");
            }
        }

        return stack;
    }
}