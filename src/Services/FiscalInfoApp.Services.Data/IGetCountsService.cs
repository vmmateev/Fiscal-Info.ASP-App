namespace FiscalInfoApp.Services.Data
{
    using FiscalInfoApp.Web.ViewModels.Home;

    public interface IGetCountsService
    {
        IndexViewModel GetCounts();
    }
}
