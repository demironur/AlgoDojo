namespace AlgoDojo.NeetCode.Arrays_Hashing
{
    public class ValidAnagram_242
    {
        //https://leetcode.com/problems/valid-anagram/
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            if (s == t)
                return true;

            var sDic = new Dictionary<char, int>();
            var tDic = new Dictionary<char, int>();

            foreach (var item in s)
            {
                if (!sDic.ContainsKey(item))
                    sDic.Add(item, 1);
                else
                    sDic[item]++;
            }

            foreach (var item in t)
            {
                if (!tDic.ContainsKey(item))
                    tDic.Add(item, 1);
                else
                    tDic[item]++;
            }

            foreach (var item in sDic)
            {
                if (!tDic.ContainsKey(item.Key) || tDic[item.Key] != item.Value)
                    return false;
            }

            return true;
        }
    }
}
