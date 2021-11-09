using P2_Aplicada1_PedroSolorin_2018_0613.BLL;
using P2_Aplicada1_PedroSolorin_2018_0613.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P2_Aplicada1_PedroSolorin_2018_0613.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cProyecto.xaml
    /// </summary>
    public partial class cProyecto : Window
    {
        public cProyecto()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Proyectos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = ProyectosBLL.GetList(r => r.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 1:
                        lista = ProyectosBLL.GetList(r => r.Descripcion.Contains(CriterioTextBox.Text.ToUpper()) || r.Descripcion.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lista = ProyectosBLL.GetList(e => true);

            }
            if (DesdeDataPicker.SelectedDate != null)
                lista = ProyectosBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDataPicker.SelectedDate != null)
                lista = ProyectosBLL.GetList(c => c.Fecha.Date >= HastaDataPicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = lista;
        }
    }
}
