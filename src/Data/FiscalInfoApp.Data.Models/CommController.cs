namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class CommController : BaseDeletableModel<int>
    {
        public string CommType { get; set; }

        public string BoxColor { get; set; }

        public bool IsConcentrator { get; set; }

        [ForeignKey(nameof(PetrolStation))]
        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }
    }
}
