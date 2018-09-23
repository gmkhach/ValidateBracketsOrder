/**
* Given a string containing a combination of parentheses and brackets, determine if they open/close in the correct order.
* []{}()<> are all valid.
* ie: "{()}" should return true, but "{(})" should return false
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBracketsOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string of brackets\n\n>>> ");
            string input = Console.ReadLine().Trim();
            bool valid = ValidateBrackets(input);
            if (valid)
            {
                Console.WriteLine("The bracket are in proper order.");
            }
            else
            {
                Console.WriteLine("The brackets are not in proper order.");
            }
                
        }

        static bool ValidateBrackets(string input)
        {
            int[] array = GenerateIntArray(input);
            if (array[0] < 0)
                return false;
            List<int> tracker = new List<int>();
            tracker.Add(array[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (array[i] > 0)
                {
                    tracker.Add(array[i]);
                }
                else
                {
                    if (tracker[tracker.Count()-1] == Math.Abs(array[i]))
                    {
                        tracker.RemoveRange(tracker.Count() - 1, 1);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static int[] GenerateIntArray(string input)
        {
            int[] array = new int[input.Length];
            int i = 0;
            foreach (char ch in input)
            {
                array[i] = GetVal(ch);
                i++;
            }
            return array;
        }

        private static int GetVal(char ch)
        {
            int value = 0;
            switch (ch)
            {
                case '(':
                    value = 1;
                    break;
                case ')':
                    value = -1;
                    break;
                case '{':
                    value = 2;
                    break;
                case '}':
                    value = -2;
                    break;
                case '[':
                    value = 3;
                    break;
                case ']':
                    value = -3;
                    break;
                case '<':
                    value = 4;
                    break;
                case '>':
                    value = -4;
                    break;
            }
            return value;
        }
    }
}
