using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();

using var inputStream = new FileStream("./movies.csv", FileMode.Open, FileAccess.Read);

var putObjectRequest = new PutObjectRequest
{
    BucketName = "samuel-aws-fundamentals",
    Key = "files/movies.csv",
    ContentType = "text/csv",
    InputStream = inputStream
};

await s3Client.PutObjectAsync(putObjectRequest);