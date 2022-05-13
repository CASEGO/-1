using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Курсач
{
    public partial class tarif : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ARM2.mdb"; //Создание параметров подключения к базе данных
        private OleDbConnection myConnection;
        public tarif()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Menu f = new Menu();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tarif_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRM2DataSet.Тарифы". При необходимости она может быть перемещена или удалена.
            this.тарифыTableAdapter.Fill(this.aRM2DataSet.Тарифы);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "SELECT [КодТарифа], [Наименование], [Абонентская плата], [Скорость] FROM Тарифы WHERE  [КодТарифа] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = тарифыBindingSource1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Тарифы WHERE [КодТарифа] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = тарифыBindingSource1;
            this.тарифыTableAdapter.Fill(this.aRM2DataSet.Тарифы);
            textBox1.Clear();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox3.Text);
            string query = "UPDATE Тарифы SET [Абонентская плата] ='" + textBox2.Text + "' WHERE [КодТарифа] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.тарифыTableAdapter.Fill(this.aRM2DataSet.Тарифы);
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
