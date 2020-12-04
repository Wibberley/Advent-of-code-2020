using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PassportProcessing;

namespace PassportProcessingTest
{
    public class BasicPassportValidatorTest
    {
        private IPassportValidator _passportValidator;

        [SetUp]
        public void Setup()
        {
            _passportValidator = new BasicPassportValidator();
        }

        [TestCase]
        public void GivenIHavePopulatedAllProperties_WhenIValidateThis_ThenIExpectThisToBeValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                CountryId = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                HairColour = "1",
                Height = "1",
                IssueYear = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = true;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyBirthYear_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                CountryId = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                HairColour = "1",
                Height = "1",
                IssueYear = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyCountryId_WhenIValidateThis_ThenIExpectThisToBeValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                HairColour = "1",
                Height = "1",
                IssueYear = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = true;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyExpirationYear_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                CountryId = "1",
                EyeColour = "1",
                HairColour = "1",
                Height = "1",
                IssueYear = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyEyeColour_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                CountryId = "1",
                ExpirationYear = "1",
                HairColour = "1",
                Height = "1",
                IssueYear = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyHairColour_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                CountryId = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                Height = "1",
                IssueYear = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyHeight_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                CountryId = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                HairColour = "1",
                IssueYear = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyIssueYear_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                CountryId = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                HairColour = "1",
                Height = "1",
                PassportId = "1"
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyPassportId_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                CountryId = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                HairColour = "1",
                Height = "1",
                IssueYear = "1",
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }

        [TestCase]
        public void GivenIHaveMissedThePropertyPassportIdAndCountryId_WhenIValidateThis_ThenIExpectThisToBeInValid()
        {
            // given 
            var passport = new Passport
            {
                BirthYear = "1",
                ExpirationYear = "1",
                EyeColour = "1",
                HairColour = "1",
                Height = "1",
                IssueYear = "1",
            };

            // when
            var output = _passportValidator.IsPassportValid(passport);

            // then 
            var expected = false;
            Assert.AreEqual(output, expected);
        }
    }
}
