using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listsortsql
{
    public class Number
    {
        public static string ListSort(string unsortedNumber, string direction, bool boolDir)
        {
            List<int> numList = new List<int>();
            numList = unsortedNumber.Select(x => (int)char.GetNumericValue(x)).ToList();
            if (direction == "1")
            {
                numList.Sort((a, b) => a.CompareTo(b));
                boolDir = true;
            }
            else if(direction == "2")
            {
                numList.Sort((b, a) => a.CompareTo(b));
                boolDir = false;
            }
            else
            {
                numList.Sort((b, a) => a.CompareTo(b));
                boolDir = false;
            }
            string sortedNumber = string.Empty;
            foreach (int num in numList)
            {
                sortedNumber += "" + num;
            }
            return sortedNumber;

        }

    }
}
