namespace FiscalInfoApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FiscalInfoApp.Data.Common.Models;

    using static FiscalInfoApp.Common.DataConstants.PetrolStationConstants;

    public class PetrolStation : BaseDeletableModel<int>
    {
        public PetrolStation()
        {
            this.FuelDispensers = new HashSet<FuelDispenser>();
            this.FuelTanks = new HashSet<FuelTank>();
            this.CommControllers = new HashSet<CommController>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [Required]
        [MaxLength(StreetMaxLength)]
        public string Street { get; set; }

        public virtual ICollection<FuelDispenser> FuelDispensers { get; set; }

        public virtual ICollection<FuelTank> FuelTanks { get; set; }

        public virtual ICollection<CommController> CommControllers { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [ForeignKey(nameof(FiscalPrinter))]
        public int FiscalPrinterId { get; set; }

        public virtual FiscalPrinter FiscalPrinter { get; set; }

        [ForeignKey(nameof(OilLevel))]
        public int OilLevelId { get; set; }

        public virtual OilLevel OilLevel { get; set; }
    }
}
