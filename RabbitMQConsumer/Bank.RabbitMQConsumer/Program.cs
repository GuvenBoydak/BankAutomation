using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Bank.RabbitMQConsumer.Models;
using Bank.RabbitMQConsumer.Service;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://navgcsdb:2SavWUQMJlFzNh8Yv6wFte0bJhjc6Ms6@moose.rmq.cloudamqp.com/navgcsdb");
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.QueueDeclare("email_queue", false, false, false);

EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

consumer.Received += async (s, e) =>
{
    string serializData = Encoding.UTF8.GetString(e.Body.Span);
    var userTransaction = JsonSerializer.Deserialize<UserTransactionDto>(serializData);
    
    try
    {
        await MailService.SendAsync(userTransaction);
    }
    catch (Exception ex)
    {
        Console.WriteLine("RabitMq tarafıdan Mesaj Gönderilemedi");
    }
};

channel.BasicConsume("email_queue", true, consumer);

Console.Read();