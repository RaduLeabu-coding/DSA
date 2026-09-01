namespace DSA.Strings;
using System.Linq;
using System.Text;
public  class LexicographicallySmallestPalindrome
{
    public static bool IsPalindrome(string s)
    {
        // return s.SequenceEqual(s.Reverse());
        if (s is null)
        {
            return false;
        }


        int left = 0;
        int right = s.Length - 1;

        while(left < right)
        {
            if(s[left] != s[right] && char.IsLetterOrDigit(s[left]) && char.IsLetterOrDigit(s[right]))
            {
                return false;
            }
            
            left++;
            right--;
        }

        return true;
    }

    public static bool IsPrime(int n)
    {
        if(n <= 1)
        {
            return false;
        }

          if (n == 2)
        {
            return true;
        }

        if (n % 2 == 0)
        {
            return false;
        }
       
        for(int i = 3; i * i <= n; i += 2)
        {
            if(n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

     public string SmallestPalindrome(string s) {
        // O(n log n) solution
        //grupez literele si le numar frecventa
        // var counts =  s.GroupBy(c => c)
        //               .Select(charGroup => new { Char = charGroup.Key, Count = charGroup.Count() })
        //               .OrderBy(c => c.Char)
        //               .ToList();

        // verific daca exista mai mult de un caracter cu frecventa impara
        // var oddCounts = counts.Where(c => c.Count % 2 != 0).ToList();
        
        // if(oddCounts.Count > 1)
        // {
        //     return "NO PALINDROME";
        // }

       
        // construiesc prima jumate a palindromului
        // StringBuilder firstHalf = new StringBuilder();
        
        // iau exact jumate din numarul de aparitii al fiecarei litere
        // foreach (var item in counts)
        // {
        //     int half = item.Count / 2;
        //     firstHalf.Append(item.Char, half);
        // }

        // identific caracterul din mijloc daca exista
        // string middle = oddCounts.Count == 1 ? oddCounts[0].Char.ToString() : "";

        // construiesc a doua jumate prin reverse la prima
        // char[] firstHalfArray = firstHalf.ToString().ToCharArray();
        // Array.Reverse(firstHalfArray);
        // string secondHalf = new string(firstHalfArray);


        // return firstHalf.ToString() + middle + secondHalf;

        //much faster solution O(n)
        string result = "";

        if(s.Length == 1)
        {
            return s;
        }

        int n = s.Length;
        int[] bucket = new int[26];

        for (int i = 0; i < n / 2; i++) {
            bucket[s[i] - 'a']++;
        }

        char[] res = new char[n];
        int left = 0;
        int right = n - 1;

        for (int i = 0; i < 26; i++) {
            while (bucket[i] > 0) {
                char c = (char)(i + 'a');
                res[left++] = c;
                res[right--] = c;
                bucket[i]--;
            }
        }

        if (n % 2 != 0) {
            res[left] = s[n / 2];
        }

        return new string(res);

    }

    

}