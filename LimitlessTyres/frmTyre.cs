using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LimitlessTyres
{
    public partial class frmTyre : Form
    {
        DataRow drTyre;
        DataSet dsLimitlessTyres = new DataSet();
        SqlCommandBuilder cmdBTyre, cmdBTyreType, cmdBSupplier;
        SqlDataAdapter daTyre, daTyreType, daSupplier;
        String connStr, sqlTyre, sqlTyreType, sqlSupplier, tyreNoSelected = "0";

        public frmTyre()
        {
            InitializeComponent();
        }

        private void frmTyre_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = LimitlessTyres; Integrated Security = true";

            //Set up simple dataset with no parameters for tyre
            sqlTyre = @"select * from Tyre";
            daTyre = new SqlDataAdapter(sqlTyre, connStr);
            cmdBTyre = new SqlCommandBuilder(daTyre);
            daTyre.FillSchema(dsLimitlessTyres, SchemaType.Source, "Tyre");
            daTyre.Fill(dsLimitlessTyres, "Tyre");

            //Set up simple dataset with no parameters for tyre type
            sqlTyreType = @"select * from TyreType";
            daTyreType = new SqlDataAdapter(sqlTyreType, connStr);
            cmdBTyreType = new SqlCommandBuilder(daTyreType);
            daTyreType.FillSchema(dsLimitlessTyres, SchemaType.Source, "TyreType");
            daTyreType.Fill(dsLimitlessTyres, "TyreType");

            //Set up simple dataset with no parameters for supplier
            sqlSupplier = @"select * from Supplier";
            daSupplier = new SqlDataAdapter(sqlSupplier, connStr);
            cmdBSupplier = new SqlCommandBuilder(daSupplier);
            daSupplier.FillSchema(dsLimitlessTyres, SchemaType.Source, "Supplier");
            daSupplier.Fill(dsLimitlessTyres, "Supplier");

            //Set data grid view
            dgvTyre.DataSource = dsLimitlessTyres.Tables["Tyre"];

            //Auto resize data grid view columns
            dgvTyre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //Fill tyre type combo box in add tab
            cmbAddTyreType.DataSource = dsLimitlessTyres.Tables["TyreType"];
            cmbAddTyreType.ValueMember = "TyreTypeCode";
            cmbAddTyreType.DisplayMember = "TyreTypeDesc";

            //Fill supplier combo box in add tab
            cmbAddSupplier.DataSource = dsLimitlessTyres.Tables["Supplier"];
            cmbAddSupplier.ValueMember = "SupplierID";
            cmbAddSupplier.DisplayMember = "SupplierName";

            //Fill tyre type combo box in edit tab
            cmbEditTyreType.DataSource = dsLimitlessTyres.Tables["TyreType"];
            cmbEditTyreType.ValueMember = "TyreTypeCode";
            cmbEditTyreType.DisplayMember = "TyreTypeDesc";

            //Fill supplier combo box in edit tab
            cmbEditSupplier.DataSource = dsLimitlessTyres.Tables["Supplier"];
            cmbEditSupplier.ValueMember = "SupplierID";
            cmbEditSupplier.DisplayMember = "SupplierName";

            tbcTyre.SelectedIndex = 1;
            tbcTyre.SelectedIndex = 0;
        }

        private void tbcTyre_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbcTyre.TabPages[tbcTyre.SelectedIndex].Focus();
            tbcTyre.TabPages[tbcTyre.SelectedIndex].CausesValidation = true;

            switch (tbcTyre.SelectedIndex)
                case 0:
                    dsLimitlessTyres.Tables["Tyre"].Clear();
                    daTyre.Fill(dsLimitlessTyres, "Tyre");

                    break;
                case 1:
                    errP.Clear();
                    clearAddForm();

                    break;
                case 2:

                    //Find selected tyre
                    drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(tyreNoSelected);

                    //Fill in the details of the selected tyre
                    cmbEditWidth.Text = drTyre["TyreID"].ToString().Substring(0, 3);
                    cmbEditProfile.Text = drTyre["TyreID"].ToString().Substring(4, 2);
                    cmbEditDiameter.Text = drTyre["TyreID"].ToString().Substring(7, 2);
                    cmbEditSpeed.Text = drTyre["TyreID"].ToString().Substring(10, 1);

                    DataRow drTyreType = dsLimitlessTyres.Tables["TyreType"].Rows.Find(drTyre["TyreTypeCode"].ToString());
                    cmbEditTyreType.Text = drTyreType["TyreTypeDesc"].ToString();

                    DataRow drSupplier = dsLimitlessTyres.Tables["Supplier"].Rows.Find(drTyre["SupplierID"].ToString());
                    cmbEditSupplier.Text = drSupplier["SupplierName"].ToString();

                    txtEditDesc.Text = drTyre["TyreDesc"].ToString();
                    nudEditPrice.Text = drTyre["TyrePrice"].ToString();
                    nudEditStock.Text = drTyre["QtyInStock"].ToString();

                    cmbEditWidth.Enabled = false;
                    cmbEditProfile.Enabled = false;
                    cmbEditDiameter.Enabled = false;
                    cmbEditSpeed.Enabled = false;
                    cmbEditTyreType.Enabled = false;
                    cmbEditSupplier.Enabled = false;
                    txtEditDesc.Enabled = false;
                    nudEditPrice.Enabled = false;
                    nudEditStock.Enabled = false;

                    btnEditEdit.Text = "Edit Tyre";

                    break;
        }

        private void frmTyre_Shown(object sender, EventArgs e)
        {
            tbcTyre.TabPages[0].CausesValidation = true;
            tbcTyre.TabPages[0].Validating += new CancelEventHandler(AddTabValidate);

            tbcTyre.TabPages[2].CausesValidation = true;
            tbcTyre.TabPages[2].Validating += new CancelEventHandler(EditTabValidate);
        }

        void AddTabValidate(object sender, CancelEventArgs e)
        {
            if (dgvTyre.SelectedRows.Count == 0)
                tyreNoSelected = "0";
            else if (dgvTyre.SelectedRows.Count == 1)
                tyreNoSelected = Convert.ToString(dgvTyre.SelectedRows[0].Cells[0].Value);
        }

        void EditTabValidate(object sender, CancelEventArgs e)
        {
            if (dgvTyre.SelectedRows.Count == 0)
                tyreNoSelected = "0";
            else if (dgvTyre.SelectedRows.Count == 1)
                tyreNoSelected = Convert.ToString(dgvTyre.SelectedRows[0].Cells[0].Value);
        }

        //Display tab button panel
        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tbcTyre.SelectedIndex = 1;
        }

        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            //Check if a tyre has been selected
            if (dgvTyre.SelectedRows.Count == 0)
                MessageBox.Show("Please select a tyre from the list.", "Select Tyre");
            else
                tbcTyre.SelectedIndex = 2;
        }

        private void btnDisplayDelete_Click(object sender, EventArgs e)
        {
            //Check if a tyre has been selected
            if (dgvTyre.SelectedRows.Count == 0)
                MessageBox.Show("Please select a tyre from the list.", "Select Tyre");
            else
            {
                drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(dgvTyre.SelectedRows[0].Cells[0].Value);

                if (MessageBox.Show("Confirm deletion of " + drTyre["TyreID"].ToString() + ": " + drTyre["TyreDesc"].ToString() + "?", "Delete Tyre", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drTyre.Delete();
                    daTyre.Update(dsLimitlessTyres, "Tyre");
                }
            }
        }

        //User feedback
        private void btnDisplayAdd_MouseEnter(object sender, EventArgs e)
        {
            pcbDisplayAddLine.Visible = true;
        }

        private void btnDisplayAdd_MouseLeave(object sender, EventArgs e)
        {
            pcbDisplayAddLine.Visible = false;
        }

        private void btnDisplayEdit_MouseEnter(object sender, EventArgs e)
        {
            pcbDisplayEditLine.Visible = true;
        }

        private void btnDisplayEdit_MouseLeave(object sender, EventArgs e)
        {
            pcbDisplayEditLine.Visible = false;
        }

        private void btnDisplayDelete_MouseEnter(object sender, EventArgs e)
        {
            pcbDisplayDeleteLine.Visible = true;
        }

        private void btnDisplayDelete_MouseLeave(object sender, EventArgs e)
        {
            pcbDisplayDeleteLine.Visible = false;
        }

        //Add tab
        void clearAddForm()
        {
            cmbAddWidth.SelectedIndex = -1;
            cmbAddProfile.SelectedIndex = -1;
            cmbAddDiameter.SelectedIndex = -1;
            cmbAddSpeed.SelectedIndex = -1;
            cmbAddTyreType.SelectedIndex = -1;
            cmbAddSupplier.SelectedIndex = -1;
            txtAddDesc.Clear();
            nudAddPrice.Value = 0;
            nudAddStock.Value = 0;
        }

        //Button panel
        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            MyTyre myTyre = new MyTyre();
            bool ok = true;
            errP.Clear();

            try
            {
                foreach (DataRow dr in dsLimitlessTyres.Tables["Tyre"].Rows)
                {
                    bool found = false;

                    if (dr["TyreID"].ToString() == cmbAddWidth.Text.Trim() + "/" + cmbAddProfile.Text.Trim() + "R" + cmbAddDiameter.Text.Trim() + " " + cmbAddSpeed.Text.Trim())
                        found = true;

                    if (!found)
                    {
                        myTyre.TyreID = cmbAddWidth.Text.Trim() + "/" + cmbAddProfile.Text.Trim() + "R" + cmbAddDiameter.Text.Trim() + " " + cmbAddSpeed.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Tyre ID: " + cmbAddWidth.Text.Trim() + "/" + cmbAddProfile.Text.Trim() + "R" + cmbAddDiameter.Text.Trim() + " " + cmbAddSpeed.Text.Trim() + " already exists.", "Add Tyre");
                        ok = false;
                        break;
                    }
                }
            }
            catch (MyException MyEx)
            {
                ok = false;

                if (cmbAddWidth.SelectedIndex == -1)
                    errP.SetError(cmbAddWidth, MyEx.toString());
                if (cmbAddProfile.SelectedIndex == -1)
                    errP.SetError(cmbAddProfile, MyEx.toString());
                if (cmbAddDiameter.SelectedIndex == -1)
                    errP.SetError(cmbAddDiameter, MyEx.toString());
                if (cmbAddSpeed.SelectedIndex == -1)
                    errP.SetError(cmbAddSpeed, MyEx.toString());
            }

            try
            {
                myTyre.TyreTypeCode = Convert.ToString(cmbAddTyreType.SelectedValue);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddTyreType, MyEx.toString());
            }

            try
            {
                myTyre.SupplierID = Convert.ToInt32(cmbAddSupplier.SelectedValue);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddSupplier, MyEx.toString());
            }

            try
            {
                myTyre.TyreDesc = txtAddDesc.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddDesc, MyEx.toString());
            }

            try
            {
                myTyre.TyrePrice = Convert.ToDouble(nudAddPrice.Text.Trim());
            }


            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(nudAddPrice, MyEx.toString());
            }

            try
            {
                myTyre.QtyInStock = Convert.ToInt32(nudAddStock.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(nudAddStock, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drTyre = dsLimitlessTyres.Tables["Tyre"].NewRow();

                    drTyre["TyreID"] = myTyre.TyreID;
                    drTyre["TyreTypeCode"] = myTyre.TyreTypeCode;
                    drTyre["SupplierID"] = myTyre.SupplierID;
                    drTyre["TyreDesc"] = myTyre.TyreDesc;
                    drTyre["TyrePrice"] = myTyre.TyrePrice;
                    drTyre["QtyInStock"] = myTyre.QtyInStock;

                    dsLimitlessTyres.Tables["Tyre"].Rows.Add(drTyre);
                    daTyre.Update(dsLimitlessTyres, "Tyre");

                    MessageBox.Show("Tyre Added");

                    if (MessageBox.Show("Do you want to add another Tyre?", "AddTyre", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                    }
                    else
                        tbcTyre.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of a new tyre?", "Cancel Addition", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tbcTyre.SelectedIndex = 0;
        }

        //User feedback
        private void btnAddAdd_MouseEnter(object sender, EventArgs e)
        {
            pcbAddAddLine.Visible = true;
        }

        private void btnAddAdd_MouseLeave(object sender, EventArgs e)
        {
            pcbAddAddLine.Visible = false;
        }

        private void btnAddCancel_MouseEnter(object sender, EventArgs e)
        {
            pcbAddCancelLine.Visible = true;
        }

        private void btnAddCancel_MouseLeave(object sender, EventArgs e)
        {
            pcbAddCancelLine.Visible = false;
        }

        //Edit tab button panel
        private void btnEditEdit_Click(object sender, EventArgs e)
        {
            if (btnEditEdit.Text == "Edit Tyre")
            {
                cmbEditWidth.Enabled = true;
                cmbEditProfile.Enabled = true;
                cmbEditDiameter.Enabled = true;
                cmbEditSpeed.Enabled = true;
                cmbEditTyreType.Enabled = true;
                cmbEditSupplier.Enabled = true;
                txtEditDesc.Enabled = true;
                nudEditPrice.Enabled = true;
                nudEditStock.Enabled = true;

                btnEditEdit.Text = "Save Tyre";
            }
            else
            {
                MyTyre myTyre = new MyTyre();
                bool ok = true;
                errP.Clear();

                try
                {
                    myTyre.TyreID = cmbEditWidth.Text.Trim() + "/" + cmbEditProfile.Text.Trim() + "R" + cmbEditDiameter.Text.Trim() + " " + cmbEditSpeed.Text.Trim();
                }
                catch (MyException MyEx)
                {
                    ok = false;

                    if (cmbEditWidth.SelectedIndex == -1)
                        errP.SetError(cmbAddWidth, MyEx.toString());
                    if (cmbEditProfile.SelectedIndex == -1)
                        errP.SetError(cmbAddProfile, MyEx.toString());
                    if (cmbEditDiameter.SelectedIndex == -1)
                        errP.SetError(cmbAddDiameter, MyEx.toString());
                    if (cmbEditSpeed.SelectedIndex == -1)
                        errP.SetError(cmbAddSpeed, MyEx.toString());
                }

                try
                {
                    myTyre.TyreTypeCode = Convert.ToString(cmbEditTyreType.SelectedValue);
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditTyreType, MyEx.toString());
                }

                try
                {
                    myTyre.SupplierID = Convert.ToInt32(cmbEditSupplier.SelectedValue);
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditSupplier, MyEx.toString());
                }

                try
                {
                    myTyre.TyreDesc = txtEditDesc.Text.Trim();
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditDesc, MyEx.toString());
                }

                try
                {
                    myTyre.TyrePrice = Convert.ToDouble(nudEditPrice.Text.Trim());
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(nudEditPrice, MyEx.toString());
                }

                try
                {
                    myTyre.QtyInStock = Convert.ToInt32(nudEditStock.Text.Trim());
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(nudEditStock, MyEx.toString());
                }

                try
                {
                    if (ok)
                    {
                        drTyre.BeginEdit();

                        drTyre["TyreID"] = myTyre.TyreID;
                        drTyre["TyreTypeCode"] = myTyre.TyreTypeCode;
                        drTyre["SupplierID"] = myTyre.SupplierID;
                        drTyre["TyreDesc"] = myTyre.TyreDesc;
                        drTyre["TyrePrice"] = myTyre.TyrePrice;
                        drTyre["QtyInStock"] = myTyre.QtyInStock;

                        drTyre.EndEdit();
                        daTyre.Update(dsLimitlessTyres, "Tyre");

                        MessageBox.Show("Tyre Details Updated", "Tyre");

                        cmbEditWidth.Enabled = false;
                        cmbEditProfile.Enabled = false;
                        cmbEditDiameter.Enabled = false;
                        cmbEditSpeed.Enabled = false;
                        cmbEditTyreType.Enabled = false;
                        cmbEditSupplier.Enabled = false;
                        txtEditDesc.Enabled = false;
                        nudEditPrice.Enabled = false;
                        nudEditStock.Enabled = false;

                        btnEditEdit.Text = "Edit Tyre";
                        tbcTyre.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Stop editing this tyre?", "Cancel Edit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tbcTyre.SelectedIndex = 0;
        }

        //User feedback
        private void btnEditEdit_MouseEnter(object sender, EventArgs e)
        {
            pcbEditEditLine.Visible = true;
        }

        private void btnEditEdit_MouseLeave(object sender, EventArgs e)
        {
            pcbEditEditLine.Visible = false;
        }

        private void btnEditCancel_MouseEnter(object sender, EventArgs e)
        {
            pcbEditCancelLine.Visible = true;
        }

        private void btnEditCancel_MouseLeave(object sender, EventArgs e)
        {
            pcbEditCancelLine.Visible = false;
        }
    }
}
