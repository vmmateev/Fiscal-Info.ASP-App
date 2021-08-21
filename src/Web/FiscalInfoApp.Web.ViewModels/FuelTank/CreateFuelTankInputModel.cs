namespace FiscalInfoApp.Web.ViewModels.FuelTank
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FiscalInfoApp.Web.ViewModels.PetrolStation;

    using static FiscalInfoApp.Common.DataConstants.FuelTankConstants;

    public class CreateFuelTankInputModel
    {
        [Required]
        [Range(TankMinNumber, TankMaxNumber)]
        public int TankNumber { get; set; }

        [Required]
        [Range(FullVolumeMin, FullVolumeMax)]
        public double FullVolume { get; set; }

        [Required]
        [Range(DiameterMinMm, DiameterMaxMm)]
        public double Diameter { get; set; }

        [Required]
        public DateTime CalibrationDate { get; set; }

        [Required]
        [MinLength(FuelTypeMinLength)]
        [MaxLength(FuelTypeMaxLength)]
        public string FuelType { get; set; }

        public int PetrolStationId { get; set; }

        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }
    }
}
