namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;
 
    public class PetrolstationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PetrolStations.Any())
            {
                return;
            }

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция",
                City = "с.Опан",
                Street = "Околовръстен път",
                CompanyId = 2, //AMK
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Петрол",
                City = "Хасково",
                Street = "ул.Дунав 23",
                CompanyId = 3, //Темпо
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Хаджията Талев",
                City = "Пловдив",
                Street = "ул.Димитър Талев 101",
                CompanyId = 4, //Хаджията Талев
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Хаджията Ландос",
                City = "Пловдив",
                Street = "ул.Ландос 2",
                CompanyId = 4, //Хаджията Ландос
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Мора",
                City = "Кърджали",
                Street = "бул.Васил Априлов 23",
                CompanyId = 5, //Стил-96 Мора
            });
            await dbContext.SaveChangesAsync();

            await dbContext.PetrolStations.AddAsync(new PetrolStation
            {
                Name = "Бензиностанция Гледка",
                City = "Кърджали",
                Street = "кв.Гледка 30",
                CompanyId = 5, //Стил-96 Гледка
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
