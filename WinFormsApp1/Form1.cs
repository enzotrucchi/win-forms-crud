using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //format dd/mm/yyyy to datetimepicker
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //read only all cells
            dataGridView1.ReadOnly = true;


            // fill data to Datagridview
            dataGridView1.ColumnCount = 3;
            //dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].Name = "Descripción";
            dataGridView1.Columns[1].Name = "Valor";
            dataGridView1.Columns[2].Name = "Fecha de Vencimiento";
            

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //add rows with custom date format (dd/MM/yyyy)
           

            string[] row = new string[] { "Mouse", "1000", "01/01/2020" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Teclado", "2000", "01/01/2020" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Monitor", "3000", "22/01/2021" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Auriculares", "4000", "01/04/2022" };
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
               
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //addRow(txtNombre.Text, txtValor.Text, dateTimePicker1.Text);

            //addRow with datetimepicker in "dd/mm/yyyy" format
            addRow(txtNombre.Text, txtValor.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
        }
        private void addRow(string nombre, string valor, string fecha)
        {
            //dataGridView1.Rows.Add(nombre, valor, fecha);
            String[] row = { nombre, valor, fecha };
            dataGridView1.Rows.Add(row);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            //ask if is ok to delete
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
                dataGridView1.Refresh();
                MessageBox.Show("Modificado");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //put data in textbox on row click


    }
}
