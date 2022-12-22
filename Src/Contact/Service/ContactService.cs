using ContactApp.Data;
using ContactApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Src.Contact.Service;

public class ContactService
{
    private readonly CompanyContext _context;
    public ContactService(CompanyContext context)
    {
        _context = context;
    }
    public IEnumerable<ContactDto> GetAll()
    {
        return _context.Contact.AsNoTracking().ToList().Select(contact => contact.AsDto());
    }
    public ContactDto Get(int id)
    {
        var value = _context.Contact.AsNoTracking().SingleOrDefault(p => p.Id == id);
        return value.AsDto();
    }


}