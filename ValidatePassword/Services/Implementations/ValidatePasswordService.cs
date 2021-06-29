using System.Linq;

namespace ValidatePassword.Services.Implementations
{
    public class ValidatePasswordService : IValidatePasswordService
    {
        private readonly int minLength = 9;
        private readonly char[] allowedSpecials = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+' };

        #region [ Public Methods ]

        /// <summary>
        /// Returns if the typed password is a valid password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>True for valid and false for invalid.</returns>
        public bool IsValid(string password)
        {
            try
            {
                return
                     CheckCount(password) &&
                     password.Any(ch => IsDigit(ch)) &&
                     password.Any(ch => IsUpperCharacter(ch)) &&
                     password.Any(ch => IsLowerCharacter(ch)) &&
                     HaveSpecialCharacter(password) &&
                     !HaveDuplicates(password);
            }
            catch
            {
                return false;
            }
        }
        #endregion [ Public Methods ]

        #region [ Private Methods ]
        /// <summary>
        /// Verifies if the password size is the minimum required to be valid.
        /// </summary>
        /// /// <returns>True for valid size and false for invalid size.</returns>
        private bool CheckCount(string password)
        {
            bool validSize;

            if (string.IsNullOrEmpty(password))
                validSize = false;
            else if (password.Length < minLength)
                validSize = false;
            else
                validSize = true;

            return validSize;
        }

        /// <summary>
        /// Verifies if the password contains at least one number.
        /// </summary>        
        /// /// <returns>True if is a digit and false if its not a digit.</returns>
        private static bool IsDigit(char character)
        {
            bool isDigit = char.IsDigit(character);

            return isDigit;
        }

        /// <summary>
        /// Verifies if the character is uppercase.
        /// </summary>        
        /// <returns>True if is upper char and false if it's not a upper char.</returns>
        private static bool IsUpperCharacter(char character)
        {
            bool isUpperChar = char.IsUpper(character);

            return isUpperChar;
        }

        /// <summary>
        /// Verifies if the character is lower case.
        /// </summary>        
        /// <returns>True if is lower char and false if it's not a lower char.</returns>
        private static bool IsLowerCharacter(char character)
        {
            bool isLowerChar = char.IsLower(character);

            return isLowerChar;
        }

        /// <summary>
        /// Verifies if the password have any special character specified in allowedSpecials propertie.
        /// </summary>        
        /// <returns>True if have at least one special character and false if there is any special character.</returns>
        private bool HaveSpecialCharacter(string password)
        {
            int specialCharacters = password.IndexOfAny(allowedSpecials);

            if (specialCharacters > -1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifies if the password have duplicate characters.
        /// </summary>        
        /// <returns>False if there is not duplicated characters and true if there is any duplicates.</returns>
        private static bool HaveDuplicates(string password)
        {
            int distinctCount = password.Distinct().Count();
            bool containsDupes = !(distinctCount == password.Length);

            return containsDupes;
        }
        #endregion [ Private Methods ]
    }
}
