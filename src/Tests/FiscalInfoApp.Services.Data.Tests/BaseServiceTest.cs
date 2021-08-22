namespace FiscalInfoApp.Services.Data.Tests
{
    using System;

    using FiscalInfoApp.Data;
    using Microsoft.EntityFrameworkCore;

    public class BaseServiceTest
    {
        public static ApplicationDbContext GetDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new ApplicationDbContext(options);

            return db;
        }
    }
}
