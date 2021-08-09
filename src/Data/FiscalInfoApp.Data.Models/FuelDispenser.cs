namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.FuelDispenserConstants;

    public class FuelDispenser : BaseDeletableModel<int>
    {
        [Range(FuelDispenserNumberMin,FuelDispenserNumberMax)]
        public int DispenserNumber { get; set; }

        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        [Range(NozzleCountMin,NozzleCountMax)]
        public int NozzleCount { get; set; }

        [MaxLength(MidCertificateMaxLength)]
        public string MidCertificate { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }
    }
}
