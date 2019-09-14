using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiante.Entidades
{
    public class Inscripcion
    {
        public int Estudianteid { get; set; }
        public int Inscripcionid { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public decimal Deposito  { get; set; }
        public string Comentarios { get; set; }

        public Inscripcion()
        {
            
        }
    }
}
