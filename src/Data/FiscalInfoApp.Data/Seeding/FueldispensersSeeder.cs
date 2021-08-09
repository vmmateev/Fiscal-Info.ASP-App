namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class FueldispensersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FuelDispensers.Any())
            {
                return;
            }

            var fuelDispensers = new List<FuelDispenser>
            {   
                //opan Id 1
                new FuelDispenser
                {
                    DispenserNumber=1,
                    Brand = "Gilbarco",
                    Model = "SK700-2",
                    NozzleCount = 6,
                    MidCertificate = "T10055",
                    PetrolStationId = 1,
                },
                new FuelDispenser
                {
                    DispenserNumber=2,
                    Brand = "Adast",
                    Model = "8991.65",
                    NozzleCount = 1,
                    MidCertificate = "2053",
                    PetrolStationId = 1,
                },
                //Tempo Id 2
                new FuelDispenser
                {
                    DispenserNumber=1,
                    Brand = "Adast",
                    Model = "899x.xxx/COM/BG",
                    NozzleCount = 8,
                    MidCertificate = "2443",
                    PetrolStationId = 2,
                },
                new FuelDispenser
                {
                    DispenserNumber=2,
                    Brand = "Adast",
                    Model = "899x.xxx/COM/BG",
                    NozzleCount = 6,
                    MidCertificate = "2243",
                    PetrolStationId = 2,
                },
                new FuelDispenser
                {
                    DispenserNumber=3,
                    Brand = "Adast",
                    Model = "8995",
                    NozzleCount = 2,
                    MidCertificate = "2343",
                    PetrolStationId = 2,
                },
                new FuelDispenser
                {
                    DispenserNumber=4,
                    Brand = "Bimco",
                    Model = "B50",
                    NozzleCount = 1,
                    MidCertificate = "BG-TAC-007",
                    PetrolStationId = 2,
                },

                //hadjiqta talev Id3
                new FuelDispenser
                {
                    DispenserNumber=1,
                    Brand = "S&B",
                    Model = "2392",
                    NozzleCount = 8,
                    MidCertificate = "2209",
                    PetrolStationId = 3,
                },

                new FuelDispenser
                {
                    DispenserNumber=2,
                    Brand = "S&B",
                    Model = "2392",
                    NozzleCount = 8,
                    MidCertificate = "2209",
                    PetrolStationId = 3,
                },

                new FuelDispenser
                {
                    DispenserNumber=3,
                    Brand = "S&B",
                    Model = "2395/50+130",
                    NozzleCount = 8,
                    MidCertificate = "2210",
                    PetrolStationId = 3,
                },

                new FuelDispenser
                {
                    DispenserNumber=4,
                    Brand = "S&B",
                    Model = "2395/50+130",
                    NozzleCount = 8,
                    MidCertificate = "2210",
                    PetrolStationId = 3,
                },
                //hadjiqta landos ID4
                new FuelDispenser
                {
                    DispenserNumber=1,
                    Brand = "Tokheim",
                    Model = "Quantium 500",
                    NozzleCount = 8,
                    MidCertificate = "3537",
                    PetrolStationId = 4,
                },

                new FuelDispenser
                {
                    DispenserNumber=2,
                    Brand = "Tokheim",
                    Model = "Quantium 500",
                    NozzleCount = 8,
                    MidCertificate = "3537",
                    PetrolStationId = 4,
                },

                new FuelDispenser
                {
                    DispenserNumber=3,
                    Brand = "ADAST",
                    Model = "8992.602/LPG",
                    NozzleCount = 2,
                    MidCertificate = "3536",
                    PetrolStationId = 4,
                },
                //stil96 mora Id5
                new FuelDispenser
                {
                    DispenserNumber=1,
                    Brand = "Wayne",
                    Model = "Helix 6000",
                    NozzleCount = 4,
                    MidCertificate = "MID 107026",
                    PetrolStationId = 5,
                },
                //stil96 gledka Id 6
                new FuelDispenser
                {
                    DispenserNumber=1,
                    Brand = "Gilbarco",
                    Model = "SK700",
                    NozzleCount = 2,
                    MidCertificate = "MID T10055",
                    PetrolStationId = 6,
                },
                new FuelDispenser
                {
                    DispenserNumber=2,
                    Brand = "Adast",
                    Model = "8xxx.xxx",
                    NozzleCount = 4,
                    MidCertificate = "4663",
                    PetrolStationId = 6,
                },
            };

            foreach (var dispenser in fuelDispensers)
            {
                await dbContext.FuelDispensers.AddAsync(new FuelDispenser
                {
                    DispenserNumber = dispenser.DispenserNumber,
                    Brand = dispenser.Brand,
                    Model = dispenser.Model,
                    NozzleCount = dispenser.NozzleCount,
                    MidCertificate = dispenser.MidCertificate,
                    PetrolStationId = dispenser.PetrolStationId,
                });
            }
        }
    }
}
