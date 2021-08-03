namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class FiscalPrinter : BaseDeletableModel<int>
    {
        public string OsNumber { get; set; }

        public string MemoryNumber { get; set; }

        public string Fdrid { get; set; }

        [ForeignKey(nameof(SimCard))]
        public int SimCardId { get; set; }

        public SimCard SimCard { get; set; }
    }
}
