//given a sequence of transactions, return the total successful amount for every customer, ignoring duplicate transactions. A transaction is considered successful if it has a positive amount and a unique transaction ID. 
using System;

namespace DSA.Common;

public record Transaction(string CustomerId, string TransactionId, decimal Amount, bool IsSuccessful);

public static class TransactionCalculator
{
    public static IReadOnlyDictionary<string, decimal> CalculateTotals(IEnumerable<Transaction> transactions)
    {
        // var totals = new Dictionary<string, decimal>();
        // var seenTransactionIds = new HashSet<string>();

        // foreach (var transaction in transactions)
        // {
        //     if (transaction.IsSuccessful && transaction.Amount > 0 && !seenTransactionIds.Contains(transaction.TransactionId))
        //     {
        //         if (!totals.ContainsKey(transaction.CustomerId))
        //         {
        //             totals[transaction.CustomerId] = 0;
        //         }
        //         totals[transaction.CustomerId] += transaction.Amount;
        //         seenTransactionIds.Add(transaction.TransactionId);
        //     }
        // }

        // return totals;

        // return transactions.Aggregate(
        //     new Dictionary<string, decimal>(),
        //     (totals, transaction) =>
        //     {
        //         if (transaction.IsSuccessful && transaction.Amount > 0)
        //         {
        //             if (!totals.ContainsKey(transaction.CustomerId))
        //             {
        //                 totals[transaction.CustomerId] = 0;
        //             }
        //             totals[transaction.CustomerId] += transaction.Amount;
        //         }
        //         return totals;
        //     });


        return transactions
            .Where(t => t.IsSuccessful)
            .DistinctBy(t => t.TransactionId)
            .GroupBy(t => t.CustomerId)
            .ToDictionary( 
                g => g.Key,
                g => g.Sum(x => x.Amount));
    }

    //array nesortat
    public static int[] FindPair(int[] arr, int targetSum)
    {
        // for(int i = 0; i< arr.Length; i++)
        // {
        //     for(int j = i+1; j< arr.Length; j++)
        //     {
        //         if(arr[i] + arr[j] == targetSum)
        //         {
        //             return [i, j];
        //         }
        //     }
        // }
        // return [];
        var seen = new Dictionary<int, int>();
        for(int i=0; i < arr.Length; i++)
        {
            int complement = targetSum - arr[i];
            if(seen.TryGetValue(complement, out int index))
            {
                return new int[] { index, i };
            }
            seen[arr[i]] = i;
        }
        return new int[] { };
    }

    
    //array sortat
    public static int[] TwoSumSorted(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        // Continuăm cât timp left < right
        while(left < right)
        {
            int sum = nums[left] + nums[right];
            if(sum > target)
            {
                right--;
            }
            else if(sum == target )
            {
                return new int[] { left, right};
            }
            else
            {
                left++;
            }
        }

        throw new InvalidOperationException("No solution found.");
    }


    public static int FindMostFrequent(int[] arr)
    {
        var map = new Dictionary<int, int>();
        int mosFreq = arr[0];
        int highestCount = 0;
        foreach(var num in arr)
        {
            int newCount = map.TryGetValue(num, out int count) ? count + 1 : 1;
            map[num] = newCount;

            if (newCount > highestCount)
            {
                highestCount = newCount;
                mosFreq = num;
            }
        }       
        return mosFreq;
    }


    //Find all elements occurring strictly more than N/K times.
    public static int FindMostFrequentMisraGries(int[] arr, int k)
    {
        ArgumentNullException.ThrowIfNull(arr);
        if (arr.Length == 0)
        {
            throw new ArgumentException("The array must not be empty.", nameof(arr));
        }
        if (k < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(k), "k must be at least 2.");
        }

        var candidates = new Dictionary<int, int>();

        foreach (var value in arr)
        {
            if (candidates.ContainsKey(value))
            {
                candidates[value]++;
            }
            else if (candidates.Count < k - 1)
            {
                candidates[value] = 1;
            }
            else
            {
                foreach (var candidate in candidates.Keys.ToArray())
                {
                    candidates[candidate]--;
                    if (candidates[candidate] == 0)
                    {
                        candidates.Remove(candidate);
                    }
                }
            }
        }

        if (candidates.Count == 0)
        {
            throw new InvalidOperationException("No frequent candidate was found.");
        }

        var exactCounts = candidates.Keys.ToDictionary(value => value, _ => 0);
        foreach (var value in arr)
        {
            if (exactCounts.ContainsKey(value))
            {
                exactCounts[value]++;
            }
        }

        return exactCounts
            .OrderByDescending(pair => pair.Value)
            .Select(pair => pair.Key)
            .First();
    }


     //Scrie o metodă care primește o listă de intervale și unește intervalele care se suprapun:
    //Input:
    // [[1,3], [2,6], [8,10], [15,18]]

    // Output:
    // [[1,6], [8,10], [15,18]]

    public static int[][] MergeIntervals(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return Array.Empty<int[]>();
        }
        // Sort the intervals based on the starting point
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        //
        int[] currentInterval = intervals[0];
        // Iterate through the intervals and merge overlapping ones
        foreach (var interval in intervals.Skip(1))
        {
            if (interval[0] <= currentInterval[1])
            {
                // Overlapping intervals, merge them 
                //
                currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
            }
            else
            {
                // No overlap, add the current interval to the merged list and move to the next one
                merged.Add(currentInterval);
                currentInterval = interval;
            }
        }

        merged.Add(currentInterval);
        return merged.ToArray();
    }

    
}