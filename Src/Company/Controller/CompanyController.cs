using ContactApp.Src.Company.Dto;
using ContactApp.Src.Company.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Src.Company.Controller;

[ApiController]
[Route("company/[controller]")]
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

        //Check the data passed against the Db to avoid repetition
        var companyCheck = _service.CheckCompany(companyDto.Name);//returns true when repetition is found
        if (companyCheck is true) return BadRequest("Company Already Exists");

        var contactCheck = _service.CheckContact(companyDto.Number);
        if (contactCheck is true) return BadRequest("Contact Already Exists");

        var company = _service.CreateNewCompany(companyDto);
        return Ok(company);
    }

    [HttpGet]
    public ActionResult<CompanyDto> GetCompanies()
    {
        var company = _service.GetCompany();
        return Ok(company);
    }

}