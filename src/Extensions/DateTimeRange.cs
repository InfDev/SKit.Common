// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2019.05.26
// Modified: 2020.05.14

using System;

namespace SKit.Common.Extensions
{
    /// <summary>
    /// Period of time
    /// </summary>
    public class DateTimeRange
    {        
        
        /// <summary>
        /// Start date and time
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// End date and time
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DateTimeRange()
        {
        }

        /// <summary>
        /// Constructor defining a time period
        /// </summary>
        /// <param name="actualDate"></param>
        /// <param name="period"></param>
        public DateTimeRange(DateTime actualDate, DateTimePeriod period)
        {
            switch (period)
            {
                case DateTimePeriod.Day:
                    BeginDate = actualDate.BeginDay();
                    EndDate = actualDate.EndDay();
                    break;
                case DateTimePeriod.Month:
                    BeginDate = actualDate.BeginMonth();
                    EndDate = actualDate.EndMonth();
                    break;
                case DateTimePeriod.Quarter:
                    BeginDate = actualDate.BeginQuarter();
                    EndDate = actualDate.EndQuarter();
                    break;
                case DateTimePeriod.HalfYear:
                    BeginDate = actualDate.BeginHalfYear();
                    EndDate = actualDate.EndHalfYear();
                    break;
                case DateTimePeriod.Year:
                    BeginDate = actualDate.BeginYear();
                    EndDate = actualDate.EndYear();
                    break;
            }
        }
    }
}
