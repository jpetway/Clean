using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data;

public class CleanDbContext : DbContext
{
    public CleanDbContext(DbContextOptions<CleanDbContext> options) : base(options) { }
    
    public virtual DbSet<PersonEntity> Person { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=clean.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonEntity>().ToTable("Person");
        base.OnModelCreating(modelBuilder);
    }
}
