using Generics_Delegates_Exercise.Models;
using System;
using System.Collections.Generic;

namespace Generics_Delegates_Exercise
{
    public class Checkout<Item> where Item : IVehicle
    {
        private Dictionary<Item, int> _itemOrders;

        public Checkout()
        {
            _itemOrders = new Dictionary<Item, int>();
        }

        public void AddToCheckout(Item item)
        {
            //Not the best way to check if obj is in dictionary (defeats the purpose of a dictionary if we have to loop to see if a key matches)
            //ideally we would have to implement a hashkey for the object
            foreach (var keyValue in _itemOrders)
            {
                if (keyValue.Key.Equals(item))
                {
                    _itemOrders[keyValue.Key] = keyValue.Value + 1;
                    return;
                }
            }
            _itemOrders.Add(item, 1);
        }

        public void PrintOrders()
        {
            Console.WriteLine($"{Environment.NewLine}Order consists of the following:");
            foreach (var kv in _itemOrders)
            {
                var carInstance = kv.Key;
                var info = $"Car Brand: {carInstance.Brand}{Environment.NewLine}";
                info += $"Car Year: {carInstance.Year:d}{Environment.NewLine}";
                info += $"Car Color: {carInstance.Color}";
            
                Console.WriteLine($"{info}");
                Console.WriteLine($"Quantity {kv.Value} {Environment.NewLine}");
            }
        }
    }
}
