// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for Ride repository.
    /// </summary>
    public class RideRepository
    {
        private Dictionary<string, List<Rides>> userRides;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Rides>>();
        }

        /// <summary>
        /// Function to add user id and rides to list.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <param name="rides">rides.</param>
        public void AddRides(string userId, Rides[] rides)
        {
            List<Rides> list = new List<Rides>();
            list.AddRange(rides);
            this.userRides.Add(userId, list);
        }

        /// <summary>
        /// Function to get user id.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <returns>user id in the form of array.</returns>
        public Rides[] GetRides(string userId)
        {
            return this.userRides[userId].ToArray();
        }
    }
}
