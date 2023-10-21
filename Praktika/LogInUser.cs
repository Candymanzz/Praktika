using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika
{
    public partial class LogInUser : Form
    {
        public LogInUser()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            String login = loginFild.Text;
            String password = passwordFild.Text;

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @l AND `password` = @p", db.getConnection());
            
            cmd.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
            cmd.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                MessageBox.Show("Успех");
            }
            else
            {
                MessageBox.Show("Провал");
                return;
            }

            Discrim discrim = new Discrim();

            string getRole;
            
            db.openConnectin();

            cmd = new MySqlCommand("SELECT role FROM `users` WHERE `login` = @l", db.getConnection());

            cmd.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;

            getRole = cmd.ExecuteScalar().ToString();

            db.closeConnectin();

            discrim.Discrm(int.Parse(getRole));

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registrations = new Registration();
            registrations.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
