using System.Reflection;

public class MaxSub
{
    //SLIDING WINDOW
    //suma maxima a celui mai lung subsir dintr un sir si indexii 
   public (int Sum, int[] idx) MaxSubArray(int[] nums)
   {
        int maxSum = nums[0];
        int currentSum = nums[0];

        int bestStart =0;
        int bestEnd = 0;
        int currentStart = 0;

        for(int i=0; i< nums.Length; i++)
        {
            if(nums[i] > currentSum + nums[i])
            {
                currentSum = nums[i];
                currentStart = i;
            }
            else
            {
                currentSum = currentSum + nums[i];
            }

            if(currentSum > maxSum)
            {
                maxSum = currentSum;
                bestStart = currentStart;
                bestEnd = i;
            }
        }

        int[] values = nums[bestStart..(bestEnd +1)];
        return (Sum: maxSum, idx: values);
   }

    public double FindMaxAverage(int[] nums, int k)
    {
        int windowSum = nums.Take(k).Sum();
        int maxSum = 0;

        for(int i=k; i<nums.Length; i++)
        {
           windowSum = windowSum - nums[i-k] + nums[i];
           maxSum = Math.Max(maxSum, windowSum);
        }

        return (double) maxSum/k;
    }

    //slinding window cu dimensiune variabila
    public int LengthOfLongestSubstringNoDuplicates(string s)
    {
        HashSet<char> window = new HashSet<char>();
        int left = 0;
        int maxLength = 0;

        for(int i=0; i< s.Length; i++)
        {
            while(window.Contains(s[i]))
            {
                window.Remove(s[left]);
                left++;
            }

            window.Add(s[i]);
            maxLength = Math.Max(maxLength, i - left + 1);
        }

       return maxLength;

    }



}