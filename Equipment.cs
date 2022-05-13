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
    public partial class Equipment : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ARM2.mdb"; //Создание параметров подключения к базе данных
        private OleDbConnection myConnection;
        public Equipment()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRM2DataSet.Оборудование". При необходимости она может быть перемещена или удалена.
            this.оборудованиеTableAdapter.Fill(this.aRM2DataSet.Оборудование);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox5.Text);
            string query = "UPDATE Оборудование SET Стоимость ='" + textBox4.Text + "' WHERE [Код оборудования] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.оборудованиеTableAdapter.Fill(this.aRM2DataSet.Оборудование);
            textBox5.Clear();
            textBox4.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox8.Text);
            string query = "SELECT [Код Оборудования], [Название], [Стоимость] FROM Оборудование WHERE  [Код Оборудования] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox8.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = оборудованиеBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox8.Text);
            string query = "DELETE FROM Оборудование WHERE [Код оборудования] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = оборудованиеBindingSource;
            this.оборудованиеTableAdapter.Fill(this.aRM2DataSet.Оборудование);
            textBox8.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Price = textBox2.Text;
            string query = "INSERT INTO Оборудование ([Название],[Стоимость]) VALUES('" + Name + "','" + Price + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.оборудованиеTableAdapter.Fill(this.aRM2DataSet.Оборудование);
            textBox1.Clear();
            textBox2.Clear();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
