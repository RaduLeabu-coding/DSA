public class ValidParanthesis
{
    public static bool IsValid(string s)
    {
        Stack<char> stiva = new Stack<char>();

        var pairs = new Dictionary<char, char>
        {
            [')'] = '(',
            [']'] = '[',
            ['}'] = '{'
        };

        foreach(var character in s)
        {
            if (pairs.TryGetValue(character, out char expectedOpening))
            {
                //inchisa
                if(stiva.Count == 0)
                    return false;
                if(stiva.Pop() != expectedOpening)
                    return false;
            }
            else
            {
                //deschisa
                stiva.Push(character);
            }
        }

        return stiva.Count == 0;
    }


    
}