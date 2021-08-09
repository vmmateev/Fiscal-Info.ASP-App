namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class CommControllersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CommControllers.Any())
            {
                return;
            }

            // амк опан
            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "CL",
                BoxColor = "White",
                PetrolStationId = 1,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "485",
                BoxColor = "White",
                PetrolStationId = 1,
            });
            await dbContext.SaveChangesAsync();

            // темпо
            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "485",
                BoxColor = "White",
                PetrolStationId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "485",
                BoxColor = "Black",
                PetrolStationId = 2,
            });
            await dbContext.SaveChangesAsync();

            // хаджията Талев
            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "Tekom",
                BoxColor = "White",
                PetrolStationId = 3,
                IsConcentrator = true,
            });
            await dbContext.SaveChangesAsync();

            // хаджията Ландос
            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "Tokheim",
                BoxColor = "White",
                PetrolStationId = 4,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "Tokheim",
                BoxColor = "White",
                PetrolStationId = 4,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "485",
                BoxColor = "White",
                PetrolStationId = 4,
            });
            await dbContext.SaveChangesAsync();

            // Мора
            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "485",
                BoxColor = "White",
                PetrolStationId = 5,
            });
            await dbContext.SaveChangesAsync();

            // Гледка
            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "CL",
                BoxColor = "White",
                PetrolStationId = 6,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.CommControllers.AddAsync(new CommController
            {
                CommType = "485",
                BoxColor = "White",
                PetrolStationId = 6,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
