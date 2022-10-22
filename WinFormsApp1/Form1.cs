using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //read only all cells
            dataGridView1.ReadOnly = true;


            // fill data to Datagridview
            dataGridView1.ColumnCount = 2;
            //dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].Name = "Descripción";
            dataGridView1.Columns[1].Name = "Valor";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string[] row = new string[] { "Mouse", "1000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Teclado", "2000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Monitor", "3000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Auriculares", "4000" };
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
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addRow(txtNombre.Text, txtValor.Text); //alternative 1
            //dataGridView1.Rows.Add(txtNombre.Text, txtValor.Text); //alternative 2
        }
        private void addRow(string nombre, string valor)
        {
            String[] row = { nombre, valor };
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

        //put data in textbox on row click
        

    }
}
