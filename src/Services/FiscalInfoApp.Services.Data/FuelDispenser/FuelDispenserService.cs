namespace FiscalInfoApp.Services.Data.FuelDispenser
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.FuelDispenser;
    using Microsoft.EntityFrameworkCore;

    public class FuelDispenserService : IFuelDispenserService
    {
        private readonly IDeletableEntityRepository<FuelDispenser> fuelDispenserRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;

        public FuelDispenserService(
            IDeletableEntityRepository<FuelDispenser> fuelDispenserRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository)
        {
            this.fuelDispenserRepository = fuelDispenserRepository;
            this.petrolStationRepository = petrolStationRepository;
        }

        public async Task CreateAsync(CreateFuelDispenserInputModel input)
        {
            var fuelDispenser = new FuelDispenser
            {
                Id = input.Id,
                DispenserNumber = input.DispenserNumber,
                Brand = input.Brand,
                Model = input.Model,
                NozzleCount = input.NozzleCount,
                MidCertificate = input.MidCertificate,
                PetrolStationId = input.PetrolStationId,
            };
            await this.fuelDispenserRepository.AddAsync(fuelDispenser);
            await this.fuelDispenserRepository.SaveChangesAsync();
        }

        public bool FuelDispenserExists(int id)
        {
            return this.fuelDispenserRepository.All().Any(e => e.Id == id);
        }

        public IEnumerable<FuelDispenserInListViewModel> GetAllFuelDispeners(int page, int itemsPerPage = 12)
        {
            var fuelDispensers = this.fuelDispenserRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new FuelDispenserInListViewModel
                {
                    Id = x.Id,
                    DispenserNumber = x.DispenserNumber,
                    Brand = x.Brand,
                    Model = x.Model,
                    NozzleCount = x.NozzleCount,
                    MidCertificate = x.MidCertificate,
                    PetrolStationId = x.PetrolStationId,
                    PetrolStationCity = x.PetrolStation.City,
                })
                .OrderByDescending(x => x.Id)
                .ThenByDescending(x => x.PetrolStationId)
                .ToList();

            return fuelDispensers;
        }

        public int GetAllFuelDispensersCount()
        {
            return this.fuelDispenserRepository.AllAsNoTracking().Count();
        }

        public FuelDispenserInListViewModel GetFuelDispenserById(int? id)
        {
            var fuelDispenser = this.fuelDispenserRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new FuelDispenserInListViewModel
                {
                    Id = x.Id,
                    DispenserNumber = x.DispenserNumber,
                    Brand = x.Brand,
                    Model = x.Model,
                    NozzleCount = x.NozzleCount,
                    MidCertificate = x.MidCertificate,
                    PetrolStationId = x.PetrolStationId,
                    PetrolStationCity = x.PetrolStation.City,
                })
                .FirstOrDefault();

            return fuelDispenser;
        }

        //public IEnumerable<PetrolStationViewModelDropDown> GetPetrolStationsIdName()
        //{
        //    var viewModel = this.petrolStationRepository.AllAsNoTracking()
        //        .Select(x => new PetrolStationViewModelDropDown
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //        })
        //        .ToList();

        //    return viewModel;
        //}

        public async Task SoftDeleteFuelDispenserAsync(int id)
        {
            var fuelDispenser = await this.fuelDispenserRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.fuelDispenserRepository.Delete(fuelDispenser);
            await this.fuelDispenserRepository.SaveChangesAsync();
        }
    }
}
