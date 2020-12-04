using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PasswordPhilosophy;
using Utilities;

namespace PasswordPhilosophyTest
{
    public class PasswordProcessorTest
    {
        private IPasswordProcessor _passwordProcessor;

        [SetUp]
        public void Setup()
        {
            _passwordProcessor = new PasswordProcessor();
        }

        [Test]
        public void GivenIHaveAPasswordWhereBothMatch_WhenIProcessTheData_TheTheAmountOfValidPasswordsIsZero()
        {
            //given position 1 IS a h and position 6 IS also a h this is invalid
            var testData = "1-6 h: hzhhfhhxhhhhhltnh";

            // when
            int actual = _passwordProcessor.Process(new List<string>() { testData });

            // then
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenIHaveAPasswordWhereBothIndexDontMatch_WhenIProcessTheData_TheTheAmountOfValidPasswordsIsZero()
        {
            //given position 1 IS a h and position 6 IS also a h this is invalid
            var testData = "1-8 h: azhhfhhxhhhhhltnh";

            // when
            int actual = _passwordProcessor.Process(new List<string>() { testData });

            // then
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenIHaveAPasswordWhereTheFirstMatch_WhenIProcessTheData_TheTheAmountOfValidPasswordsIsOne()
        {
            //given position 1 IS a h and position 8 is NOT a h this is valid
            var testData = "1-8 h: hzhhfhhxhhhhhltnh";

            // when
            int actual = _passwordProcessor.Process(new List<string>() { testData });

            // then
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenIHaveAPasswordWhereTheSecondMatch_WhenIProcessTheData_TheTheAmountOfValidPasswordsIsOne()
        {
            //given position 1 IS a h and position 7 is a h this is valid
            var testData = "2-7 h: hzhhfhhxhhhhhltnh";

            // when
            int actual = _passwordProcessor.Process(new List<string>() { testData });

            // then
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenIHaveAdventCodeData_WhenIProcessTheData_IGetTheCorrectAmountOfValidPasswords()
        {
            //given
            var testData = FileReader.ReadFileLines("input.txt");

            // when
            int actual = _passwordProcessor.Process(testData);

            // then
            int expected = 673;
            Assert.AreEqual(expected, actual);
        }
    }
}