using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewCodeLogic.StartUp.Example_1.Entity;

namespace InterviewCodeLogic.StartUp.Example_1
{
    public class IsValid
    {
        public IsValid()
        {
        }
        public bool CheckIsValid(InputType argument)
        {
            Stack<char> stack = new Stack<char>();
            if (argument.Input == null)
            {
                return false;
            }
            foreach (char c in argument.Input)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(c);
                        break;

                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                            return false;
                        break;

                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                            return false;
                        break;

                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                            return false;
                        break;

                    default:
                        return false;
                }
            }

            return stack.Count == 0;
        }
    }
}