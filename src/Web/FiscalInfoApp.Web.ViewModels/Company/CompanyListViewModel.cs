namespace FiscalInfoApp.Web.ViewModels.Company
{
    using System.Collections.Generic;

    public class CompanyListViewModel : PagingViewModel
    {
        public IEnumerable<CompanyInListViewModel> Companies { get; set; }
    }
}
