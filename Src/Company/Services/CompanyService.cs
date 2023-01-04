using ContactApp.Data;

namespace ContactApp.Src.Company.Services;

using System;
using System.Threading.Tasks;
using ContactApp.Src.Company.Dto;
using ContactApp.Src.Company.Model;
using ContactApp.Src.Contact.Model;
using ContactApp.Src.Contact.Service;
using Microsoft.EntityFrameworkCore;

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

    public bool CheckCompany(string name)
    {
        var check = _context.Company.SingleOrDefault(s => s.Name == name);
        if (check is null)
        {
            return false;
        }
        return true;
    }

    public bool CheckContact(string number)
    {
        var check = _context.Contact.SingleOrDefault(s => s.Number == number);
        if (check is null)
        {
            return false;
        }
        return true;
    }

    public int FindId(string name)
    {
        var companyName = _context.Company.SingleOrDefault(c => c.Name == name);
        if (companyName is null)
        {
            return 0;
        }
        return companyName.Id;
    }

    public CompanyDto GetCompanyById(int id)
    {
        return _context.Company.Include(s => s.Contacts).SingleOrDefault(s => s.Id == id).AsDtos();
    }

    public CompanyDto AddCompanyContact(int companyId, CreateCompanyDto companyDto)
    {
        // Check if the company exists 
        var existing = _context.Company.Find(companyId);
        if (existing is null)
        {
            return new CompanyDto();
        }

        // Declare new Contact list instantiated with existing DB data
        List<Contact> contacts = existing.Contacts;

        // Instantiate new contact to be added to the list from user input
        var contact = new Contact
        {
            Id = new int(),
            Number = companyDto.Number,
            Provider = companyDto.Provider
        };

        // Update contact DB table
        _context.Contact.Add(contact);
        // _context.SaveChanges();

        // Add contact declared to the list
        contacts.Add(contact);

        // Instantiate Company table with latest contact list adding new contacts
        var company = new Company
        {
            Id = companyId,
            Name = companyDto.Name,
            Category = companyDto.Category,
            Contacts = contacts
        };

        // Update company DB table
        existing = company;
        _context.SaveChanges();


        return company.AsDtos();
    }

    public bool DeleteCompanyById(int id)
    {
        var company = _context.Company.Find(id);
        if (company is null)
        {
            return false;
        }
        // if (company.Contacts is not null)
        // {
        //     List<Contact> contacts = company.Contacts;
        //     foreach (var a in contacts)
        //     {
        //         var contact = _context.Contact.Find(a.Id);
        //         if(contact is null){
        //            break;
        //         }
        //         _context.Contact.Remove(contact);
        //         _context.SaveChanges();
        //     }
            

        // }
        _context.Company.Remove(company);
        _context.SaveChanges();
        return true;

    }
}