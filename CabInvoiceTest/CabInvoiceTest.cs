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

        /// <summary>
        /// Test method to calculate total fare of journey for multiple rides.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenCalculated_ReturnTotalFare()
        {
            double firstRideDistance = 26.05;
            double secondRideDistance = 12.39;
            double firstRideTime = 29;
            double secondRideTime = 25;

            Rides[] rides = { new Rides(firstRideDistance, firstRideTime), new Rides(secondRideDistance, secondRideTime) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(438.4, cabInvoiceGeneratorTotalFare);
        }
    }
}