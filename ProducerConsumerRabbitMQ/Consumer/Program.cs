using System;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver.Default.Process();
        }
    }
}
