namespace FiscalInfoApp.Services.Data.FuelTank
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.FuelTank;

    public interface IFuelTankService
    {
        public int GetAllFuelTanksCount();

        public IEnumerable<FuelTankInListViewModel> GetAllFuelTanks();

        public Task CreateFuelTankAsync(CreateFuelTankInputModel input);

    }
}
