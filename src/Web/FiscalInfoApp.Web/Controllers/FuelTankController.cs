namespace FiscalInfoApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Data.FuelDispenser;
    using FiscalInfoApp.Services.Data.FuelTank;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Web.ViewModels.FuelTank;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FiscalInfoApp.Common.MessageConstant;
    using static FiscalInfoApp.Common.PagingConstants;

    public class FuelTankController : BaseController
    {
        private readonly IDeletableEntityRepository<FuelTank> fuelTanksRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;
        private readonly IFuelTankService fuelTankService;
        private readonly IPetrolStationService petrolStationService;
        private readonly IFuelDispenserService fuelDispenser;

        public FuelTankController(
            IDeletableEntityRepository<FuelTank> fuelTanksRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository,
            IFuelTankService fuelTankService,
            IPetrolStationService petrolStationService,
            IFuelDispenserService fuelDispenser)
        {
            this.fuelTanksRepository = fuelTanksRepository;
            this.petrolStationRepository = petrolStationRepository;
            this.fuelTankService = fuelTankService;
            this.petrolStationService = petrolStationService;
            this.fuelDispenser = fuelDispenser;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All(int id = StartingPage)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            var viewModel = new FuelTankListViewModel
            {
                PageNumber = id,
                ItemsPerPage = Items12PerPage,
                ItemsCount = this.fuelTankService.GetAllFuelTanksCount(),
                FuelTanks = this.fuelTankService.GetAllFuelTanks(id, Items12PerPage),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var input = new CreateFuelTankInputModel();
            input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();
            input.CalibrationDate = DateTime.UtcNow;

            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateFuelTankInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();
                return this.View(input);
            }

            await this.fuelTankService.CreateFuelTankAsync(input);
            this.TempData["Message"] = FuelTankCreateMsg;

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var fuelTank = this.fuelTankService.GetFuelTankById(id);

            if (fuelTank == null)
            {
                return this.NotFound();
            }

            return this.View(fuelTank);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var fuelTank = this.fuelTankService.GetFuelTankById(id);

            if (fuelTank == null)
            {
                return this.NotFound();
            }

            return this.View(fuelTank);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.fuelTankService.SoftDeleteFuelTank(id);

            this.TempData["Message"] = FuelTankDeletionMsg;

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
