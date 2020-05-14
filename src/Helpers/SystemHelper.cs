// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2019.12.18
// Modified: 2020.05.14

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

using SKit.Common.Models;
using SKit.Common.Resources;

[assembly: NeutralResourcesLanguage("en")]

namespace SKit.Common.Helpers
{
    public static class SystemHelper
    {
        public static string GetOSVersion()
        {
            return Environment.OSVersion.ToString();
        }

        public static string GetNetCoreVersion()
        {
            var assembly = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly;
            var assemblyPath = assembly.CodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
            if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
                return assemblyPath[netCoreAppIndex + 1];
            return null;
        }

        /// <summary>
        /// Return correct .NET Core product name like ".NET Core 2.1.0" instead of ".NET Core 4.6.26515.07" returning by RuntimeInformation.FrameworkDescription
        /// </summary>
        /// <returns>CoreCLR</returns>
        public static string GetCoreCLR()
        {
            // ".NET Core 4.6.26515.07" => ".NET Core 2.1.0"
            var parts = RuntimeInformation.FrameworkDescription.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var i = 0;
            for (; i < parts.Length; i++)
            {
                if (Char.IsDigit(parts[i][0]))
                {
                    break;
                }
            }
            var productName = string.Join(" ", parts, 0, i);
            return string.Join(" ", productName, GetNetCoreVersion());
        }

        public static string GetFrameworkDescription()
        {
            return RuntimeInformation.FrameworkDescription;
        }

        public static string GetCurrentProcessName()
        {
            return Process.GetCurrentProcess().ProcessName;
        }

        public static DateTime GetCurrentProcessStartTime()
        {
            return Process.GetCurrentProcess().StartTime;
        }


        /// <summary>
        ///  Gets the amount of physical memory mapped to the process context, MB
        /// </summary>
        /// <returns></returns>
        public static string GetProcessUsedPhysicalMemoryMB()
        {
            return (Environment.WorkingSet / (1024 * 1024)).ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Get current environment runtime
        /// </summary>
        /// <returns></returns>
        public static string GetASPNETCoreEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        /// <summary>
        /// Gets the number of processors on the current machine
        /// </summary>
        /// <returns></returns>
        public static string GetProcessorCount()
        {
            return Environment.ProcessorCount.ToString(CultureInfo.CurrentCulture);
        }

        public static IEnumerable<ValueText> GetSystemInfo()
        {
            return new List<ValueText>
            {
                new ValueText
                {
                    Value = GetOSVersion(),
                    Text = SR.OperatingSystem
                },
                new ValueText
                {
                    Value = GetProcessorCount(),
                    Text = SR.NumberOfProcessors
                },
                new ValueText
                {
                    Value = GetFrameworkDescription(),
                    Text = SR.FrameworkDescription
                },
                //new ValueText
                //{
                //    Value = GetCoreCLR(),
                //    Text = SR.CLR
                //},
                new ValueText
                {
                    Value = GetProcessUsedPhysicalMemoryMB(),
                    Text = SR.ProcessPhysicalMemoryUsed
                },
                new ValueText
                {
                    Value = GetASPNETCoreEnvironment(),
                    Text = SR.RuntimeEnvironment_ASPNETCORE_ENVIRONMENT
                },
                new ValueText
                {
                    Value = GetCurrentProcessName(),
                    Text = SR.ProcessName
                },
                new ValueText
                {
                    Value = GetCurrentProcessStartTime().ToString(CultureInfo.CurrentCulture),
                    Text = SR.ProcessStartTime
                },
             };
        }
    }
}
