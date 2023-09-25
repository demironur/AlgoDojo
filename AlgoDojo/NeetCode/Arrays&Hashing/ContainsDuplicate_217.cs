namespace AlgoDojo.NeetCode.Arrays_Hashing
{
    //https://leetcode.com/problems/contains-duplicate/description/
    public class ContainsDuplicate_217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> numsHash = new HashSet<int>();

            foreach (var item in nums)
            {
                if (numsHash.Contains(item))
                    return true;
                else
                    numsHash.Add(item);
            }

            return false;
        }
    }
}
