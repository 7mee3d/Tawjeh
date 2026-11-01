namespace Validations;


public static class Validations
{

    public static bool IsContainDigits(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            System.Console.WriteLine("The text is empty or null");
            return true;
        }

        foreach (var c in text)
        {
            if (
                char.IsDigit(c) ||
                char.IsNumber(c) ||
                char.IsPunctuation(c) ||
                char.IsSymbol(c)
                )
                return true;
        }

        return false ;
    }
}