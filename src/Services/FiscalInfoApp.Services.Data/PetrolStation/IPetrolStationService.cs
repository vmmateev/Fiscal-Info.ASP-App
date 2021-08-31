namespace FiscalInfoApp.Services.Data.PetrolStation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.PetrolStation;

    public interface IPetrolStationService
    {
        Task CreatePetrolStationAsync(CreatePetrolStationInputModel input);

        int GetPetrolStationsCount();

        IEnumerable<PetrolStationInListViewModel> GetAllPetrolStations(int page, int itemsPerPage = 12);

        public IEnumerable<PetrolStationViewModelDropDown> GetPetrolStationsIdName();

        public PetrolStationInListViewModel GetPetrolStationById(int? id);
    }
}
