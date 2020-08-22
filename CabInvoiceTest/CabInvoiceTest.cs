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
            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, distance, time) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(55.0, cabInvoiceGeneratorTotalFare);
        }

        /// <summary>
        /// Test method to check minimum fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenLessThanMinimumFareGetCalculated_ThenReturnMinimumFare()
        {
            double rideDistance = 0.132;
            double rideTime = 1.0;

            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, rideDistance, rideTime) };

            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
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

            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, firstRideDistance, firstRideTime), new Rides(Rides.RideType.NORMAL_RIDE, secondRideDistance, secondRideTime) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(438.4, cabInvoiceGeneratorTotalFare);
        }

        /// <summary>
        /// Test method to calculate invoice summery.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenCalculated_ThenShouldReturnInvoiceSummery()
        {
            double firstRideDistance = 25.12;
            double secondRideDistance = 12.39;
            double firstRideTime = 40;
            double secondRideTime = 25;

            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, firstRideDistance, firstRideTime), new Rides(Rides.RideType.NORMAL_RIDE, secondRideDistance, secondRideTime) };
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
            double firstRideDistance = 25.12;
            double secondRideDistance = 12.39;
            double firstRideTime = 40;
            double secondRideTime = 25;
            string userId = "user@.com";

            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, firstRideDistance, firstRideTime), new Rides(Rides.RideType.NORMAL_RIDE, secondRideDistance, secondRideTime) };
            this.cabInvoiceGenerator.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary summary = new InvoiceSummary(2, 440.1);
            Assert.AreEqual(invoiceSummary, summary);
        }

        /// <summary>
        /// Test method to calculate total fare for normal ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForNormalRides_WhenCalculated_ThenShouldReturnTotalFare()
        {
            double rideDistance = 25.12;
            double rideTime = 45;
            Rides[] rides = { new Rides(Rides.RideType.NORMAL_RIDE, rideDistance, rideTime) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(296.2, cabInvoiceGeneratorTotalFare, 0.1);
        }

        /// <summary>
        /// Test method to calculate total fare for premium ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRides_WhenCalculated_ShouldReturnTotalFare()
        {
            double rideDistance = 25.12;
            double rideTime = 45;
            Rides[] rides = { new Rides(Rides.RideType.PREMIUM_RIDE, rideDistance, rideTime) };
            double cabInvoiceGeneratorTotalFare = this.cabInvoiceGenerator.GetTotalFare(rides);
            Assert.AreEqual(466.8, cabInvoiceGeneratorTotalFare, 0.1);
        }
    }
}