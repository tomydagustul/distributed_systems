namespace DevicesAPI
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    using Microsoft.EntityFrameworkCore.Storage;

    //Database context
    class DevicesDb : DbContext
    {
        public DevicesDb(DbContextOptions<DevicesDb> options) : base(options) 
        {

            //Folosim un obiect tip IDatabaseCreator
            var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreator != null)
            {
                // Create Database 
                if (!dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }

                // Create Tables
                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                }
            }
        }
        public DbSet<Devices> Devices => Set<Devices>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Devices>().HasData(
                new Devices() { id = 0, description = "Smart Thermostat", adress = "Living Room", kWh_energy_consumption = 2.50f },
                new Devices() { id = 1, description = "Motion Sensor", adress = "Entryway", kWh_energy_consumption = 0.75f },
                new Devices() { id = 2, description = "Smart Light Bulb", adress = "Bedroom", kWh_energy_consumption = 5.20f },
                new Devices() { id = 3, description = "Security Camera", adress = "Front Door", kWh_energy_consumption = 2.50f },
                new Devices() { id = 4, description = "Smart Refrigerator", adress = "Kitchen", kWh_energy_consumption = 2.50f },
                new Devices() { id = 5, description = "Weather Sensor", adress = "Backyard", kWh_energy_consumption = 2.50f },
                new Devices() { id = 6, description = "Smart Lock", adress = "Front Door", kWh_energy_consumption = 2.50f },
                new Devices() { id = 7, description = "Air Quality Monitor", adress = "Living Room", kWh_energy_consumption = 2.50f },
                new Devices() { id = 8, description = "Water Leak Detector", adress = "Bathroom", kWh_energy_consumption = 2.50f },
                new Devices() { id = 9, description = "Smart TV", adress = "Entertainment Room", kWh_energy_consumption = 2.50f },
                new Devices() { id = 10, description = "Fitness Tracker", adress = "Wearable", kWh_energy_consumption = 2.50f },
                new Devices() { id = 11, description = "Smart Oven", adress = "Kitchen", kWh_energy_consumption = 2.50f },
                new Devices() { id = 12, description = "Smart Mirror", adress = "Bathroom", kWh_energy_consumption = 2.50f },
                new Devices() { id = 13, description = "Smart Scale", adress = "Bathroom", kWh_energy_consumption = 2.50f },
                new Devices() { id = 14, description = "Automated Plant Watering System", adress = "Garden", kWh_energy_consumption = 2.50f },
                new Devices() { id = 15, description = "Smart Doorbell", adress = "Front Door", kWh_energy_consumption = 0.75f },
                new Devices() { id = 16, description = "Garage Door Opener", adress = "Garage", kWh_energy_consumption = 5.20f },
                new Devices() { id = 17, description = "Pet Tracker", adress = "Pet Collar", kWh_energy_consumption = 2.50f },
                new Devices() { id = 18, description = "Smart Ceiling Fan", adress = "Bedroom", kWh_energy_consumption = 2.50f },
                new Devices() { id = 19, description = "Smart Faucet", adress = "Kitchen", kWh_energy_consumption = 2.50f }
            );
        }
    }
}
