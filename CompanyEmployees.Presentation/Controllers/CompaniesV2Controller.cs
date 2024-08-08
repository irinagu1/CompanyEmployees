using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesV2Controller(IServiceManager service) => _service = service;
        
        [HttpGet]
        public async Task<IActionResult> 
            GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            var companies = await _service.CompanyService.
                                  GetAllCompaniesAsync(companyParameters, trackChanges: false);
            return Ok(companies.companies.Select(x => $"{x.Name} V2"));
        }
    }

}
