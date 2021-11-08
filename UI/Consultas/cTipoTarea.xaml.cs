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
    /// Interaction logic for cTipoTarea.xaml
    /// </summary>
    public partial class cTipoTarea : Window
    {
        public cTipoTarea()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<TiposTareas>();

            if (!String.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = TipoTareasBLL.GetList(r => r.TareaId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 1:
                        lista = TipoTareasBLL.GetList(r => r.Descripcion.Contains(CriterioTextBox.Text.ToUpper()) || r.Descripcion.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 2:
                        lista = TipoTareasBLL.GetList(r => r.Tiempo == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lista = TipoTareasBLL.GetList(e => true);

            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = lista;
        }
    }
}


