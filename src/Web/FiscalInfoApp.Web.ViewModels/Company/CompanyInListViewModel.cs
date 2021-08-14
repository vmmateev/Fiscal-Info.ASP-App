namespace FiscalInfoApp.Web.ViewModels.Company
{
    using System.ComponentModel;

    using AutoMapper;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Services.Mapping;

    public class CompanyInListViewModel : IMapFrom<Company>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [DisplayName("Service Organization")]
        public string IsServiceOrganization { get; set; }

        [DisplayName("Petrol Stations Count")]
        public int PetrolStationsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Company, CompanyInListViewModel>()
                .ForMember(x => x.IsServiceOrganization, opt =>
                opt.MapFrom(x => x.IsServiceOrganization.ToString().ToLower() == "true" ? "Yes" : "No"));
        }
    }
}
