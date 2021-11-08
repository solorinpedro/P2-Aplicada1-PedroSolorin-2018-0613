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
    public  class TipoTareasBLL
    {
        public static bool Existe(string descripcion)
        {
            bool encontrado = false;
            var contexto = new Contexto();

            try
            {
                encontrado = contexto.Tareas.Any(e => e.Descripcion.ToLower() == descripcion.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static bool Insertar(TiposTareas tarea)
        {
            bool paso = false;
            var contexto = new Contexto();

            try
            {
                contexto.Tareas.Add(tarea);
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

        private static bool Modificar(TiposTareas tarea)
        {
            bool paso = false;
            var contexto = new Contexto();

            try
            {
                contexto.Entry(tarea).State = EntityState.Modified;
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

        public static bool Guardar(TiposTareas tarea)
        {
            if (!Existe(tarea.Descripcion))
                return Insertar(tarea);
            else
                return Modificar(tarea);
        }

        public static TiposTareas Buscar(int id)
        {
            var contexto = new Contexto();
            var tiposTarea = new TiposTareas();

            try
            {
                tiposTarea = contexto.Tareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tiposTarea;
        }

        public static string BuscarRequerimiento(int id)
        {
            var contexto = new Contexto();
            var tiposTarea = new TiposTareas();

            try
            {
                tiposTarea = contexto.Tareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tiposTarea.Requerimiento;
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

        public static List<TiposTareas> GetList(Expression<Func<TiposTareas, bool>> criterio)
        {
            var lista = new List<TiposTareas>();
            var contexto = new Contexto();

            try
            {
                lista = contexto.Tareas.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<TiposTareas> GetTareas()
        {
            var lista = new List<TiposTareas>();
            var contexto = new Contexto();

            try
            {
                lista = contexto.Tareas.ToList();
            }
            catch (Exception)
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

