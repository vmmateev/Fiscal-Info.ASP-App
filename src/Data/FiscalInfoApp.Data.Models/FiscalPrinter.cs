namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class FiscalPrinter : BaseDeletableModel<int>
    {
        public string OsNumber { get; set; }

        public string MemoryNumber { get; set; }

        public string Fdrid { get; set; }

        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }

        [ForeignKey(nameof(SimCard))]
        public int SimCardId { get; set; }

        public virtual SimCard SimCard { get; set; }
    }
}
