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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
            labelTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            design();
        }
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            menuHide();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            menuOpen(pnlSales);
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
    }
}
