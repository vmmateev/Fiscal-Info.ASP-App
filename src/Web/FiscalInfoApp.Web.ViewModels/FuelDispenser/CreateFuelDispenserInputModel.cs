namespace FiscalInfoApp.Web.ViewModels.FuelDispenser
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

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
        public string Brand { get; set; }

        [Required]
        [DisplayName("Model")]
        [MinLength(ModelMinLength)]
        public string Model { get; set; }

        [Required]
        [DisplayName("Count of nozzles")]
        [Range(NozzleCountMin, NozzleCountMax)]
        public int NozzleCount { get; set; }

        [Required]
        [DisplayName("MID Certificate")]
        [MinLength(MidCertificateMinLength)]
        public string MidCertificate { get; set; }

        public int PetrolStationId { get; set; }

        // Dropdown for petrolstation
        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }
    }
}
