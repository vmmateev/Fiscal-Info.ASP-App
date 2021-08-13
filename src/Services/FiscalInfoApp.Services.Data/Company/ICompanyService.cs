namespace FiscalInfoApp.Services.Data.Company
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task CreateAsync(CreateCompanyInputModel input);
    }
}
