using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private INumberArrayTotaler _defaultTotaler = new NumberArrayTotaler();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresNumberTotalerOnInitialise()
        {
            // Arrange
            INumberArrayTotaler totaler = null;
            var calculator = new StringCalculator(numberTotaler: totaler);
        }

        [TestMethod]
        public void AddZeroNumbersReturnsZero()
        {
            // Arrange
            int expected = 0;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string numbers = String.Empty;

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddOneNumberReturnsTheNumber()
        {
            // Arrange
            var expected = 4;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string numbers = expected.ToString();

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoCommaThreeReturnsFive()
        {
            // Arrange
            var expected = 5;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string numbers = "2,3";

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFourCommaSevenReturnsEleven()
        {
            // Arrange
            var expected = 11;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string numbers = "4,7";

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoCommaThreeCommaFourReturnsNine()
        {
            // Arrange
            var expected = 9;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string numbers = "2,3,4";

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoNewlineThreeReturnsFive()
        {
            // Arrange
            var expected = 5;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string numbers = String.Format("2{0}3", Environment.NewLine);

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoNewlineThreeCommaFourReturnsNine()
        {
            // Arrange
            var expected = 9;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string numbers = String.Format("2{0}3{0}4", "\n", ",");

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoHyphenThreeHyphenFourReturnsNine()
        {
            // Arrange
            var expected = 9;
            var calculator = new StringCalculator(numberTotaler: _defaultTotaler);
            string delimiter = "-";
            string numbers =
                String.Format("\\{0}{1}2{2}3{3}4", delimiter, "\n", delimiter, delimiter);

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
