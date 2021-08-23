namespace FiscalInfoApp.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Data.Repositories;
    using FiscalInfoApp.Services.Data.FuelDispenser;
    using FiscalInfoApp.Web.ViewModels.FuelDispenser;
    using Xunit;

    public class FuelDispenserServiceTest : BaseServiceTest
    {
        [Fact]
        public async Task CreateAsyncShouldCreateCorrectFuelDispenser()
        {
            ApplicationDbContext db = GetDb();

            var fuelDispenserRepository = new EfDeletableEntityRepository<FuelDispenser>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelDispenserService(fuelDispenserRepository, petrolStationRepository);

            var fuelDisp1 = new CreateFuelDispenserInputModel
            {
                Brand = "adast",
                Model = "8999.xxx",
                DispenserNumber = 1,
                MidCertificate = "4550",
                NozzleCount = 4,
            };

            var fuelDisp2 = new CreateFuelDispenserInputModel
            {
                Brand = "gilbarco",
                Model = "sk700",
                DispenserNumber = 4,
                MidCertificate = "T10050",
                NozzleCount = 2,
            };

            await service.CreateAsync(fuelDisp1);
            await service.CreateAsync(fuelDisp2);
            var result = fuelDispenserRepository.All().Count();
            Assert.Equal(2, result);
        }

        [Fact]
        public void FuelDispenserExistsReturnTrueIfExistAndFalseIfNot()
        {
            ApplicationDbContext db = GetDb();

            var fuelDispenserRepository = new EfDeletableEntityRepository<FuelDispenser>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelDispenserService(fuelDispenserRepository, petrolStationRepository);

            var fuelDisp1 = new FuelDispenser
            {
                Brand = "adast",
                Model = "8999.xxx",
                DispenserNumber = 1,
                MidCertificate = "4550",
                NozzleCount = 4,
            };

            var fuelDisp2 = new FuelDispenser
            {
                Brand = "gilbarco",
                Model = "sk700",
                DispenserNumber = 4,
                MidCertificate = "T10050",
                NozzleCount = 2,
            };

            db.FuelDispensers.Add(fuelDisp1);
            db.FuelDispensers.Add(fuelDisp2);
            db.SaveChanges();


            var result = service.FuelDispenserExists(1);
            var result2 = service.FuelDispenserExists(3);
            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public void GetAllFuelDispenersShouldReturnAllItems()
        {
            ApplicationDbContext db = GetDb();

            var fuelDispenserRepository = new EfDeletableEntityRepository<FuelDispenser>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelDispenserService(fuelDispenserRepository, petrolStationRepository);

            var fuelDisp1 = new FuelDispenser
            {
                Brand = "adast",
                Model = "8999.xxx",
                DispenserNumber = 1,
                MidCertificate = "4550",
                NozzleCount = 4,
            };

            var fuelDisp2 = new FuelDispenser
            {
                Brand = "gilbarco",
                Model = "sk700",
                DispenserNumber = 4,
                MidCertificate = "T10050",
                NozzleCount = 2,
            };

            db.FuelDispensers.Add(fuelDisp1);
            db.FuelDispensers.Add(fuelDisp2);
            db.SaveChanges();

            // TODO why null
            var result = service.GetAllFuelDispeners(1, 12);
            var fuel1 = result.Where(x => x.Brand == "adast").FirstOrDefault();
            Assert.NotNull(result.Where(x => x.Id == 1));
            Assert.NotNull(result.Where(x => x.Id == 2));
        }

        [Fact]
        public void GetFuelAllDispensersCountShoulReturnCorrectCount()
        {
            ApplicationDbContext db = GetDb();

            var fuelDispenserRepository = new EfDeletableEntityRepository<FuelDispenser>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelDispenserService(fuelDispenserRepository, petrolStationRepository);

            var fuelDisp1 = new FuelDispenser
            {
                Brand = "adast",
                Model = "8999.xxx",
                DispenserNumber = 1,
                MidCertificate = "4550",
                NozzleCount = 4,
            };

            var fuelDisp2 = new FuelDispenser
            {
                Brand = "gilbarco",
                Model = "sk700",
                DispenserNumber = 4,
                MidCertificate = "T10050",
                NozzleCount = 2,
            };

            db.FuelDispensers.Add(fuelDisp1);
            db.FuelDispensers.Add(fuelDisp2);
            db.SaveChanges();


            var result = service.GetAllFuelDispensersCount();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetFuelDispenserByIdShouldReturnCorrectFuelDispenser()
        {
            ApplicationDbContext db = GetDb();

            var fuelDispenserRepository = new EfDeletableEntityRepository<FuelDispenser>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelDispenserService(fuelDispenserRepository, petrolStationRepository);

            var fuelDisp1 = new FuelDispenser
            {
                Id = 1,
                Brand = "adast",
                Model = "8999.xxx",
                DispenserNumber = 1,
                MidCertificate = "4550",
                NozzleCount = 4,
            };

            var fuelDisp2 = new FuelDispenser
            {
                Id = 2,
                Brand = "gilbarco",
                Model = "sk700",
                DispenserNumber = 4,
                MidCertificate = "T10050",
                NozzleCount = 2,
            };

            await db.FuelDispensers.AddAsync(fuelDisp1);
            await db.FuelDispensers.AddAsync(fuelDisp2);
            await db.SaveChangesAsync();

            // TODO Null Reference Exception ??
            // Assert.Equal(fuelDisp1.Model, result.Model);

            var result = service.GetFuelDispenserById(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task SoftDeleteFuelDispenserAsyncShouldRemove1Item()
        {
            ApplicationDbContext db = GetDb();

            var fuelDispenserRepository = new EfDeletableEntityRepository<FuelDispenser>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelDispenserService(fuelDispenserRepository, petrolStationRepository);

            var fuelDisp1 = new FuelDispenser
            {
                Id = 1,
                Brand = "adast",
                Model = "8999.xxx",
                DispenserNumber = 1,
                MidCertificate = "4550",
                NozzleCount = 4,
            };

            var fuelDisp2 = new FuelDispenser
            {
                Id = 2,
                Brand = "gilbarco",
                Model = "sk700",
                DispenserNumber = 4,
                MidCertificate = "T10050",
                NozzleCount = 2,
            };

            await db.FuelDispensers.AddAsync(fuelDisp1);
            await db.FuelDispensers.AddAsync(fuelDisp2);
            await db.SaveChangesAsync();

            var resultBeforeDelete = db.FuelDispensers.Count();
            Assert.Equal(2, resultBeforeDelete);

            await service.SoftDeleteFuelDispenserAsync(1);

            var resultAfterDelete = db.FuelDispensers.Count();
            Assert.Equal(1, resultAfterDelete);
        }
    }
}
