using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework;

namespace LoopRefactoring.Test
{
    public class Listing3Tests
    {
        private IList<int> listOfNumbers;
        
        [SetUp]
        public void Setup()
        {
            this.listOfNumbers = Enumerable.Range(0, 10000).ToList();
        }

        [Test]
        public void FilterNumbers_HandoverListOfNumbers_GetFilteredList()
        {
            // Assert
            var expected = new List<int> {9992, 9994, 9996, 9998};
            var filter = new List<Func<int, bool>>
            {
                i => i % 2 == 0,
                i => i > 9990
            };
            
            // Act
            var start = DateTime.Now;
            var evenNumbers = this.listOfNumbers.FilterNumbers(filter);
            var end = DateTime.Now;
            var executionTime = end - start;
            Console.WriteLine($"Execution time: {executionTime.Ticks} Ticks");
            
            // Assert
            Assert.That(evenNumbers, Is.EquivalentTo(expected));
        }
        
        [Test]
        public void FilterNumbersImmediate_HandoverListOfNumbers_GetFilteredList()
        {
            // Assert
            var expected = new List<int> {9992, 9994, 9996, 9998};
            var filter = new List<Func<int, bool>>
            {
                i => i % 2 == 0,
                i => i > 9990
            };
            
            // Act
            var start = DateTime.Now;
            var evenNumbers = this.listOfNumbers.FilterNumbersImmediate(filter);
            var end = DateTime.Now;
            var executionTime = end - start;
            Console.WriteLine($"Execution time: {executionTime.Ticks} Ticks");
            
            // Assert
            Assert.That(evenNumbers, Is.EquivalentTo(expected));
        }
    }
}