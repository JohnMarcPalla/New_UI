using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
