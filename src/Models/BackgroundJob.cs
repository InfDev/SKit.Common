// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.01.27
// Modified: 2020.05.24

using System;
using System.Collections.Generic;

namespace SKit.Common.Models
{
    /// <summary>
    /// Фоновая задача
    /// </summary>
    public class BackgroundJob : KeyEntity<int>
    {
        /// <summary>
        /// Наименование фоновой задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание фоновой задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Задача разрешена
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// График выполнения, если пусто, выполняется по требованию
        /// </summary>
        public string CronWhenTo { get; set; }

        /// <summary>
        /// Задача выполняется
        /// </summary>
        public bool Running { get; set; }

        /// <summary>
        /// Время запуска выполнения
        /// </summary>
        public DateTime? LastStartAt { get; set; }

        /// <summary>
        /// Время завершения выполнения
        /// </summary>
        public DateTime? LastStopAt { get; set; }

        /// <summary>
        /// История выполнения задачи
        /// </summary>
        public IReadOnlyList<JobHistory> JobHistory { get; set; }
    }
}
