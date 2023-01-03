using ContactApp.Src.Company.Model;

namespace ContactApp.Src.Company.Dto;
public record CreateCompanyDto
{
    public string Name { get; set; } = string.Empty;
    public Category Category { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
}