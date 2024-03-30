using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab3
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUserName.Text;
            string password = tbxpwd.Text;
            var userLines = File.ReadAllLines("user.txt");
            var isValidUser = userLines.Any(line => line.Split(',')[0] == username && line.Split(',')[1] == password);

            if (isValidUser)
            {
                
                this.DialogResult = DialogResult.OK;
               
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
