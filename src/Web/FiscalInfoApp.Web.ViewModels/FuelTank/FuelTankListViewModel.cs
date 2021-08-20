namespace FiscalInfoApp.Web.ViewModels.FuelTank
{
    using System.Collections.Generic;

    public class FuelTankListViewModel : PagingViewModel
    {
        public IEnumerable<FuelTankInListViewModel> FuelTanks { get; set; }
    }
}
