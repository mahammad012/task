using System;

namespace ConsoleApp4;

public class Car : Vehicle
{
    public double FuelCapacityLiters { get; private set; }
    public double FuelLiters { get; private set; }
    public double FuelConsumptionPer100Km { get; private set; }

    public Car(string brand, string model, int year, double fuelCapacityLiters, double fuelConsumptionPer100Km, double initialFuelLiters)
        : base(brand, model, year)
    {
        if (fuelCapacityLiters <= 0)
            throw new ArgumentException("Fuel capacity liters must be greater than 0!");

        if (fuelConsumptionPer100Km <= 0)
            throw new ArgumentException("Fuel consumption per 100km must be greater than 0!");

        if (initialFuelLiters < 0 || initialFuelLiters > fuelCapacityLiters)
            throw new ArgumentException("Initial fuel liters must be between 0 and fuel capacity!");

        FuelCapacityLiters = fuelCapacityLiters;
        FuelConsumptionPer100Km = fuelConsumptionPer100Km;
        FuelLiters = initialFuelLiters;
    }

    public void Refuel(double liters)
    {
        if (liters > 0 && FuelLiters + liters <= FuelCapacityLiters)
        {
            FuelLiters += liters;
        }
    }

    public override void Drive(int km)
    {
        if (km > 0 && IsRunning)
        {
            double requiredLiters = (km / 100.0) * FuelConsumptionPer100Km;
            if (FuelLiters >= requiredLiters)
            {
                FuelLiters -= requiredLiters;
                MileageKm += km;
            }
        }
    }

    public override void VehicleInfo()
    {
        Console.WriteLine("Type: Car");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Mileage: {MileageKm} km");
        Console.WriteLine($"Running: {(IsRunning ? "Yes" : "No")}");
        Console.WriteLine($"Fuel: {FuelLiters:F1}L / {FuelCapacityLiters:F1}L");
    }
}