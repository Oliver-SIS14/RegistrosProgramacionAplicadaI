using RegistroEstudiante.DAL;
using RegistroEstudiante.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiante.BLL
{
    public class InscripcionBLL
    {
        public static bool guardar(Inscripcion inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Inscripcion.Add(inscripcion) != null)
                    paso = (db.SaveChanges() > 0);
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Inscripcion inscripcion)
        {
            bool paso;
            Contexto db = new Contexto();

            try
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
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
            bool paso;
            Inscripcion inscripcion = new Inscripcion();
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Inscripcion.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Inscripcion Buscar(int id)
        {
            Estudiante estudiante = new Estudiante();
            Inscripcion inscripcion = new Inscripcion();
            Contexto db = new Contexto();
            
            try
            { 

                inscripcion = db.Inscripcion.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return inscripcion;
        }

        public static List<Inscripcion> GetListInscripcion(Expression<Func<Inscripcion,bool>> inscripcion)
        {

            List<Inscripcion> Lista = new List<Inscripcion>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Inscripcion.Where(inscripcion).ToList();
            }
            catch (Exception)
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
