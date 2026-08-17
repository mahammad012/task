using System;

namespace ConsoleApp4;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Toyota", "Corolla", 2018, 50.0, 7.5, 20.0);
        car.StartEngine();
        car.Drive(100);
        car.Refuel(15.0);
        car.VehicleInfo();
        car.StopEngine();

        Console.WriteLine("------------------");

        Vehicle v = new ElectricCar("Tesla", "Model 3", 2022, 60.0, 15.0, 30.0);
        v.StartEngine();
        v.Drive(120);
        v.VehicleInfo();
        v.StopEngine();
    }
}

    
