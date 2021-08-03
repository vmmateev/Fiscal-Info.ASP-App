namespace FiscalInfoApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class Company : BaseModel<int>
    {
        public Company()
        {
            this.PetrolStations = new HashSet<PetrolStation>();
            this.ServiceUsers = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public virtual ICollection<PetrolStation> PetrolStations { get; set; }

        [DefaultValue(false)]
        public bool IsServiceOrganization { get; set; }

        public ICollection<ApplicationUser> ServiceUsers { get; set; }
    }
}
