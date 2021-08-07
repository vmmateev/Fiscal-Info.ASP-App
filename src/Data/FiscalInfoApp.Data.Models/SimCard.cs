namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class SimCard : BaseDeletableModel<int>
    {
        public string Imsi { get; set; }

        public string GsmNumber { get; set; }

        public string OperatorName { get; set; }

        public int FiscalPrinterId { get; set; }

        public virtual FiscalPrinter FiscalPrinter { get; set; }
    }
}
