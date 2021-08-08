namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class OillevelSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.OilLevels.Any())
            {
                return;
            }

            await dbContext.OilLevels.AddAsync(new OilLevel //Opan
            {
                Brand = "Veeder-Root",
                Model = "TLS 2",
            });

            await dbContext.OilLevels.AddAsync(new OilLevel //tempo
            {
                Brand = "Petrovend",
                Model = "SiteSentinel 1",
            });

            await dbContext.OilLevels.AddAsync(new OilLevel //hadjiqta talev
            {
                Brand = "Veeder-Root",
                Model = "TLS 2P",
            });

            await dbContext.OilLevels.AddAsync(new OilLevel //hadjiqta landos
            {
                Brand = "Veeder-Root",
                Model = "TLS 350",
            });

            await dbContext.OilLevels.AddAsync(new OilLevel //stil96 mora
            {
                Brand = "Fafnir",
                Model = "Visy-x GUI",
            });

            await dbContext.OilLevels.AddAsync(new OilLevel //stil96 gledka
            {
                Brand = "Fafnir",
                Model = "Visy-x No GUI",
            });
        }
    }
}
