using System.ComponentModel.DataAnnotations;

namespace ContactApp.Src.Contact.Model;

public class Contact
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Number { get; set; } = string.Empty;
    [Required]
    public string Provider { get; set; } =string.Empty;

}