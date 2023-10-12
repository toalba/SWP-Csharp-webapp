namespace Web_App.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public class  Websitecontext : DbContext
{
    public Websitecontext()
    {
        
    }

    public Websitecontext(DbContextOptions<Websitecontext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("server=localhost;uid=admin;pwd=wa22er!wasser;database=webapp");
        }
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("Name");
        });
        
    }


}