using System.Linq;
using NUnit.Framework;
using PassportProcessing;

namespace PassportProcessingTest
{
    public class BatchDataProcessorTest
    {
        private BatchDataProcessor _batchDataProcessor;

        [SetUp]
        public void Setup()
        {
            _batchDataProcessor = new BatchDataProcessor();
        }

        [TestCase]
        public void GivenISupplyAPassportRecord_WhenIProcessThis_ThenIExpectedAPopulatedDataCollection()
        {
            // given 
            var data = @"eyr:2029 iyr:2013
hcl:#ceb3a1 byr:1939 ecl:blu
hgt:163cm
pid:660456119";

            // when 
            var output = _batchDataProcessor.ProcessData(data);

            // then
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual(7, output.First().Count());
            Assert.AreEqual("eyr:2029", output.First().First());
        }

        [TestCase]
        public void GivenISupplyMutiplePassportRecord_WhenIProcessThese_ThenIExpectedAPopulatedDataCollection()
        {
            // given 
            var data = @"hcl:#0f8b2e ecl:grn
byr:1975 iyr:2011
eyr:2028 cid:207 hgt:158cm
pid:755567813

byr:2002 pid:867936514 eyr:2021 iyr:2012
hcl:#18171d ecl:brn cid:293 hgt:177cm

hgt:193cm
iyr:2010 pid:214278931 ecl:grn byr:1953
eyr:2021
hcl:#733820";

            // when 
            var output = _batchDataProcessor.ProcessData(data);

            // then
            Assert.AreEqual(3, output.Count);
            Assert.AreEqual(8, output.First().Count());
            Assert.AreEqual(7, output.Last().Count());
        }
    }
}