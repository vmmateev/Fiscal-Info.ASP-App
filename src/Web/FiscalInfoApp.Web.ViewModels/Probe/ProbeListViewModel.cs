namespace FiscalInfoApp.Web.ViewModels.Probe
{
    using System.Collections.Generic;

    public class ProbeListViewModel : PagingViewModel
    {
        public IEnumerable<ProbeInListViewModel> Probes { get; set; }
    }
}
