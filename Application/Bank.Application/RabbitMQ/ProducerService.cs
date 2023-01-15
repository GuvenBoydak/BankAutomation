using System.Text;
using System.Text.Json;
using Bank.Application.DTOs;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Bank.Application.RabbitMQ;

public static class ProducerService
{
    private static IConfiguration _configuration;

    static ProducerService()
    {
        _configuration = Configuration;
    }

    public static IConfiguration Configuration
    {
        get
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            return _configuration;
        }
    }

    public static void Producer(UserTransactionDto @event)
    {
        //Baglantıyı Oluşturuyoruz..
        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri(_configuration.GetSection("RabbitMq").Value);
        using IConnection connection = factory.CreateConnection();
        using IModel channel = connection.CreateModel();
        
        channel.QueueDeclare("email_queue", false, false, false);

        string data = JsonSerializer.Serialize(@event);
        Byte[] bytes = Encoding.UTF8.GetBytes(data);
        
        channel.BasicPublish("", "email_queue", body: bytes, basicProperties: channel.CreateBasicProperties());
    }
}