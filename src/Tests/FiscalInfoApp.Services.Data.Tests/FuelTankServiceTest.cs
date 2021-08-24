namespace FiscalInfoApp.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Data.Repositories;
    using FiscalInfoApp.Services.Data.FuelTank;
    using FiscalInfoApp.Web.ViewModels.FuelTank;
    using Xunit;

    public class FuelTankServiceTest : BaseServiceTest
    {
        [Fact]
        public async Task CreateFuelAsyncShouldCreateFuelTankCorrect()
        {
            ApplicationDbContext db = GetDb();
            var fuelTankRepository = new EfDeletableEntityRepository<FuelTank>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelTankService(fuelTankRepository, petrolStationRepository);

            var fuelTank1 = new CreateFuelTankInputModel
            {
                TankNumber = 1,
                FullVolume = 40000,
                Diameter = 2600,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "diesel",
                PetrolStationId = 1,
            };

            await service.CreateFuelTankAsync(fuelTank1);

            var result = db.FuelTanks.Where(x => x.TankNumber == 1).FirstOrDefault();
            Assert.Equal("diesel", result.FuelType);
            Assert.Equal(2600, result.Diameter);
            Assert.Equal(40000, result.FullVolume);
        }

        [Fact]
        public void GetAllFuelTanksShoulReturnCollectionOfAllFuelTanks()
        {
            ApplicationDbContext db = GetDb();
            var fuelTankRepository = new EfDeletableEntityRepository<FuelTank>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelTankService(fuelTankRepository, petrolStationRepository);
            var petrolStation = new PetrolStation
            {
                Name = "tempo",
                Street = "dunav",
                City = "haskovo",
                FiscalPrinterId = 1,
                OilLevelId = 1,
            };
            db.PetrolStations.Add(petrolStation);

            var fuelTank1 = new FuelTank
            {
                TankNumber = 1,
                FullVolume = 40000,
                Diameter = 2600,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "diesel",
                PetrolStationId = 1,
            };

            var fuelTank2 = new FuelTank
            {
                TankNumber = 2,
                FullVolume = 20000,
                Diameter = 2601,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "a-95",
                PetrolStationId = 1,
            };
            var fuelTank3 = new FuelTank
            {
                TankNumber = 3,
                FullVolume = 9000,
                Diameter = 2500,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "lpg",
                PetrolStationId = 1,
            };

            db.FuelTanks.Add(fuelTank1);
            db.FuelTanks.Add(fuelTank2);
            db.FuelTanks.Add(fuelTank3);
            db.SaveChanges();

            var result = service.GetAllFuelTanks(1, 12);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetAllFuelTanksCountShouldReturnCorrectCount()
        {
            ApplicationDbContext db = GetDb();
            var fuelTankRepository = new EfDeletableEntityRepository<FuelTank>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelTankService(fuelTankRepository, petrolStationRepository);

            var fuelTank1 = new FuelTank
            {
                TankNumber = 1,
                FullVolume = 40000,
                Diameter = 2600,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "diesel",
                PetrolStationId = 1,
            };

            var fuelTank2 = new FuelTank
            {
                TankNumber = 2,
                FullVolume = 20000,
                Diameter = 2601,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "a-95",
                PetrolStationId = 1,
            };
            var fuelTank3 = new FuelTank
            {
                TankNumber = 3,
                FullVolume = 9000,
                Diameter = 2500,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "lpg",
                PetrolStationId = 1,
            };

            db.FuelTanks.Add(fuelTank1);
            db.FuelTanks.Add(fuelTank2);
            db.FuelTanks.Add(fuelTank3);
            db.SaveChanges();

            var result = service.GetAllFuelTanksCount();

            Assert.Equal(3, result);

        }

        [Fact]
        public void GetFuelTankByIdShoulGetCorrectFuelTankById()
        {
            ApplicationDbContext db = GetDb();
            var fuelTankRepository = new EfDeletableEntityRepository<FuelTank>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelTankService(fuelTankRepository, petrolStationRepository);

            var petrolStation1 = new PetrolStation
            {
                Name = "benzinostanciq propan",
                City = "plovdiv",
                Street = "carigradsko",
                CompanyId = 3,
            };

            db.PetrolStations.Add(petrolStation1);
            db.SaveChanges();

            var fuelTank1 = new FuelTank
            {
                TankNumber = 1,
                FullVolume = 40000,
                Diameter = 2600,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "diesel",
                PetrolStationId = 1,
            };

            var fuelTank2 = new FuelTank
            {
                TankNumber = 2,
                FullVolume = 20000,
                Diameter = 2601,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "a-95",
                PetrolStationId = 1,
            };
            var fuelTank3 = new FuelTank
            {
                TankNumber = 3,
                FullVolume = 9000,
                Diameter = 2500,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "lpg",
                PetrolStationId = 1,
            };

            db.FuelTanks.Add(fuelTank1);
            db.FuelTanks.Add(fuelTank2);
            db.FuelTanks.Add(fuelTank3);
            db.SaveChanges();

            var result = service.GetFuelTankById(3);

            Assert.Equal("lpg", result.FuelType);
        }

        [Fact]
        public async Task SoftDeleteFuelTankShoulDeleteCorrectFuelTank()
        {
            ApplicationDbContext db = GetDb();
            var fuelTankRepository = new EfDeletableEntityRepository<FuelTank>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new FuelTankService(fuelTankRepository, petrolStationRepository);

            var fuelTank1 = new CreateFuelTankInputModel
            {
                TankNumber = 1,
                FullVolume = 40000,
                Diameter = 2600,
                CalibrationDate = DateTime.UtcNow,
                FuelType = "diesel",
                PetrolStationId = 1,
            };

            await service.CreateFuelTankAsync(fuelTank1);

            var resultBeforeDelete = db.FuelTanks.Count();
            Assert.Equal(1, resultBeforeDelete);

            await service.SoftDeleteFuelTank(1);

            var resultAfterDelete = db.FuelTanks.Count();
            Assert.Equal(0, resultAfterDelete);
        }
    }
}
