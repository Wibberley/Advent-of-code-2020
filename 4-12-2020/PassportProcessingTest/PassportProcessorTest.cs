using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PassportProcessing;

namespace PassportProcessingTest
{
    public class PassportProcessorTest
    {
        private PassportProcessor _basicPassportProcessor;
        private PassportProcessor _advancedPassportProcessor;

        [SetUp]
        public void SetUp()
        {
            _basicPassportProcessor = new PassportProcessor(
                new BatchDataProcessor(),
                new BasicPassportValidator());

            _advancedPassportProcessor = new PassportProcessor(
                new BatchDataProcessor(),
                new AdvancedPassportValidator());
        }

        [TestCase]
        public void GivenIHaveATestFileAndBasicValidation_WhenIProcessThis_IGetTheExpectedValue()
        {
            // when
            var testFile = "input.txt";

            // given 
            var output = _basicPassportProcessor.ProcessBatchFile(testFile);

            // then 
            int expected = 204;
            Assert.AreEqual(expected, output);
        }

        [TestCase]
        public void GivenIHaveATestFileAndAdvancedValidation_WhenIProcessThis_IGetTheExpectedValue()
        {
            // when
            var testFile = "input.txt";

            // given 
            var output = _advancedPassportProcessor.ProcessBatchFile(testFile);

            // then 
            int expected = 179;
            Assert.AreEqual(expected, output);
        }
    }
}
