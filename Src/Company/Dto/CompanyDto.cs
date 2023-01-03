namespace ContactApp.Src.Company.Dto;

using System.Text.Json.Serialization;
using ContactApp.Src.Company.Model;
using ContactApp.Src.Contact.Model;

public record CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Contact> Contacts { get; set; } = new List<Contact>();
    public Category Category { get; set; }

}