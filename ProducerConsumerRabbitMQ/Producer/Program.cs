﻿using System;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Sender.Default.Process();
        }
    }
}
