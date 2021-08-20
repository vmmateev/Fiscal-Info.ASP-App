using System.Collections.Generic;

namespace FiscalInfoApp.Web.ViewModels.CommDevice
{
    public class ComDeviceListViewModel : PagingViewModel
    {
        public IEnumerable<CommDeviceInListViewModel> CommDevices { get; set; }
    }
}
