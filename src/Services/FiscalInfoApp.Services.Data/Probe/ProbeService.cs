namespace FiscalInfoApp.Services.Data.Probe
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.Probe;
    using Microsoft.EntityFrameworkCore;

    public class ProbeService : IProbeService
    {
        private readonly IDeletableEntityRepository<Probe> probeRepository;
        private readonly IDeletableEntityRepository<OilLevel> oilLevelRepository;

        public ProbeService(
            IDeletableEntityRepository<Probe> probeRepository,
            IDeletableEntityRepository<OilLevel> oilLevelRepository)
        {
            this.probeRepository = probeRepository;
            this.oilLevelRepository = oilLevelRepository;
        }

        public async Task CreateAsync(CreateProbeInputModel input)
        {
            var probe = new Probe
            {
                ProbeLength = input.ProbeLength,
                FloatSize = input.FloatSize,
                FloatFuelType = input.FloatFuelType,
                TankNumber = input.TankNumber,
                OilLevelId = input.OilLevelId,
            };

            await this.probeRepository.AddAsync(probe);
            await this.probeRepository.SaveChangesAsync();
        }

        public IEnumerable<ProbeInListViewModel> GetAllProbes(int page, int itemsPerPage = 12)
        {
            var probes = this.probeRepository.All()
                 .OrderByDescending(x => x.Id)
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .Select(x => new ProbeInListViewModel
                 {
                     Id = x.Id,
                     ProbeLength = x.ProbeLength,
                     FloatSize = x.FloatSize,
                     FloatFuelType = x.FloatFuelType,
                     TankNumber = x.TankNumber,
                     OilLevelId = x.OilLevelId,
                     OilLevelModel = x.OilLevel.Model,
                     PetrolStationId = x.OilLevel.PetrolStationId,
                     PetrolStationName = x.OilLevel.PetrolStation.Name,
                     PetrolStationCity = x.OilLevel.PetrolStation.City,
                     PetrolStationStreet = x.OilLevel.PetrolStation.Street,
                 })
                 .OrderByDescending(x => x.Id)
                 .ToList();

            return probes;
        }

        public int GetAllProbesCount()
        {
            return this.probeRepository.All().Count();
        }

        public IEnumerable<OilLevelViewModelDropDown> GetOilLevelIdName()
        {
            var oilLevels = this.oilLevelRepository.All()
                .Select(x => new OilLevelViewModelDropDown
                {
                    Id = x.Id,
                    Model = x.Model,
                    PetrolStationId = x.PetrolStation.Id,
                    PetrolStationName = x.PetrolStation.Name,
                })
                .ToList();

            return oilLevels;
        }

        public ProbeInListViewModel GetProbeById(int? id)
        {
            var probe = this.probeRepository.All()
                 .Where(x => x.Id == id)
                 .Select(x => new ProbeInListViewModel
                 {
                     Id = x.Id,
                     ProbeLength = x.ProbeLength,
                     FloatSize = x.FloatSize,
                     FloatFuelType = x.FloatFuelType,
                     TankNumber = x.TankNumber,
                     OilLevelId = x.OilLevelId,
                     OilLevelModel = x.OilLevel.Model,
                     PetrolStationId = x.OilLevel.PetrolStationId,
                     PetrolStationName = x.OilLevel.PetrolStation.Name,
                     PetrolStationCity = x.OilLevel.PetrolStation.City,
                     PetrolStationStreet = x.OilLevel.PetrolStation.Street,
                 })
                 .FirstOrDefault();

            return probe;
        }

        public async Task SoftDeleteProbe(int id)
        {
            var probe = await this.probeRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.probeRepository.Delete(probe);

            await this.probeRepository.SaveChangesAsync();
        }
    }
}
