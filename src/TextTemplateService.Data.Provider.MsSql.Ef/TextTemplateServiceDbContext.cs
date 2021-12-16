﻿using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider.MsSql.Ef
{
  public class TextTemplateServiceDbContext : DbContext, IDataProvider
  {
    public DbSet<DbEmailTemplate> EmailTemplates { get; set; }
    public DbSet<DbEmailTemplateText> EmailTemplateTexts { get; set; }
    public DbSet<DbKeyword> ParseEntities { get; set; }

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
