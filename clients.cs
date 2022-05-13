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
    public partial class clients : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM2.mdb";//Обозначение параметров подключения к БД
        private OleDbConnection myConnection;
        public clients()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//Открытие подключения к БД
            myConnection.Open();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            Menu f = new Menu();
            f.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 af = new Form1();
            af.Owner = this;
            af.Show();
        }

        private void clients_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRM2DataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.aRM2DataSet.Клиенты);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox4.Text);
            string query = "SELECT [id клиента], ФИО, Тарифы, [Стоимость тарифа] FROM Клиенты WHERE  [id клиента] LIKE '%" + kod + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox4.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox4.Text);
            string query = "DELETE FROM Клиенты WHERE [id клиента] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
           dataGridView1.DataSource = клиентыBindingSource1;
            this.клиентыTableAdapter.Fill(this.aRM2DataSet.Клиенты);
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
             myConnection.Open();
             dataGridView1.DataSource = клиентыBindingSource1;
           this.клиентыTableAdapter.Fill(this.aRM2DataSet.Клиенты);
        }

        private void clients_Activated(object sender, EventArgs e)
        {
            this.клиентыTableAdapter.Fill(this.aRM2DataSet.Клиенты);
        }
    }
}
