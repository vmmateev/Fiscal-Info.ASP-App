namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class FueltankSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FuelTanks.Any())
            {
                return;
            }

            var randomYear = new Random();

            // opan Id 1
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 1,
                    FullVolume = 25000,
                    Diameter = 2600,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Diesel",
                    PetrolStationId = 1,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
            new FuelTank
            {
                TankNumber = 2,
                FullVolume = 10000,
                Diameter = 2600,
                CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                FuelType = "A-95H",
                PetrolStationId = 1,
            });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 3,
                    FullVolume = 10400,
                    Diameter = 1600,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "LPG",
                    PetrolStationId = 1,
                });
            await dbContext.SaveChangesAsync();

            // Tempo Id2
            await dbContext.FuelTanks.AddAsync(
           new FuelTank
           {
               TankNumber = 1,
               FullVolume = 20400,
               Diameter = 2500,
               CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
               FuelType = "Disel",
               PetrolStationId = 2,
           });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 2,
                    FullVolume = 12500,
                    Diameter = 2500,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Disel Premium",
                    PetrolStationId = 2,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 3,
                    FullVolume = 15643,
                    Diameter = 2500,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "A-95H",
                    PetrolStationId = 2,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
            new FuelTank
            {
                TankNumber = 4,
                FullVolume = 7308,
                Diameter = 2230,
                CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                FuelType = "A-98H",
                PetrolStationId = 2,
            });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 5,
                    FullVolume = 10234,
                    Diameter = 1600,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "LPG",
                    PetrolStationId = 2,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 6,
                    FullVolume = 10121,
                    Diameter = 1600,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Битова Газ",
                    PetrolStationId = 2,
                });
            await dbContext.SaveChangesAsync();

            // hadjiqta talev Id 3
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 1,
                    FullVolume = 9800,
                    Diameter = 2400,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "A-95H",
                    PetrolStationId = 3,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 2,
                    FullVolume = 15300,
                    Diameter = 2400,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "A-98H",
                    PetrolStationId = 3,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 3,
                    FullVolume = 25800,
                    Diameter = 2600,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Diesel",
                    PetrolStationId = 3,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 4,
                    FullVolume = 22300,
                    Diameter = 2600,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Diesel Ecto",
                    PetrolStationId = 3,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 5,
                    FullVolume = 25000,
                    Diameter = 2200,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "LPG",
                    PetrolStationId = 3,
                });
            await dbContext.SaveChangesAsync();

            // hadjiqta landos Id 4
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 1,
                    FullVolume = 13240,
                    Diameter = 2400,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Diesel",
                    PetrolStationId = 4,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 2,
                    FullVolume = 7220,
                    Diameter = 2400,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "A-95H",
                    PetrolStationId = 4,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 3,
                    FullVolume = 6544,
                    Diameter = 2400,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "A-99H",
                    PetrolStationId = 4,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 4,
                    FullVolume = 16544,
                    Diameter = 2400,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Diesel",
                    PetrolStationId = 4,
                });
            await dbContext.SaveChangesAsync();

            // stil96 mora Id 5
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 1,
                    FullVolume = 18233,
                    Diameter = 2100,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Diesel",
                    PetrolStationId = 5,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 2,
                    FullVolume = 8976,
                    Diameter = 2100,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "A-95",
                    PetrolStationId = 5,
                });
            await dbContext.SaveChangesAsync();

            // stil96 gledka Id 6
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 1,
                    FullVolume = 13433,
                    Diameter = 2000,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "Diesel",
                    PetrolStationId = 6,
                });
            await dbContext.SaveChangesAsync();
            await dbContext.FuelTanks.AddAsync(
                new FuelTank
                {
                    TankNumber = 2,
                    FullVolume = 9822,
                    Diameter = 2000,
                    CalibrationDate = DateTime.UtcNow.AddYears(-randomYear.Next(1, 15)),
                    FuelType = "A-95",
                    PetrolStationId = 6,
                });
            await dbContext.SaveChangesAsync();
        }
    }
}
