namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Services.Data.Company;
    using FiscalInfoApp.Web.ViewModels.Company;
    using Microsoft.AspNetCore.Mvc;

    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.companyService.CreateAsync(input);

            // TODO redirect to Company All page
            return this.Redirect("/");
        }
    }
}
