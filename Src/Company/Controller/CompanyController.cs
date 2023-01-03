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
        var company = _service.CreateNewCompany(companyDto);
        // var companies = _service.GetCompany();
        return Ok(company);
    }

    [HttpGet]
    public ActionResult<CompanyDto> GetCompanies()
    {
        var company = _service.GetCompany();
        return Ok(company);
    }

}