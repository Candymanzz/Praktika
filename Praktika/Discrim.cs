using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika
{
    public class Discrim
    {
        public void Discrm(int role)
        {
            if(role == 0)
            {
                MessageBox.Show("123");
            }
            else
            {
                LogInUser logInUser = new LogInUser();
                logInUser.Show();
            }
        }
    }
}
