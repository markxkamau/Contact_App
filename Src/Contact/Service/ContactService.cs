using ContactApp.Data;
using ContactApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Src.Contact.Service;

using ContactApp.Src.Contact.Model;

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
    public async Task<ContactDto> AddNewContact(CreateContactDto contactDto)
    {
        var contact = new Contact
        {
            Id =  (int)new Random().NextInt64(),
            Number = contactDto.Number,
            Provider = contactDto.Provider
        };

        _context.Contact.Add(contact);
        await _context.SaveChangesAsync();
        return contact.AsDto();
    }

    public bool checkContact(CreateContactDto contact){
        var check = _context.Contact.Any(c => c.Number == contact.Number);
        if (check is false)
        {
            return true;
        }
        return false;

    }

    public async Task UpdateContact(int id, UpdateContactDto contactDto){
        var contact = new Contact
        {
            Id = id,
            Number = contactDto.Number,
            Provider = contactDto.Provider
        };

        _context.Contact.Update(contact);
        await _context.SaveChangesAsync();
    }


}