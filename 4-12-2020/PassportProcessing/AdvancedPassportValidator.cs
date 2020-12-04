using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PassportProcessing
{
    public class AdvancedPassportValidator : IPassportValidator
    {
        private readonly BasicPassportValidator _basicPassportValidator;

        public AdvancedPassportValidator()
        {
            _basicPassportValidator = new BasicPassportValidator();
        }

        public bool IsPassportValid(Passport passport)
        {
            if (!_basicPassportValidator.IsPassportValid(passport))
                return false;

            if (!int.TryParse(passport.BirthYear, out var birthYear))
                return false;

            if (!(birthYear >= 1920 && birthYear <= 2002))
                return false;

            if (!int.TryParse(passport.IssueYear, out var issueYear))
                return false;

            if (!(issueYear >= 2010 && issueYear <= 2020))
                return false;

            if (!int.TryParse(passport.ExpirationYear, out var expYear))
                return false;

            if (!(expYear >= 2020 && expYear <= 2030))
                return false;

            var hgtPattern = "^(((1[5-8][0-9])|(19[0-3]))cm)$|^(((59|6[0-9]|7[0-6]))in)$";

            if (!Regex.IsMatch(passport.Height, hgtPattern))
                return false;

            var hclPattern = "^#[0-9a-f]{6}$";

            if (!Regex.IsMatch(passport.HairColour, hclPattern))
                return false;

            var eclPattern = "^(amb|blu|brn|gry|grn|hzl|oth)$";

            if (!Regex.IsMatch(passport.EyeColour, eclPattern))
                return false;

            var pidPattern = "^[0-9]{9}$";

            if (!Regex.IsMatch(passport.PassportId, pidPattern))
                return false;

            return true;
        }
    }
}
