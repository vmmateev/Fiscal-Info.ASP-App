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

        public IEnumerable<FuelTankInListViewModel> GetAllFuelTanks(int page, int itemsPerPage);

        public Task CreateFuelTankAsync(CreateFuelTankInputModel input);

        public FuelTankInListViewModel GetFuelTankById(int? id);

        public Task SoftDeleteFuelTank(int id);
    }
}
