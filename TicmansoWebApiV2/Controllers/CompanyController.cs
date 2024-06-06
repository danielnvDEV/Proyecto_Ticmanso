using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicmansoV2.Shared;
using TicmansoWebApiV2.Context;


namespace TicmansoWebApiV2.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly TicmansoDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CompanyController(TicmansoDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            return await _dbContext.Companies
                .Select(c => new CompanyDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Country = c.Country,
                    Address = c.Address,
                    PostalCode = c.PostalCode,
                    City = c.City,
                    Cif = c.Cif
                })
                .ToListAsync();
        }
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            var company = await _dbContext.Companies
                .Where(c => c.Id == id)
                .Select(c => new CompanyDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Country = c.Country,
                    Address = c.Address,
                    PostalCode = c.PostalCode,
                    City = c.City,
                    Cif = c.Cif
                })
                .FirstOrDefaultAsync();

            if (company == null) return NotFound();

            return company;
        }


        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<CompanyDTO>> CreateCompany(CompanyDTO companyDTO)
        {
            var company = new Company
            {
                Name = companyDTO.Name,
                Country = companyDTO.Country,
                Address = companyDTO.Address,
                PostalCode = companyDTO.PostalCode,
                City = companyDTO.City,
                Cif = companyDTO.Cif
            };

            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyDTO companyDTO)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null) return NotFound();

            company.Name = companyDTO.Name;
            company.Country = companyDTO.Country;
            company.Address = companyDTO.Address;
            company.PostalCode = companyDTO.PostalCode;
            company.City = companyDTO.City;
            company.Cif = companyDTO.Cif;

            _dbContext.Companies.Update(company);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null) return NotFound();

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}
