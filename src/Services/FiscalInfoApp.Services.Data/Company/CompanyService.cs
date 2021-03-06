namespace FiscalInfoApp.Services.Data.Company
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Mapping;
    using FiscalInfoApp.Web.ViewModels.Company;

    public class CompanyService : ICompanyService
    {
        private readonly IDeletableEntityRepository<Company> companyRepository;

        public CompanyService(IDeletableEntityRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task CreateCompanyAsync(CreateCompanyInputModel input)
        {
            var company = new Company
            {
                Name = input.Name,
                City = input.City,
                Street = input.Street,
                IsServiceOrganization = input.IsServiceOrganization,
            };

            await this.companyRepository.AddAsync(company);
            await this.companyRepository.SaveChangesAsync();
        }

        // public IEnumerable<CompanyInListViewModel> GetAllCompanies(int page, int itemsPerPage = 12)
        public IEnumerable<T> GetAllCompanies<T>(int page, int itemsPerPage = 12)
        {
            // 1-12 - page1 - skip 0 (page-1) * itemsPerPage = 0-1 * 12 = 0
            // 13-24 - page 2 - skip 12 (page-1) * itemsPerPage = 0-1 * 12 = 0
            // 25-36 - page 3 - skip 24
            var companies = this.companyRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)

                // .Select(x => new CompanyInListViewModel
                // {
                //    Id = x.Id,
                //    Name = x.Name,
                //    City = x.City,
                //    Street = x.Street,
                //    IsServiceOrganization = x.IsServiceOrganization.ToString().ToLower() == "true" ? "Yes" : "No",
                //    PetrolStationsCount = x.PetrolStations.Count(),
                // })
                .OrderByDescending(x => x.Id)
                .To<T>()

                // .To<CompanyInListViewModel>()
                .ToList();

            return companies;
        }

        public int GetCompaniesCount()
        {
            var companiesCount = this.companyRepository.All().Count();

            return companiesCount;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllCompaniesAsKeyValuePairs()
        {
            return this.companyRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name));
        }

        public IEnumerable<CompanyInStatsViewModel> GetAllStatsCompanies(int page, int itemPerPage = 12)
        {
            var companyCollection = this.companyRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemPerPage)
                .Take(itemPerPage)
                .Select(company => new CompanyInStatsViewModel
                {
                    CompanyId = company.Id,
                    CompanyName = company.Name,
                    PetrolStationsCount = company.PetrolStations.Count(),
                    ProbesCount = company.PetrolStations.SelectMany(x => x.OilLevel.Probes).Count(),
                    CommControllersCount = company.PetrolStations.SelectMany(x => x.CommControllers).Count(),
                    FuelDispensersCount = company.PetrolStations.SelectMany(x => x.FuelDispensers).Count(),
                })
                .ToList();

            return companyCollection;
        }
    }
}
