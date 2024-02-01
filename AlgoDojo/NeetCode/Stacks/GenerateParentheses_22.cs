using System.Collections;
using System.Text;

namespace AlgoDojo.NeetCode.Stacks
{
    //https://leetcode.com/problems/generate-parentheses/description/
    public class GenerateParentheses_22
    {
        public IList<string> GenerateParenthesis(int n)
        {

            Stack stack = new Stack();

            var result = GenerateParenthesis(n, stack, 0, 0);

            return result;
        }

        //todo
        public IList<string> GenerateParenthesis(int n, Stack stack, int openN, int closeN)
        {
            List<string> result = new List<string>();

            if (stack.Count == n * 2)
            {
                result.Add(stack.ToString());
                stack.Clear();
            }

            if (openN < n)
            {
                stack.Push('(');
                openN++;
            }

            if (closeN < openN)
            {
                stack.Push(')');
                closeN++;
            }

            GenerateParenthesis(n, stack, openN, closeN);

            return result;
        }

        public IList<string> GenerateParenthesisBacktrack(int n)
        {
            var result = new List<string>();
            var seq = new StringBuilder();

            void backtrack(int open, int close)
            {
                if (seq.Length == n * 2)
                {
                    result.Add(seq.ToString());
                    return;
                }

                if (open < n)
                {
                    seq.Append("(");
                    backtrack(open + 1, close);
                    seq.Remove(seq.Length - 1, 1);
                }
                if (close < open)
                {
                    seq.Append(")");
                    backtrack(open, close + 1);
                    seq.Remove(seq.Length - 1, 1);
                }

            }

            backtrack(0, 0);

            return result;
        }
    }
}
