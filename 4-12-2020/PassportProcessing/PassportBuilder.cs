using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PassportProcessing
{
    public class PassportBuilder
    {
        private readonly Passport _passport;

        public PassportBuilder()
        {
            _passport = new Passport();
        }

        public PassportBuilder AddData(List<string> passportProperties)
        {
            foreach (var property in passportProperties)
            {
                Add(property);
            }

            return this;
        }

        public PassportBuilder Add(string property)
        {
            var propertyParts = property.Split(":");

            var propertyName = propertyParts[0].Trim();
            var value = propertyParts[1].Trim();
             
            if (propertyParts.Length != 2)
                return this;

            switch (propertyName)
            {
                case "byr":
                    _passport.BirthYear = value;
                    break;
                case "iyr":
                    _passport.IssueYear = value;
                    break;
                case "eyr":
                    _passport.ExpirationYear = value;
                    break;
                case "hgt":
                    _passport.Height = value;
                    break;
                case "hcl":
                    _passport.HairColour = value;
                    break;
                case "ecl":
                    _passport.EyeColour = value;
                    break;
                case "pid":
                    _passport.PassportId = value;
                    break;
                case "cid":
                    _passport.CountryId = value;
                    break;
                default:
                    throw new ApplicationException("Unknown property");
            }

            return this;
        }

        public Passport GetPassport()
        {
            return _passport;
        }
    }
}
