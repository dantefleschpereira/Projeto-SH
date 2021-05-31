﻿using Entities.Model;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL
{
    public class SecondHandContext : IdentityDbContext<ApplicationUser>
    {
        public SecondHandContext() : base()
        {
        }

        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
       // public DbSet<Questionamento> Questionamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SecondHand;Trusted_Connection=True;");
        }

        // associar a PK do Identity
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

    }
}
