namespace AlgoDojo.NeetCode.Arrays_Hashing
{
    //https://leetcode.com/problems/longest-consecutive-sequence/
    public class LongestConsecutiveSequence_128
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            HashSet<int> numsSet = nums.ToHashSet();
            int longest = 0;

            foreach (var item in numsSet)
            {
                if (!numsSet.Contains(item - 1))
                {
                    var index = item + 1;
                    int tempLongest = 1;

                    while (numsSet.Contains(index))
                    {
                        tempLongest++;
                        index++;
                    }

                    longest = Math.Max(longest, tempLongest);
                }
            }

            return longest;
        }
    }
}
