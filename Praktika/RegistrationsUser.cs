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

namespace Praktika
{
    public partial class RegistrationsUser : Form
    {
        public RegistrationsUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registrations = new Registration();
            registrations.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String login = loginFild.Text;
            String password = passwordFild.Text;

            if(login == "" || password == "")
            {
                return;
            }

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @l", db.getConnection());

            cmd.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO `users` (`id`, `login`, `password`, `role`) VALUES (NULL, @l, @p, 0)", db.getConnection());

                cmd.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
                cmd.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;

                db.openConnectin();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Успех");
                }
                else
                {
                    MessageBox.Show("Провал");
                }

                db.closeConnectin();
            }
            else
            {
                MessageBox.Show("Провал");
            }

            
        }

        private void loginFild_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
