namespace FiscalInfoApp.Web.ViewModels.CommDevice
{
    using System.Collections.Generic;

    public class ComDeviceListViewModel : PagingViewModel
    {
        public IEnumerable<CommDeviceInListViewModel> CommDevices { get; set; }
    }
}
