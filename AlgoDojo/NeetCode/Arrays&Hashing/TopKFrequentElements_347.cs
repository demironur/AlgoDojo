namespace AlgoDojo.NeetCode.Arrays_Hashing
{
    //https://leetcode.com/problems/top-k-frequent-elements/
    public class TopKFrequentElements_347
    {
        //Bucket Sort
        public int[] TopKFrequent(int[] nums, int k)
        {
            // Step 1: Build the frequency map of elements in the nums array
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (freqMap.ContainsKey(num))
                    freqMap[num]++;
                else
                    freqMap[num] = 1;
            }

            // Step 2: Prepare a list of lists to store elements with the same frequency
            List<int>[] buckets = new List<int>[nums.Length + 1];
            foreach (var num in freqMap.Keys)
            {
                int freq = freqMap[num];
                if (buckets[freq] == null)
                    buckets[freq] = new List<int>();
                buckets[freq].Add(num);
            }

            // Step 3: Build the result array from buckets in descending order of frequency
            List<int> result = new List<int>();
            for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--)
            {
                if (buckets[i] != null)
                    result.AddRange(buckets[i]);
            }

            // Step 4: Convert the result list to an array and return
            return result.ToArray();
        }
        //Priority Queue (Heap)
        public int[] TopKFrequentWithPriorityQueue(int[] nums, int k)
        {
            Dictionary<int, int> freqMap = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (freqMap.ContainsKey(nums[i]))
                    freqMap[nums[i]]++;
                else
                    freqMap[nums[i]] = 1;
            }

            PriorityQueue<int, int> pq = new();
            foreach (var key in freqMap.Keys)
            {
                pq.Enqueue(key, freqMap[key]);
                if (pq.Count > k)
                    pq.Dequeue();
            }

            int[] res = new int[k];
            int j = k;

            while (pq.Count > 0)
                res[--j] = pq.Dequeue();

            return res;
        }
        //Linq
        public int[] TopKFrequentLinq(int[] nums, int k)
        {

            Dictionary<int, int> numsDic = new();
            Dictionary<int, int> resultDic = new();
            int[] result = new int[k];

            foreach (var item in nums)
            {
                if (!numsDic.ContainsKey(item))
                {
                    numsDic.Add(item, 1);
                }
                else
                {
                    numsDic[item]++;
                }
            }

            //Linq
            foreach (var item in numsDic.OrderByDescending(x => x.Value).Take(k))
            {
                result[k - 1] = item.Key;
                k--;
            }

            return result;
        }
    }
}
