using ContactApp.Data;

namespace ContactApp.Src.Company.Services;

using System.Threading.Tasks;
using ContactApp.Src.Company.Dto;
using ContactApp.Src.Company.Model;
using ContactApp.Src.Contact.Model;
using ContactApp.Src.Contact.Service;

public class CompanyService
{
    private readonly CompanyContext _context;
    private readonly ContactService _service;
    public CompanyService(CompanyContext context, ContactService service)
    {
        _context = context;
        _service = service;
    }

    public IEnumerable<CompanyDto> GetCompany()
    {
        var companies = _context.Company.ToList().Select(c => c.AsDtos());
        return companies;
    }

    public async Task<CompanyDto> CreateCompany(CompanyDto companyDto)
    {
        var company = new Company
        {
            Id = new int(),
            Name = companyDto.Name,
            Contacts = companyDto.Contacts
        };

        await _context.Company.AddAsync(company);
        await _context.SaveChangesAsync();
        return company.AsDtos();
    }

    public CompanyDto CreateNewCompany(CreateCompanyDto createCompanyDto)
    {
        List<Contact> contactList = new List<Contact>();

        var contact = new Contact
        {
            Id = new int(),
            Number = createCompanyDto.Number,
            Provider = createCompanyDto.Provider
        };

        contactList.Add(contact);

        var company = new Company
        {
            Id = new int(),
            Name = createCompanyDto.Name,
            Category = createCompanyDto.Category,
            Contacts = contactList
        };
        _context.Company.Add(company);
        _context.SaveChanges();

        return company.AsDtos();

    }

}