namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Data.FuelTank;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Services.Data.FuelDispenser;
    using FiscalInfoApp.Web.ViewModels.FuelTank;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpGet] // FuelTanks/All
        public IActionResult All(int id = 1)
        {
            if (id < 1)
            {
                return this.NotFound();
            }
            const int ItemsPerPage = 6;
            var viewModel = new FuelTankListViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                ItemsCount = this.fuelTankService.GetAllFuelTanksCount(),
                FuelTanks = this.fuelTankService.GetAllFuelTanks(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var input = new CreateFuelTankInputModel();
            input.PetrolStationItems = this.fuelDispenser.GetPetrolStationsIdName();

            return this.View(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFuelTankInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.PetrolStationItems = this.fuelDispenser.GetPetrolStationsIdName();
                return this.View(input);
            }

            await this.fuelTankService.CreateFuelTankAsync(input);
            this.TempData["Message"] = "Fuel Tank created successfully.";

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            // Todo : details view of FuelTank
            return this.View();
        }
    }
}
