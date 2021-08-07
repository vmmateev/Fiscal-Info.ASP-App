namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }
    }
}
