namespace FiscalInfoApp.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Data.Repositories;
    using FiscalInfoApp.Services.Data.Probe;
    using FiscalInfoApp.Web.ViewModels.Probe;
    using Xunit;

    public class ProbeServiceTest : BaseServiceTest
    {
        [Fact]
        public async Task CreateAsyncShouldCreateProbeCorrect()
        {
            ApplicationDbContext db = GetDb();

            var probeRepository = new EfDeletableEntityRepository<Probe>(db);
            var oilLevelRepository = new EfDeletableEntityRepository<OilLevel>(db);

            var service = new ProbeService(probeRepository, oilLevelRepository);

            var oilLevel = new OilLevel
            {
                Brand = "Gilbarco",
                Model = "Tls2",
                PetrolStationId = 1,
            };

            db.OilLevels.Add(oilLevel);
            db.SaveChanges();

            var probe1 = new CreateProbeInputModel
            {
                ProbeLength = 2.4,
                FloatFuelType = "gas",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };

            await service.CreateAsync(probe1);

            var result = db.Probes.Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetAllProbesShouldReturnCorrectCollectionOfProbes()
        {
            ApplicationDbContext db = GetDb();

            var probeRepository = new EfDeletableEntityRepository<Probe>(db);
            var oilLevelRepository = new EfDeletableEntityRepository<OilLevel>(db);

            var service = new ProbeService(probeRepository, oilLevelRepository);

            var oilLevel = new OilLevel
            {
                Brand = "Gilbarco",
                Model = "Tls2",
                PetrolStationId = 1,
            };

            db.OilLevels.Add(oilLevel);
            db.SaveChanges();

            var probe1 = new Probe
            {
                ProbeLength = 2.4,
                FloatFuelType = "lpg",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };

            var probe2 = new Probe
            {
                ProbeLength = 2.3,
                FloatFuelType = "gas",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };
            db.Probes.Add(probe1);
            db.Probes.Add(probe2);
            db.SaveChanges();

            var result = service.GetAllProbes(1, 2);
            var firstProbeFuel = result.FirstOrDefault(x => x.Id == 1).FloatFuelType;
            Assert.Equal("lpg", firstProbeFuel);
        }

        [Fact]
        public void GetAllProbesCountShouldReturnCorrectIntCount()
        {
            ApplicationDbContext db = GetDb();

            var probeRepository = new EfDeletableEntityRepository<Probe>(db);
            var oilLevelRepository = new EfDeletableEntityRepository<OilLevel>(db);

            var service = new ProbeService(probeRepository, oilLevelRepository);

            var oilLevel = new OilLevel
            {
                Brand = "Gilbarco",
                Model = "Tls2",
                PetrolStationId = 1,
            };

            db.OilLevels.Add(oilLevel);
            db.SaveChanges();

            var probe1 = new Probe
            {
                ProbeLength = 2.4,
                FloatFuelType = "lpg",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };

            var probe2 = new Probe
            {
                ProbeLength = 2.3,
                FloatFuelType = "gas",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };
            db.Probes.Add(probe1);
            db.Probes.Add(probe2);
            db.SaveChanges();

            var result = service.GetAllProbesCount();

            Assert.Equal(2, result);
        }

        [Fact]
        public void GetOilLevelIdNameShouldReturnCollectionOfOilLevelLinkedToPetrolStationIdModelAndName()
        {
            ApplicationDbContext db = GetDb();

            var probeRepository = new EfDeletableEntityRepository<Probe>(db);
            var oilLevelRepository = new EfDeletableEntityRepository<OilLevel>(db);

            var service = new ProbeService(probeRepository, oilLevelRepository);

            var oilLevel = new OilLevel
            {
                Brand = "Gilbarco",
                Model = "Tls2",
                PetrolStationId = 1,
            };

            db.OilLevels.Add(oilLevel);
            db.SaveChanges();

            var probe1 = new Probe
            {
                ProbeLength = 2.4,
                FloatFuelType = "lpg",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };

            var probe2 = new Probe
            {
                ProbeLength = 2.3,
                FloatFuelType = "gas",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };
            db.Probes.Add(probe1);
            db.Probes.Add(probe2);
            db.SaveChanges();

            // TO DO dropdown menu collection
        }

        [Fact]
        public void GetProbeByIdShouldReturnCorrectProbe()
        {
            ApplicationDbContext db = GetDb();

            var probeRepository = new EfDeletableEntityRepository<Probe>(db);
            var oilLevelRepository = new EfDeletableEntityRepository<OilLevel>(db);

            var service = new ProbeService(probeRepository, oilLevelRepository);

            var oilLevel = new OilLevel
            {
                Brand = "Gilbarco",
                Model = "Tls2",
                PetrolStationId = 1,
            };

            db.OilLevels.Add(oilLevel);
            db.SaveChanges();

            var probe1 = new Probe
            {
                ProbeLength = 2.4,
                FloatFuelType = "lpg",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };

            var probe2 = new Probe
            {
                ProbeLength = 2.3,
                FloatFuelType = "gas",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };
            db.Probes.Add(probe1);
            db.Probes.Add(probe2);
            db.SaveChanges();

            var result = service.GetProbeById(1);
            Assert.Equal("lpg", result.FloatFuelType);
            Assert.Equal(50, result.FloatSize);
        }

        [Fact]
        public async Task SoftDeleteProbeShoulDeleteProbeFromRepo()
        {
            ApplicationDbContext db = GetDb();

            var probeRepository = new EfDeletableEntityRepository<Probe>(db);
            var oilLevelRepository = new EfDeletableEntityRepository<OilLevel>(db);

            var service = new ProbeService(probeRepository, oilLevelRepository);

            var oilLevel = new OilLevel
            {
                Brand = "Gilbarco",
                Model = "Tls2",
                PetrolStationId = 1,
            };

            db.OilLevels.Add(oilLevel);
            db.SaveChanges();

            var probe1 = new Probe
            {
                ProbeLength = 2.4,
                FloatFuelType = "lpg",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };

            var probe2 = new Probe
            {
                ProbeLength = 2.3,
                FloatFuelType = "gas",
                FloatSize = 50,
                TankNumber = 1,
                OilLevelId = 1,
            };

            db.Probes.Add(probe1);
            db.Probes.Add(probe2);
            db.SaveChanges();

            var resultBeforeDelete = db.Probes.Count();
            Assert.Equal(2, resultBeforeDelete);

            await service.SoftDeleteProbe(1);

            var resultAfterDelete = db.Probes.Count();
            Assert.Equal(1, resultAfterDelete);
        }
    }
}
