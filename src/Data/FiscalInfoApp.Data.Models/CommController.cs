namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.CommControllerConstants;

    public class CommController : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CommTypeMaxLength)]
        public string CommType { get; set; }

        [Required]
        [MaxLength(BoxColorMaxLength)]
        public string BoxColor { get; set; }

        [DefaultValue(false)]
        public bool IsConcentrator { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }
    }
}
