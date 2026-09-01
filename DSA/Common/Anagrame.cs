public static class Anagrame
{
    //complexitate O(n * k log k) n = numarul de cuvinte, k = lungimea medie a cuvintelor
    public static IList<IList<string>> GroupAnagrams(string[] words)
    {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

        foreach(var word in words)
        {
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);

            if(!groups.TryGetValue(key, out List<string>? group))
            {
                group = new List<string>();
                groups[key] = group;
            }
            group.Add(word);

        }
        return groups.Values.ToList<IList<string>>();
    }


    //complexitate O(n * k) n = numarul de cuvinte, k = lungimea medie a cuvintelor
    public static IList<IList<string>> GroupAnagramsOptimized(string[] words)
    {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

        foreach(var word in words)
        {
            int[] frequency = new int[26];

            for(int i=0; i<word.Length;i++)
            {
                frequency[word[i] - 'a']++;
            }
            
            string key = string.Join("#", frequency);
            if(!groups.TryGetValue(key, out List<string>? group))
            {
                group = new List<string>();
                groups[key] = group;
            }
            group.Add(word);

        }
        return groups.Values.ToList<IList<string>>();
    }
}