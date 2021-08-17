namespace FiscalInfoApp.Services.Data.PetrolStation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.PetrolStation;

    public class PetrolStationService : IPetrolStationService
    {
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;
        private readonly IDeletableEntityRepository<Company> companyRepository;

        public PetrolStationService(IDeletableEntityRepository<PetrolStation> petrolStationRepository)
        {
            this.petrolStationRepository = petrolStationRepository;
        }

        public async Task CreatePetrolStationAsync(CreatePetrolStationInputModel input)
        {
            var petrolStation = new PetrolStation
            {
                Name = input.Name,
                City = input.City,
                Street = input.Street,
                CompanyId = input.CompanyId,
            };

            await this.petrolStationRepository.AddAsync(petrolStation);

            await this.petrolStationRepository.SaveChangesAsync();
        }

        public IEnumerable<PetrolStationInListViewModel> GetAllPetrolStations(int page, int itemsPerPage = 12)
        {
            var petrolStations = this.petrolStationRepository.AllAsNoTracking()
               .OrderByDescending(x => x.Id)
               .Skip((page - 1) * itemsPerPage)
               .Take(itemsPerPage)
               .Select(x => new PetrolStationInListViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   City = x.City,
                   Street = x.Street,
                   CompanyId = x.CompanyId,
                   CompanyName = x.Company.Name,
               })
               .OrderBy(x => x.CompanyName)
            .ToList();

            return petrolStations;
        }

        public int GetPetrolStationsCount()
        {
            var petrolStationsCount = this.petrolStationRepository.All().Count();

            return petrolStationsCount;
        }
    }
}
