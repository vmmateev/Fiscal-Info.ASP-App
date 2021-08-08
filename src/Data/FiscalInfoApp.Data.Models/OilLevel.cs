namespace FiscalInfoApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.OilLevelTypeConstants;

    public class OilLevel : BaseDeletableModel<int>
    {
        public OilLevel()
        {
            this.Probes = new HashSet<Probe>();
        }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        public virtual ICollection<Probe> Probes { get; set; }

        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }
    }
}
