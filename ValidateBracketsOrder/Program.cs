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
                    Console.Write("Enter a string of brackets\n\n>>> ");
                    string input = Console.ReadLine().Trim();
                    if (ValidateBrackets(input))
                    {
                        Console.WriteLine("\nThe order is correct.");
                    }
                    else
                    {
                        Console.WriteLine("\nThe order is incorrect.");
                    }
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

        /*
        ASCII Values
        ( - 40
        ) - 41
        < - 60
        > - 62
        [ - 91
        ] - 93
        { - 123
        } - 125
        */
        static bool ValidateBrackets(string input)
        {
            Stack<char> myStack = new Stack<char>();
            // the inputted character's ASCII value has to be in one of these two sets
            int[] openValues = { 40, 60, 91, 123 };
            int[] closeValues = { 41, 62, 93, 125 };
            bool keepLooping = true;
            bool isValid = false;
            do
            {
                foreach (var ch in input)
                {
                    // adds the opening bracket to the Stack
                    if (openValues.Contains(ch))
                    {
                        myStack.Push(ch);
                    }
                    // compares the closing brackets with with the last opening bracket on Stack and pops it if they match
                    else if (closeValues.Contains(ch) && myStack.Count() != 0)
                    {
                        if (myStack.Peek() + 1 == ch || myStack.Peek() + 2 == ch)
                        {
                            myStack.Pop();
                        }
                        else
                        {
                            return isValid;
                        }
                    }
                    //checks for unmatched closing brackets
                    else if (closeValues.Contains(ch) && myStack.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        keepLooping = false;
                        throw new Exception("\nInvalid Entry!");
                    }
                }
                // Checks for unmatched opening brackets
                if (myStack.Count() == 0)
                {
                    isValid = true;
                }
                keepLooping = false;
            } while (keepLooping);
            return isValid;
        }
    }
}
