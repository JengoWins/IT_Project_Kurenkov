using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsYes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            if (user == "")
            {
                MessageBox.Show("Где логин,Либовский!?", "Предупреждение");
            }
            else
            {
                string connect = "server=192.168.4.211;user=student;database=shop_kurenkov;password=12345;";

                MySqlConnection conn = new MySqlConnection(connect);

                conn.Open();


                string passwords = textBox2.Text;
                string sql = "SELECT `password` FROM `users` WHERE login=@uL";


                MySqlCommand command = new MySqlCommand(sql, conn);

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user;

                string password = command.ExecuteScalar().ToString();

                if (password == passwords)
                {
                    //Console.WriteLine(password);
                    conn.Close();
                    MessageBox.Show("Он работает!", "Уведомление");
                }
                else if (password != passwords)
                {
                    conn.Close();
                    MessageBox.Show("Неверный пароль", "Предупреждение");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 autoreg = new Form2();
            autoreg.ShowDialog();
            this.Close();
        }
    }
}
