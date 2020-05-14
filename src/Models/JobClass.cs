// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.01.27
// Modified: 2020.05.14

using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common.Models
{
    /// <summary>
    /// Тип работы
    /// </summary>
    public enum JobClass
    {
        /// <summary>
        /// Внутренняя
        /// </summary>
        Inside,
        /// <summary>
        /// Импорт
        /// </summary>
        Import,
        /// <summary>
        /// Экспорт
        /// </summary>
        Export
    }
}
