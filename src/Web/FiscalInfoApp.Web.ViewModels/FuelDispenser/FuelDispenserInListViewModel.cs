namespace FiscalInfoApp.Web.ViewModels.FuelDispenser
{
    using System.ComponentModel;

    public class FuelDispenserInListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Dispenser Number")]
        public int DispenserNumber { get; set; }

        [DisplayName("Brand")]
        public string Brand { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }

        [DisplayName("Count of nozzles")]
        public int NozzleCount { get; set; }

        [DisplayName("MID Certificate")]
        public string MidCertificate { get; set; }

        public int PetrolStationId { get; set; }

        [DisplayName("Petrol Station City")]
        public string PetrolStationCity { get; set; }
    }
}
