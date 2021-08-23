
namespace FiscalInfoApp.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data;
    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Data.Repositories;
    using FiscalInfoApp.Services.Data.CommDevice;
    using FiscalInfoApp.Web.ViewModels.CommDevice;
    using Moq;
    using Xunit;

    public class CommDeviceServiceTest : BaseServiceTest
    {
        private readonly Mock<IDeletableEntityRepository<CommController>> commRepository;
        private readonly Mock<IDeletableEntityRepository<PetrolStation>> petrolStationRepository;

        public CommDeviceServiceTest()
        {
            this.commRepository = new Mock<IDeletableEntityRepository<CommController>>();
            this.petrolStationRepository = new Mock<IDeletableEntityRepository<PetrolStation>>();
        }

        [Fact]
        public async Task CreateCommDeviceShouldCreateCommDeviceCorrect()
        {
            ApplicationDbContext db = GetDb();

            var commRepository = new EfDeletableEntityRepository<CommController>(db);

            var service = new CommDeviceService(commRepository, this.petrolStationRepository.Object);

            var input = new CreateCommDeviceInputModel
            {
                CommType = "rs485",
                BoxColour = "test",
                IsConcentrator = false,
                PetrolStationId = 1,
            };

            await service.CreateCommDeviceAsync(input);

            var expectedCommDevice = commRepository.All()//.CommControllers
                .Where(x => x.CommType == "rs485")
                .FirstOrDefault();

            Assert.Equal(expectedCommDevice.BoxColor, input.BoxColour);
        }

        [Fact]
        public async Task GetAllCommDevicesCountShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var commRepository = new EfDeletableEntityRepository<CommController>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new CommDeviceService(commRepository, petrolStationRepository);

            var input1 = new CreateCommDeviceInputModel
            {
                CommType = "rs232",
                BoxColour = "white",
                IsConcentrator = false,
            };

            var input2 = new CreateCommDeviceInputModel
            {
                CommType = "rs484",
                BoxColour = "black",
                IsConcentrator = false,
            };
            var input3 = new CreateCommDeviceInputModel
            {
                CommType = "Tekom",
                BoxColour = "black",
                IsConcentrator = true,
            };

            await service.CreateCommDeviceAsync(input1);
            await service.CreateCommDeviceAsync(input2);
            await service.CreateCommDeviceAsync(input3);

            var result = service.GetAllCommDevicesCount();

            Assert.Equal(3, result);
        }
        [Fact]
        public void GetAllCommDevicesShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var commRepository = new EfDeletableEntityRepository<CommController>(db);
            var petrolStationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new CommDeviceService(commRepository, petrolStationRepository);

            var comm1 = new CommController
            {
                CommType = "rs232",
                BoxColor = "white",
                IsConcentrator = false,
            };

            var comm2 = new CommController
            {
                CommType = "rs484",
                BoxColor = "black",
                IsConcentrator = false,
            };
            db.Add(comm1);
            db.Add(comm2);
            db.SaveChangesAsync();

            var result = service.GetAllCommDevices(1, 12);
            Assert.NotNull(result.Where(x => x.Id == 1));
            Assert.NotNull(result.Where(x => x.Id == 2));
        }

        [Fact]
        public async Task SoftDeleteCommDeviceDeleteTheGivenCountFromRepo()
        {
            ApplicationDbContext db = GetDb();

            var commRepo = new EfDeletableEntityRepository<CommController>(db);
            var petrolRepo = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new CommDeviceService(commRepo, petrolRepo);

            var input1 = new CommController
            {
                CommType = "rs232",
                BoxColor = "white",
                IsConcentrator = false,
            };

            var input2 = new CommController
            {
                CommType = "rs484",
                BoxColor = "black",
                IsConcentrator = false,
            };
            var input3 = new CommController
            {
                CommType = "Tekom",
                BoxColor = "black",
                IsConcentrator = true,
            };
            await db.CommControllers.AddAsync(input1);
            await db.CommControllers.AddAsync(input2);
            await db.CommControllers.AddAsync(input3);
            await db.SaveChangesAsync();

            var resultBeforeDelete = db.CommControllers.Count();
            var resultFromRepo = commRepo.All().Count();
            Assert.Equal(3, resultBeforeDelete);
            Assert.Equal(3, resultFromRepo);
            await service.SoftDeleteCommDevice(1);

            var result = db.CommControllers.Count();
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetCommDeviceByIdShouldReturnNotNull()
        {
            ApplicationDbContext db = GetDb();

            var commRepo = new EfDeletableEntityRepository<CommController>(db);
            var petrolRepo = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new CommDeviceService(commRepo, petrolRepo);

            var input1 = new CommController
            {
                CommType = "rs232",
                BoxColor = "white",
                IsConcentrator = false,
            };

            db.CommControllers.Add(input1);
            db.SaveChanges();

            var result = service.GetCommDeviceById(null);

            Assert.Null(result);
        }
    }
}
