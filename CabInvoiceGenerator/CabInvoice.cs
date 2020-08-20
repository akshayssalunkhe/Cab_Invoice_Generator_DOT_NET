// <copyright file="CabInvoice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Main class.
    /// </summary>
    public class CabInvoice
    {
        private double costPerKilometer = 10;
        private int costPerMinute = 1;
        private int minimumFare = 5;

        /// <summary>
        /// Function to calculate total fare of journey.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns>Total fare of journey.</returns>
        public double GetTotalTravelFare(double distance, double time)
        {
            double totalTravelFare = (this.costPerKilometer * distance) + (this.costPerMinute * time);
            totalTravelFare = Math.Max(totalTravelFare, this.minimumFare);
            return totalTravelFare;
        }
    }
}
