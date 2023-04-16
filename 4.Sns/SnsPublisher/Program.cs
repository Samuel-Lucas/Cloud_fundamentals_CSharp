using System.Text.Json;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SnsPublisher;

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "samuel@hotmail.com",
    FullName = "Samuel Lucas",
    DateOfBirth = new DateTime(1996, 1, 1),
    GitHubUsername = "samuellucas"
};

var snsClient = new AmazonSimpleNotificationServiceClient();
var topicArnResponse = await snsClient.FindTopicAsync("customers");

var publishRequest = new PublishRequest {
    TopicArn = topicArnResponse.TopicArn,
    Message = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        {
            "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = nameof(CustomerCreated)
            }
        }
    }
};

var response = await snsClient.PublishAsync(publishRequest);
Console.WriteLine($"Result: {response.HttpStatusCode}");