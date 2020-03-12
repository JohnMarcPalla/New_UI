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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
            labelTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            design();
        }

        #region design related
        private void design()
        {
            pnlSales.Visible = false;
            pnlInventory.Visible = false;
           
        }
        private void menuHide()
        {
            if (pnlSales.Visible == true)
                pnlSales.Visible = false;
            if (pnlInventory.Visible == true)
                pnlInventory.Visible = false;
           
        }
        private void menuOpen(Panel panel)
        {
            if (panel.Visible == false)
            {
                menuHide(); panel.Visible = true;
            }
            else { panel.Visible = false; }
        }
        #endregion

        #region Click Events
        private void btnHome_Click(object sender, EventArgs e)
        {
            menuHide();
            if (activeChildform != null)
            {
                activeChildform.Close();
            }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            menuOpen(pnlSales);
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            openChildform(new frmNewTrans());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            menuOpen(pnlInventory);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Close();
            login.Show();
        }
        #endregion

        #region drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        public Form activeChildform;
        private void openChildform(Form childform)
        {
            if (activeChildform != null)
            {
                activeChildform.Close();
            }
            activeChildform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnlChildform.Controls.Add(childform);
            pnlChildform.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        
    }
}
