using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }
        public async Task<PagedList<Company>> 
            GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges)
        {
            var companies = await FindAll(trackChanges)
                .FilterCompanies(companyParameters.Country)
                .OrderBy(c => c.Name)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return PagedList<Company>.ToPagedList(companies, 
                   companyParameters.PageNumber, companyParameters.PageSize);
        }


        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges)
        {
            Console.WriteLine("code in the getasync");
            return await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
             .SingleOrDefaultAsync();
        }

        public void CreateCompany(Company company) => Create(company);

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();

        public void DeleteCompany(Company company) => Delete(company);
    }

}
