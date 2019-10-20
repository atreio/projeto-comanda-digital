﻿using Microsoft.EntityFrameworkCore;
using ComandaDigital.Models;

public class ComandaDigitalContext : DbContext
{
    public ComandaDigitalContext(DbContextOptions<ComandaDigitalContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Estabelecimento> Estabelecimento { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>().HasKey(e => e.Id);
        modelBuilder.Entity<Usuario>().HasKey(e => e.Id);
        modelBuilder.Entity<Estabelecimento>().HasKey(e => e.Id);
    }
}
