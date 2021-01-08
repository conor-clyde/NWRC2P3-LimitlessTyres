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
    public partial class frmServices : Form
    {
        public frmServices()
        {
            InitializeComponent();
        }

        private void frmServices_Load(object sender, EventArgs e)
        {

            int[] slots = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int day = 3, time = 5, noSlots = 3;

            for (int r = 0; r <= 10; r++)
            {
                dgvServices.Rows.Add(new object[] { "", "", "", "", "" });
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dgvServices.Rows[j].Cells[i].Value = DBNull.Value;
                    dgvServices.Rows[j].Cells[i].Style.BackColor = Color.Ivory;
                }
            }


            for (int i = 0; i < 5; i++)
            {
                if (i == day)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (j == time)
                        {
                            for (int k = j; k < j + noSlots; k++)
                            {
                                dgvServices.Rows[k].Cells[i].Value = DBNull.Value;
                                dgvServices.Rows[k].Cells[i].Style.BackColor = Color.HotPink;
                            }
                        }

                    }
                }
            }
        }
    }
}

