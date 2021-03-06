namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Data.FuelDispenser;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Web.ViewModels.FuelDispenser;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FiscalInfoApp.Common.MessageConstant;
    using static FiscalInfoApp.Common.PagingConstants;

    public class FuelDispenserController : BaseController
    {
        private readonly IFuelDispenserService fuelDispenserService;
        private readonly IPetrolStationService petrolStationService;
        private readonly IDeletableEntityRepository<FuelDispenser> fuelDispenserRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;

        public FuelDispenserController(
            IPetrolStationService petrolStationService,
            IFuelDispenserService fuelDispenserService,
            IDeletableEntityRepository<FuelDispenser> fuelDispenserRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository)
        {
            this.fuelDispenserService = fuelDispenserService;
            this.fuelDispenserRepository = fuelDispenserRepository;
            this.petrolStationRepository = petrolStationRepository;
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

            var viewModel = new FuelDispenserListViewModel
            {
                PageNumber = id,
                ItemsPerPage = Items12PerPage,
                ItemsCount = this.fuelDispenserService.GetAllFuelDispensersCount(),
                FuelDispensers = this.fuelDispenserService.GetAllFuelDispeners(id, Items12PerPage),
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

            var fuelDispenser = this.fuelDispenserService.GetFuelDispenserById(id);

            if (fuelDispenser == null)
            {
                return this.NotFound();
            }

            return this.View(fuelDispenser);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var input = new CreateFuelDispenserInputModel();
            input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();

            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateFuelDispenserInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();
                return this.View(input);
            }

            await this.fuelDispenserService.CreateAsync(input);
            this.TempData["Message"] = FuelDispenserCreateMsg;

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var fuelDispenser = this.fuelDispenserService.GetFuelDispenserById(id);

            if (fuelDispenser == null)
            {
                return this.NotFound();
            }

            return this.View(fuelDispenser);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.fuelDispenserService.SoftDeleteFuelDispenserAsync(id);

            this.TempData["Message"] = FuelDispenserDeletionMsg;

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
