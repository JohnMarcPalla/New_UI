using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "password") 
            {
                frmMain main = new frmMain();
                main.lblCurUser.Text = textBox1.Text;
                this.Hide();
                main.Show();

            }
            else if (textBox1.Text == "user" && textBox2.Text == "pass")
            {
                frmEmployee employee = new frmEmployee();
                employee.lblCurUser.Text = textBox1.Text;
                this.Hide();
                employee.Show();
            }




        }
    }
}
