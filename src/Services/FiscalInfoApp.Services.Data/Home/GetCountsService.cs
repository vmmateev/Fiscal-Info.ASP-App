namespace FiscalInfoApp.Services.Data.Home
{
    using System.Linq;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Company> companiesRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolstationRepository;

        public GetCountsService(
            IDeletableEntityRepository<Company> companiesRepository,
            IDeletableEntityRepository<PetrolStation> petrolstationRepository)
        {
            this.companiesRepository = companiesRepository;
            this.petrolstationRepository = petrolstationRepository;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                CompaniesCount = this.companiesRepository.All().Where(c => c.IsServiceOrganization == false).Count(),
                ServiceOrganization = this.companiesRepository.All().Where(c => c.IsServiceOrganization == true).Count(),
                PetrolStationsCount = this.petrolstationRepository.All().Count(),
            };

            return data;
        }
    }
}
