namespace FiscalInfoApp.Web.ViewModels.FuelTank
{
    using System.Collections.Generic;

    public class FuelTankListViewModel
    {
        public IEnumerable<FuelTankInListViewModel> FuelTanks { get; set; }
    }
}
