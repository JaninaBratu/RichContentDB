﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.BL.Utils
{
    public class RegistrationAction
    {

        public static bool CheckUsernameForRegistration(string username)
        {
            const int MIN_LENGTH = 5;
            const int MAX_LENGTH = 15;

            return username.Length > MIN_LENGTH && username.Length <= MAX_LENGTH;
        }


        public static bool CheckPasswordForRegistration(string password)
        {
            const int MIN_LENGTH = 6;
            const int MAX_LENGTH = 15;

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            return meetsLengthRequirements
                        && hasUpperCaseLetter
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        ;
            

        }
    }
}
