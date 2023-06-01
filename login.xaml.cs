using System.Windows;

namespace GestionRutasSenderistas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Aquí se realizaría la lógica de autenticación
            if (AuthenticateUser(username, password))
            {
                // Si la autenticación es exitosa, abrir la ventana principal
                MainWindow mainAppWindow = new MainWindow();
                mainAppWindow.Show();
                Close();
            }
            else
            {
                txtStatus.Text = "Nombre de usuario o contraseña incorrectos.";
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Aquí se implementaría la lógica de autenticación
            // Por ejemplo, se podría verificar si los datos coinciden con una base de datos o una lista de usuarios permitidos
            return (username == "admin" && password == "admin");
        }
    }
}
