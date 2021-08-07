namespace FiscalInfoApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class OilLevel : BaseDeletableModel<int>
    {
        public OilLevel()
        {
            this.Probes = new HashSet<Probe>();
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public virtual ICollection<Probe> Probes { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public PetrolStation PetrolStation { get; set; }
    }
}
