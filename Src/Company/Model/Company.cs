using System.ComponentModel.DataAnnotations;

namespace ContactApp.Src.Company.Model;
using ContactApp.Src.Contact.Model;

public class Company
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = string.Empty;
    public Contact contact {get; set;} = new Contact();
}