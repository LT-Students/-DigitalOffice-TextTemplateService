using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider.MsSql.Ef
{
  public class TextTemplateServiceDbContext : DbContext, IDataProvider
  {
    public DbSet<DbTemplate> Templates { get; set; }
    public DbSet<DbTemplateText> TemplateTexts { get; set; }
    public DbSet<DbKeyword> Keywords { get; set; }

    public TextTemplateServiceDbContext(DbContextOptions<TextTemplateServiceDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("LT.DigitalOffice.TextTemplateService.Models.Db"));
    }

    public void EnsureDeleted()
    {
      Database.EnsureDeleted();
    }

    public bool IsInMemory()
    {
      return Database.IsInMemory();
    }

    public object MakeEntityDetached(object obj)
    {
      Entry(obj).State = EntityState.Detached;

      return Entry(obj).State;
    }

    public void Save()
    {
      SaveChanges();
    }

    public async Task SaveAsync()
    {
      await SaveChangesAsync();
    }
  }
}
