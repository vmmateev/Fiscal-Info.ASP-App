namespace FiscalInfoApp.Services.Data.Company
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task CreateCompanyAsync(CreateCompanyInputModel input);

        IEnumerable<T> GetAllCompanies<T>(int page, int itemsPerPage = 12); // IEnumerable<CompanyInListViewModel> GetAllCompanies(int page, int itemsPerPage = 12);

        int GetCompaniesCount();

        IEnumerable<KeyValuePair<int, string>> GetAllCompaniesAsKeyValuePairs(); // Визуализация на списък с фирмите при създаване на бензиностанция

        IEnumerable<CompanyInStatsViewModel> GetAllStatsCompanies(int page, int itemsPerPage = 12);
    }
}
