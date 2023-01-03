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
        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Contacts = company.Contacts,
            Category = company.Category
        };
    }
}