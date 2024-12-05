using System;
using System.Windows.Forms;
using InfraGuard_BO.Funciones;

namespace InfraGuard_BO
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void BtnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtboxUsuario.Text;
            string password = txtboxPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Se autentica el usuario usando la clase LogIn
                bool isAuthenticated = await LogIn.AuthenticateUserAsync(username, password);

                if (isAuthenticated)
                {
                    MessageBox.Show($"Bienvenido, {username}!", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir el formulario de reportes
                    var reportesForm = new ReportesForm(); // Asegúrate de que 'ReportesForm' sea el nombre de tu formulario de reportes
                    reportesForm.Show();

                    // Ocultar el formulario actual
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al autenticar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos generados por los eventos
        private void txtboxUsuario_TextChanged(object sender, EventArgs e)
        {
            // Opcional: lógica cuando el texto cambia
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Opcional: lógica cuando se hace clic en label1
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void labelSingIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Crear una instancia del formulario que deseas abrir
            var signUpForm = new SignIn(); // Reemplaza 'SignUpForm' con el nombre de tu formulario

            // Mostrar el formulario
            signUpForm.Show();
        }
    }
}
