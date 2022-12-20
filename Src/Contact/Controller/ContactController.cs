using ContactApp;
using ContactApp.Data;
using ContactApp.Dtos;
using ContactApp.Src.Contact.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly CompanyContext _context;
    public ContactController(CompanyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<ContactDto> GetAll()
    {
        return _context.Contact.AsNoTracking().ToList().Select(contact => contact.AsDto());
    }

    [HttpGet("{id}")]
    public ActionResult<ContactDto> Get(int id)
    {
        var value = _context.Contact.AsNoTracking().SingleOrDefault(p => p.Id == id);
        if (value is null)
        {
            return NotFound();
        }
        return value.AsDto();
    }

    [HttpPost]
    public ActionResult<ContactDto> Add(CreateContactDto contactDto)
    {
        var contact = new Contact()
        {
            Id = (int)new Random().NextInt64(),
            Number = contactDto.Number,
            Provider = contactDto.Provider
        };
        _context.Contact.Add(contact);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact.AsDto());
    }

    [HttpPut("{id}")]
    public ActionResult UpdateContact(int id, UpdateContactDto contactDto)
    {
        var existing = _context.Contact.AsNoTracking().SingleOrDefault(o => o.Id == id);
        if (existing is null)
        {
            return NotFound();
        }
        var updated = new Contact
        {
            Id = id,
            Number = contactDto.Number,
            Provider = contactDto.Provider
        };

        _context.Contact.Update(updated);
        _context.SaveChanges();

        return NoContent();

    }

    [HttpDelete("{id}")]
    public ActionResult DeleteContact(int id)
    {
        var existing = _context.Contact.SingleOrDefault(ob => ob.Id == id);
        if (existing is null)
        {
            return NotFound();
        }
        _context.Contact.Remove(existing);
        _context.SaveChanges();
        return NoContent();
    }

}