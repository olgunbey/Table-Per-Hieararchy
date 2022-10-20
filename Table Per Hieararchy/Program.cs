// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
{
    DbXContext dbXContext = new();
    BaskanEntity baskan = new() { BaskanOz = "baskan", Name = "eren",CreateDate=DateTime.Now };
    dbXContext.BaskanEntities.Add(baskan);
    dbXContext.SaveChanges();
    //BaseEntity entity = new()
    //{
    //    CreateDate = DateTime.Now
    //};
}
public  class BaseEntity
{
    public int ID { get; set; }
    public string Name { get; set; }
    public virtual DateTime CreateDate { get; set; }

}
public class BaskanEntity:BaseEntity
{
    public string BaskanOz { get; set; }
   
    public override DateTime CreateDate { get => base.CreateDate; set => base.CreateDate = value; }
}
public class UyeEntity:BaskanEntity
{
    public string UyeOz { get; set; }
    //public override DateTime CreateDate { get => base.CreateDate; set => base.CreateDate = value; }

}
public class YardımcıOz:BaskanEntity
{
    public string YardımciOz { get; set; }
    //public override DateTime CreateDate { get => base.CreateDate; set => base.CreateDate = value; }

}
public class DbXContext:DbContext
{
    public DbSet<BaskanEntity> BaskanEntities { get; set; }
    public DbSet<UyeEntity> UyeEntities { get; set; }
    public DbSet<YardımcıOz> YardımcıOz { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb; Initial Catalog=TphKlupMantigi");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaskanEntity>().Ignore(p => p.CreateDate);
    }
}

