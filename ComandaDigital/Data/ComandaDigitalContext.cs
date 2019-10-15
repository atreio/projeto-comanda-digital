using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComandaDigital.Models;

public class ComandaDigitalContext : DbContext
{
    public ComandaDigitalContext(DbContextOptions<ComandaDigitalContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>().HasKey(e => e.Id);
        modelBuilder.Entity<Usuario>().HasKey(e => e.Id);
    }
}
