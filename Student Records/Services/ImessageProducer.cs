using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
namespace Student_Records.Services
{
    public class IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
               
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("students", exclusive: false);

            var messageToSend = new { Name = "Producer", Message = "Hello" };
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
           

            channel.BasicPublish(exchange: "", routingKey: "students", body: body);
           
        }

    }
}
