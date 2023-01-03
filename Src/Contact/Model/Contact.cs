using System.ComponentModel.DataAnnotations;

namespace ContactApp.Src.Contact.Model;

using ContactApp.Src.Company.Model;
public class Contact
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
}