namespace AlgoDojo.NeetCode.Stacks
{
    public class MinStack_155
    {
        private Stack<int> stack;
        private Stack<int> minStack;

        public MinStack_155()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            int min = Math.Min(val, minStack.Count != 0 ? minStack.Peek() : val);
            minStack.Push(min);
        }

        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
