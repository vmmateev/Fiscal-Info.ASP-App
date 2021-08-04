namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class SimCard : BaseDeletableModel<int>
    {
        public int Imsi { get; set; }

        public int GsmNumber { get; set; }

        public string OperatorName { get; set; }

        public int FiscalPrinterId { get; set; }

        public FiscalPrinter FiscalPrinter { get; set; }
    }
}
