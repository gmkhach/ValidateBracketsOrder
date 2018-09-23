using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBracketsOrder
{
    class BracketStringHandler
    {
        public BracketStringHandler(string input)
        {
            this.input = input;
        }

        private string input;

        public void Run()
        {
            if (ValidateBrackets(input))
            {
                Console.WriteLine("\nThe bracket are in proper order.");
            }
            else
            {
                Console.WriteLine("\nThe brackets are not in proper order.");
            }
        }

        public bool ValidateBrackets(string input)
        {
            int[] array = Util.GenerateIntArray(input);
            if (array[0] < 0)
            {
                return false;
            }
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
                    if (tracker[tracker.Count() - 1] == Math.Abs(array[i]))
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

    }
}
