using System;

namespace ConsoleApp4;

public class ElectricCar : Vehicle
{
    public double BatteryCapacityKWh { get; private set; }
    public double BatteryKWh { get; private set; }
    public double ConsumptionKWhPer100Km { get; private set; }

    public ElectricCar(string brand, string model, int year, double batteryCapacityKWh, double consumptionKWhPer100Km, double initialBatteryKWh)
        : base(brand, model, year)
    {
        if (batteryCapacityKWh <= 0)
            throw new ArgumentException("Battery capacity kwh must be greater than 0!");

        if (consumptionKWhPer100Km <= 0)
            throw new ArgumentException("Consumption kwh must be greater than 0!");

        if (initialBatteryKWh < 0 || initialBatteryKWh > batteryCapacityKWh)
            throw new ArgumentException("Initial battery kWh must be between 0 and battery capacity!");

        BatteryCapacityKWh = batteryCapacityKWh;
        ConsumptionKWhPer100Km = consumptionKWhPer100Km;
        BatteryKWh = initialBatteryKWh;
    }

    public void Charge(double kwh)
    {
        if (kwh > 0 && BatteryKWh + kwh <= BatteryCapacityKWh)
        {
            BatteryKWh += kwh;
        }
    }

    public override void Drive(int km)
    {
        if (km > 0 && IsRunning)
        {
            double requiredKWh = (km / 100.0) * ConsumptionKWhPer100Km;
            if (BatteryKWh >= requiredKWh)
            {
                BatteryKWh -= requiredKWh;
                MileageKm += km;
            }
        }
    }

    public override void VehicleInfo()
    {
        Console.WriteLine("Type: ElectricCar");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Mileage: {MileageKm} km");
        Console.WriteLine($"Running: {(IsRunning ? "Yes" : "No")}");
        Console.WriteLine($"Battery: {BatteryKWh:F1}kWh / {BatteryCapacityKWh:F1}kWh");
    }
}