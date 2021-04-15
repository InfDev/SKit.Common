using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Threading;
using Xunit;

namespace SKit.Common.Tests
{
    using SKit.Common.Helpers;

    public class FileHelperTests
    {
        private string filePath => @"data\FileForCalcHash.txt";
        private string hashfilePathForMD5 => filePath + ".md5";
        private string hashfilePathForSHA256 => filePath + ".sha256";

        private string GetRealHashFromFile(string filePath)
        {
            var line = File.ReadAllLines(filePath)[0];
            var spacePos = line.IndexOf(' ');
            if (spacePos >= 0)
                line = line.Substring(0, spacePos);
            return line;
        }
        
        [Fact]
        public void MD5()
        {
            var calcHash = FileHelper.GetFileHashByMD5(filePath);
            var realHash = GetRealHashFromFile(hashfilePathForMD5);
            Assert.Equal(realHash, calcHash);
        }

        [Fact]
        public void SHA256()
        {
            var calcHash = FileHelper.GetFileHashBySHA256(filePath);
            var realHash = GetRealHashFromFile(hashfilePathForSHA256);
            Assert.Equal(realHash, calcHash);
        }
    }
}
