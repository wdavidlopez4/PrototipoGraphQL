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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>()
                .HasOne<Autor>(x => x.Autor)
                .WithMany(y => y.Libros)
                .HasForeignKey(z => z.IdAutor);

            modelBuilder.Entity<Autor>().HasData(
                new Autor
                {
                    Id = 1,
                    Nacionalidad = "peruana",
                    Anios = 44,
                    Nombre = "camilo"
                },
                new Autor
                {
                    Id = 2,
                    Nacionalidad = "peruana",
                    Anios = 44,
                    Nombre = "camilo",

                }
                );

            modelBuilder.Entity<Libro>().HasData(
                new Libro
                {
                    Id = 1,
                    Nombre = "literatura",
                    Descripcion = "nuevo",
                    IdAutor = 1
                },
                new Libro
                {
                    Id = 2,
                    Nombre = "español",
                    Descripcion = "nuevo",
                    IdAutor = 1
                },
                new Libro
                {
                    Id = 3,
                    Nombre = "matematicas",
                    Descripcion = "nuevo",
                    IdAutor = 2
                },
                new Libro
                {
                    Id = 4,
                    Nombre = "mate",
                    Descripcion = "nuevo",
                    IdAutor = 2
                }
                );

            
        }
    }
}
