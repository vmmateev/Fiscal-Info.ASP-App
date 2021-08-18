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
            this.TempData["Message"] = "Company added successfully.";

            // TODO redirect to Company All page
            return this.Redirect("/Company/All");
        }

        // Companies/All/1 2 3 4
        public IActionResult All(int id = 1)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new CompanyListViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                ItemsCount = this.companyService.GetCompaniesCount(),
                Companies = this.companyService.GetAllCompanies<CompanyInListViewModel>(id, ItemsPerPage), // For IMapper T Template Class viewModel

                // Companies = this.companyService.GetAllCompanies(id, 12),
            };

            return this.View(viewModel);
        }

        public IActionResult Stats(int id = 1)
        {
            if (id < 1)
            {
                return this.NotFound();
            }
            const int ItemsPerPage = 12;

            var viewModel = new CompanyStatsViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                ItemsCount = this.companyService.GetCompaniesCount(),
                Companies = this.companyService.GetAllStatsCompanies(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }
    }
}
