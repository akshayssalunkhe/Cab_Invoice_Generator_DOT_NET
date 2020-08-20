// <copyright file="CabInvoiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Test class.
    /// </summary>
    public class CabInvoiceTest
    {
        private CabInvoice cabInvoiceGenerator;

        /// <summary>
        /// set up for test class.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoice();
        }

        /// <summary>
        /// Test method to check total fare of the journey.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenCalculated_ReturnTotalFare()
        {
            double distance = 5.0;
            double time = 5.0;
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalTravelFare(distance, time);
            Assert.AreEqual(55.0, cabInvoiceGeneratorTotalFare);
        }

        /// <summary>
        /// Test method to check minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenLessThanMinimumFareGetCalculated_ThenReturnMinimumFare()
        {
            double distance = 0.132;
            double time = 1.0;
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalTravelFare(distance, time);
            Assert.AreEqual(5, cabInvoiceGeneratorTotalFare);
        }
    }
}