using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryCompanyExtensions
    {

        public static IQueryable<Company> FilterCompanies(this IQueryable<Company> companies, string? country) 
        {
            if (country == null) 
                return companies;
            return companies.Where(x => x.Country == country);
        }
    }
}
