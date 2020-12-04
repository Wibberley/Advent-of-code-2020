using System;
using System.Collections.Generic;
using System.Text;

namespace PassportProcessing
{
    public class BasicPassportValidator : IPassportValidator
    {
        public bool IsPassportValid(Passport passport)
        {
            if (string.IsNullOrEmpty(passport.BirthYear))
                return false;

            if (string.IsNullOrEmpty(passport.ExpirationYear))
                return false;

            if (string.IsNullOrEmpty(passport.EyeColour))
                return false;

            if (string.IsNullOrEmpty(passport.HairColour))
                return false;

            if (string.IsNullOrEmpty(passport.Height))
                return false;

            if (string.IsNullOrEmpty(passport.IssueYear))
                return false;

            if (string.IsNullOrEmpty(passport.PassportId))
                return false;

            return true;
        }
    }
}
