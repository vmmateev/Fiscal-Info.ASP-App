namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Services.Data.Company;
    using FiscalInfoApp.Web.ViewModels.Company;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FiscalInfoApp.Common.MessageConstant;
    using static FiscalInfoApp.Common.PagingConstants;

    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
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
            this.TempData["Message"] = CompanyCreateMsg;

            return this.Redirect("/Company/All");
        }

        [HttpGet]
        [Authorize]
        public IActionResult All(int id = StartingPage)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            var viewModel = new CompanyListViewModel
            {
                PageNumber = id,
                ItemsPerPage = Items12PerPage,
                ItemsCount = this.companyService.GetCompaniesCount(),
                Companies = this.companyService.GetAllCompanies<CompanyInListViewModel>(id, Items12PerPage), // For IMapper T Template Class viewModel

                // Companies = this.companyService.GetAllCompanies(id, 12),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Stats(int id = StartingPage)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            var viewModel = new CompanyStatsViewModel
            {
                PageNumber = id,
                ItemsPerPage = Items12PerPage,
                ItemsCount = this.companyService.GetCompaniesCount(),
                Companies = this.companyService.GetAllStatsCompanies(id, Items12PerPage),
            };

            return this.View(viewModel);
        }
    }
}
