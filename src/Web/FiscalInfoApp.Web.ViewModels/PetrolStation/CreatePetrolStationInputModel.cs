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
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [Required]
        [MinLength(StreetMinLength)]
        [MaxLength(StreetMaxLength)]
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
        [MaxLength(SimCardConstants.OperatorNameMaxLength)]
        public string OperatoName { get; set; }

        // Oillevel
        [Required]
        [MinLength(OilLevelTypeConstants.BrandMinLength)]
        [MaxLength(OilLevelTypeConstants.BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MinLength(OilLevelTypeConstants.ModelMinLength)]
        [MaxLength(OilLevelTypeConstants.ModelMaxLength)]
        public string Model { get; set; }

        // DropDown Company
        public int CompanyId { get; set; }

        public IEnumerable<KeyValuePair<int, string>> CompaniesItems { get; set; }
    }
}
