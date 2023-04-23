using Amazon.S3.Model;

namespace Customers.Api.Services
{
    public interface ICustomerImageServices
    {
        Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile file);
        Task<PutObjectResponse> GetImageAsync(Guid id);
        Task<PutObjectResponse> DeleteImageAsync(Guid id);
    }
}