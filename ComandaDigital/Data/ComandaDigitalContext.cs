using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComandaDigital.Models;

    public class ComandaDigitalContext : DbContext
    {
        public ComandaDigitalContext (DbContextOptions<ComandaDigitalContext> options)
            : base(options)
        {
        }

        public DbSet<ComandaDigital.Models.Cliente> Cliente { get; set; }
    }
