using SysEnum = System.Enum;
namespace Pokedex
{
    public partial class Form1 : Form
    {
        public enum pokemon : int
        {
            Bulbasur = 1,
            Ivysaur = 2,
            Venusaur = 3,
            Pikachu = 4,
        }
        
        public Form1()
        {
            InitializeComponent();
        }







        
        private void Form1_Load(object sender, EventArgs e)
        {
            //cargarCombo();
            //load different image in pictureBox1
            pictureBox1.Image = Image.FromFile(
                "../../../Imagenes/0.png");

        }

        








        





        
        void cargarCombo()
        {
            cmbPokemon.DataSource = SysEnum.GetValues(typeof(pokemon));
        }

        private void cmbPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int pokemonSeleccionado = (int)cmbPokemon.SelectedValue;

            //string rutaImagen = $"../../../Images/{pokemonSeleccionado}.png";

            //pcbPokemon.Image = Image.FromFile(rutaImagen);
            
            int pokemonSeleccionado = cmbPokemon.SelectedIndex;
            switch (pokemonSeleccionado)
            {
                case 0:
                    pcbPokemon.Image =
                        Image.FromFile("../../../Imagenes/1.png");
                    break;
                case 1:
                    pcbPokemon.Image =
                        Image.FromFile("../../../Imagenes/2.png");
                    break;
                case 2:
                    pcbPokemon.Image =
                        Image.FromFile("../../../Imagenes/3.png");
                    break;
            }
        }
    }
}