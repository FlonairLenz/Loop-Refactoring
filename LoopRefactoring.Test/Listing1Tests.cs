using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LoopRefactoring.Test
{
    public class Listing1Tests
    {
        private IList<int> listOfNumbers;
        
        [SetUp]
        public void Setup()
        {
            this.listOfNumbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
        }

        [Test]
        public void GetEvenNumbersWithLoop_HandoverListOfNumbers_GetListOfEvenNumbers()
        {
            // Assert
            var expected = new List<int> {2, 4, 6, 8};
            
            // Act
            var evenNumbers = this.listOfNumbers.GetEvenNumbersWithLoop();
            
            // Assert
            Assert.That(evenNumbers, Is.EquivalentTo(expected));
        }
        
        [Test]
        public void GetEvenNumbersWithLinq_HandoverListOfNumbers_GetListOfEvenNumbers()
        {
            // Assert
            var expected = new List<int> {2, 4, 6, 8};
            
            // Act
            var evenNumbers = this.listOfNumbers.GetEvenNumbersWithLinq();
            
            // Assert
            Assert.That(evenNumbers, Is.EquivalentTo(expected));
        }
    }
}