using System;
using System.Text;

namespace DesignPattern.Builder
{
    // Product class
    public class Computer
    {
        public string CPU { get; set; } = "";
        public string RAM { get; set; } = "";
        public string Storage { get; set; } = "";
        public string GraphicsCard { get; set; } = "";
        public string Motherboard { get; set; } = "";
        public string PowerSupply { get; set; } = "";
        public string Case { get; set; } = "";
        public bool HasWifi { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasOpticalDrive { get; set; }

        public void DisplaySpecs()
        {
            Console.WriteLine("=== Computer Specifications ===");
            Console.WriteLine($"CPU: {CPU}");
            Console.WriteLine($"RAM: {RAM}");
            Console.WriteLine($"Storage: {Storage}");
            Console.WriteLine($"Graphics Card: {GraphicsCard}");
            Console.WriteLine($"Motherboard: {Motherboard}");
            Console.WriteLine($"Power Supply: {PowerSupply}");
            Console.WriteLine($"Case: {Case}");
            Console.WriteLine($"WiFi: {(HasWifi ? "Yes" : "No")}");
            Console.WriteLine($"Bluetooth: {(HasBluetooth ? "Yes" : "No")}");
            Console.WriteLine($"Optical Drive: {(HasOpticalDrive ? "Yes" : "No")}");
            Console.WriteLine();
        }
    }

    // Builder interface
    public interface IComputerBuilder
    {
        IComputerBuilder SetCPU(string cpu);
        IComputerBuilder SetRAM(string ram);
        IComputerBuilder SetStorage(string storage);
        IComputerBuilder SetGraphicsCard(string graphicsCard);
        IComputerBuilder SetMotherboard(string motherboard);
        IComputerBuilder SetPowerSupply(string powerSupply);
        IComputerBuilder SetCase(string caseType);
        IComputerBuilder SetWifi(bool hasWifi);
        IComputerBuilder SetBluetooth(bool hasBluetooth);
        IComputerBuilder SetOpticalDrive(bool hasOpticalDrive);
        Computer Build();
    }

    // Concrete Builder
    public class ComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public IComputerBuilder SetCPU(string cpu)
        {
            _computer.CPU = cpu;
            return this;
        }

        public IComputerBuilder SetRAM(string ram)
        {
            _computer.RAM = ram;
            return this;
        }

        public IComputerBuilder SetStorage(string storage)
        {
            _computer.Storage = storage;
            return this;
        }

        public IComputerBuilder SetGraphicsCard(string graphicsCard)
        {
            _computer.GraphicsCard = graphicsCard;
            return this;
        }

        public IComputerBuilder SetMotherboard(string motherboard)
        {
            _computer.Motherboard = motherboard;
            return this;
        }

        public IComputerBuilder SetPowerSupply(string powerSupply)
        {
            _computer.PowerSupply = powerSupply;
            return this;
        }

        public IComputerBuilder SetCase(string caseType)
        {
            _computer.Case = caseType;
            return this;
        }

        public IComputerBuilder SetWifi(bool hasWifi)
        {
            _computer.HasWifi = hasWifi;
            return this;
        }

        public IComputerBuilder SetBluetooth(bool hasBluetooth)
        {
            _computer.HasBluetooth = hasBluetooth;
            return this;
        }

        public IComputerBuilder SetOpticalDrive(bool hasOpticalDrive)
        {
            _computer.HasOpticalDrive = hasOpticalDrive;
            return this;
        }

        public Computer Build()
        {
            return _computer;
        }
    }

    // Director class
    public class ComputerDirector
    {
        public Computer BuildGamingPC(IComputerBuilder builder)
        {
            return builder
                .SetCPU("Intel Core i9-12900K")
                .SetRAM("32GB DDR4-3200")
                .SetStorage("1TB NVMe SSD")
                .SetGraphicsCard("NVIDIA RTX 4080")
                .SetMotherboard("ASUS ROG Strix Z690")
                .SetPowerSupply("850W 80+ Gold")
                .SetCase("Full Tower ATX")
                .SetWifi(true)
                .SetBluetooth(true)
                .SetOpticalDrive(false)
                .Build();
        }

        public Computer BuildOfficePC(IComputerBuilder builder)
        {
            return builder
                .SetCPU("Intel Core i5-12400")
                .SetRAM("16GB DDR4-2666")
                .SetStorage("512GB SSD")
                .SetGraphicsCard("Integrated Graphics")
                .SetMotherboard("ASUS Prime B660")
                .SetPowerSupply("500W 80+ Bronze")
                .SetCase("Mid Tower ATX")
                .SetWifi(true)
                .SetBluetooth(false)
                .SetOpticalDrive(true)
                .Build();
        }

        public Computer BuildBudgetPC(IComputerBuilder builder)
        {
            return builder
                .SetCPU("AMD Ryzen 5 5600G")
                .SetRAM("8GB DDR4-2400")
                .SetStorage("256GB SSD")
                .SetGraphicsCard("Integrated Graphics")
                .SetMotherboard("MSI B450M")
                .SetPowerSupply("400W 80+ White")
                .SetCase("Mini Tower")
                .SetWifi(false)
                .SetBluetooth(false)
                .SetOpticalDrive(false)
                .Build();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Computer Builder Example
            Console.WriteLine("1. Computer Builder Example:");
            var computerBuilder = new ComputerBuilder();
            var director = new ComputerDirector();

            Console.WriteLine("Building Gaming PC:");
            var gamingPC = director.BuildGamingPC(computerBuilder);
            gamingPC.DisplaySpecs();

            Console.WriteLine("Building Office PC:");
            var officePC = director.BuildOfficePC(computerBuilder);
            officePC.DisplaySpecs();

            Console.WriteLine("Building Budget PC:");
            var budgetPC = director.BuildBudgetPC(computerBuilder);
            budgetPC.DisplaySpecs();

            // Custom Computer using Fluent Interface
            Console.WriteLine("Building Custom PC:");
            var customPC = computerBuilder
                .SetCPU("AMD Ryzen 7 5800X")
                .SetRAM("64GB DDR4-3600")
                .SetStorage("2TB NVMe SSD")
                .SetGraphicsCard("NVIDIA RTX 4090")
                .SetMotherboard("ASUS ROG Crosshair VIII")
                .SetPowerSupply("1000W 80+ Platinum")
                .SetCase("Custom Water Cooled Case")
                .SetWifi(true)
                .SetBluetooth(true)
                .SetOpticalDrive(false)
                .Build();
            customPC.DisplaySpecs();
            
        }
    }
}
