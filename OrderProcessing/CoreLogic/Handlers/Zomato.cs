﻿namespace OrderProcessing
{
    public class Zomato : IHandler
    {
        public async Task<bool> TryToHandleOrder(Order order)
        {
            if (order.SystemType == SystemType.zomato)
            {
                Console.WriteLine("Zomato detected");
                Console.WriteLine($"Order number: {order.OrderNumber}");

                return true;
            }
            return false;
        }
    }
}
