namespace FiscalInfoApp.Services.Data.FuelDispenser
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.FuelDispenser;

    public interface IFuelDispenserService
    {
        // for All
        public IEnumerable<FuelDispenserInListViewModel> GetAllFuelDispeners(int page, int itemsPerPage = 12);

        public int GetAllFuelDispensersCount();

        public FuelDispenserInListViewModel GetFuelDispenserById(int? id);

        public Task CreateAsync(CreateFuelDispenserInputModel input);

        Task SoftDeleteFuelDispenserAsync(int id);

        public bool FuelDispenserExists(int id);
    }
}
