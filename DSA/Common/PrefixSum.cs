public class PrefixSum
{
    public int EquilibriumIndex(int[] array)
    {
        int[] suffixesSums = new int[array.Length];
        int[] prefixesSums = new int[array.Length];

        prefixesSums[0] = array[0];
        suffixesSums[array.Length -1] = array[array.Length-1];

        for(int i=1; i< array.Length; i++)
        {
            prefixesSums[i]= prefixesSums[i-1] + array[i];
        }

        for(int i=array.Length - 2; i>= 0; i--)
        {
            suffixesSums[i]= suffixesSums[i+1] + array[i];
        }

        for(int i=0; i<array.Length; i++)
        {
            if(suffixesSums[i] == prefixesSums[i])
                return i;
        }

        return -1;
    }


    public int EquilibriumPoint(int[] arr) {
        int prefSum = 0, total = 0;

        // Calculate the array sum
        foreach (int ele in arr) {
            total += ele;
        }

        // Iterate pivot over all the elements
        // of the array and till prefSum != suffSum
        for (int pivot = 0; pivot < arr.Length; pivot++) {
            int suffSum = total - prefSum - arr[pivot];
            if (prefSum == suffSum) {
                return pivot;
            }
            prefSum += arr[pivot];
        }
        
        return -1;
    }
}