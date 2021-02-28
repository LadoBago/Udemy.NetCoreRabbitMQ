using System;
using System.Text;
using RabbitMQ.Client;


namespace Producer
{
    internal class Sender
    {
        private static Sender _Default;

        internal static Sender Default
        {
            get
            {
                if (_Default == null)
                {
                    _Default = new Sender();
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
                channel.QueueDeclare("BasicTest", false, false, false, null);

                var message = $"Getting started with .Net Core RabbitMQ [{DateTime.Now.ToLongTimeString()}].";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine($"Sent Message: {message}");
            }

            Console.WriteLine("Press [enter] to exit the Sender App...");
            Console.ReadLine();
        }
    }
}
