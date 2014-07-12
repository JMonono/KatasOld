using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestClass]
    public class NumberExtractorTests
    {
        [TestMethod]
        public void ImplementsINumberStringParser()
        {
            // Arrange
            var extractor = new NumberStringParser();

            // Act

            // Assert
            Assert.IsTrue(extractor is INumberStringParser);
        }

        [TestMethod]
        public void ParseWithOneNumberReturnsTheNumber()
        {
            // Arrange
            var expected = new string[] { "2" };
            var extractor = new NumberStringParser();
            string numbers = "2";

            // Act
            string[] actual = extractor.Parse(numberString: numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseTwoCommaThreeReturnsNumbersInAnArray()
        {
            // Arrange
            var expected = new string[] { "2", "3" };
            var extractor = new NumberStringParser();
            string numbers = "2,3";

            // Act
            string[] actual = extractor.Parse(numberString: numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseTwoCommaThreeCommaFourReturnsNine()
        {
            // Arrange
            var expected = new string[] { "2", "3", "4" };
            var extractor = new NumberStringParser();
            string numbers = "2,3,4";

            // Act
            string[] actual = extractor.Parse(numberString: numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
