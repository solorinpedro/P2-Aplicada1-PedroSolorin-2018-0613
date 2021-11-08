using P2_Aplicada1_PedroSolorin_2018_0613.UI.Consultas;
using P2_Aplicada1_PedroSolorin_2018_0613.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P2_Aplicada1_PedroSolorin_2018_0613
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Proyectos_Click(object sender, RoutedEventArgs e)
        {
            rProyectos proyectos = new rProyectos();
            proyectos.Show();
        }

        private void ConsultarTipo_Click(object sender, RoutedEventArgs e)
        {
            cTipoTarea tipo = new cTipoTarea();
            tipo.Show();
        }
    }
}
