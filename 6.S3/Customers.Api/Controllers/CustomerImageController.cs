using Microsoft.AspNetCore.Mvc;
using Customers.Api.Services;
using System.Net;

namespace Customers.Api.Controllers
{
    public class CustomerImageController : ControllerBase
    {
        private readonly ICustomerImageServices _customerImageServices;

        public CustomerImageController(ICustomerImageServices customerImageServices)
        {
            _customerImageServices = customerImageServices;
        }

        [HttpPost("customers/{id:guid}/image")]
        public async Task<IActionResult> Upload([FromRoute] Guid id, [FromForm(Name = "Data")]IFormFile file)
        {
            var response = await _customerImageServices.UploadImageAsync(id, file);

            if (response.HttpStatusCode == HttpStatusCode.OK)
                return Ok();
            
            return BadRequest();
        }

        [HttpGet("customers/{id:guid}/image")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return default;
        }

        [HttpDelete("customers/{id:guid}/image")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return default;
        }
    }
}