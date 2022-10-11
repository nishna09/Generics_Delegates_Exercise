using Generics_Delegates_Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Delegates_Exercise
{
    public static class VehicleHelperClass
    {
        public static void DisplayInventory<T>(Dictionary<int, T> allVehiclesInInventory, Checkout<T> checkOutInstance, Func<KeyValuePair<int, T>, T, string> funcDisplay=null) where T:IVehicle
        {
            int quitValue = -1;
            //create a delegate using Func for the method DisplayVehicleInfo
            //Func<KeyValuePair<int, T>, T, string> funcDisplay = DisplayVehicleInfo;

            if (funcDisplay==null)
                funcDisplay=DisplayVehicleInfo;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"This is the inventory: ");
                foreach (var vehicleKV in allVehiclesInInventory)
                {
                    var vehicleInstance = vehicleKV.Value;
                    string info = funcDisplay(vehicleKV, vehicleInstance);

                    Console.WriteLine($"{info}"); Console.WriteLine();
                }

                Console.WriteLine("Please select Id or enter -1 to go back to previous menu");

                var inputId = int.Parse(Console.ReadLine()); //Assume that selection will not require error handling 

                if (inputId == quitValue) break;

                checkOutInstance.AddToCheckout(allVehiclesInInventory[inputId]);
                Console.WriteLine("Item has been added to checkout!");
            }
        }

        private static string DisplayVehicleInfo<T>(KeyValuePair<int, T> vehicleKV, T vehicleInstance) where T : IVehicle
        {
            Console.WriteLine($"Inventory Id: {vehicleKV.Key}");
            var info = $"Item Brand: {vehicleInstance.Brand}{Environment.NewLine}";
            info += $"Item Year: {vehicleInstance.Year:d}{Environment.NewLine}";
            info += $"Item Color: {vehicleInstance.Color}";
            return info;
        }
    }
}
