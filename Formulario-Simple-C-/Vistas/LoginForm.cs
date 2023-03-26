using Datos;
using MySql.Data.MySqlClient;

namespace Vistas
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ConexionDB test = new();
            try
            {
                MySqlConnection m = test.conectarse();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            UsuarioDB usuarioDB = new UsuarioDB();
            string codUsuario = this.txtCodUsuario.Text;
            string contra = this.txtContrasena.Text;
            bool respuesta = usuarioDB.Login(codUsuario, contra);
            if (respuesta)
            {
                MessageBox.Show("Bienvenido", "Información correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}