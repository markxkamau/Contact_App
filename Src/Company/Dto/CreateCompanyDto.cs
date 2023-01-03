using System.ComponentModel.DataAnnotations;
using ContactApp.Src.Company.Model;

namespace ContactApp.Src.Company.Dto;
public record CreateCompanyDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public Category Category { get; set; } = new Category();
    [Required]
    public string Number { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
}