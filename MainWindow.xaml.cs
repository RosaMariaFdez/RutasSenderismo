using RutasSenderismo.Dominio;
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
using System.Xml;
using System.Xml.Linq;

namespace RutasSenderismo
{

    public partial class MainWindow : Window
    {
        private List<Guia> listaGuias;
        private List<Ruta> listaRutas;
        private List<Excursión> listaExcursiones;

        public MainWindow()
        {
            InitializeComponent();
            /*this.initialize_guia_list();
            lstGuias.DataContext = listaGuias;*/
            this.Closing += ExitWindow_Closing;
            this.Closing += Button_Click_3;

            CargarContenidoRutas();


            //Creación de guias por defecto

            Guia guia = new Guia();
            guia.NombreGuia = "Juan";
            guia.Apellidos = "Pérez";
            guia.Imagen = new Uri("Fotos/Juan.jpg", UriKind.Relative);
            guia.Idiomas = "Español, Ingles";
            guia.Restricciones = "Ninguna";
            guia.Telefono = "123456789";
            guia.Email = "juan@example.com";
            guia.RutasRealizadas = "Ciudad Real";
            guia.RutasPorRealizar = "Puertollano";
            //guia.RutasRealizadas.Add(listaRutas[1]);
            //guia.RutasPorRealizar.Add(listaRutas[3]);
            guia.Puntuacion = 4;

            Guia guia2 = new Guia();
            guia2.NombreGuia = "Pepe";
            guia2.Apellidos = "Ballesteros";
            guia2.Imagen = new Uri("Fotos/Pepe.jpg", UriKind.Relative);
            guia2.Idiomas = "Español, Ingles";
            guia2.Restricciones = "Es tonto";
            guia2.Telefono = "123456744";
            guia2.Email = "pepe@example.com";
            guia2.RutasRealizadas="Ciudad Real";
            guia2.RutasPorRealizar="Puertollano";
            //guia2.RutasRealizadas.Add(listaRutas[0]);
            //guia2.RutasPorRealizar.Add(listaRutas[2]);
            guia2.Puntuacion = 6;
            listaGuias = new List<Guia>()
            {
            guia,guia2
            };
            lstGuias.ItemsSource = listaGuias;
            lstRutas.ItemsSource = listaRutas;
            CmbExcursiones.ItemsSource = listaRutas;
            LstExcGuias.ItemsSource = listaGuias;
            lstExc.ItemsSource = listaExcursiones;

            //Creacion de usuario

            Usuario usuario = new Usuario("Cristian", "Ballesteros", "cristian.ballesteros@alu.uclm.es", 632451726, "Fotos/cristianBalles6.jpg", "CristianBalles6");
    

        }

        //cargar las rutas
        private void CargarContenidoRutas()
        {
            listaRutas = new List<Ruta>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/rutas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaRuta = new Ruta("", "", "", 0, 0, null);
                nuevaRuta.Nombre = node.Attributes["Nombre"].Value;
                nuevaRuta.Informacion = node.Attributes["Informacion"].Value;
                nuevaRuta.Dificultad = node.Attributes["Dificultad"].Value;
                nuevaRuta.DuracionHoras = Convert.ToInt32(node.Attributes["DuracionHoras"].Value);
                nuevaRuta.DistanciaKm = Convert.ToInt32(node.Attributes["DistanciaKm"].Value);
                nuevaRuta.Imagen = new Uri(node.Attributes["Imagen"].Value, UriKind.Relative);
                listaRutas.Add(nuevaRuta);
            }
        }

        /*private void initialize_guia_list()
        {
            this.listaGuias = new List<Guia>();
            this.listaGuias.Add(new Guia("Juan", "Pérez","Español", "juan.perez@example.com",0,5,626252526,"imagen_xd","No puede andar"));

        }*/

        private void CmbExcursiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtener el elemento seleccionado en el ComboBox
            Ruta seleccion = (Ruta)CmbExcursiones.SelectedItem;

            // Agregar el elemento seleccionado al ListBox
            LstExcursiones.Items.Add(seleccion.Nombre);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Vaciar el contenido del ListBox
            LstExcursiones.Items.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 1;
            LstExcursiones.Items.Clear();
            lblExcursiones.Visibility = Visibility.Hidden;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                // Obtener los elementos seleccionados del ListBox
                listaExcursiones = new List<Excursión>();
                List<string> rutasSeleccionadas = new List<string>();
                foreach (string item in LstExcursiones.Items)
                {
                    rutasSeleccionadas.Add(item);
                }
                if (rutasSeleccionadas.Count == 0)
                {
                    throw new InvalidOperationException("No se han añadido rutas para crear la excursión.");
                }
                Guia guiaSeleccionado = new Guia();
                guiaSeleccionado = (Guia)LstExcGuias.SelectedItem;
                if (guiaSeleccionado == null)
                {
                    throw new InvalidOperationException("No se ha añadido un guia para la excursion.");
                }
                string nombreExc = txtNombreExc.Text;
                Excursión nuevaExcursion = new Excursión(rutasSeleccionadas, guiaSeleccionado, nombreExc, 0);
                lblExcursiones.Content = "La excursion ha sido creada correctamente";
                lblExcursiones.Visibility = Visibility.Visible;
                LstExcursiones.Items.Clear();
                listaExcursiones.Add(nuevaExcursion);
                lstExc.ItemsSource = null;
                lstExc.ItemsSource = listaExcursiones;

                await Task.Delay(3000); // Espera 3 segundos

                lblExcursiones.Visibility = Visibility.Hidden;

            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al crear la excursión: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lstRutas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstRutas.SelectedItem != null)
            {
                Ruta rutaSeleccionada = (Ruta)lstRutas.SelectedItem;
                txtNombre.Text = rutaSeleccionada.Nombre;
                txtInformacion.Text = rutaSeleccionada.Informacion;
                txtDificultad.Text = rutaSeleccionada.Dificultad;
                txtDistancia.Text = rutaSeleccionada.DistanciaKm.ToString();
                txtDuracion.Text = rutaSeleccionada.DuracionHoras.ToString();

            }
        }
        private void lstGuias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstGuias.SelectedItem != null)
            {
                Guia guiaSeleccionado = (Guia)lstGuias.SelectedItem;
                txtNombre2.Text = guiaSeleccionado.NombreGuia;
                txtApellidos.Text = guiaSeleccionado.Apellidos;
                txtEmail.Text = guiaSeleccionado.Email;
                txtIdiomas.Text = guiaSeleccionado.Idiomas;
                txtRestriciones.Text=guiaSeleccionado.Restricciones;
                txtTelefono2.Text = guiaSeleccionado.Telefono;
                txtRutaspR.Text = guiaSeleccionado.RutasPorRealizar;
                
                
            }
        }


        private void btnAltaGuias_Click(object sender, RoutedEventArgs e) {
            var nuevoGuia = new Guia("Nuevo Guía", "", null, "", "","",null,null,0, new Uri("Fotos/default.png", UriKind.Relative));
            listaGuias.Add(nuevoGuia);
            lstGuias.Items.Refresh();
            lstGuias.SelectedIndex = listaGuias.Count - 1;
            lstGuias.ScrollIntoView(lstGuias.Items.GetItemAt(listaGuias.Count - 1));
        }
        private void btnDarDeBaja_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer eliminar este guia?", "Eliminar guia", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                listaGuias.RemoveAt(lstGuias.SelectedIndex);
                lstGuias.SelectedIndex = lstGuias.Items.Count - 1;
                lstGuias.Items.Refresh();
            }
        }

        /*private void btnAltaGuias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnAltaGuias.IsEnabled = false;
                Guia guia = new Guia();

                // Validar el nombre
                if (txtNombre2.Text.Length > 12)
                {
                    throw new ArgumentException("El nombre no puede tener más de 12 caracteres.");
                }
                guia.NombreGuia = txtNombre2.Text;

                // Validar el teléfono
                if (txtTelefono2.Text.Length != 9 || !int.TryParse(txtTelefono2.Text, out _))
                {
                    throw new ArgumentException("El teléfono debe tener 9 dígitos y ser un número entero.");
                }
                guia.Telefono = txtTelefono2.Text;

                guia.Restricciones = txtRestriciones.Text;
                guia.Apellidos = txtApellidos.Text;
                guia.Foto = txtFoto.Text;
                guia.Email = txtEmail.Text;
                string idiomasInput = txtIdiomas.Text;
                string[] idiomasArray = idiomasInput.Split(',');
                foreach (string idioma in idiomasArray)
                {
                    guia.Idiomas.Add(idioma.Trim());
                }
                string RutasRInput = txtRutasR.Text;
                string[] RutasArray = RutasRInput.Split(',');
                foreach (string rutas1 in RutasArray)
                {
                    guia.RutasRealizadas.Add(rutas1.Trim());
                }
                string RutaspRInput = txtRutaspR.Text;
                string[] RutaspArray = RutaspRInput.Split(',');
                foreach (string rutas2 in RutaspArray)
                {
                    guia.RutasPorRealizar.Add(rutas2.Trim());
                }
                int puntuacion = (int)sldGuias.Value;
                guia.Puntuacion = puntuacion;
                listaGuias.Add(guia);
                lstGuias.ItemsSource = null;
                lstGuias.ItemsSource = listaGuias;
                LstExcGuias.ItemsSource = null;
                LstExcGuias.ItemsSource = listaGuias;
                btnAltaGuias.IsEnabled = true;
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.Message);
                btnAltaGuias.IsEnabled = true;
            }


        }*/

        /*private void btnDarDeBaja_Click(object sender, RoutedEventArgs e)
        {
            Guia guiaSeleccionada = lstGuias.SelectedItem as Guia;


            if (guiaSeleccionada != null)
            {
                listaGuias.Remove(guiaSeleccionada);
                lstGuias.ItemsSource = null;
                lstGuias.ItemsSource = listaGuias;
                LstExcGuias.ItemsSource = null;
                LstExcGuias.ItemsSource = listaGuias;
            }
        }*/


        private void ExitWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            ExitWindow nuevaVentana = new ExitWindow();
            nuevaVentana.Show();

        }

        private void Button_Click_3(object sender, EventArgs e)
        {

            IniSesion iniSesion = new IniSesion();
            iniSesion.Show();
            this.Hide();

        }

        private void btnAnadirRuta_Click(object sender, RoutedEventArgs e)
        {
            var nuevaRuta = new Ruta("Nueva ruta", "-", "-", 0, 0, new Uri("Fotos/default.png", UriKind.Relative));
            listaRutas.Add(nuevaRuta);
            lstRutas.Items.Refresh();
            lstRutas.SelectedIndex = listaRutas.Count - 1;
            lstRutas.ScrollIntoView(lstRutas.Items.GetItemAt(listaRutas.Count - 1));
        }

        private void btnEliminarRuta_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer eliminar esta ruta?", "Eliminar ruta", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                listaRutas.RemoveAt(lstRutas.SelectedIndex);
                lstRutas.SelectedIndex = lstRutas.Items.Count - 1;
                lstRutas.Items.Refresh();
            }
        }

        private void btnEliminarRutaExcursiones_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer eliminar esta ruta de la excursión?", "Eliminar ruta", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                
                LstExcursiones.Items.RemoveAt(LstExcursiones.SelectedIndex);
                LstExcursiones.SelectedIndex = lstRutas.Items.Count - 1;
                LstExcursiones.Items.Refresh();
            }
        }

        /*private void lstGuias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstGuias.SelectedItem != null)
            {
                Guia guia = (Guia)lstGuias.SelectedItem;
                txtNombre2.Text = guia.NombreGuia;
                txtApellidos.Text = guia.Apellidos;
                txtEmail.Text = guia.Email;
                imgGuia.Source = new BitmapImage(guia.Imagen);
                txtRestriciones.Text = guia.Restricciones;
                txtTelefono2.Text = guia.Telefono;
                sldGuias.Value = guia.Puntuacion;

                txtIdiomas.Text = "";
                txtRutasR.Text = "";
                txtRutaspR.Text = "";

                if (guia.Idiomas != null)
                {
                    foreach (string elemento in guia.Idiomas)
                    {
                        txtIdiomas.AppendText(elemento + ",");
                    }
                }

                if (guia.RutasPorRealizar != null)
                {
                    foreach (string elemento in guia.RutasPorRealizar)
                    {
                        txtRutaspR.AppendText(elemento);
                    }
                }

                if (guia.RutasRealizadas != null)
                {
                    foreach (string elemento in guia.RutasRealizadas)
                    {
                        txtRutasR.AppendText(elemento);
                    }
                }

            }
        }*/

        private void lstExc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstExc.SelectedItem != null)
            {
                Excursión exc = (Excursión)lstExc.SelectedItem;
                lblNombreE.Content = exc.NombreExc;
                foreach (string elemento in exc.listRutas)
                {
                    lblRutasE.Content += elemento + ",";
                }
                
                lblGuiaE.Content += exc.guiaExc.NombreGuia + " " +exc.guiaExc.Apellidos;
            }
        }

        private async void btnReservar_Click(object sender, RoutedEventArgs e)
        {
            if (lstExc.SelectedItem != null)
            {
                Excursión exc = (Excursión)lstExc.SelectedItem;
                exc.contador++;
                lblReserva.Content = "La inscripción ha sido exitosa. Numero de inscritos: " + exc.contador;
                await Task.Delay(3000); // Espera 3 segundos
                lblReserva.Content = "";
            }
        }
    }

}

