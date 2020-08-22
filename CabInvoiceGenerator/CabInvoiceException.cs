// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Cab invoice Exception Class.
    /// </summary>
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Enum.
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// Enum for invalid user.
            /// </summary>
            INVALID_USER,
        }

        /// <summary>
        /// Exception type.
        /// </summary>
        public ExceptionType exceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="exceptionType">type.</param>
        public CabInvoiceException(string message, ExceptionType exceptionType)
            : base(message)
        {
            this.exceptionType = exceptionType;
        }

    }
}