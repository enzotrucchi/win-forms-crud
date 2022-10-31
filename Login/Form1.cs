using System.Text.RegularExpressions;
using System.IO;

namespace Login
{
    public partial class Form1 : Form
    {
        /*
         * Una expresión regular es una secuencia de caracteres que define un patrón de búsqueda sobre un texto.
         * Por lo tanto a esta secuencia de caracteres la denominamos patrón.
         * 
         * Cuando definimos expresiones regulares debemos entender que lo que estamos haciendo es buscar coincidencias de un patrón dentro de un texto, la cual es una cadena de caracteres dentro de un texto, ya sea en una variable string o en un fichero.
         * 
         * 
         */
        static Regex validarEmail = esEmail();
        int intentos = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private static Regex esEmail()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        private string readFile()
        {
            //using (StreamReader reader = new StreamReader("../../../Fichero.txt"))
            string fileReader = File.ReadAllText("../../../Usuario.txt");

            return fileReader;
        }

         private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioDB = "";
            string passwordDB = "";
            
            string fileReader = readFile();

            usuarioDB = fileReader.Split(';')[0];
            passwordDB = fileReader.Split(';')[1];
            
            if (validarEmail.IsMatch(txtUsuario.Text) != true)
            {
                MessageBox.Show("No es un email", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return;
            }

            if (txtPassword.Text == "" || txtUsuario.Text == "")
            {
                MessageBox.Show("Completá los campos", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
                return;
            }

            if (txtUsuario.Text == usuarioDB
                && txtPassword.Text == passwordDB)
            {
                MessageBox.Show("Login correcto");
            }
            else
            {
                intentos++;
                MessageBox.Show($"Login incorrecto. Intentos: {intentos}");

                if (intentos == 3)
                {
                    MessageBox.Show("Demasiados intentos");
                    Application.Exit();
                }
            }



            //if (txtUsuario.Text == "mail@gmail.com"
            //    && txtPassword.Text == "1234")
            //{
            //    MessageBox.Show("Login correcto");
            //}
            //else
            //{
            //    intentos++;
            //    MessageBox.Show($"Login incorrecto. Intentos: {intentos}");

            //    if (intentos == 3)
            //    {
            //        MessageBox.Show("Demasiados intentos");
            //        Application.Exit();
            //    }
            //}
        }
    }
}