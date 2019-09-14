using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RegistroEstudiante.Entidades;

namespace RegistroEstudiante.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; } 

        public Contexto() : base("ConStr") { }
    }
}
