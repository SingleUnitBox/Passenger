using AnotherWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnotherWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var phone = _phoneService.Get(id);
            return Ok(phone);
        }
    }
}
