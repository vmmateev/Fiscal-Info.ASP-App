namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class FuelDispenser : BaseDeletableModel<int>
    {
        public int DispenserNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int NozzleCount { get; set; }

        public string MidCertificate { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }
    }
}
