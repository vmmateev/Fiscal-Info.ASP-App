namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.ProbeConstants;

    public class Probe : BaseDeletableModel<int>
    {
        [Required]
        [Range(ProbeMinLengthMeters, ProbeMaxLengthMeters)]
        public double ProbeLength { get; set; }

        [Required]
        [Range(FloatSizeMinMm, FloatSizeMaxMm)]
        public int FloatSize { get; set; }

        [Required]
        [MaxLength(FloatFuelTypeMaxLength)]
        public string FloatFuelType { get; set; }

        [Required]
        public int TankNumber { get; set; }

        [ForeignKey(nameof(OilLevel))]
        public int OilLevelId { get; set; }

        public virtual OilLevel OilLevel { get; set; }
    }
}
