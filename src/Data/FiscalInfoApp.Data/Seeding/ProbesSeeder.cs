namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class ProbesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Probes.Any())
            {
                return;
            }

            // амк опан
            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.74,
                FloatSize = 76,
                FloatFuelType = "Disel",
                TankNumber = 1,
                OilLevelId = 1,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.66,
                FloatSize = 76,
                FloatFuelType = "Gasoline",
                TankNumber = 2,
                OilLevelId = 1,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 50,
                FloatFuelType = "LPG",
                TankNumber = 3,
                OilLevelId = 1,
            });
            await dbContext.SaveChangesAsync();

            // темпо
            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.74,
                FloatSize = 76,
                FloatFuelType = "Disel",
                TankNumber = 1,
                OilLevelId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.74,
                FloatSize = 76,
                FloatFuelType = "Disel",
                TankNumber = 2,
                OilLevelId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.74,
                FloatSize = 76,
                FloatFuelType = "Gasoline",
                TankNumber = 3,
                OilLevelId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 76,
                FloatFuelType = "Gasoline",
                TankNumber = 4,
                OilLevelId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.14,
                FloatSize = 50,
                FloatFuelType = "LPG",
                TankNumber = 5,
                OilLevelId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.14,
                FloatSize = 50,
                FloatFuelType = "LPG",
                TankNumber = 6,
                OilLevelId = 2,
            });
            await dbContext.SaveChangesAsync();

            // хаджията талев
            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 50,
                FloatFuelType = "Gasoline",
                TankNumber = 1,
                OilLevelId = 3,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 76,
                FloatFuelType = "Gasoline",
                TankNumber = 2,
                OilLevelId = 3,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.74,
                FloatSize = 76,
                FloatFuelType = "Diesel",
                TankNumber = 3,
                OilLevelId = 3,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.74,
                FloatSize = 76,
                FloatFuelType = "Diesel",
                TankNumber = 4,
                OilLevelId = 3,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.14,
                FloatSize = 50,
                FloatFuelType = "LPG",
                TankNumber = 5,
                OilLevelId = 3,
            });
            await dbContext.SaveChangesAsync();

            // хаджията ландос
            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 76,
                FloatFuelType = "Diesel",
                TankNumber = 1,
                OilLevelId = 4,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 76,
                FloatFuelType = "Gasoline",
                TankNumber = 2,
                OilLevelId = 4,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 76,
                FloatFuelType = "Gasoline",
                TankNumber = 3,
                OilLevelId = 4,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.44,
                FloatSize = 76,
                FloatFuelType = "Diesel",
                TankNumber = 4,
                OilLevelId = 4,
            });
            await dbContext.SaveChangesAsync();

            // стил96 мора
            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.13,
                FloatSize = 50,
                FloatFuelType = "Diesel",
                TankNumber = 1,
                OilLevelId = 5,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.13,
                FloatSize = 50,
                FloatFuelType = "Gasoline",
                TankNumber = 2,
                OilLevelId = 5,
            });
            await dbContext.SaveChangesAsync();

            // стил гледка
            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.24,
                FloatSize = 76,
                FloatFuelType = "Diesel",
                TankNumber = 1,
                OilLevelId = 6,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Probe
            {
                ProbeLength = 2.24,
                FloatSize = 76,
                FloatFuelType = "Gasoline",
                TankNumber = 2,
                OilLevelId = 6,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
