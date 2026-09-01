public class BinarySearch
{
    public int BinarySearchSorted(int[] nums, int target)
    {
        int left =0;
        int right = nums.Length - 1;

        while(left <= right)
        {
            int mid = left + (right - left)/2;
            if(nums[mid] < target)
            {
                left = mid + 1;
            }
            else if(nums[mid] > target)
            {
                right = mid - 1;
            }
            else if(nums[mid] == target)
            { 
                return mid;
            }

        }
        return -1;
    }


    public int SearchRotated(int[] nums, int target)
    {
        int left =0;
        int right = nums.Length - 1;

        while(left <= right)
        {
            int mid = left + (right - left)/2;

            if(nums[mid] == target)
                return mid;

            if(nums[left] <= nums[mid])
            {
                if(nums[left] <= target && target < nums[mid])
                {
                    right = mid -1;
                }
                else
                {
                    left = mid + 1;
                }
                
            }else
            {
                if(nums[mid] < target && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

        }
        return -1;
    }


    public int LongestSubstringWithNoDuplicates(string s)
    {
        HashSet<char> window = new HashSet<char>();
        int max =0;
        int left = 0;

        for(int i=0; i< s.Length; i++)
        {
            while(window.Contains(s[i]))
            {
                left++;
                window.Remove(s[i]);
            }
            
            window.Add(s[i]);
            max = Math.Max(window.Count, max);
        }

        return max;
    }
}