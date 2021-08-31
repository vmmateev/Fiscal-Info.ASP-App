namespace FiscalInfoApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.CompanyConstants;

    public class Company : BaseDeletableModel<int>
    {
        public Company()
        {
            this.PetrolStations = new HashSet<PetrolStation>();
            this.ServiceUsers = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [MaxLength(StreetMaxLength)]
        public string Street { get; set; }

        [DefaultValue(false)]
        public bool IsServiceOrganization { get; set; }

        public virtual ICollection<PetrolStation> PetrolStations { get; set; }

        public virtual ICollection<ApplicationUser> ServiceUsers { get; set; }
    }
}
