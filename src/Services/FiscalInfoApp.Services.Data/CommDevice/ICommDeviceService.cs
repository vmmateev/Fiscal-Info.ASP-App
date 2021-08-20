namespace FiscalInfoApp.Services.Data.CommDevice
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using FiscalInfoApp.Web.ViewModels.CommDevice;

    public interface ICommDeviceService
    {
        public int GetAllCommDevicesCount();

        public void SoftDeleteCommDevice(int id);

        public IEnumerable<CommDeviceInListViewModel> GetAllCommDevices(int page, int itemsPerPage);

        public Task CreateCommDeviceAsync(CreateCommDeviceInputModel input);

        public CommDeviceInListViewModel GetCommDeviceById(int? id);
     }
}
