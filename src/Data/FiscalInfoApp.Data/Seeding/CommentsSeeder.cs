using FiscalInfoApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalInfoApp.Data.Seeding
{
    public class CommentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Comments.Any())
            {
                return;
            }

            await dbContext.AddAsync(new Comment
            {
                Description = "Изгорял фискален принтер, работи с оборотно дъно!",
                PetrolStationId = 1,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Comment
            {
                Description = "Подменено захранване на pc",
                PetrolStationId = 1,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Comment
            {
                Description = "Бимко е със нов датчик за тегло",
                PetrolStationId = 2,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Comment
            {
                Description = "Токхайм колонките губят комуникация когато са двете на един контролер.",
                PetrolStationId = 4,
            });
            await dbContext.SaveChangesAsync();

            await dbContext.AddAsync(new Comment
            {
                Description = "Подменена колонка от Wayne Dresser",
                PetrolStationId = 6,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
