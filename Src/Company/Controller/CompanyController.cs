using ContactApp.Src.Company.Dto;
using ContactApp.Src.Company.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Src.Company.Controller;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _service;

    public CompanyController(CompanyService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult CreateCompany(CreateCompanyDto companyDto)
    {
        //Check if input is null/not yet filled ensuring all required fields filled
        if (companyDto is null)
        {
            return NoContent();
        }

        var contactCheck = _service.CheckContact(companyDto.Number);
        if (contactCheck is true)
        {
            return BadRequest("Contact Already Exists");
        }

        //Check the data passed against the Db to avoid repetition
        var companyCheck = _service.CheckCompany(companyDto.Name);//returns true when repetition is found
        if (companyCheck is true)
        {
            return BadRequest("Company Already Exists");
        }
        var company = _service.CreateNewCompany(companyDto);
        return Ok(company);
    }

    [HttpGet]
    public ActionResult<CompanyDto> GetCompanies()
    {
        var company = _service.GetCompany();
        return Ok(company);
    }

    [HttpGet("{id}")]
    public ActionResult<CompanyDto> GetCompanyById(int id)
    {
        var company = _service.GetCompanyById(id);
        if (company is null)
        {
            return NotFound();
        }
        return Ok(company);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCompany(int id, CreateCompanyDto companyDto)
    {
        // Check if company with id exists
        var company = _service.GetCompanyById(id);
        if (company is null)
        {
            return NotFound();
        }
        var newCompany = _service.AddCompanyContact(id, companyDto);
        return Ok(newCompany);

    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCompany(int id)
    {
        var check = _service.DeleteCompanyById(id);
        if (check is false)
        {
            return BadRequest("Company Id doesn't exist");
        }

        return NoContent();
    }

}