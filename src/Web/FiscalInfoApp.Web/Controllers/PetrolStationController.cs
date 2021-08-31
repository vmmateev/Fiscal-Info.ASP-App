namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Services.Data.Company;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Web.ViewModels.PetrolStation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FiscalInfoApp.Common.MessageConstant;
    using static FiscalInfoApp.Common.PagingConstants;

    public class PetrolStationController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly IPetrolStationService petrolStationService;

        public PetrolStationController(
            ICompanyService companyService,
            IPetrolStationService petrolStationService)
        {
            this.companyService = companyService;
            this.petrolStationService = petrolStationService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All(int id = StartingPage)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            var viewModel = new PetrolStationListViewModel
            {
                PageNumber = id,
                ItemsPerPage = Items12PerPage,
                ItemsCount = this.petrolStationService.GetPetrolStationsCount(),
                PetrolStations = this.petrolStationService.GetAllPetrolStations(id, Items12PerPage),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePetrolStationInputModel();
            viewModel.CompaniesItems = this.companyService.GetAllCompaniesAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePetrolStationInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CompaniesItems = this.companyService.GetAllCompaniesAsKeyValuePairs(); // dropdown menu company
                return this.View(input);
            }

            await this.petrolStationService.CreatePetrolStationAsync(input);
            this.TempData["Message"] = PetrolStationCreateMsg;

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Stats(int id = StartingPage)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            var viewModel = new PetrolStationListViewModel
            {
                PageNumber = id,
                ItemsPerPage = Items12PerPage,
                ItemsCount = this.petrolStationService.GetPetrolStationsCount(),
                PetrolStations = this.petrolStationService.GetAllPetrolStations(id, Items12PerPage),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var petrolStation = this.petrolStationService.GetPetrolStationById(id);

            if (petrolStation == null)
            {
                return this.NotFound();
            }

            return this.View(petrolStation);
        }
    }
}
