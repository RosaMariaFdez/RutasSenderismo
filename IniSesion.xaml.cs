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

namespace RutasSenderismo
{
    /// <summary>
    /// Lógica de interacción para IniSesion.xaml
    /// </summary>
    public partial class IniSesion : Window
    {
        public IniSesion()
        {
            InitializeComponent();
            txtUsuario.Focus();
            this.Closing += ExitWindow_Closing;
            App.DefineIdioma("es-ES");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Password;

            if (usuario == "admin" && contrasena == "ipo1")
            {
                MainWindow formSecundaria = new MainWindow();
                formSecundaria.Show();
                this.Hide();
            }

            else
            {
                if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtContrasena.Password))
                {
                    // feedback al usuario
                    lblEstadoLogin.Foreground = Brushes.Red;
                    lblEstadoLogin.Content = "Introduzca el usuario y la contraseña";
                }
                else
                {
                    lblEstadoLogin.Foreground = Brushes.Red;
                    lblEstadoLogin.Content = "El usuario o la contraseña no coinciden";
                    
                }
                
            }


        }

        private void cbNationalities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idioma = "";
            int cbi = cbNationalities.SelectedIndex;
            switch (cbi)
            {
                case 0:
                    idioma = "es-ES";
                    break;
                case 1:
                    idioma = "en-UK";
                    break;
            }
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
        }
        private void ExitWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            ExitWindow nuevaVentana = new ExitWindow();
            nuevaVentana.Show();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtContrasena.Focus();
            }
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
