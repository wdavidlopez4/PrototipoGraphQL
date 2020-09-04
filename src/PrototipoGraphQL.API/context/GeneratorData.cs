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

                context.Autores.AddRange(
                    new Autor
                    {
                        Id = 1,
                        Nacionalidad = "peruana",
                        Anios = 44,
                        Nombre = "camilo",
                        Libros = { new Libro { Id = 1}, new Libro { Id = 2 } }
                    },

                    new Autor
                    {
                        Id = 2,
                        Nacionalidad = "colombiano",
                        Anios = 44,
                        Nombre = "juan",
                        Libros = { new Libro { Id = 3 }, new Libro { Id = 4 } }
                    }
                    );

                context.Libros.AddRange(
                    new Libro
                    {
                        Id = 1,
                        Nombre = "literatura",
                        Descripcion = "nuevo",
                        Autor = { Id = 1}
                    },
                    new Libro
                    {
                        Id = 2,
                        Nombre = "literatura",
                        Descripcion = "nuevo",
                        Autor = { Id = 1 }
                    },

                    new Libro
                    {
                        Id = 3,
                        Nombre = "literatura grado 7",
                        Descripcion = "nuevo",
                        Autor = { Id = 2 }
                    },
                    new Libro
                    {
                        Id = 4,
                        Nombre = "literatura grado 9",
                        Descripcion = "nuevo",
                        Autor = { Id = 2 }
                    }

                    );


                context.SaveChanges();
            }
        }
    }
}
