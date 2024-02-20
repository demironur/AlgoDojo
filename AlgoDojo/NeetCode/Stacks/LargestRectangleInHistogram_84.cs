namespace AlgoDojo.NeetCode.Stacks
{
    //https://leetcode.com/problems/largest-rectangle-in-histogram/
    public class LargestRectangleInHistogram_84
    {
        public int LargestRectangleArea(int[] heights)
        {
            int maxArea = 0;
            int count = 0;
            List<int> areaList = new List<int>();

            for (int i = 0; i < heights.Length; i++)
            {

                if (heights[i] >= maxArea)
                {
                    maxArea = heights[i];
                    count = 1;
                    areaList.Clear();
                    areaList.Add(heights[i]);
                    continue;
                }

                int min = Math.Min(areaList.Min(), heights[i]);

                if (min * (count + 1) > maxArea)
                {
                    count++;
                    maxArea = heights[i] * count;
                    areaList.Add(heights[i]);
                }
            }

            return maxArea;
        }
    }
}
