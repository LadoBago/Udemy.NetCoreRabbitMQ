using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer
{
    internal class Receiver
    {
        private static Receiver _Default;

        internal static Receiver Default
        {
            get
            {
                if (_Default == null)
                {
                    _Default = new Receiver();
                }
                return _Default;
            }
        }
        internal void Process()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "BasicTest", durable: false, exclusive: false, autoDelete: false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;

                channel.BasicConsume("BasicTest", true, consumer);
            }

            Console.WriteLine("Press [enter] to exit...");
            Console.ReadLine();
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.Span);
            Console.WriteLine($"Received message: {message}");
        }
    }
}
