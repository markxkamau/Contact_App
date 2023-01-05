using ContactApp.Src.Company.Dto;
using ContactApp.Src.Company.Model;
using ContactApp.Src.Contact.Model;
using ContactApp.Src.Contact.Dtos;

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
    public static CompanyDto AsDtos(this Company? company)
    {
        List<ContactDto> contacts = new List<ContactDto>();
        foreach (var item in company.Contacts)
        {
            var contactDto = new ContactDto()
            {
                Id = item.Id,
                Number = item.Number,
                Provider = item.Provider
            };
            contacts.Add(contactDto);
        }
        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Contacts = contacts,
            Category = company.Category
        };
    }
}