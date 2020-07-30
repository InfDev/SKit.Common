// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.01.27
// Modified: 2020.05.24

using System;

namespace SKit.Common.Models
{
    /// <summary>
    /// История выполненных работ
    /// </summary>
    public class JobHistory : KeyEntity<long>
    {
        /// <summary>
        /// Ключ работы
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// Класс работы
        /// </summary>
        public JobClass JobClass { get; set; }
        /// <summary>
        /// Дата и время события
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// Успешность выполнения
        /// </summary>
        public bool Ok { get; set; }
        /// <summary>
        /// Состояние выполнения, json
        /// </summary>
        public string JobState { get; set; }
        /// <summary>
        /// Имя пользователя, если инициатором является он
        /// </summary>
        public string UserName { get; set; }
    }
}
