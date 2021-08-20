namespace FiscalInfoApp.Web.Controllers
{
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Data.FuelTank;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Web.ViewModels.FuelTank;
    using Microsoft.AspNetCore.Mvc;

    using static FiscalInfoApp.Common.PagingConstants;

    public class FuelTankController : BaseController
    {
        private readonly IDeletableEntityRepository<FuelTank> fuelTanksRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;
        private readonly IFuelTankService fuelTankService;
        private readonly IPetrolStationService petrolStationService;

        public FuelTankController(
            IDeletableEntityRepository<FuelTank> fuelTanksRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository,
            IFuelTankService fuelTankService,
            IPetrolStationService petrolStationService)
        {
            this.petrolStationRepository = petrolStationRepository;
            this.fuelTankService = fuelTankService;
            this.petrolStationService = petrolStationService;
            this.fuelTanksRepository = fuelTanksRepository;
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
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    return this.View();
        //}

    }
}
