namespace FiscalInfoApp.Services.Data.Probe
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.Probe;

    public interface IProbeService
    {
        public IEnumerable<ProbeInListViewModel> GetAllProbes(int page, int itemsPerPage = 12);

        public int GetAllProbesCount();

        public ProbeInListViewModel GetProbeById(int? id);

        public Task CreateAsync(CreateProbeInputModel input);

        public IEnumerable<OilLevelViewModelDropDown> GetOilLevelIdName();

        Task SoftDeleteProbe(int id);
    }
}
