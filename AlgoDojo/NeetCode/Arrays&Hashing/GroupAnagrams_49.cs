namespace AlgoDojo.NeetCode.Arrays_Hashing
{
    //https://leetcode.com/problems/group-anagrams/
    public class GroupAnagrams_49
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var groupedStrings = new Dictionary<string, IList<string>>() { };

            for (int i = 0; i < strs.Length; i++)
            {
                var key = Core.GetStringHashKey(strs[i]);

                if (!groupedStrings.ContainsKey(key))
                    groupedStrings.Add(key, new List<string>() { strs[i] });
                else
                    groupedStrings[key].Add(strs[i]);
            }

            return groupedStrings.Values.ToList();
        }
    }
}
