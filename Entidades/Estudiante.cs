using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiante.Entidades
{
    public class Estudiante
    {
        public int Estudianteid { get; set; }
        public string Matricula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public decimal Balance { get; set; }

        public Estudiante()
        {

        }

        public Estudiante(int estudianteid, string matricula, string nombres, string apellidos, string cedula, string telefono, string celular, string email, DateTime fechaNacimiento, int sexo, decimal balance)
        {
            Estudianteid = estudianteid;//
            Matricula = matricula;//
            Nombres = nombres;//
            Apellidos = apellidos;//
            Cedula = cedula;//
            Telefono = telefono;//
            Celular = celular;//
            Email = email;//
            FechaNacimiento = fechaNacimiento;//
            Sexo = sexo;
            Balance = balance;
        }
    }
}
