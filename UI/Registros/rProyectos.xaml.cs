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

namespace P2_Aplicada1_PedroSolorin_2018_0613.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private TiposTareas Tareas = new TiposTareas();
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = Tareas;

            TareaIdComboBox.ItemsSource = TipoTareasBLL.GetTareas();
            TareaIdComboBox.SelectedValuePath = "TareasId";
            TareaIdComboBox.DisplayMemberPath = "Descripcion";
        }
    }
}
