namespace FiscalInfoApp.Web.ViewModels.PetrolStation
{
    using System.Collections.Generic;
 
    using FiscalInfoApp.Web.ViewModels.Probe;

    public class PetrolStationViewModelDropDown
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OilLevelId { get; set; }

        public string OilLevelModel { get; set; }
    }
}
