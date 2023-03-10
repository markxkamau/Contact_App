namespace ContactApp.Src.Company.Dto;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ContactApp.Src.Company.Model;
using ContactApp.Src.Contact.Dtos;
using ContactApp.Src.Contact.Model;

public record CompanyDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public List<ContactDto> Contacts { get; set; } = new List<ContactDto>();
    public Category Category { get; set; } = new Category();

}