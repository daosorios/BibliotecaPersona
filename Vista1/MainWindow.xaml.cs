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
using BeLife;


namespace Vista1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //lista para almacenar a las clientes
         List<Cliente> misclientes = new List<Cliente>();

        public MainWindow()
        {
            InitializeComponent();
            Limpiar();
        }


        //boton agregar a clientes 
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Cliente cli = new Cliente();

                cli.rut = txtRut.Text;
                cli.nombres = txtNombre.Text;
                cli.apellidos = txtApellidos.Text;
                cli.fechaNacimiento = (DateTime)dpFechaNac.SelectedDate;


                //me quede aqui arreglando
                Console.WriteLine();
                if (rbfemenino.IsChecked.Equals(true))
                {
                    cli.sexo = "Mujer";
                }
                else if (rbmasculino.IsChecked.Equals(true))
                {
                    cli.sexo = "Maculino";
                }


                cli.estadoCiv = cbsituacion.Text;



                misclientes.Add(cli);

                MostrarPersonas();
                Limpiar();
            }
            catch (Exception)
            {


            }


        }

        //metodo muestra clientes en la datagrid
        private void MostrarPersonas()
        {
            //las personas que se agregan a la lista se muestran aqui en el dategrid
            dgCliente.ItemsSource = misclientes;
            dgCliente.Items.Refresh();
        }

           //metodo limpiar controles
        private void Limpiar()
        {
            txtRut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            dpFechaNac.SelectedDate = DateTime.Today;
            rbfemenino.IsChecked = false;
            cbsituacion.SelectedIndex = 0;
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Limpiar();
        //}

        //boton buscar
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //busca en la coleccion al primer cliente que tenga el mismo rut
            if (txtRut.Text != string.Empty)
            {

                try
                {
                    //el metodo first busca en la coleccion al primer cliente que tenga el mismo rut
                    Persona per = misclientes.First(p => p.rut == txtRut.Text);
                    txtNombre.Text = per.nombres;
                    txtApellidos.Text = per.apellidos;
                    dpFechaNac.SelectedDate = per.fechaNaci;
                    if (per.sexo.Equals("Mujer"))
                    {
                        rbfemenino.IsChecked = true;
                    }
                    else if (per.sexo.Equals("Maculino"))
                    {
                        rbmasculino.IsChecked = true;
                    }


                }
                catch (Exception)
                {

                    MessageBox.Show("Cliente no encontrado!", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar el rut del cliente","Atención", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //boton editar
        private void bEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Persona per = misclientes.First(p => p.rut == txtRut.Text);
                per.nombres = txtNombre.Text;
                per.apellidos = txtApellidos.Text;
                per.fechaNaci = (DateTime)dpFechaNac.SelectedDate;
                //sexo
                Console.WriteLine();
                if (rbfemenino.IsChecked.Equals(true))
                {
                    per.sexo = "Mujer";
                }
                else if (rbmasculino.IsChecked.Equals(true))
                {
                    per.sexo = "Maculino";
                }
                per.estadoCiv = cbsituacion.Text;
                MessageBox.Show("Cliente Actualizado");

                //para que el datagrid se actualice con los datos editados
                MostrarPersonas();
                Limpiar();

            }
            catch
            {
                MessageBox.Show("Cliente no encontrado!");
            }
        }

        //boton eliminar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //mensaje que tiene boton si o no para confirmar eliminacion 
               MessageBoxResult eliminar= MessageBox.Show("¿Seguro de eliminar este cliente?", "Confirmar",MessageBoxButton.YesNo,MessageBoxImage.Question);
                Persona per = misclientes.First(p => p.rut == txtRut.Text);
                misclientes.Remove(per);

                if (eliminar == MessageBoxResult.Yes)
                {
                    misclientes.Remove(per);
                    MostrarPersonas();
                    Limpiar();
                    MessageBox.Show("Cliente eliminado", "Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch
            {
                MessageBox.Show("Cliente no encontrado!","Atención",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbsituacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}