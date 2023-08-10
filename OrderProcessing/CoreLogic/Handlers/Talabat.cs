﻿namespace OrderProcessing.CoreLogic.Handlers
{
    public class Talabat : IHandler
    {
        public bool IsSuccess(Order order)
        {
            if (order.SystemType == SystemType.talabat)
            {

                Console.WriteLine("Talabat detected");
                Console.WriteLine($"Order number: {order.OrderNumber}");

                return true;
            }
            return false;
        }
    }
}
