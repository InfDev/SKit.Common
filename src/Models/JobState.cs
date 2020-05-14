// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.01.27
// Modified: 2020.05.14

using System.Collections.Generic;

namespace SKit.Common.Models
{
    /// <summary>
    /// Состояние работы
    /// </summary>
    public class JobState
    {
        /// <summary>
        /// Список единиц работы
        /// </summary>
        public List<JobUnitState> UnitJobStates { get; } = new List<JobUnitState>();
        /// <summary>
        /// Сообщения
        /// </summary>
        public List<string> Messages { get; } = new List<string>();
    }
}
