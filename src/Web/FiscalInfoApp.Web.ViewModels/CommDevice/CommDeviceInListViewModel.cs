namespace FiscalInfoApp.Web.ViewModels.CommDevice
{
    using System.Collections.Generic;

    using FiscalInfoApp.Web.ViewModels.FuelDispenser;

    public class CommDeviceInListViewModel
    {
        public int Id { get; set; }

        public string CommType { get; set; }

        public string BoxColour { get; set; }

        public string IsConcentrator { get; set; }

        public int PetrolStationId { get; set; }

        // dropdown
        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }

        public string PetrolStationName { get; set; }

        public string PetrolStationCity { get; set; }
    }
}
