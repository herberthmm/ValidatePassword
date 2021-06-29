using System.Collections.Generic;

namespace ValidatePassword.Services
{
    public interface IValidatePasswordService
    {
        bool IsValid(string password);        
    }
}
