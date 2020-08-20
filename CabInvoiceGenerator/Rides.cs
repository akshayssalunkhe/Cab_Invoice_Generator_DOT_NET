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
        /// Initializes a new instance of the <see cref="Rides"/> class.
        /// Constuctor for model rides.
        /// </summary>
        /// <param name="distance">Travel distance.</param>
        /// <param name="time">Travel time.</param>
        public Rides(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
