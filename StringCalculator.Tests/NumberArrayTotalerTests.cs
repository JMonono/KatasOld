using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestClass]
    public class NumberArrayTotalerTests
    {
        [TestMethod]
        public void ImplementsINumberArrayTotaler()
        {
            // Arrange
            var totaler = new NumberArrayTotaler();

            // Act

            // Assert
            Assert.IsTrue(totaler is INumberArrayTotaler);
        }

        [TestMethod]
        public void TotalWithEmptyArrayReturnsZero()
        {
            // Arrange
            var expected = 0;
            var totaler = new NumberArrayTotaler();

            // Act
            var actual = totaler.Total(new string[] { });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalWithNullArrayReturnsZero()
        {
            // Arrange
            var expected = 0;
            var totaler = new NumberArrayTotaler();

            // Act
            var actual = totaler.Total(null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalWithArrayContainingTwoAndThreeReturnsFive()
        {
            // Arrange
            var expected = 5;
            var totaler = new NumberArrayTotaler();

            // Act
            var actual = totaler.Total(new string[] { "2", "3" });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalWithArrayContainingTwoAndThreeAndFourReturnsNine()
        {
            // Arrange
            var expected = 9;
            var totaler = new NumberArrayTotaler();

            // Act
            var actual = totaler.Total(new string[] { "2", "3", "4" });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalWithArrayContainingOneAndTwoAndThreeAndFourReturnsTen()
        {
            // Arrange
            var expected = 10;
            var totaler = new NumberArrayTotaler();

            // Act
            var actual = totaler.Total(new string[] { "1", "2", "3", "4" });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalWithArrayContainingMinusOneThrowsException()
        {
            // Arrange
            Exception expected = new Exception("Negatives not allowed: -1");
            Exception actual = null;
            var totaler = new NumberArrayTotaler();

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
            var totaler = new NumberArrayTotaler();

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

        [TestMethod]
        public void TotalWithArrayContainingOneAndOneThousandReturnsOneThousandAndOne()
        {
            // Arrange
            var expected = 1001;
            var totaler = new NumberArrayTotaler();

            // Act
            var actual = totaler.Total(new string[] { "1", "1000" });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalWithArrayContainingOneAndOneThousandAndOneReturnsOne()
        {
            // Arrange
            var expected = 1;
            var totaler = new NumberArrayTotaler();

            // Act
            var actual = totaler.Total(new string[] { "1", "1001" });

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
