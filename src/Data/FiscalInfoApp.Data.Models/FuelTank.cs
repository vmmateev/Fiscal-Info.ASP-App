namespace FiscalInfoApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.FuelTankConstants;

    public class FuelTank : BaseDeletableModel<int>
    {
        [Required]
        [Range(TankMinNumber,TankMaxNumber)]
        public int TankNumber { get; set; }

        [Required]
        [Range(FullVolumeMin,FullVolumeMax)]
        public double FullVolume { get; set; }

        [Required]
        [Range(DiameterMinCm, DiameterMaxCm)]
        public double Diameter { get; set; }

        [Required]
        public DateTime CalibrationDate { get; set; }

        [Required]
        [MaxLength(FuelTypeMaxLength)]
        public string FuelType { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }
    }
}
