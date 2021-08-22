namespace FiscalInfoApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Data.PetrolStation;
    using FiscalInfoApp.Services.Data.Probe;
    using FiscalInfoApp.Web.ViewModels.Probe;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProbeController : BaseController
    {
        private readonly IDeletableEntityRepository<Probe> probeRepository;
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;
        private readonly IProbeService probeService;
        private readonly IPetrolStationService petrolStationService;

        public ProbeController(
            IDeletableEntityRepository<Probe> probeRepository,
            IDeletableEntityRepository<PetrolStation> petrolStationRepository,
            IProbeService probeService,
            IPetrolStationService petrolStationService)
        {
            this.probeRepository = probeRepository;
            this.petrolStationRepository = petrolStationRepository;
            this.probeService = probeService;
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

            var viewModel = new ProbeListViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                ItemsCount = this.probeService.GetAllProbesCount(),
                Probes = this.probeService.GetAllProbes(id, ItemsPerPage),
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

            var probe = this.probeService.GetProbeById(id);

            if (probe == null)
            {
                return this.NotFound();
            }

            return this.View(probe);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var input = new CreateProbeInputModel();

            input.OilLevelItems = this.probeService.GetOilLevelIdName();
            input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();

            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateProbeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.OilLevelItems = this.probeService.GetOilLevelIdName();
                input.PetrolStationItems = this.petrolStationService.GetPetrolStationsIdName();

                return this.View(input);
            }

            await this.probeService.CreateAsync(input);
            this.TempData["Message"] = "Probe created successfully.";

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

            var probe = this.probeService.GetProbeById(id);

            if (probe == null)
            {
                return this.NotFound();
            }

            return this.View(probe);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.probeService.SoftDeleteProbe(id);

            this.TempData["Message"] = "Probe deleted successfully.";

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
