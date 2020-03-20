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
using BibliotecaPersona;


namespace Vista1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //lista para almacenar a las clientes
        List<Persona> misclientes = new List<Persona>();

        public MainWindow()
        {
            InitializeComponent();
            Limpiar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Persona per = new Persona();

                per.rut = txtRut.Text;
                per.nombres = txtNombre.Text;
                per.apellidos = txtApellidos.Text;
                per.fechaNaci = (DateTime)dpFechaNac.SelectedDate;

                Console.WriteLine();
                if (rbfemenino.IsChecked.Equals(true))
                {
                    per.sexo = "Mujer";
                }
                else if (rbmasculino.IsChecked.Equals(true))
                {
                    per.sexo = "Maculino";
                }

                Console.WriteLine("dfxdfxdf");
                per.estadoCiv=cbsituacion.Text;

                

                misclientes.Add(per);

                MostrarPersonas();
                Limpiar();
            }
            catch (Exception )
            {
              
                
            }
 

        }

        private void MostrarPersonas()
        {
            //las personas que se agregan a la lista se muestran aqui en el dategrid
            dgCliente.ItemsSource = misclientes;
            dgCliente.Items.Refresh();
        }

        private void Limpiar()
        {
            txtRut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            dpFechaNac.SelectedDate = DateTime.Today;
            rbfemenino.IsChecked = false;
            cbsituacion.SelectedIndex =0 ;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

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

                    MessageBox.Show("Cliente no encontrado !");
                }
               
            }
            else
            {
                MessageBox.Show("Debe ingresar el rut del cliente");
            }
        }
    }  
}
