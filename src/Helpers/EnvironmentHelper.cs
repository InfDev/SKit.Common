// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.05.03
// Modified: 2020.05.14

using System.Runtime.InteropServices;
using System.Linq;

namespace SKit.Misc.Common.Helpers
{
    using SKit.Common.Exceptions;

#pragma warning disable CA1707

    public static class EnvironmentHelper
    {

        // Portable RIDs (Platform Runtime Identifier)
        // https://docs.microsoft.com/en-us/dotnet/core/rid-catalog

        public const string PRID_WIN_X64 = "win-x64";
        public const string PRID_WIN_X86 = "win-x86";
        public const string PRID_WIN_ARM_X64 = "win-arm64";
        public const string PRID_WIN_ARM = "win-arm";

        public const string PRID_LINUX_X64 = "linux-x64";   // Most desktop distributions like CentOS, Debian, Fedora, Ubuntu, and derivatives
        public const string PRID_LINUX_ARM = "linux-arm";   // Linux distributions running on ARM like Raspberry Pi

        public const string PRID_OSX_X64 = "osx-x64";       // Minimum OS version is macOS 10.12 Sierra

        /// <summary>
        /// Get portable RID (Platform Runtime Identifier)
        /// </summary>
        /// <returns></returns>
        public static string GetPortableRID() {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch(RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.X64: return PRID_WIN_X64;
                    case Architecture.X86: return PRID_WIN_X86;
                    case Architecture.Arm64: return PRID_WIN_ARM_X64;
                    case Architecture.Arm: return PRID_WIN_ARM;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.X64: return PRID_LINUX_X64;
                    case Architecture.Arm: return PRID_LINUX_ARM;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.X64: return PRID_OSX_X64;
                }
            }
            return string.Empty;
        }


        /// <summary>
        /// Get portable RID (Platform Runtime Identifier) and tested with supported
        /// </summary>
        /// <param name="supportedRIDs"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportPlatformException">NotSupportPlatformException</exception>
        public static string GetPortableRID(string[] supportedPRIDs)
        {
            var rid = GetPortableRID();
            if (supportedPRIDs == null || !supportedPRIDs.Contains(rid))
                throw new NotSupportPlatformException(rid, supportedPRIDs);
            return rid;
        }
    }
}
