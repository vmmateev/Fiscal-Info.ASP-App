namespace FiscalInfoApp.Services.Data.FuelTank
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.FuelTank;
    using Microsoft.EntityFrameworkCore;

    public class FuelTankService : IFuelTankService
    {
        private readonly IDeletableEntityRepository<FuelTank> fuelTankRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;

        public FuelTankService(
            IDeletableEntityRepository<FuelTank> fuelTankRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository)
        {
            this.fuelTankRepository = fuelTankRepository;
            this.petrolStationRepository = petrolStationRepository;
        }

        public async Task CreateFuelTankAsync(CreateFuelTankInputModel input)
        {
            var fuelTank = new FuelTank
            {
                TankNumber = input.TankNumber,
                FullVolume = input.FullVolume,
                Diameter = input.Diameter,
                CalibrationDate = input.CalibrationDate,
                FuelType = input.FuelType,
                PetrolStationId = input.PetrolStationId,
            };

            await this.fuelTankRepository.AddAsync(fuelTank);
            await this.fuelTankRepository.SaveChangesAsync();
        }

        public IEnumerable<FuelTankInListViewModel> GetAllFuelTanks(int page, int itemsPerPage = 12)
        {
            var fuelTanks = this.fuelTankRepository.All()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new FuelTankInListViewModel
                {
                    Id = x.Id,
                    TankNumber = x.TankNumber,
                    CalibrationDate = x.CalibrationDate.ToString("d"),
                    Diameter = x.Diameter,
                    FullVolume = x.FullVolume,
                    FuelType = x.FuelType,
                    PetrolStationId = x.PetrolStationId,
                    PetrolStationCity = x.PetrolStation.City,
                    PetrolStationName = x.PetrolStation.Name,
                })
                .OrderByDescending(x => x.Id)
                .ThenByDescending(x => x.PetrolStationId)
                .ToList();

            return fuelTanks;
        }

        public int GetAllFuelTanksCount()
        {
            return this.fuelTankRepository.AllAsNoTracking().Count();
        }

        public FuelTankInListViewModel GetFuelTankById(int? id)
        {
            var fuelTankById = this.fuelTankRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new FuelTankInListViewModel
                {
                    Id = x.Id,
                    TankNumber = x.TankNumber,
                    CalibrationDate = x.CalibrationDate.ToString("d"),
                    Diameter = x.Diameter,
                    FullVolume = x.FullVolume,
                    FuelType = x.FuelType,
                    PetrolStationId = x.PetrolStationId,
                    PetrolStationCity = x.PetrolStation.City,
                    PetrolStationName = x.PetrolStation.Name,
                })
                .FirstOrDefault();

            return fuelTankById;
        }

        public async Task SoftDeleteFuelTank(int id)
        {
            var fuelTank = await this.fuelTankRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.fuelTankRepository.Delete(fuelTank);
            await this.fuelTankRepository.SaveChangesAsync();
        }
    }
}
