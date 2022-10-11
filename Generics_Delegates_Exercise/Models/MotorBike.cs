﻿using Generics_Delegates_Exercise.Models;
using System;

namespace Generics_Delegates_Exercise
{
    public class MotorBike : IEquatable<MotorBike>, IVehicle
    {
        public Brand Brand { get; set; }
        public DateTime Year { get; set; }
        public Color Color { get; set; }
        public int CountInStock { get; set; }

        public bool Equals(MotorBike other)
        {
            return Brand == other.Brand && Year == other.Year && Color == other.Color;
        }
    }
}
