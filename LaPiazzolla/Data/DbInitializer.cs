using LaPiazzolla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaPiazzolla.Data
{
    public class DbInitializer
    {
        public static void Initialize(LaPiazzollaContext context)
        {
            context.Database.EnsureCreated();

            //Buscar si existen registros en la tabla Cursos
            if (context.Cursos.Any())
            {
                return;
            }

            var curso = new Curso[]
            {
                new Curso{ Nombre="Guitarra", Descripcion="Curso integral de guitarra", PrecioMensual=1600},
                new Curso{ Nombre="Piano", Descripcion="Curso integral de Piano", PrecioMensual=1600},
                new Curso{ Nombre="Violin", Descripcion="Curso integral de violin", PrecioMensual=1600},
                new Curso{ Nombre="Canto", Descripcion="Curso vocal de canto", PrecioMensual=1600}
            };

            foreach (Curso c in curso)
            {
                context.Cursos.Add(c);
            }

            context.SaveChanges();
        }
    }
}
