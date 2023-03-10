using System.ComponentModel.DataAnnotations;

namespace ContactApp.Src.Company.Model;

using System.Text.Json.Serialization;
using ContactApp.Src.Contact.Model;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Contact> Contacts { get; set; } = new List<Contact>();
    public Category Category { get; set; }
}