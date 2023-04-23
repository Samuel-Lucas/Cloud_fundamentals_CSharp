using Amazon.S3;
using Amazon.S3.Model;

namespace Customers.Api.Services
{
    public class CustomerImageService : ICustomerImageServices
    {
        private readonly IAmazonS3? _s3;
        private readonly string _bucketName = "samuel-aws-fundamentals";

        public CustomerImageService(IAmazonS3? s3)
        {
            _s3 = s3;
        }

        public async Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile file)
        {
            var putObjectRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = $"image/{id}",
                ContentType = file.ContentType,
                InputStream = file.OpenReadStream(),
                Metadata = 
                {
                    ["x-amz-meta-originalname"] = file.FileName,
                    ["x-amz-meta-extension"] = Path.GetExtension(file.FileName)
                }
            };

            return await _s3!.PutObjectAsync(putObjectRequest);
        }

        public async Task<PutObjectResponse> GetImageAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PutObjectResponse> DeleteImageAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}