using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void AddZeroNumbersReturnsZero()
        {
            // Arrange
            int expected = 0;
            var calculator = new StringCalculator();
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
            var calculator = new StringCalculator();
            string numbers = expected.ToString();

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoCommaThreeNumbersReturnsFive()
        {
            // Arrange
            var expected = 5;
            var calculator = new StringCalculator();
            string numbers = "2,3";

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFourCommaSevenNumbersReturnsEleven()
        {
            // Arrange
            var expected = 11;
            var calculator = new StringCalculator();
            string numbers = "4,7";

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoCommaThreeCommaFourNumbersReturnsNine()
        {
            // Arrange
            var expected = 9;
            var calculator = new StringCalculator();
            string numbers = "2,3,4";

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoNewlineThreeNumbersReturnsFive()
        {
            // Arrange
            var expected = 5;
            var calculator = new StringCalculator();
            string numbers = String.Format("2{0}3", Environment.NewLine);

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwoNewlineThreeCommaFourNumbersReturnsNine()
        {
            // Arrange
            var expected = 9;
            var calculator = new StringCalculator();
            string numbers = String.Format("2{0}3{0}4", Environment.NewLine, ",");

            // Act
            int actual = calculator.Add(numbersToAdd: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
