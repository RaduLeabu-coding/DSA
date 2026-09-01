public class Subsets
{
    public IList<IList<int>> SubsetsBacktracking(int[] nums)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();

        Backtrack(result, current, nums, 0);
       

        return result;
    }


    private void Backtrack(List<IList<int>> result,  List<int> current, int[] nums, int index)
    {
        result.Add(new List<int>(current));

        for(int i = index; i < nums.Length; i++)
        {
            // Alegem numărul
            current.Add(nums[i]);

            // Explorăm toate continuările acestei alegeri
            Backtrack(result, current, nums, i + 1);

            // Anulăm alegerea
            current.RemoveAt(current.Count - 1);
        }
    }
}