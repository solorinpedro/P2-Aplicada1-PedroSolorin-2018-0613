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
        private Proyectos proyectos = new Proyectos();
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = proyectos;

            DescripcionComboBox.ItemsSource = TipoTareasBLL.GetTareas();
            DescripcionComboBox.SelectedValuePath = "TareasId";
            DescripcionComboBox.DisplayMemberPath = "Descripcion";
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyectos;
        }
        private void Limpiar()
        {
            this.proyectos = new Proyectos();
            this.DataContext = proyectos;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectosBLL.Buscar(Utilidades.ToInt(ProyectoIdTextBox.Text));
            if(encontrado != null)
            {
                proyectos = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            proyectos.Detalles.Add(new ProyectoDetalle
            {
                ProyectoId = proyectos.ProyectoId,
                TiposTareas = (TiposTareas)DescripcionComboBox.SelectedItem

            });
            Cargar();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                proyectos.Detalles.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var paso = ProyectosBLL.Guardar(proyectos);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar ", "fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(Utilidades.ToInt(ProyectoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DescripcionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DescripcionComboBox.SelectedIndex == 0)
            {
                RequerimientoTextBox.Text = ProyectosBLL.BuscarRequerimiento(1);
                TiempoTextBox.Text = Convert.ToString(ProyectosBLL.BuscarTiempo(1));
            }
            else if (DescripcionComboBox.SelectedIndex == 1)
            {
                RequerimientoTextBox.Text = ProyectosBLL.BuscarRequerimiento(2);
                TiempoTextBox.Text = Convert.ToString(ProyectosBLL.BuscarTiempo(2));
            }
            else if (DescripcionComboBox.SelectedIndex == 2)
            {
                RequerimientoTextBox.Text = ProyectosBLL.BuscarRequerimiento(3);
                TiempoTextBox.Text = Convert.ToString(ProyectosBLL.BuscarTiempo(3));
            }
            else if (DescripcionComboBox.SelectedIndex == 3)
            {
                RequerimientoTextBox.Text = ProyectosBLL.BuscarRequerimiento(4);
                TiempoTextBox.Text = Convert.ToString(ProyectosBLL.BuscarTiempo(4));
            }
        }
    }
}
