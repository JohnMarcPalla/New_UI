using MongoDB.Driver;
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
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("chairDB");
        static IMongoCollection<userDB> collection = db.GetCollection<userDB>("usersID");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            List<userDB> list = collection.AsQueryable().ToList<userDB>();
            
            var userQuery_username = list.Any(p => String.Equals(p.Username, textBox1.Text, StringComparison.CurrentCulture));
            var userQuery_password = list.Any(p => String.Equals(p.Password, textBox2.Text, StringComparison.CurrentCulture));
            if (textBox1.Text == "admin" && textBox2.Text == "password")
            {
                frmMain main = new frmMain();
                main.lblCurUser.Text = textBox1.Text;
                this.Hide();
                main.Show();

            }
            else if (userQuery_username && userQuery_password == true)
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
