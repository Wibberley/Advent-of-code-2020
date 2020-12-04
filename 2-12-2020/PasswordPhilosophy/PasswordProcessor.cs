using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordPhilosophy
{
    public interface IPasswordProcessor
    {
        int Process(List<string> passwords);
    }

    public class PasswordProcessor : IPasswordProcessor
    {
        public int Process(List<string> passwords)
        {
            int validPasswords = 0;

            foreach (var password in passwords)
            {
                if (CheckValidPassword(password))
                    validPasswords++;
            }

            return validPasswords;
        }

        private bool CheckValidPassword(string password)
        {
            var passwordParts = password.Split(':');

            if (passwordParts.Length < 2)
                return false;

            var rule = passwordParts[0].Trim();
            var actualPassword = passwordParts[1].Trim();

            var ruleParts = rule.Split(' ');

            if (ruleParts.Length < 2)
                return false;

            var letterLocations = ruleParts[0];
            var letter = ruleParts[1];

            var letterIndex = actualPassword.ToCharArray();

            var letterLocationParts = letterLocations.Split('-');

            if (letterLocationParts.Length < 2)
                return false;

            if (!int.TryParse(letterLocationParts[0], out int firstLocation))
                return false;

            if (!int.TryParse(letterLocationParts[1], out int secondLocation))
                return false;

            var matchingIndex = 0;

            if (letter == letterIndex[firstLocation - 1].ToString())
                matchingIndex++;

            if (letter == letterIndex[secondLocation - 1].ToString())
                matchingIndex++;

            return matchingIndex == 1;
        }
    }
}
