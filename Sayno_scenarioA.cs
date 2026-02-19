using System;

// ================= BASE CLASS =================
abstract class Vehicle
{
    // Private fields (Encapsulation)
    private string vehicleID;
    private string modelName;

    // Public properties with validation
    public string VehicleID
    {
        get { return vehicleID; }
        set { vehicleID = value; }
    }

    public string ModelName
    {
        get { return modelName; }
        set { modelName = value; }
    }

    // Constructor
    public Vehicle(string id, string model)
    {
        VehicleID = id;
        ModelName = model;
    }

    // Virtual method for polymorphism
    public abstract double CalculateRange();
}

// ================= ELECTRIC BUS =================
class ElectricBus : Vehicle
{
    private double batteryPercentage;

    public double BatteryPercentage
    {
        get { return batteryPercentage; }
        set
        {
            if (value < 0) throw new ArgumentException("Battery cannot be negative.");
            batteryPercentage = value;
        }
    }

    public ElectricBus(string id, string model, double battery)
        : base(id, model)
    {
        BatteryPercentage = battery;
    }

    public override double CalculateRange()
    {
        if (BatteryPercentage < 5)
            throw new InvalidOperationException("Battery too low for range calculation.");

        return BatteryPercentage * 2; // sample formula
    }
}

// ================= GAS VAN =================
class GasPoweredVan : Vehicle
{
    private double fuelLevel;

    public double FuelLevel
    {
        get { return fuelLevel; }
        set
        {
            if (value < 0) throw new ArgumentException("Fuel level cannot be negative.");
            fuelLevel = value;
        }
    }

    public GasPoweredVan(string id, string model, double fuel)
        : base(id, model)
    {
        FuelLevel = fuel;
    }

    public override double CalculateRange()
    {
        if (FuelLevel < 5)
            throw new InvalidOperationException("Fuel too low for range calculation.");

        return FuelLevel * 10; // sample formula
    }
}

// ================= MAIN PROGRAM =================
class Program
{
    static void Main()
    {
        try
        {
            ElectricBus bus = new ElectricBus("EB101", "VoltaBus", 60);
            GasPoweredVan van = new GasPoweredVan("GV202", "TransitVan", 40);

            Console.WriteLine("=== RANGE REPORT ===");
            Console.WriteLine($"Bus Range: {bus.CalculateRange()} km");
            Console.WriteLine($"Van Range: {van.CalculateRange()} km");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("System Shutdown");
        }
    }
}
