﻿using Microsoft.EntityFrameworkCore;
using ComandaDigital.Models;

public class ComandaDigitalContext : DbContext
{
    public ComandaDigitalContext(DbContextOptions<ComandaDigitalContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Estabelecimento> Estabelecimento { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Mesa> Mesa { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<ItemPedido> ItemPedido { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pedido>().HasKey(e => e.Id);
        modelBuilder.Entity<Usuario>().HasKey(e => e.Id);
        modelBuilder.Entity<Estabelecimento>().HasKey(e => e.Id);
        modelBuilder.Entity<Produto>().HasKey(e => e.Id);
        modelBuilder.Entity<Mesa>().HasKey(e => e.Id);
        modelBuilder.Entity<ItemPedido>().HasKey(e => e.Id);
    }
}
