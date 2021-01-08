using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessTyres
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnNavOrder_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            pnlForm.Controls.Add(frm);
            frm.Show();
        }

        private void btnNavTyre_Click(object sender, EventArgs e)
        {
            frmTyre frm = new frmTyre();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            pnlForm.Controls.Add(frm);
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNavHome_MouseEnter(object sender, EventArgs e)
        {
            pcbNavHomeLine.Visible = true;
        }

        private void btnNavHome_MouseLeave(object sender, EventArgs e)
        {
            pcbNavHomeLine.Visible = false;
        }

        private void btnNavCust_MouseEnter(object sender, EventArgs e)
        {
            pcbNavCustLine.Visible = true;
        }

        private void btnNavCust_MouseLeave(object sender, EventArgs e)
        {
            pcbNavCustLine.Visible = false;
        }

        private void btnNavOrder_MouseEnter(object sender, EventArgs e)
        {
            pcbNavOrderLine.Visible = true;
        }

        private void btnNavOrder_MouseLeave(object sender, EventArgs e)
        {
            pcbNavOrderLine.Visible = false;
        }

        private void btnNavBooking_MouseEnter(object sender, EventArgs e)
        {
            pcbNavBookingLine.Visible = true;
        }

        private void btnNavBooking_MouseLeave(object sender, EventArgs e)
        {
            pcbNavBookingLine.Visible = false;
        }

        private void btnNavTyre_MouseEnter(object sender, EventArgs e)
        {
            pcbNavTyreLine.Visible = true;
        }

        private void btnNavTyre_MouseLeave(object sender, EventArgs e)
        {
            pcbNavTyreLine.Visible = false;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            pcbExitLine.Visible = true;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            pcbExitLine.Visible = false;
        }


        private void btnNavHome_Click(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            pnlForm.Controls.Add(frm);
            frm.Show();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            pnlForm.Controls.Add(frm);
            frm.Show();
        }

        private void btnNavCust_Click(object sender, EventArgs e)
        {
            CustomerFrm frm = new CustomerFrm();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            pnlForm.Controls.Add(frm);
            frm.Show();
        }

        private void btnNavBooking_Click(object sender, EventArgs e)
        {
            frmServices frm = new frmServices();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            pnlForm.Controls.Add(frm);
            frm.Show();
        }
    }
}
