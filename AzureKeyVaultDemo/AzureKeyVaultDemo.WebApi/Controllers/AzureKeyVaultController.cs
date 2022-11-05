using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureKeyVaultDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureKeyVaultController : ControllerBase
    {
        private IConfiguration _configuration;

        public AzureKeyVaultController(IConfiguration config)
        {
            _configuration = config;


        }

        [HttpGet(Name = "GetAzureKeyVaultTestValue")]
        public string Get()
        {
            return _configuration["TestSecret001"];
        }
    }
}
