// <copyright file="CabInvoice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Main class.
    /// </summary>
    public class CabInvoice
    {
        private double costPerKilometer = 10;
        private int costPerMinute = 1;
        private int minimumFare = 5;

        private RideRepository rideRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoice"/> class.
        /// </summary>
        public CabInvoice()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// Function to calculate total fare of journey.
        /// </summary>
        /// <param name="distance">Travel distance.</param>
        /// <param name="time">Travel time.</param>
        /// <returns>Total fare of journey.</returns>
        public double GetTotalTravelFare(double distance, double time)
        {
            double totalTravelFare = (this.costPerKilometer * distance) + (this.costPerMinute * time);
            totalTravelFare = Math.Max(totalTravelFare, this.minimumFare);
            return totalTravelFare;
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
                totalFare += (ride.distance * this.costPerKilometer) + (ride.time * this.costPerMinute);
            }

            totalFare = Math.Max(totalFare, this.minimumFare);
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
            this.rideRepository.AddRides(userId, rides);
        }
    }
}
