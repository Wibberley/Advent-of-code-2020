using NUnit.Framework;
using PassportProcessing;

namespace PassportProcessingTest
{
    public class PassportBuilderTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase("byr:1937", "BirthYear", "1937")]
        [TestCase("byr:1954", "BirthYear", "1954")]
        [TestCase("byr:2012     ", "BirthYear", "2012")]
        [TestCase("pid:860033327", "PassportId", "860033327")]
        [TestCase("ecl:gry", "EyeColour", "gry")]
        [TestCase("iyr:2017", "IssueYear", "2017")]
        [TestCase("hgt:183cm", "Height", "183cm")]
        [TestCase("hcl:#fffffd", "HairColour", "#fffffd")]
        [TestCase("cid:147", "CountryId", "147")]
        [TestCase("eyr:2020", "ExpirationYear", "2020")]
        public void GivenISupplyAValue_WhenISupplyThisToTheBuilder_ThenTheExpectedPropertyIsPopulated(string input, string expectedPropertyName, string expectedValue)
        {
            var passportBuilder = new PassportBuilder().Add(input);
            var passport = passportBuilder.GetPassport();

            var output = passport.GetType()
                .GetProperty(expectedPropertyName)
                .GetValue(passport, null);

            Assert.AreEqual(expectedValue, output);
        }
    }
}