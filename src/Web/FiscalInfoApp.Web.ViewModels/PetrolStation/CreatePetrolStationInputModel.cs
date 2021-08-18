namespace FiscalInfoApp.Web.ViewModels.PetrolStation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static FiscalInfoApp.Common.DataConstants;
    using static FiscalInfoApp.Common.DataConstants.PetrolStationConstants;

    public class CreatePetrolStationInputModel
    {
        [Required]
        [MinLength(NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(CityMinLength)]
        public string City { get; set; }

        [Required]
        [MinLength(StreetMinLength)]
        public string Street { get; set; }

        // Fiscal Printer
        [Required]
        [StringLength(FiscalPrinterConstants.OsNumberLength)]
        public string OsNumber { get; set; }

        [Required]
        [StringLength(FiscalPrinterConstants.MemotyNumberLength)]
        public string MemoryNumber { get; set; }

        [Required]
        [StringLength(FiscalPrinterConstants.FdridLength)]
        public string Fdrid { get; set; }

        // Simcard
        [Required]
        [StringLength(SimCardConstants.SimCardImsiLength)]
        public string Imsi { get; set; }

        [Required]
        [StringLength(SimCardConstants.GsmNumberLength)]
        public string GsmNumber { get; set; }

        [Required]
        [MinLength(SimCardConstants.OperatorNameMinLength)]
        public string OperatoName { get; set; }

        // Oillevel
        [Required]
        [MinLength(OilLevelTypeConstants.BrandMinLength)]
        public string Brand { get; set; }

        [Required]
        [MinLength(OilLevelTypeConstants.ModelMinLength)]
        public string Model { get; set; }

        // DropDown Company
        public int CompanyId { get; set; }

        public IEnumerable<KeyValuePair<int, string>> CompaniesItems { get; set; }
    }
}
