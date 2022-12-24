using ContactApp;
using ContactApp.Data;
using ContactApp.Dtos;
using ContactApp.Src.Contact.Model;
using ContactApp.Src.Contact.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly ContactService _context;
    public ContactController(ContactService context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<ContactDto> GetAll()
    {
        return _context.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<ContactDto> Get(int id)
    {
        var value = _context.Get(id);
        if (value is null)
        {
            return NotFound();
        }
        return Ok(value);
    }

    [HttpPost]
    public async Task<ActionResult<ContactDto>> AddAsync(CreateContactDto contactDto)
    {
        var check = _context.checkContact(contactDto);
        if (check is false)
        {
            return BadRequest("Contact already exists");
        }
        var newContact = await _context.AddNewContact(contactDto);

        return Ok(newContact);

    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateContactAsync(int id, UpdateContactDto contactDto)
    {
        var existing = _context.checkContactExists(id);

        if (existing is false)
        {
            return NotFound();
        }

        await _context.UpdateContact(id, contactDto);

        return NoContent();

    }

    [HttpDelete("{id}")]
    public ActionResult DeleteContact(int id)
    {
        var existing = _context.checkContactExists(id);
        if (existing is false)
        {
            return NotFound();
        }
        _context.DeleteContact(id);
        return NoContent();
    }

}