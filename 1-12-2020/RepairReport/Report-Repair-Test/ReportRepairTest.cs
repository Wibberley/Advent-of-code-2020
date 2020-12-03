using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Report_Repair;
using Utilities;

namespace Report_Repair_Test
{
    public class ReportRepairTest
    {
        private ReportRepair _reportRepair;

        [SetUp]
        public void Setup()
        {
            _reportRepair = new ReportRepair();   
        }

        [Test]
        public void Given_When_Then()
        {
            // given
            var input = FileReader.ReadFileLines("input.txt");

            // when
            var actual = _reportRepair.GetTotal(input, 2);

            // then
            long expected = 618144;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_When_Then_2()
        {
            // given
            var input = FileReader.ReadFileLines("input.txt");

            // when
            var actual = _reportRepair.GetTotal(input, 3);

            // then
            double expected = 173538720D;
            Assert.AreEqual(expected, actual);
        }
    }
}