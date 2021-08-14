namespace FiscalInfoApp.Services.Data.Company
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
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
    }
}
