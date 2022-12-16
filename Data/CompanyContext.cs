using ContactApp.Src.Company.Model;
using ContactApp.Src.Contact.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data;

public class CompanyContext : DbContext
{
    public CompanyContext(DbContextOptions<CompanyContext> options): base(options){}
    public DbSet<Company> Company => Set<Company>();
    public DbSet<Contact> Contact => Set<Contact>();

    internal void Find(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}