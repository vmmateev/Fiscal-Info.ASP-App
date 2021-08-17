namespace FiscalInfoApp.Web.ViewModels.Company
{
    using System.Collections.Generic;

    using FiscalInfoApp.Web.ViewModels;

    public class CompanyStatsViewModel : PagingViewModel
    {
        public IEnumerable<CompanyInStatsViewModel> Companies { get; set; }
    }
}
