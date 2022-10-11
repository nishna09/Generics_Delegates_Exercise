using Generics_Delegates_Exercise.Models;
using System;
using System.Collections.Generic;


namespace Generics_Delegates_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CAR_SELECTION = 1;
            const int BIKE_SELECTION = 2;
            bool isAdmin=true;

            Func<KeyValuePair<int, MotorBike>, MotorBike, string> funcDisplay = null;

            if (isAdmin)
                funcDisplay = DisplayVehicleInfo;


            while (true)
            {
                Console.WriteLine("Selection:");
                Console.WriteLine("1. View Cars");
                Console.WriteLine("2. View MotorBike");

                switch (int.Parse(Console.ReadLine())) //Assume no error handling is required
                {
                    case CAR_SELECTION:
                        var carManagement = new CarManagement();
                        carManagement.Execute();
                        break;

                    case BIKE_SELECTION:
                        var bikeManagement = new BikeManagement();
                        bikeManagement.Execute(funcDisplay);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static string DisplayVehicleInfo(KeyValuePair<int, MotorBike> vehicleKV, MotorBike vehicleInstance)
        {
            Console.WriteLine($"Inventory Id: {vehicleKV.Key}");
            var info = $"Item Brand: {vehicleInstance.Brand}{Environment.NewLine}";
            info += $"Item Year: {vehicleInstance.Year:d}{Environment.NewLine}";
            info += $"Item Color: {vehicleInstance.Color}";
            info += $"Item Count: {vehicleInstance.CountInStock}{Environment.NewLine}";
            return info;
        }
    }
}
