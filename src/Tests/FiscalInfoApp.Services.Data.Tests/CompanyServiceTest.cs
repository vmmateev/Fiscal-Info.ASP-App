namespace FiscalInfoApp.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data;
    using FiscalInfoApp.Data.Models;
    using FiscalInfoApp.Data.Repositories;
    using FiscalInfoApp.Services.Data.Company;
    using FiscalInfoApp.Web.ViewModels.Company;
    using Xunit;

    public class CompanyServiceTest : BaseServiceTest
    {
        [Fact]
        public async Task CreateCompanyAsyncShouldCreateCompanyCorrect()
        {
            ApplicationDbContext db = GetDb();

            var companyRepo = new EfDeletableEntityRepository<Company>(db);

            var service = new CompanyService(companyRepo);

            var company1 = new CreateCompanyInputModel
            {
                Name = "stimex",
                Street = "plovdivska",
                City = "haskovo",
                IsServiceOrganization = true,
            };

            await service.CreateCompanyAsync(company1);
            await companyRepo.SaveChangesAsync();

            var result = db.Companies.Count();

            var expected = 1;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAllCompaniesShouldGetAllCompaniesAdded()
        {
            ApplicationDbContext db = GetDb();

            var companyRepo = new EfDeletableEntityRepository<Company>(db);

            var service = new CompanyService(companyRepo);

            var company1 = new Company
            {
                Name = "stimex",
                Street = "plovdivska",
                City = "haskovo",
                IsServiceOrganization = true,
            };

            var company2 = new Company
            {
                Name = "tempo",
                Street = "dunav",
                City = "dimitrovgrad",
                IsServiceOrganization = false,
            };

            db.Companies.Add(company1);
            db.Companies.Add(company2);
            db.SaveChanges();

            var result = service.GetAllCompanies<Company>(1, 12);
            var companyResult1 = result.FirstOrDefault(x => x.Name == "stimex");
            var companyResult2 = result.FirstOrDefault(x => x.Name == "tempo");
            Assert.Equal("stimex", companyResult1.Name);
            // TODO automapper collection
        }

        [Fact]
        public void GetCompaniesCountShouldReturnCorrectCount()
        {
            ApplicationDbContext db = GetDb();

            var companyRepo = new EfDeletableEntityRepository<Company>(db);

            var service = new CompanyService(companyRepo);

            var company1 = new Company
            {
                Name = "stimex",
                Street = "plovdivska",
                City = "haskovo",
                IsServiceOrganization = true,
            };

            var company2 = new Company
            {
                Name = "tempo",
                Street = "dunav",
                City = "dimitrovgrad",
                IsServiceOrganization = false,
            };

            db.Companies.Add(company1);
            db.Companies.Add(company2);
            db.SaveChanges();

            var result = service.GetCompaniesCount();

            Assert.Equal(2, result);
        }

        [Fact]
        public void GetAllStatsCompaniesShouldReturnAllAddedCompanies()
        {
            ApplicationDbContext db = GetDb();

            var companyRepo = new EfDeletableEntityRepository<Company>(db);

            var service = new CompanyService(companyRepo);

            var company1 = new Company
            {
                Name = "stimex",
                Street = "plovdivska",
                City = "haskovo",
                IsServiceOrganization = true,
            };

            var company2 = new Company
            {
                Name = "tempo",
                Street = "dunav",
                City = "dimitrovgrad",
                IsServiceOrganization = false,
            };

            db.Companies.Add(company1);
            db.Companies.Add(company2);
            db.SaveChanges();

            var result = service.GetAllStatsCompanies(1, 12);

            Assert.Equal(2, result.Count());

            var company1Result = result.Where(x => x.CompanyId == 1).FirstOrDefault();
            Assert.Equal("stimex", company1Result.CompanyName);
        }
    }
}
