using System;
using System.Linq;
using System.Globalization;
using System.Threading;
using Xunit;

namespace SKit.Common.Tests
{
    using SKit.Common.Helpers;

    public class SystemHelperTest
    {
        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        [Fact]
        public void SysInfo_En()
        {
            SetCulture("en-US");
            var sysinfo = SystemHelper.GetSystemInfo();
            var os = sysinfo.Where(e => e.Text == "Operating system").FirstOrDefault();
            Assert.NotNull(os);
        }

        [Fact]
        public void SysInfo_Ru()
        {
            SetCulture("ru-RU");
            var sysinfo = SystemHelper.GetSystemInfo();
            var os = sysinfo.Where(e => e.Text == "Операционная система").FirstOrDefault();
            Assert.NotNull(os);
        }

        [Fact]
        public void SysInfo_Uk()
        {
            SetCulture("uk-UA");
            var sysinfo = SystemHelper.GetSystemInfo();
            var os = sysinfo.Where(e => e.Text == "Операційна система").FirstOrDefault();
            Assert.NotNull(os);
        }
    }
}
