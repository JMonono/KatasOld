using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestClass]
    public class ValidatingNumberArrayTotalerTests
    {
        private INumberArrayTotaler _numberTotaler = null;

        [TestInitialize]
        public void Setup()
        {
            _numberTotaler = new NumberArrayTotaler();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresNumberArrayTotalerOnInitialise()
        {
            // Arrange
            INumberArrayTotaler totaler = null;

            // Act
            var validatingTotaler = new ValidatingNumberArrayTotaler(numberTotaler: totaler);
        }

        [TestMethod]
        public void ImplementsINumberArrayTotaler()
        {
            // Arrange
            var validatingTotaler = new ValidatingNumberArrayTotaler(_numberTotaler);

            // Act

            // Assert
            Assert.IsTrue(validatingTotaler is INumberArrayTotaler);
        }

        [TestMethod]
        public void TotalReturnsZeroWhenArrayIsEmpty()
        {
            // Arrange
            var expected = 0;
            var validatingTotaler = new ValidatingNumberArrayTotaler(_numberTotaler); 

            // Act
            var actual = validatingTotaler.Total(new string[] { });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalReturnsZeroWhenArrayIsNull()
        {
            // Arrange
            var expected = 0;
            var validatingTotaler = new ValidatingNumberArrayTotaler(_numberTotaler);

            // Act
            var actual = validatingTotaler.Total(null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalReturnsSumOfAllNumbersInArray()
        {
            // Arrange
            var expected = 6;
            var numbers = new string[] { "1", "2", "3" };
            var validatingTotaler = new ValidatingNumberArrayTotaler(_numberTotaler);

            // Act
            var actual = validatingTotaler.Total(numbers: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalIgnoresValuesGreaterThanOneThousandAndOne()
        {
            // Arrange
            var expected = 1;
            var numbers = new string[] { "1", "1001", "5000" };
            var validatingTotaler = new ValidatingNumberArrayTotaler(_numberTotaler);

            // Act
            var actual = validatingTotaler.Total(numbers: numbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalWithArrayContainingMinusOneThrowsException()
        {
            // Arrange
            Exception expected = new Exception("Negatives not allowed: -1");
            Exception actual = null;
            var totaler = new ValidatingNumberArrayTotaler(_numberTotaler);

            // Act
            try
            {
                var result = totaler.Total(new string[] { "-1" });
            }
            catch (Exception ex)
            {
                actual = ex;
            }

            // Assert
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TotalWithArrayContainingMinusOneTwoMinusThreeThrowsException()
        {
            // Arrange
            Exception expected = new Exception("Negatives not allowed: -1,-3");
            Exception actual = null;
            var totaler = new ValidatingNumberArrayTotaler(_numberTotaler);

            // Act
            try
            {
                var result = totaler.Total(new string[] { "-1", "2", "-3" });
            }
            catch (Exception ex)
            {
                actual = ex;
            }

            // Assert
            Assert.AreEqual(expected.Message, actual.Message);
        }
    }
}
