// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2019.12.18
// Modified: 2020.05.14

namespace SKit.Common.Models
{
    /// <summary>
    /// A simple list item entity to display in user controls
    /// </summary>
    public class ValueText
    {
        /// <summary>
        /// Key/Item ID
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Item display name
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Display name of group/category
        /// </summary>
        public string GroupBy { get; set; }

        ///// <summary>
        ///// Additional properties
        ///// </summary>
        //public IDictionary<string, object> Features { get; set; }
    }

    /// <summary>
    /// A simple list item entity to display in user controls with item object
    /// </summary>
    public class ValueText<T> : ValueText where T : class
    {
        public T Item { get; set; }
    }

}
