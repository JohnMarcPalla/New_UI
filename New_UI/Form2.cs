using System;
using System.Windows.Forms;

namespace New_UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            labelTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            design();
        }
        private void design()
        {
            pnlSales.Visible = false;
            pnlInventory.Visible = false;
            pnlAdmin.Visible = false;
        }
        private void menuHide()
        {
            if (pnlSales.Visible == true)
                pnlSales.Visible = false;
            if (pnlInventory.Visible == true)
                pnlInventory.Visible = false;
            if (pnlAdmin.Visible == true)
                pnlAdmin.Visible = false;
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

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            menuOpen(pnlAdmin);
        }
    }

}
