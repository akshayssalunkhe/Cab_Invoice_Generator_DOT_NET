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
        public void GivenDistanceAndTime_WhenCalculated_ThenReturnTotalFare()
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

        /// <summary>
        /// Test method to calculate total fare of journey for multiple rides.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenCalculated_ThenShouldReturnTotalFare()
        {
            double firstRideDistance = 26.05;
            double secondRideDistance = 12.39;
            double firstRideTime = 29;
            double secondRideTime = 25;

            Rides[] rides = { new Rides(firstRideDistance, firstRideTime), new Rides(secondRideDistance, secondRideTime) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(438.4, cabInvoiceGeneratorTotalFare);
        }

        /// <summary>
        /// Test method to calculate invoice summery.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenCalculated_ThenShouldReturnInvoiceSummery()
        {
            Rides[] rides = { new Rides(25.12, 40), new Rides(12.39, 25) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 440.1);
            Assert.AreEqual(summary, invoiceSummary);
        }

        /// <summary>
        /// Test method to check invoice summary of particular user.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_WhenFoundRecord_ThenShouldReturnUserInvoiceSummary()
        {
            string userId = "user@.com";
            Rides[] rides = { new Rides(25.12, 40), new Rides(12.39, 25) };
            this.cabInvoiceGenerator.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary summary = new InvoiceSummary(2, 440.1);
            Assert.AreEqual(invoiceSummary, summary);
        }
    }
}