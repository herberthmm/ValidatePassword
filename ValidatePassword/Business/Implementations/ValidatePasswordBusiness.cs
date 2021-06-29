using ValidatePassword.Services;

namespace ValidatePassword.Business.Implementations
{
    public class ValidatePasswordBusiness : IValidatePasswordBusiness
    {
        IValidatePasswordService _validatePasswordService;

        public ValidatePasswordBusiness(IValidatePasswordService validatePasswordService)
        {
            _validatePasswordService = validatePasswordService;
        }

        public bool IsValid(string password)
        {
            return _validatePasswordService.IsValid(password);
        }
    }
}
