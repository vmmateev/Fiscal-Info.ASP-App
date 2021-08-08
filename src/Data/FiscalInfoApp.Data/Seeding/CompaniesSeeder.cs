namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class CompaniesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Companies.Any())
            {
                return;
            }

            await dbContext.Companies.AddAsync(new Company { Name = "Стимекс ООД", City = "Хасково", Street = "ул.Пловдивска №2", IsServiceOrganization = true });
            await dbContext.Companies.AddAsync(new Company { Name = "АМК-2002 ООД", City = "с.Опан", Street = "Околовръстен път" });
            await dbContext.Companies.AddAsync(new Company { Name = "Темпо-ММ ООД", City = "Хасково", Street = "ул.Дунав 23" });
            await dbContext.Companies.AddAsync(new Company { Name = "Хаджията 2 ЕООД", City = "Пловдив", Street = "ул.Димитър Талев 101" });
            await dbContext.Companies.AddAsync(new Company { Name = "Стил-96 ООД", City = "Кърджали", Street = "бул.Васил Априлов 23"});

            await dbContext.SaveChangesAsync();
        }
    }
}
