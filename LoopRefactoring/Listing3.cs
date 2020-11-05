using System;
using System.Collections.Generic;
using System.Linq;

namespace LoopRefactoring
{
    public static class Listing3
    {
        public static IEnumerable<int> FilterNumbers(this IEnumerable<int> listOfNumbers, IList<Func<int, bool>> whereConditions)
        {
            foreach (var whereCondition in whereConditions)
            {
                listOfNumbers = listOfNumbers.Where(whereCondition);
            }

            return listOfNumbers;
        }
        
        public static IEnumerable<int> FilterNumbersImmediate(this IList<int> listOfNumbers, IList<Func<int, bool>> whereConditions)
        {
            foreach (var whereCondition in whereConditions)
            {
                listOfNumbers = listOfNumbers.Where(whereCondition).ToList();
            }

            return listOfNumbers;
        }
    }
}