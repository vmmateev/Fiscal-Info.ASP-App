namespace FiscalInfoApp.Web.Controllers
{
    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class FuelTankController : BaseController
    {
        private readonly IDeletableEntityRepository<FuelTank> fuelTanksRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;

        public FuelTankController(
            IDeletableEntityRepository<FuelTank> fuelTanksRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository)
        {
            this.petrolStationRepository = petrolStationRepository;
            this.fuelTanksRepository = fuelTanksRepository;
        }

        [HttpGet] // FuelTanks/All
        public IActionResult All()
        {
            return this.View();
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
