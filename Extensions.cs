using ContactApp.Dtos;
using ContactApp.Src.Contact.Model;

namespace ContactApp;
public static class Extensions
{
    public static ContactDto AsDto(this Contact? contact)
    {
        return new ContactDto
        {
            Id = contact.Id,
            Number = contact.Number,
            Provider = contact.Provider

        };
    }
}