namespace FiscalInfoApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class Probe : BaseDeletableModel<int>
    {
        public double ProbeLength { get; set; }

        public int FloatSize { get; set; }

        public string FloatFuelType { get; set; }

        [ForeignKey(nameof(OilLevel))]
        public int OilLevelId { get; set; }

        public virtual OilLevel OilLevel { get; set; }
    }
}
