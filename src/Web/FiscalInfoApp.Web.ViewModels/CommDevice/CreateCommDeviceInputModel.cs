namespace FiscalInfoApp.Web.ViewModels.CommDevice
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FiscalInfoApp.Web.ViewModels.FuelDispenser;

    using static FiscalInfoApp.Common.DataConstants.CommControllerConstants;

    public class CreateCommDeviceInputModel
    {
        [Required]
        [MinLength(CommTypeMinLength)]
        public string CommType { get; set; }

        [Required]
        [MinLength(BoxColorMinLength)]
        public string BoxColour { get; set; }

        public bool IsConcentrator { get; set; }

        public int PetrolStationId { get; set; }

        public IEnumerable<PetrolStationViewModelDropDown> PetrolStationItems { get; set; }
    }
}
