namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Data.CommDevice;
    using FiscalInfoApp.Services.Data.FuelDispenser;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Web.ViewModels.CommDevice;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FiscalInfoApp.Common.MessageConstant;
    using static FiscalInfoApp.Common.PagingConstants;

    public class CommDeviceController : BaseController
    {
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;
        private readonly IDeletableEntityRepository<CommController> commRepository;
        private readonly IPetrolStationService petrolStationService;
        private readonly ICommDeviceService commDeviceService;
        private readonly IFuelDispenserService fuelDispenser;

        public CommDeviceController(
            ICommDeviceService commDeviceService,
            IDeletableEntityRepository<CommController> commRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository,
            IPetrolStationService petrolStationService,
            IFuelDispenserService fuelDispenser)
        {
            this.petrolStationRepository = petrolStationRepository;
            this.petrolStationService = petrolStationService;
            this.commRepository = commRepository;
            this.commDeviceService = commDeviceService;
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

            var viewModel = new ComDeviceListViewModel
            {
                PageNumber = id,
                ItemsPerPage = Items12PerPage,
                ItemsCount = this.commDeviceService.GetAllCommDevicesCount(),
                CommDevices = this.commDeviceService.GetAllCommDevices(id, Items12PerPage),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var input = new CreateCommDeviceInputModel();
            input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();

            return this.View(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommDeviceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();
                return this.View(input);
            }

            await this.commDeviceService.CreateCommDeviceAsync(input);
            this.TempData["Message"] = CommCreationMsg;

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

            var commController = this.commDeviceService.GetCommDeviceById(id);

            if (commController == null)
            {
                return this.NotFound();
            }

            return this.View(commController);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var fuelTank = this.commDeviceService.GetCommDeviceById(id);

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
            await this.commDeviceService.SoftDeleteCommDevice(id);

            this.TempData["Message"] = CommDeletionMsg;

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
