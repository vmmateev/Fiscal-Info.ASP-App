namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class PetrolstationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PetrolStations.Any())
            {
                return;
            }

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция ОПАН",
                City = "с.Опан",
                Street = "Околовръстен път",
                CompanyId = 2, // AMK
                FiscalPrinterId = 1,
                OilLevelId = 1,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Петрол",
                City = "Хасково",
                Street = "ул.Дунав 23",
                CompanyId = 3, // Темпо
                FiscalPrinterId = 2,
                OilLevelId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Хаджията Талев",
                City = "Пловдив",
                Street = "ул.Димитър Талев 101",
                CompanyId = 4, // Хаджията Талев
                FiscalPrinterId = 3,
                OilLevelId = 3,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Хаджията Ландос",
                City = "Пловдив",
                Street = "ул.Ландос 2",
                CompanyId = 4, // Хаджията Ландос
                FiscalPrinterId = 4,
                OilLevelId = 4,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Мора",
                City = "Кърджали",
                Street = "бул.Васил Априлов 23",
                CompanyId = 5, // Стил-96 Мора
                FiscalPrinterId = 5,
                OilLevelId = 5,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Гледка",
                City = "Кърджали",
                Street = "кв.Гледка 30",
                CompanyId = 5, // Стил-96 Гледка
                FiscalPrinterId = 6,
                OilLevelId = 6,
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
