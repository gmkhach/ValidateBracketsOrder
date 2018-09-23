using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBracketsOrder
{
    class Util
    {
        public static string GetString()
        {
            Console.Write("Enter a string of brackets\n\n>>> ");
            return Console.ReadLine().Trim();
        }

        public static int[] GenerateIntArray(string input)
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

        public static int GetVal(char ch)
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
