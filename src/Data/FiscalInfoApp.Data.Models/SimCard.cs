namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.SimCardConstants;

    public class SimCard : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(SimCardImsiLength)] // 123456789012345
        public string Imsi { get; set; }

        [Required]
        [MaxLength(GsmNumberLength)] // 359123123456
        public string GsmNumber { get; set; }

        [Required]
        [MaxLength(OperatorNameMaxLength)]
        public string OperatorName { get; set; }

        public int FiscalPrinterId { get; set; }

        public virtual FiscalPrinter FiscalPrinter { get; set; }
    }
}
