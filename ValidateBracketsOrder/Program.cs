/**
* Given a string containing a combination of parentheses and brackets, determine if they open/close in the correct order.
* []{}()<> are all valid.
* ie: "{()}" should return true, but "{(})" should return false
*/

using System;
using System.Collections;
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
            do
            {
                try
                {
                    Console.Write("Enter an expression containing brackets\n\n>>> ");
                    string input = Console.ReadLine().Trim();
                    Console.WriteLine($"\nThe order is {(ValidateBrackets(input) ? "correct" : "incorrect.")}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Write("\nPress Enter to try another string...");
                Console.ReadLine();
                Console.Clear();
            } while (true);
        }

        static bool ValidateBrackets(string input)
        {
            Stack<char> myStack = new Stack<char>();
            foreach (var ch in input)
            {
                // adds the opening bracket to the Stack
                if ("({[<".Contains(ch))
                {
                    myStack.Push(ch);
                }
                // compares the closing brackets with the last opening bracket on Stack and pops it if they match
                else if (")}]>".Contains(ch))
                {
                    // checks for unmatched closing brackets
                    if (myStack.Count() == 0)
                    {
                        return false;
                    }
                    // tries to match the closing bracket with the last character in myStack.
                    else if (myStack.Peek() + 1 == ch || myStack.Peek() + 2 == ch)
                    {
                        myStack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // Checks for unmatched opening brackets
            return myStack.Count() == 0;
        }
    }
}
