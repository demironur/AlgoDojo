using System.Collections;

namespace AlgoDojo.NeetCode.Stacks
{
    public class ValidParentheses_20
    {
        public bool IsValid(string s)
        {
            Stack stack = new Stack();

            foreach (var item in s)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    stack.Push(item);
                }
                else
                {
                    if (stack.Count == 0)
                        return false;

                    var temp = (char)stack.Peek();

                    if ((temp == '(' && item == ')') || (temp == '[' && item == ']') || (temp == '{' && item == '}'))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        public bool IsValidOrNot(string s)
        {
            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char>()
            {
                [')'] = '(',
                [']'] = '[',
                ['}'] = '{'
            };

            foreach (char c in s)
            {
                if (!pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
