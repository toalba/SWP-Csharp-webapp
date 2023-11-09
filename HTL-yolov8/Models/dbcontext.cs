namespace HTL_yolov8.Models;
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
            optionsBuilder.UseNpgsql("server=localhost;uid=postgres;pwd=wa22er!wasser;database=yolov8");
        }
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.Property(e => e.email).HasColumnName("email").IsRequired();
            entity.Property(e => e.name).HasColumnName("name");
            entity.Property(e => e.password).HasColumnName("password").IsRequired();
        });
        
    }


}