namespace FiscalInfoApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    public class PetrolStation : BaseDeletableModel<int>
    {
       // public PetrolStation()
       // {
       //     this.Dispensers = new HashSet<Dispenser>();
       //     this.Tanks = new HashSet<Tank>();
       //     this.Controllers = new HashSet<Controller>();
       //     this.Comments = new HashSet<Comment>();
       // }

        public string Name { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [ForeignKey(nameof(FiscalPrinter))]
        public int FiscalPrinterId { get; set; }

        public virtual FiscalPrinter FiscalPrinter { get; set; }

        public virtual ICollection<Tank> Tanks { get; set; }

        ////TODO implement this table with the other entities if there is enough time later
        //public virtual ICollection<Dispenser> Dispensers { get; set; }

        //public virtual ICollection<Controller> Controllers { get; set; }

        //public int OilLevelId { get; set; }

        //public virtual OilLevel OilLevel { get; set; }

        //public virtual ICollection<Comment> Comments { get; set; }
    }
}
