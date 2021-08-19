namespace FiscalInfoApp.Web.ViewModels.FuelTank
{
    using System;
    using System.Collections.Generic;

    using FiscalInfoApp.Web.ViewModels.FuelDispenser;

    public class FuelTankInListViewModel
    {
        public int Id { get; set; }

        public int TankNumber { get; set; }

        public double FullVolume { get; set; }

        public double Diameter { get; set; }

        public string CalibrationDate { get; set; }

        public string FuelType { get; set; }

        public int PetrolStationId { get; set; }

        // Dropdown
        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }

        public string PetrolStationName { get; set; }

        public string PetrolStationCity { get; set; }
    }
}
