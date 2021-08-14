namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Services.Data.Company;
    using FiscalInfoApp.Web.ViewModels.Company;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCompanyInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.companyService.CreateCompanyAsync(input);

            // TODO redirect to Company All page
            return this.Redirect("/");
        }
    }
}
