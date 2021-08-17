namespace FiscalInfoApp.Web.ViewModels.PetrolStation
{
    using System.ComponentModel;

    public class PetrolStationInListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Petrol Station Name")]
        public string Name { get; set; }

        [DisplayName("Petrol Station City")]
        public string City { get; set; }

        [DisplayName("Petrol Station Address")]
        public string Street { get; set; }

        public int CompanyId { get; set; }

        [DisplayName("Petrol Station Company")]
        public string CompanyName { get; set; }
    }
}
