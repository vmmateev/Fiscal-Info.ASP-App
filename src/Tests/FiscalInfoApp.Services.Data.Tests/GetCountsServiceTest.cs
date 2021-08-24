namespace FiscalInfoApp.Services.Data.Tests
{
    using FiscalInfoApp.Data;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Data.Repositories;
    using FiscalInfoApp.Services.Data.Home;
    using Xunit;

    public class GetCountsServiceTest : BaseServiceTest
    {
        [Fact]
        public void GetCountsServiceShouldReturnCorrectCountForCompanyAndServiceComapnyAndPetrolStation()
        {
            ApplicationDbContext db = GetDb();

            var companyRepository = new EfDeletableEntityRepository<Company>(db);
            var petrolstationRepository = new EfDeletableEntityRepository<PetrolStation>(db);

            var service = new GetCountsService(companyRepository, petrolstationRepository);

            var company1 = new Company
            {
                Name = "stimex",
                City = "haskovo",
                Street = "plovdivska",
                IsServiceOrganization = true,
            };

            var company2 = new Company
            {
                Name = "tempo",
                City = "haskovo",
                Street = "dunav",
                IsServiceOrganization = false,
            };

            var company3 = new Company
            {
                Name = "propan",
                City = "plovdiv",
                Street = "kragovo",
                IsServiceOrganization = false,
            };

            var petrolStation1 = new PetrolStation
            {
                Name = "benzinostanciq propan",
                City = "plovdiv",
                Street = "carigradsko",
                CompanyId = 3,
            };
            db.Companies.Add(company1);
            db.Companies.Add(company2);
            db.Companies.Add(company3);
            db.PetrolStations.Add(petrolStation1);
            db.SaveChanges();

            var result = service.GetCounts();

            Assert.Equal(2, result.CompaniesCount);
            Assert.Equal(1, result.ServiceOrganization);
            Assert.Equal(1, result.PetrolStationsCount);
        }
    }
}
