// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.05.03
// Modified: 2020.05.14

using System;

namespace SKit.Common.Exceptions
{
#pragma warning disable CA1032

    public class NotSupportPlatformException : Exception
    {
        public NotSupportPlatformException(string currentPRID, string[] supportedPRID) 
            : base($"OS platform or processor architecture with PRID '{currentPRID}' not supported. Supported: {supportedPRID}") { }
    }
}
