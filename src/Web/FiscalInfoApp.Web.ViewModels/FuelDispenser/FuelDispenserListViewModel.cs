namespace FiscalInfoApp.Web.ViewModels.FuelDispenser
{
    using System.Collections.Generic;

    public class FuelDispenserListViewModel : PagingViewModel
    {
        public IEnumerable<FuelDispenserInListViewModel> FuelDispensers { get; set; }
    }
}
