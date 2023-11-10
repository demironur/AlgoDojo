namespace AlgoDojo.NeetCode.Arrays_Hashing
{
    //https://leetcode.com/problems/two-sum/ 
    public class TwoSum_1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var numsDic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];

                if (numsDic.ContainsKey(diff))
                    return new int[] { i, numsDic[diff] };

                numsDic[nums[i]] = i;
            }

            return null;
        }
    }
}
