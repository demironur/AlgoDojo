namespace AlgoDojo.NeetCode.Stacks
{
    //https://leetcode.com/problems/car-fleet/description/
    public class CarFleet_853
    {
        public int CarFleet(int target, int[] position, int[] speed)
        {
            int numberofFleets = 0;
            decimal distance = 0;
            var pair = new (int pos, int sp)[position.Length];

            for (var i = 0; i < position.Length; i++)
            {
                pair[i] = (position[i], speed[i]);
            }

            foreach (var (p, s) in pair.OrderByDescending(i => i.Item1))
            {
                var tempDistance = (decimal)(target - p) / s;

                if (distance == 0 || tempDistance > distance)
                {
                    distance = tempDistance;
                    numberofFleets++;
                }
            }

            return numberofFleets;
        }

        public int CarFleetwithStack(int target, int[] position, int[] speed)
        {
            var pair = new (int, int)[position.Length];
            for (var i = 0; i < position.Length; i++)
            {
                pair[i] = (position[i], speed[i]);
            }

            var stack = new Stack<double>();
            foreach (var (p, s) in pair.OrderByDescending(i => i.Item1))
            {
                stack.Push((target - p) / (double)s);
                if (stack.Count >= 2 && stack.Peek() <= stack.Skip(1).First())
                {
                    stack.Pop();
                }
            }

            return stack.Count;
        }

        //slow bad solution
        public int CarFleetwithoutTuple(int target, int[] position, int[] speed)
        {
            var pair = new (int pos, int sp)[position.Length];

            for (var i = 0; i < position.Length; i++)
            {
                pair[i] = (position[i], speed[i]);
            }

            int numberofFleets = 0;
            decimal distance = 0;

            var sortedPosition = position.ToList();
            sortedPosition.Sort();

            for (int i = sortedPosition.Count - 1; i >= 0; i--)
            {
                var index = Array.FindIndex(position, x => x == sortedPosition[i]);
                var tempDistance = (decimal)(target - position[index]) / speed[index];

                if (distance == 0 || tempDistance > distance)
                {
                    distance = tempDistance;
                    numberofFleets++;
                }
            }

            return numberofFleets;
        }
    }
}
