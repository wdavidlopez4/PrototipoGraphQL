using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrototipoGraphQL.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.context
{
    public class GeneratorData
    {
        public static void Inicializar(IServiceProvider service)
        {
            using (var context = new MemoryContext(service.GetRequiredService<DbContextOptions<MemoryContext>>()))
            {
                if(context.Libros.Any() || context.Autores.Any())
                {
                    return;
                }


                //crear autores
                 var autor1 = context.Autores.Add(new Autor 
                 {
                     Id = 1,
                     Nacionalidad = "peruana",
                     Anios = 44,
                     Nombre = "camilo",

                 });

                var autor2 = context.Autores.Add(new Autor
                {
                    Id = 2,
                    Nacionalidad = "peruana",
                    Anios = 44,
                    Nombre = "camilo",

                });


                //creamos los libros
                context.Libros.AddRange(
                    new Libro
                    {
                        Id = 1,
                        Nombre = "literatura",
                        Descripcion = "nuevo",
                        IdAutor = autor1.Entity.Id
                    },
                    new Libro
                    {
                        Id = 2,
                        Nombre = "literatura",
                        Descripcion = "nuevo",
                        IdAutor = autor1.Entity.Id
                    },

                    new Libro
                    {
                        Id = 3,
                        Nombre = "literatura grado 7",
                        Descripcion = "nuevo",
                        IdAutor = autor2.Entity.Id
                    },
                    new Libro
                    {
                        Id = 4,
                        Nombre = "literatura grado 9",
                        Descripcion = "nuevo",
                        IdAutor = autor2.Entity.Id
                    }

                    );

                //guardamos en memoria 
                context.SaveChanges();
            }
        }
    }
}
