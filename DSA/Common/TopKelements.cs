public class TopK
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var keyValuePairs = new Dictionary<int, int>();

        int[] result = new int[k];

        foreach (int number in nums)
        {
            keyValuePairs.TryGetValue(number, out int count);
            keyValuePairs[number] = count + 1;
        }

        var sortedValues = keyValuePairs.OrderByDescending(x => x.Value).ToList();

        for (int i=0; i < k; i++)
        {
            result[i] = sortedValues[i].Key;
        }
        return result;
    }

    public int[] TopKFrequentOptimizedPriorityQueue(int[] nums, int k)
    {
        var keyValuePairs = new Dictionary<int, int>();
        var minHeap = new PriorityQueue<int, int>();

        int[] result = new int[k];

        foreach (int number in nums)
        {
            keyValuePairs.TryGetValue(number, out int count);
            keyValuePairs[number] = count + 1;
        }

        foreach(var pair in keyValuePairs)
        {
            minHeap.Enqueue(pair.Key, pair.Value);

            if(minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        for (int i=0; i < k; i++)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
    }

}