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
                string input = GetString();
                if (ValidateBrackets(input))
                {
                    Console.WriteLine("\nThe order is correct.");
                }
                else
                {
                    Console.WriteLine("\nThe order is incorrect.");
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
            int[] openValues = { 40, 60, 91, 123 };
            int[] closeValues = { 41, 62, 93, 125 };
            bool keepLooping = true;

            do
            {
                try
                {
                    foreach (var ch in input)
                    {
                        if (openValues.Contains(ch))
                        {
                            myStack.Push(ch);
                        }
                        else if (closeValues.Contains(ch) && myStack.Count() != 0)
                        {
                            if(myStack.Peek() + 1 == ch || myStack.Peek() + 2 == ch)
                            {
                                myStack.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (myStack.Count() == 0)
                        {
                            return false;
                        }
                        else
                        {
                            keepLooping = false;
                            throw new Exception("Invalid Entry!");
                        }
                    }
                    keepLooping = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }while(keepLooping) ;

            return true;
        }

        static string GetString()
        {
            Console.Write("Enter a string of brackets\n\n>>> ");
            return Console.ReadLine().Trim();
        }
    }
}
