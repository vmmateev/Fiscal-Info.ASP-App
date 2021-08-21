namespace FiscalInfoApp.Web.ViewModels.CommDevice
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FiscalInfoApp.Web.ViewModels.PetrolStation;

    using static FiscalInfoApp.Common.DataConstants.CommControllerConstants;

    public class CreateCommDeviceInputModel
    {
        [Required]
        [MinLength(CommTypeMinLength)]
        [MaxLength(CommTypeMaxLength)]
        public string CommType { get; set; }

        [Required]
        [MinLength(BoxColorMinLength)]
        [MaxLength(BoxColorMaxLength)]
        public string BoxColour { get; set; }

        public bool IsConcentrator { get; set; }

        public int PetrolStationId { get; set; }

        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }
    }
}
