using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WinSQLApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connstring = string.Format("Server=localhost; database=testdb; UID=root; password=");
            connection = new MySqlConnection(connstring);
            connection.Open();

            string query = "SELECT Nombre FROM users";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0); //first column
                comboBox1.Items.Add(name);
            }
        }


        private MySqlConnection connection = null;
        private void sqlConn_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Connection open");
          
            
        }

        private void getTablbtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM users";
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0); //first column
                string dept = reader.GetString(1); //second column
                Console.WriteLine("-> "+ name + ", " + dept);
                richTextBox1.AppendText("-> " + name + ", " + dept + "\n");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            label1.Text = monthCalendar1.SelectionRange.Start.ToString("dd MMM yyyy");
        }
    }
}
