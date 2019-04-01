using Microsoft.AspNetCore.Mvc;

namespace Payment.API.Controllers
{
   [Route("api/[controller]")]
    public class ResponseController : Controller 
    
    {
        [HttpGet]
        public string Get()
        {
            return "Response OK";
        }
    }
}