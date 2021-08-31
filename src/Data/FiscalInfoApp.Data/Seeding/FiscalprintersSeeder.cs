namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Models;

    public class FiscalprintersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FiscalPrinters.Any())
            {
                return;
            }

            await dbContext.FiscalPrinters.AddAsync(new FiscalPrinter // opan
            {
                OsNumber = "OS005736",
                MemoryNumber = "58005736",
                Fdrid = "4223192",
                SimCardId = 1,
            });

            await dbContext.FiscalPrinters.AddAsync(new FiscalPrinter // tempo
            {
                OsNumber = "OS005730",
                MemoryNumber = "58005730",
                Fdrid = "4217187",
                SimCardId = 2,
            });

            await dbContext.FiscalPrinters.AddAsync(new FiscalPrinter // talev hadjiqta
            {
                OsNumber = "OS005727",
                MemoryNumber = "58005727",
                Fdrid = "4297799",
                SimCardId = 3,
            });

            await dbContext.FiscalPrinters.AddAsync(new FiscalPrinter // landos hajdiqta
            {
                OsNumber = "OS006155",
                MemoryNumber = "58006155",
                Fdrid = "4284939",
                SimCardId = 4,
            });

            await dbContext.FiscalPrinters.AddAsync(new FiscalPrinter // stil96 mora
            {
                OsNumber = "OS006132",
                MemoryNumber = "58006132",
                Fdrid = "4272876",
                SimCardId = 5,
            });

            await dbContext.FiscalPrinters.AddAsync(new FiscalPrinter // stil96 gledka
            {
                OsNumber = "OS005909",
                MemoryNumber = "58005909",
                Fdrid = "4272082",
                SimCardId = 6,
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
