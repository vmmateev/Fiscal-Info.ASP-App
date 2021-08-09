namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.FiscalPrinterConstants;

    public class FiscalPrinter : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(OsNumberLength)]
        public string OsNumber { get; set; }

        [Required]
        [MaxLength(MemotyNumberLength)]
        public string MemoryNumber { get; set; }

        [MaxLength(FdridLength)]
        public string Fdrid { get; set; }

        public int PetrolStationId { get; set; }

        public virtual PetrolStation PetrolStation { get; set; }

        [ForeignKey(nameof(SimCard))]
        public int SimCardId { get; set; }

        public virtual SimCard SimCard { get; set; }
    }
}
