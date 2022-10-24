using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using SysEnum = System.Enum;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public enum estados : int
        {
            STOCK = 1,
            FALTANTE = 2,
            REVISION = 3,
        }

        
        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = SysEnum.GetValues(typeof(estados));
            
            //format dd/mm/yyyy to datetimepicker
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //read only all cells
            dataGridView1.ReadOnly = true;


            // fill data to Datagridview
            dataGridView1.ColumnCount = 4;
            //dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].Name = "Descripción";
            dataGridView1.Columns[1].Name = "Valor";
            dataGridView1.Columns[2].Name = "Fecha de Vencimiento";
            dataGridView1.Columns[3].Name = "Estado";
            
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string[] row = new string[] { "Mouse", "1000", "01/01/2020", "STOCK" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Teclado", "2000", "01/01/2020", "STOCK" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Monitor", "3000", "22/01/2021", "STOCK" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Auriculares", "4000", "01/04/2022", "REVISION" };
            dataGridView1.Rows.Add(row);

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Click Data";
            btn.Text = "Click Here";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                
                MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //muestra la info de la fila seleccionada en los textbox
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Descripción"].Value.ToString();
                txtValor.Text = row.Cells["Valor"].Value.ToString();

                //fill datetimePicker with 3 column value
                dateTimePicker1.Value = DateTime.ParseExact(row.Cells["Fecha de Vencimiento"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //select combobox with selected option
                comboBox1.SelectedIndex = comboBox1.FindStringExact(row.Cells["Estado"].Value.ToString());


            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //add row with estado from combobox
            addRow(txtNombre.Text, txtValor.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"), comboBox1.SelectedItem.ToString());

        }
        private void addRow(string nombre, string valor, string fecha, string estado)
        {
          
            String[] row = { nombre, valor, fecha, estado };
            dataGridView1.Rows.Add(row);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            
            string message = "¿Confirmás la eliminación?";
            string title = "Eliminar producto";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                int selectedIndex = dataGridView1.CurrentCell.RowIndex;
                if (selectedIndex > -1)
                {
                    dataGridView1.Rows.RemoveAt(selectedIndex);
                    dataGridView1.Refresh();
                }
            }            
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            if (selectedIndex > -1)
            {
                dataGridView1.Rows[selectedIndex].Cells[0].Value = txtNombre.Text;
                dataGridView1.Rows[selectedIndex].Cells[1].Value = txtValor.Text;
                dataGridView1.Rows[selectedIndex].Cells[2].Value = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                dataGridView1.Rows[selectedIndex].Cells[3].Value = comboBox1.SelectedItem.ToString();
                
                dataGridView1.Refresh();
                MessageBox.Show("Modificado");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
