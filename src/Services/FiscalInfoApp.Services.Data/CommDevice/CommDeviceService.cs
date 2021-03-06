namespace FiscalInfoApp.Services.Data.CommDevice
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.CommDevice;
    using Microsoft.EntityFrameworkCore;

    public class CommDeviceService : ICommDeviceService
    {
        private readonly IDeletableEntityRepository<CommController> commRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;

        public CommDeviceService(
            IDeletableEntityRepository<CommController> commRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository)
        {
            this.commRepository = commRepository;
            this.petrolStationRepository = petrolStationRepository;
        }

        public async Task CreateCommDeviceAsync(CreateCommDeviceInputModel input)
        {
            var commDevice = new CommController
            {
                CommType = input.CommType,
                BoxColor = input.BoxColour,
                IsConcentrator = input.IsConcentrator,
                PetrolStationId = input.PetrolStationId,
            };
            await this.commRepository.AddAsync(commDevice);
            await this.commRepository.SaveChangesAsync();
        }

        public IEnumerable<CommDeviceInListViewModel> GetAllCommDevices(int page, int itemsPerPage)
        {
            var commDevices = this.commRepository.All()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new CommDeviceInListViewModel
                {
                    Id = x.Id,
                    CommType = x.CommType,
                    BoxColour = x.BoxColor,
                    IsConcentrator = x.IsConcentrator ? "Yes" : "No",
                    PetrolStationId = x.PetrolStation.Id,
                    PetrolStationName = x.PetrolStation.Name,
                    PetrolStationCity = x.PetrolStation.City,
                })
                .OrderByDescending(x => x.Id)
                .ThenByDescending(x => x.PetrolStationId)
                .ToList();

            return commDevices;
        }

        public int GetAllCommDevicesCount()
        {
            return this.commRepository.AllAsNoTracking().Count();
        }

        public CommDeviceInListViewModel GetCommDeviceById(int? id)
        {
            var commDevice = this.commRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new CommDeviceInListViewModel
                {
                    Id = x.Id,
                    CommType = x.CommType,
                    BoxColour = x.BoxColor,
                    IsConcentrator = x.IsConcentrator ? "Yes" : "No",
                    PetrolStationId = x.PetrolStation.Id,
                    PetrolStationName = x.PetrolStation.Name,
                    PetrolStationCity = x.PetrolStation.City,
                })
                .FirstOrDefault();

            return commDevice;
        }

        public async Task SoftDeleteCommDevice(int id)
        {
            var commDevice = await this.commRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.commRepository.Delete(commDevice);
            await this.commRepository.SaveChangesAsync();
        }
    }
}
