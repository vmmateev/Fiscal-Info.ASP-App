namespace FiscalInfoApp.Services.Data.Company
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task CreateCompanyAsync(CreateCompanyInputModel input);

    }
}
