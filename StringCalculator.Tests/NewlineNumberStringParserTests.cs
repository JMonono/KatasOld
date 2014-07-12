using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestClass]
    public class NewlineNumberStringParserTests
    {
        private INumberStringParser _baseParser = new NumberStringParser();

        [TestMethod]
        public void ImplementsINumberStringParser()
        {
            // Arrange
            var parser = new NewlineNumberStringParser(numberStringParser: _baseParser);

            // Act

            // Assert
            Assert.IsTrue(parser is INumberStringParser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresNumberStringParserOnInitialise()
        {
            // Arrange
            INumberStringParser baseParser = null;
            var parser = new NewlineNumberStringParser(numberStringParser: baseParser);
        }

        [TestMethod]
        public void ParseWithOneNumberReturnsTheNumber()
        {
            // Arrange
            var expected = new string[] { "1" };
            var numbers = "1";
            var parser = new NewlineNumberStringParser(numberStringParser: _baseParser);

            // Act
            var actual = parser.Parse(numberString: numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseTwoNewlineThreeReturnsFive()
        {
            // Arrange
            var expected = new string[] { "2", "3" };
            var extractor = new NewlineNumberStringParser(numberStringParser: _baseParser);
            string numbers = "2\n3";

            // Act
            string[] actual = extractor.Parse(numberString: numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtractNumbersTwoNewlineThreeCommaFourReturnsNine()
        {
            // Arrange
            var expected = new string[] { "2", "3", "4" };
            var extractor = new NewlineNumberStringParser(numberStringParser: _baseParser);
            string numbers = "2,3\n4";

            // Act
            string[] actual =
                extractor.Parse(numberString: numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
