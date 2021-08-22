namespace FiscalInfoApp.Web.ViewModels.Probe
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProbeInListViewModel
    {
        public int Id { get; set; }

        public double ProbeLength { get; set; }

        public int FloatSize { get; set; }

        public string FloatFuelType { get; set; }

        public int TankNumber { get; set; }

        public int OilLevelId { get; set; }

        public string OilLevelModel { get; set; }

        public int PetrolStationId { get; set; }

        public string PetrolStationName { get; set; }

        public string PetrolStationCity { get; set; }

        public string PetrolStationStreet { get; set; }
    }
}
