﻿using System;
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
    }
}
