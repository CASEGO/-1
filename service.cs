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
    public partial class service : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM2.mdb"; //Обозначение базы данных
        private OleDbConnection myConnection;
        public service()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//Подключение к БД
            myConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Menu f = new Menu();
            f.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Price = textBox2.Text;
            string query = "INSERT INTO Услуги ([Услуга],[Стоимость]) VALUES('" + Name + "','" + Price + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.услугиTableAdapter.Fill(this.aRM2DataSet.Услуги);
            textBox1.Clear();
            textBox2.Clear();

        }

        private void service_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRM2DataSet.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.aRM2DataSet.Услуги);
;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox5.Text);
            string query = "UPDATE Услуги SET Стоимость ='" + textBox4.Text + "' WHERE [КодУслуги] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.услугиTableAdapter.Fill(this.aRM2DataSet.Услуги);
            textBox5.Clear();
            textBox4.Clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox8.Text);
            string query = "SELECT [КодУслуги], [Услуга], [Стоимость] FROM Услуги WHERE  [КодУслуги] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox8.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox8.Text);
            string query = "DELETE FROM Услуги WHERE [КодУслуги] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.услугиTableAdapter.Fill(this.aRM2DataSet.Услуги);
            textBox8.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = услугиBindingSource1;
        }
    }
}
