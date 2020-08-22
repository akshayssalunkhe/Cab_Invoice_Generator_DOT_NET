// <copyright file="CabInvoice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Main class.
    /// </summary>
    public class CabInvoice
    {
        private double normalRideCostPerKilometer = 10;
        private double normalRideCostPerMinute = 1;
        private int normalRideMinimumFare = 5;

        private double premiumRideCostPerKilometer = 15;
        private double premiumRideCostPerMinute = 2;
        private int premiumRideMinimumFare = 20;

        private Regex userIdPattern = new Regex("^[a-z]{4,}[@][.][a-z]{3}$");
        private RideRepository rideRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoice"/> class.
        /// </summary>
        public CabInvoice()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// Function to calculate total fare of journey for multiple rides.
        /// </summary>
        /// <param name="rides">passsng the ride information.</param>
        /// <returns>Total fare of journey.</returns>
        public double GetTotalFare(Rides[] rides)
        {
            double totalFare = 0;
            foreach (Rides ride in rides)
            {
                if (ride.RideTypeValue.Equals(Rides.RideType.NORMAL_RIDE))
                {
                    totalFare += (ride.distance * this.normalRideCostPerKilometer) + (ride.time * this.normalRideCostPerMinute);
                    totalFare = Math.Max(totalFare, this.normalRideMinimumFare);
                }

                if (ride.RideTypeValue.Equals(Rides.RideType.PREMIUM_RIDE))
                {
                    totalFare += (ride.distance * this.premiumRideCostPerKilometer) + (ride.time * this.premiumRideCostPerMinute);
                    totalFare = Math.Max(totalFare, this.premiumRideMinimumFare);
                }
            }

            return totalFare;
        }

        /// <summary>
        /// Function to get invoice summary.
        /// </summary>
        /// <param name="rides">Ride information.</param>
        /// <returns>invoice summary.</returns>
        public InvoiceSummary GetInvoiceSummary(Rides[] rides)
        {
            double totalFare = this.GetTotalFare(rides);
            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Function to get invoice summary using user id.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <returns>invoice summary of particular ride.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            Rides[] rideList = this.rideRepository.GetRides(userId);
            double totalFare = this.GetTotalFare(rideList);
            return new InvoiceSummary(rideList.Length, totalFare);
        }

        /// <summary>
        /// Function to add rides.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <param name="rides">rides.</param>
        public void AddRides(string userId, Rides[] rides)
        {
            if (!this.userIdPattern.IsMatch(userId))
            {
                throw new CabInvoiceException("Invalid user", CabInvoiceException.ExceptionType.INVALID_USER);
            }

            this.rideRepository.AddRides(userId, rides);
        }
    }
}
