namespace FiscalInfoApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FiscalInfoApp.Services.Data.Company;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Web.ViewModels.Company;
    using FiscalInfoApp.Web.ViewModels.PetrolStation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult All(int id = 1)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new PetrolStationListViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                ItemsCount = this.petrolStationService.GetPetrolStationsCount(),
                PetrolStations = this.petrolStationService.GetAllPetrolStations(id, ItemsPerPage),
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
            this.TempData["Message"] = "Petrol Station added successfully.";
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Stats(int id = 1)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new PetrolStationListViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                ItemsCount = this.petrolStationService.GetPetrolStationsCount(),
                PetrolStations = this.petrolStationService.GetAllPetrolStations(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }
    }
}
