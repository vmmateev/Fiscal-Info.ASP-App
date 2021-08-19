namespace FiscalInfoApp.Services.Data.FuelTank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.FuelTank;

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

        public IEnumerable<FuelTankInListViewModel> GetAllFuelTanks()
        {
            throw new NotImplementedException();
        }

        public int GetAllFuelTanksCount()
        {
            return this.fuelTankRepository.AllAsNoTracking().Count();
        }
    }
}
