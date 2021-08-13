namespace FiscalInfoApp.Web.ViewModels.Company
{
    using System.ComponentModel.DataAnnotations;
    using static FiscalInfoApp.Common.DataConstants.CompanyConstants;

    public class CreateCompanyInputModel
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

        public bool IsServiceOrganization { get; set; }
    }
}
