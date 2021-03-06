using Microsoft.EntityFrameworkCore;
using P2_Aplicada1_PedroSolorin_2018_0613.DAL;
using P2_Aplicada1_PedroSolorin_2018_0613.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_Aplicada1_PedroSolorin_2018_0613.BLL
{
    public class ProyectosBLL
    {
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Proyectos.Any(e => e.ProyectoId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        private static bool Insertar(Proyectos proyectos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Proyectos.Add(proyectos);

                foreach (var tarea in proyectos.Detalles)
                {
                    contexto.Entry(tarea).State = EntityState.Added;
                    contexto.Entry(tarea.TiposTareas).State = EntityState.Modified;
                }
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Proyectos proyectos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyectoAnterior = contexto.Proyectos
                    .Where(x => x.ProyectoId == proyectos.ProyectoId)
                    .Include(x => x.Detalles)
                    .ThenInclude(x => x.TiposTareas)
                    .AsNoTracking()
                    .SingleOrDefault();

                contexto.Database.ExecuteSqlRaw($"DELETE FROM ProyectoDetalle Where ProyectoId = {proyectos.ProyectoId}");
                foreach(var anterior in proyectos.Detalles)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                    contexto.Entry(anterior.TiposTareas).State = EntityState.Modified;

                }
                contexto.Entry(proyectos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Guardar(Proyectos proyectos)
        {
            if (!Existe(proyectos.ProyectoId))
                return Insertar(proyectos);
            else
                return Modificar(proyectos);

        }

        public static Proyectos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proyectos proyectos = new Proyectos();

            try
            {
                proyectos = contexto.Proyectos.Include(x => x.Detalles)
                    .Where(x => x.ProyectoId == id)
                    .Include(x => x.Detalles)
                    .ThenInclude(x => x.TiposTareas)
                    .SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyectos;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyecto = contexto.Proyectos.Find(id);
                foreach (var item in proyecto.Detalles)
                {
                    contexto.Entry(item.Proyectos).State = EntityState.Modified;
                    contexto.Entry(item.TiposTareas).State = EntityState.Modified;
                }
                contexto.Entry(proyecto).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static string BuscarRequerimiento(int id)
        {
            var contexto = new Contexto();
            var proyectos = new TiposTareas();

            try
            {
                proyectos = contexto.Tareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyectos.Requerimiento;
        }

        public static string BuscarTiempo(int id)
        {
            var contexto = new Contexto();
            var tarea = new TiposTareas();

            try
            {
                tarea = contexto.Tareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Convert.ToString(tarea.Tiempo);
        }
        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool >> criterio)
        {
            List<Proyectos> lista = new List<Proyectos>();
            var contexto = new Contexto();
            try
            {
                lista = contexto.Proyectos.Where(criterio).ToList();
            }   
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
