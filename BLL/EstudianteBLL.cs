using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Entidades;
using System.Data.Entity;
using RegistroEstudiante.UI.Registros;

namespace RegistroEstudiante.BLL
{
    public class EstudianteBLL
    {
        public static bool Guardar(Estudiante estudiante)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                if (db.Estudiante.Add(estudiante) != null)
                    paso = db.SaveChanges() > 0; 

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose(); //Cerrando la conexion
            }

            return paso;
        }

        public static void GuardarBalance(int id, decimal balance)
        {
            Contexto db = new Contexto();
            Estudiante estudiante = new Estudiante();

            estudiante = db.Estudiante.Find(id);

            try
            {
                estudiante.Balance += balance;

            db.Entry(estudiante).State = EntityState.Modified;
            db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool Modificar(Estudiante estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                db.Entry(estudiante).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Estudiante.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Estudiante Buscar(int id)
        {
            Contexto db = new Contexto();

            Estudiante estudiante = new Estudiante();
            Inscripcion inscripcion = new Inscripcion();

            try
            {
                estudiante = db.Estudiante.Find(id);

            }

            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return estudiante;
        }

        public static List<Estudiante> GetList(Expression<Func<Estudiante, bool>> estudiante)
        {
            List<Estudiante> Lista = new List<Estudiante>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Estudiante.Where(estudiante).ToList();

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }
    }
}
