namespace FiscalInfoApp.Web.ViewModels.Probe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using FiscalInfoApp.Web.ViewModels.PetrolStation;

    using static FiscalInfoApp.Common.DataConstants.FuelTankConstants;
    using static FiscalInfoApp.Common.DataConstants.ProbeConstants;

    public class CreateProbeInputModel

    {
        [Required]
        [DisplayName("Probe Length in [m]")]
        [Range(ProbeMinLengthMeters, ProbeMaxLengthMeters)]
        public double ProbeLength { get; set; }

        [Required]
        [DisplayName("Float Size in [mm]")]
        [Range(FloatSizeMinMm, FloatSizeMaxMm)]
        public int FloatSize { get; set; }

        [Required]
        [DisplayName("Float Fuel Type")]
        [MinLength(FloatFuelTypeMinLength)]
        [MaxLength(FloatFuelTypeMaxLength)]
        public string FloatFuelType { get; set; }

        [Required]
        [DisplayName("Tank number")]
        [Range(TankMinNumber, TankMaxNumber)]
        public int TankNumber { get; set; }

        // static show OilLevel
        public int OilLevelId { get; set; }

        public string OilLevelModel { get; set; }

        public IEnumerable<OilLevelViewModelDropDown> OilLevelItems { get; set; }

        // DropDown petrolstation
        public int PetrolStationId { get; set; }

        public string PetrolStationName { get; set; }

        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }
    }
}
