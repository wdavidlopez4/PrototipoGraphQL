using Microsoft.EntityFrameworkCore;
using PrototipoGraphQL.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.context
{
    public class MemoryContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }

        public MemoryContext(DbContextOptions<MemoryContext> options):base(options)
        {
            //comprueba si la db esta creada si no la crea
            Database.EnsureCreated();
        }
    }
}
