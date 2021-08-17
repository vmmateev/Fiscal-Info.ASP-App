﻿namespace FiscalInfoApp.Services.Data.PetrolStation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Web.ViewModels.PetrolStation;

    public class PetrolStationService : IPetrolStationService
    {
        private readonly IDeletableEntityRepository<PetrolStation> petrolStationRepository;
        private readonly IDeletableEntityRepository<SimCard> simCardRepository;
        private readonly IDeletableEntityRepository<FiscalPrinter> fiscalPrinterRepository;
        private readonly IDeletableEntityRepository<OilLevel> oilLevelRepository;
        private readonly IDeletableEntityRepository<Company> companyRepository;

        public PetrolStationService(
            IDeletableEntityRepository<PetrolStation> petrolStationRepository,
            IDeletableEntityRepository<SimCard> simCardRepository,
            IDeletableEntityRepository<FiscalPrinter> fiscalPrinterRepository,
            IDeletableEntityRepository<OilLevel> oilLevelRepository,
            IDeletableEntityRepository<Company> companyRepository)
        {
            this.petrolStationRepository = petrolStationRepository;
            this.simCardRepository = simCardRepository;
            this.fiscalPrinterRepository = fiscalPrinterRepository;
            this.oilLevelRepository = oilLevelRepository;
            this.companyRepository = companyRepository;
        }

        public async Task CreatePetrolStationAsync(CreatePetrolStationInputModel input)
        {
            var simCard = new SimCard
            {
                Imsi = input.Imsi,
                GsmNumber = input.GsmNumber,
                OperatorName = input.OperatoName,
            };
            await this.simCardRepository.AddAsync(simCard);
            await this.simCardRepository.SaveChangesAsync();

            var fiscalPrinter = new FiscalPrinter
            {
                OsNumber = input.OsNumber,
                MemoryNumber = input.MemoryNumber,
                Fdrid = input.Fdrid,
                SimCardId = simCard.Id,
            };
            await this.fiscalPrinterRepository.AddAsync(fiscalPrinter);
            await this.fiscalPrinterRepository.SaveChangesAsync();

            var oilLevel = new OilLevel
            {
                Brand = input.Brand,
                Model = input.Model,
            };
            await this.oilLevelRepository.AddAsync(oilLevel);
            await this.oilLevelRepository.SaveChangesAsync();

            var petrolStation = new PetrolStation
            {
                Name = input.Name,
                City = input.City,
                Street = input.Street,
                CompanyId = input.CompanyId,
                FiscalPrinterId = fiscalPrinter.Id,
                OilLevelId = oilLevel.Id,
            };

            await this.petrolStationRepository.AddAsync(petrolStation);
            await this.petrolStationRepository.SaveChangesAsync();

            simCard.FiscalPrinterId = fiscalPrinter.Id;
            fiscalPrinter.PetrolStationId = petrolStation.Id;
            oilLevel.PetrolStationId = petrolStation.Id;

            // The link id-s are null 
            await this.fiscalPrinterRepository.SaveChangesAsync();
            await this.simCardRepository.SaveChangesAsync();
            await this.oilLevelRepository.SaveChangesAsync();
        }

        public IEnumerable<PetrolStationInListViewModel> GetAllPetrolStations(int page, int itemsPerPage = 12)
        {
            var petrolStations = this.petrolStationRepository.AllAsNoTracking()
               .OrderByDescending(x => x.Id)
               .Skip((page - 1) * itemsPerPage)
               .Take(itemsPerPage)
               .Select(x => new PetrolStationInListViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   City = x.City,
                   Street = x.Street,
                   CompanyId = x.CompanyId,
                   CompanyName = x.Company.Name,
               })
               .OrderBy(x => x.CompanyName)
            .ToList();

            return petrolStations;
        }

        public int GetPetrolStationsCount()
        {
            var petrolStationsCount = this.petrolStationRepository.All().Count();

            return petrolStationsCount;
        }
    }
}