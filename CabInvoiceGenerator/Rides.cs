// <copyright file="Rides.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Model class to store multiple rides.
    /// </summary>
    public class Rides
    {
        /// <summary>
        /// Variable declaration for distance.
        /// </summary>
        public double distance;

        /// <summary>
        /// Variable declaration for time.
        /// </summary>
        public double time;

        /// <summary>
        /// ride type.
        /// </summary>
        public RideType RideTypeValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rides"/> class.
        /// Constuctor for model rides.
        /// </summary>
        /// <param name="rideType">ride type.</param>
        /// <param name="distance">Travel distance.</param>
        /// <param name="time">Travel time.</param>
        public Rides(RideType rideType, double distance, double time)
        {
            this.distance = distance;
            this.time = time;
            this.RideTypeValue = rideType;
        }

        /// <summary>
        /// enum ride type.
        /// </summary>
        public enum RideType
        {
            /// <summary>
            /// Enum for normal ride.
            /// </summary>
            NORMAL_RIDE,

            /// <summary>
            /// Enum for premium ride.
            /// </summary>
            PREMIUM_RIDE,
        }
    }
}
