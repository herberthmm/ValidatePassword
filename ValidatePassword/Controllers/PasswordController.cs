using Microsoft.AspNetCore.Mvc;
using ValidatePassword.Business;

namespace ValidatePassword.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : Controller
    {
        IValidatePasswordBusiness _validatePasswordBusiness;

        public PasswordController(IValidatePasswordBusiness validatePasswordBusiness)
        {
            _validatePasswordBusiness = validatePasswordBusiness;
        }

        [HttpGet("{password}")]
        public IActionResult Get(string password)
        {
            return Ok(_validatePasswordBusiness.IsValid(password));
        }
    }
}
