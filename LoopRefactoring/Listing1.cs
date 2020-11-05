using System.Collections.Generic;
using System.Linq;

namespace LoopRefactoring
{
    public static class Listing1
    {
        public static IEnumerable<int> GetEvenNumbersWithLoop(this IList<int> listOfNumbers)
        {
            foreach (var number in listOfNumbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        public static IEnumerable<int> GetEvenNumbersWithLinq(this IList<int> listOfNumbers)
        {
            // Use local named function
            bool Even(int x) => x % 2 == 0;
            return listOfNumbers.Where(Even);
        }
    }
}