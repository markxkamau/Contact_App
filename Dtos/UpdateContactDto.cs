using System.ComponentModel.DataAnnotations;

namespace ContactApp.Dtos;

public record UpdateContactDto
{
    [Required]
    [MaxLength(20)]
    public string Number { get; set; } = string.Empty;
    [Required]
    public string Provider { get; set; } = string.Empty;

}