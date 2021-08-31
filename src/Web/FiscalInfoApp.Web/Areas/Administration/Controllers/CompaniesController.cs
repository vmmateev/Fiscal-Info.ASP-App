namespace FiscalInfoApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Data;
    using FiscalInfoApp.Data.Common.Repositories;
    using FiscalInfoApp.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class CompaniesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Company> companyRepository;

        public CompaniesController(IDeletableEntityRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.companyRepository.AllWithDeleted().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var company = await this.companyRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return this.NotFound();
            }

            return this.View(company);
        }

        // GET: Administration/Companies/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,City,Street,IsServiceOrganization,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Company company)
        {
            if (this.ModelState.IsValid)
            {
                await this.companyRepository.AddAsync(company);
                await this.companyRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(company);
        }

        // GET: Administration/Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var company = this.companyRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                return this.NotFound();
            }

            return this.View(company);
        }

        // POST: Administration/Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,City,Street,IsServiceOrganization,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Company company)
        {
            if (id != company.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.companyRepository.Update(company);
                    await this.companyRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CompanyExists(company.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(company);
        }

        // GET: Administration/Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var company = await this.companyRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return this.NotFound();
            }

            return this.View(company);
        }

        // POST: Administration/Companies/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = this.companyRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.companyRepository.Delete(company);
            await this.companyRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CompanyExists(int id)
        {
            return this.companyRepository.AllWithDeleted().Any(e => e.Id == id);
        }
    }
}
