namespace FiscalInfoApp.Web.ViewModels.PetrolStation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        
        public int CompanyId { get; set; }

        public IEnumerable<KeyValuePair<int, string>> CompaniesItems { get; set; }
    }
}
