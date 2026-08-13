using System;

namespace ConsoleApp4;

public class Vehicle
{
    private int _year;

    public string Brand { get; set; }
    public string Model { get; set; }

    public int Year
    {
        get => _year;
        set
        {
            if (value < 1886)
                throw new ArgumentException("Year 1886-dan kiciq ola bilmez!");
            _year = value;
        }
    }

    public int MileageKm { get; protected set; }
    public bool IsRunning { get; protected set; }

    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
        IsRunning = false;
        MileageKm = 0;
    }

    public void StartEngine()
    {
        IsRunning = true;
    }

    public void StopEngine()
    {
        IsRunning = false;
    }

    public virtual void Drive(int km)
    {
        if (km > 0 && IsRunning)
        {
            MileageKm += km;
        }
    }
    public virtual void VehicleInfo()
    {
        Console.WriteLine("Type: Vehicle");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Mileage: {MileageKm} km");
        Console.WriteLine($"Running: {(IsRunning ? "Yes" : "No")}");
    }
}