namespace FiscalInfoApp.Web.ViewModels.FuelDispenser
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using FiscalInfoApp.Web.ViewModels.PetrolStation;

    using static FiscalInfoApp.Common.DataConstants.FuelDispenserConstants;

    public class CreateFuelDispenserInputModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Dispenser Number")]
        [Range(FuelDispenserNumberMin, FuelDispenserNumberMax)]
        public int DispenserNumber { get; set; }

        [Required]
        [DisplayName("Brand")]
        [MinLength(BrandMinLength)]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [DisplayName("Model")]
        [MinLength(ModelMinLength)]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [DisplayName("Count of nozzles")]
        [Range(NozzleCountMin, NozzleCountMax)]
        public int NozzleCount { get; set; }

        [Required]
        [DisplayName("MID Certificate")]
        [MinLength(MidCertificateMinLength)]
        [MaxLength(MidCertificateMaxLength)]
        public string MidCertificate { get; set; }

        public int PetrolStationId { get; set; }

        // Dropdown for Petrolstation Items
        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }
    }
}
