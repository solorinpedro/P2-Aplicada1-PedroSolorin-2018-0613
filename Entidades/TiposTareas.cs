using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Aplicada1_PedroSolorin_2018_0613.Entidades
{
    public class TiposTareas
    {
        [Key]
        public int TareaId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }
        public TiposTareas()
        {
            TareaId = 0;
            Descripcion = "";
            Requerimiento = "";
            Tiempo = 0;
        }
    }
}
