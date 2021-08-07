namespace FiscalInfoApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class FuelTank : BaseDeletableModel<int>
    {
        public int TankNumber { get; set; }

        public int FullVolume { get; set; }

        public double Diameter { get; set; }

        public DateTime CalibrationDate { get; set; }

        public string FuelType { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public PetrolStation PetrolStation { get; set; }
    }
}