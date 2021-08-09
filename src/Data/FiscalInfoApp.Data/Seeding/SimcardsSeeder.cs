namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class SimcardsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.SimCards.Any())
            {
                return;
            }

            await dbContext.SimCards.AddAsync(new SimCard //amkopan
            {
                Imsi = "284050030151035",
                GsmNumber = "359892696801",
                OperatorName = "Telenor",
            });

            await dbContext.SimCards.AddAsync(new SimCard //Tempo
            {
                Imsi = "284050041356787",
                GsmNumber = "359894424915",
                OperatorName = "Telenor",
            });

            await dbContext.SimCards.AddAsync(new SimCard //Hadjiqta Talev
            {
                Imsi = "284050030151038",
                GsmNumber = "359892696804",
                OperatorName = "Telenor",
            });

            await dbContext.SimCards.AddAsync(new SimCard //Hadjiqta landos
            {
                Imsi = "284050030156441",
                GsmNumber = "359892698070",
                OperatorName = "Telenor",
            });


            await dbContext.SimCards.AddAsync(new SimCard //stil96 mora
            {
                Imsi = "284050030151069",
                GsmNumber = "359892696835",
                OperatorName = "Telenor",
            });

            await dbContext.SimCards.AddAsync(new SimCard //stil96 gledka
            {
                Imsi = "284031020276276",
                GsmNumber = "359878900317",
                OperatorName = "Telenor",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
