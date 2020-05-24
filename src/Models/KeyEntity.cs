// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2019.12.19
// Modified: 2020.05.24

using System.ComponentModel.DataAnnotations;

namespace SKit.Common.Models
{
    /// <summary>
    /// Base entity with key field
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class KeyEntity<TKey>
    {
        /// <summary>
        /// Identificator
        /// </summary>
        [Required]
        public TKey Id { get; set; }
     }

}
