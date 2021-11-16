using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsYes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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
            string fio = textBox1.Text;
            string login = textBox2.Text;
            string password = textBox3.Text;
            string password2 = textBox4.Text;

            if (password == "")
            {
                MessageBox.Show("Введите пароль", "Предупреждение");
            }
            else if (password != password2)
            {
                MessageBox.Show("Пароли не совпадают", "Предупреждение");
            }
            else if (password2 == "")
            {
                MessageBox.Show("Проверьте пароль", "Предупреждение");
            }

            if (fio == "")
            {
                MessageBox.Show("Как вас зовут?", "Предупреждение");
            }
            else if (login == "")
            {
                MessageBox.Show("Ваш логин пустой", "Предупреждение");
            }


            if (login != "" && password != "" && password2 != "")
            {
                string connect = "server=192.168.4.211;user=student;database=shop_kurenkov;password=12345;";

                MySqlConnection conn = new MySqlConnection(connect);

                conn.Open();

                string sql = "INSERT INTO `users` (`login`,`password`,`fio`)  values (@uL,@uP,@uF)";


                MySqlCommand command = new MySqlCommand(sql, conn);

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("@uF", MySqlDbType.VarChar).Value = fio;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Вы зарегистрировались", "Уведомление");
                }
                else
                {
                    MessageBox.Show("Это провал", "Сообщение");
                }
                conn.Close();

            }
            else
            {
                MessageBox.Show("Ошибка", "Уведомление");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 autoreg = new Form1();
            autoreg.ShowDialog();
            this.Close();
        }
    }
}
