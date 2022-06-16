using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listsortsql
{
    public class Number
    {
        public static string ListSort(string unsortedNumber)
        {
            List<int> numList = new List<int>();
            numList = unsortedNumber.Select(x => (int)char.GetNumericValue(x)).ToList();
            numList.Sort((a, b) => a.CompareTo(b));
            string sortedNumber = string.Empty;
            foreach (int num in numList)
            {
                sortedNumber += "" + num;
            }
            return sortedNumber;

        }

    }
}
