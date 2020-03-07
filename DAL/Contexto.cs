using Microsoft.EntityFrameworkCore;
using RegistroPersona.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPersona.DAL {
    public class Contexto : DbContext{

        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source = RegistroPersonas.db");
        }
    }
}
