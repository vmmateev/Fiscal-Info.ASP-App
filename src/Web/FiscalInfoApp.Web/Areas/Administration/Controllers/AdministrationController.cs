namespace FiscalInfoApp.Web.Areas.Administration.Controllers
{
    using FiscalInfoApp.Common;
    using FiscalInfoApp.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
