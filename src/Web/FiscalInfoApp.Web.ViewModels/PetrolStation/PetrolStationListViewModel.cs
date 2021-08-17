namespace FiscalInfoApp.Web.ViewModels.PetrolStation
{
    using System.Collections.Generic;

    using FiscalInfoApp.Web.ViewModels;

    public class PetrolStationListViewModel : PagingViewModel
    {
        public IEnumerable<PetrolStationInListViewModel> PetrolStations { get; set; }
    }
}
