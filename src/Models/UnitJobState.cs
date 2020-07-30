// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.01.27
// Modified: 2020.05.24

using System;

namespace SKit.Common.Models
{
    /// <summary>
    /// Статус единицы работы
    /// </summary>
    public class UnitJobState
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Выполнено успешно
        /// </summary>
        public bool Ok { get; set; }

        /// <summary>
        /// Время завершения
        /// </summary>
        public DateTime? DoneAt { get; set; }
    }
}
