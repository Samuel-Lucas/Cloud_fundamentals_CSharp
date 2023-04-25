using Microsoft.AspNetCore.Mvc;
using Customers.Api.Services;
using System.Net;
using Amazon.S3;

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
            try
            {
                var response = await _customerImageServices.GetImageAsync(id);
                return File(response.ResponseStream, response.Headers.ContentType);
            }
            catch (AmazonS3Exception ex) when (ex.Message is "The specified keys does not exist")
            {
                return NotFound();
            }
        }

        [HttpDelete("customers/{id:guid}/image")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _customerImageServices.DeleteImageAsync(id);

            return response.HttpStatusCode switch
            {
                HttpStatusCode.NoContent => Ok(),
                HttpStatusCode.NotFound => NotFound(),
                _ => BadRequest()
            };
        }
    }
}