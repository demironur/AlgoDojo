namespace AlgoDojo.NeetCode.Stacks
{
    internal class EvaluateReversePolishNotation_155
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> tokenStack = new();
            HashSet<string> operators = new() { "+", "-", "*", "/" };
            int result = Convert.ToInt32(tokens[0]);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (operators.Contains(tokens[i]))
                {
                    result = Calculate(tokenStack, tokens[i]);
                    tokenStack.Push(result);
                }
                else
                {
                    tokenStack.Push(Convert.ToInt32(tokens[i]));
                }
            }

            return result;
        }

        int Calculate(Stack<int> tokenStack, string op)
        {
            int result = 0;
            int num2 = tokenStack.Pop();
            int num1 = tokenStack.Pop();

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    break;
            }

            return result;
        }
        
        //NeetCode solution
        public int EvalRPN2(string[] tokens)
        {
            var stack = new Stack<int>();
            var result = 0;

            foreach (var token in tokens)
            {
                int number = 0;
                var isNumber = int.TryParse(token, out number);
                if (isNumber)
                    stack.Push(number);
                else
                {
                    result = evaluate(stack.Pop(), stack.Pop(), token);
                    stack.Push(result);
                }

            }

            return stack.Pop();
        }
        
        private static int evaluate(int b, int a, string op) => op switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => a / b,
            _ => throw new Exception()
        };
    }
}
