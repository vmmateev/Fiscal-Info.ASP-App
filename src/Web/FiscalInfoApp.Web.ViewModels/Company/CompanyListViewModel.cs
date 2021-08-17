namespace FiscalInfoApp.Web.ViewModels.Company
{
    using System.Collections.Generic;

    using FiscalInfoApp.Web.ViewModels;

    public class CompanyListViewModel : PagingViewModel
    {
        public IEnumerable<CompanyInListViewModel> Companies { get; set; }
    }
}
