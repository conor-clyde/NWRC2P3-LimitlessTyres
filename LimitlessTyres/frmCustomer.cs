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
using LimitlessTyres;

namespace LimitlessTyres
{
    public partial class CustomerFrm : Form
    {
        SqlDataAdapter daCustomer;
        DataSet dsLimitlessTyres = new DataSet();
        SqlCommandBuilder cmbBCustomer;
        DataRow drCustomer;
        String connStr, sqlCustomer;
        int selectedTab = 0;
        bool custSelected = false;
        int custNoSelected = 0;

        public CustomerFrm()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void CustomerFrm_Load(object sender, EventArgs e)
        {

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = LimitlessTyres; Integrated Security = true";

            sqlCustomer = @"select * from Customer";
            daCustomer = new SqlDataAdapter(sqlCustomer, connStr);
            cmbBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsLimitlessTyres, SchemaType.Source, "Customer");
            daCustomer.Fill(dsLimitlessTyres, "Customer");

            dgvCustomers.DataSource = dsLimitlessTyres.Tables["Customer"];
            dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            MyCustomer myCustomer = new MyCustomer();
            bool ok = true;
            errP.Clear();

            try
            {
                myCustomer.CustomerNo = Convert.ToInt32(lblCustomerNoAdd.Text.Trim());
            }
            catch(MyException MyEx)
            {
                ok = false;
                errP.SetError(lblCustomerNoAdd, MyEx.toString());
            }
            try
            {
                myCustomer.CompanyName = txtCompanyName.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCompanyName, MyEx.toString());
            }
            try
            {
                myCustomer.Forename = txtForename.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtForename, MyEx.toString());
            }
            try
            {
                myCustomer.Surname = txtSurname.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtSurname, MyEx.toString());
            }
            try
            {
                myCustomer.ContactNo = txtContactNo.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtContactNo, MyEx.toString());
            }
            try
            {
                myCustomer.Town = txtTown.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTown, MyEx.toString());
            }
            try
            {
                myCustomer.Street = txtStreet.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtStreet, MyEx.toString());
            }
            try
            {
                myCustomer.County = txtCounty.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCounty, MyEx.toString());
            }
            try
            {
                myCustomer.Postcode = txtPostcode.Text.Trim(); //passed to Customer class to check
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtPostcode, MyEx.toString());
            }
            try
            {

                if(ok)
                {
                    drCustomer = dsLimitlessTyres.Tables["Customer"].NewRow();

                    drCustomer["CustomerID"] = myCustomer.CustomerNo;
                    drCustomer["CustomerType"] = myCustomer.CustomerType;
                    drCustomer["Surname"] = myCustomer.Surname;
                    drCustomer["Forename"] = myCustomer.Forename;
                    drCustomer["Street"] = myCustomer.Street;
                    drCustomer["Town"] = myCustomer.Town;
                    drCustomer["County"] = myCustomer.County;
                    drCustomer["Postcode"] = myCustomer.Postcode;
                    drCustomer["ContactNo"] = myCustomer.ContactNo;
                    drCustomer["CompanyName"] = myCustomer.CompanyName;

                    dsLimitlessTyres.Tables["Customer"].Rows.Add(drCustomer);
                    daCustomer.Update(dsLimitlessTyres, "Customer");

                    MessageBox.Show("Customer Added");

                    if (MessageBox.Show("Do you wish to add another customer?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {

                        clearAddForm();
                        getNumber(dsLimitlessTyres.Tables["Customer"].Rows.Count);

                    }
                    else
                        tabCustomers.SelectedIndex = 0;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        void clearAddForm()
        {
            cmbCustomerType.SelectedIndex = -1;
            txtForename.Clear();
            txtSurname.Clear();
            txtStreet.Clear();
            txtTown.Clear();
            txtCounty.Clear();
            txtPostcode.Clear();
            txtContactNo.Clear();
            txtCompanyName.Clear();
        }

        private void tabCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedTab = tabCustomers.SelectedIndex;

            tabCustomers.TabPages[tabCustomers.SelectedIndex].Focus();
            tabCustomers.TabPages[tabCustomers.SelectedIndex].CausesValidation = true;

            //if (dgvCustomers.SelectedRows.Count == 0 && tabCustomers.SelectedIndex == tabCustomers.TabPages[tabCustomers.SelectedIndex].CausesValidation = true);
            //else
            //{

            switch (tabCustomers.SelectedIndex)
            {
                case 0: //Display tab selected
                    {
                        dsLimitlessTyres.Tables["Customer"].Clear();
                        daCustomer.Fill(dsLimitlessTyres, "Customer");

                        break;
                    }
                case 1: //Add tab selected
                    {
                        int noRows = dsLimitlessTyres.Tables["Customer"].Rows.Count;

                        if (noRows == 0)
                            lblCustomerNoAdd.Text = "1000";
                        else
                        {
                            getNumber(noRows);
                        }

                        errP.Clear();
                        clearAddForm();
                        break;
                    }
                case 2: //Edit tab selected
                    {
                        if (custNoSelected == 0)
                        {
                            tabCustomers.SelectedIndex = 0;
                            break;
                        }
                        else
                        {
                            lblCustomerNoEdit.Text = custNoSelected.ToString();

                            drCustomer = dsLimitlessTyres.Tables["Customer"].Rows.Find(lblCustomerNoEdit.Text);

                            if (drCustomer["CustomerType"].ToString() == "General")
                                cmbCustomerType2.SelectedIndex = 0;                                
                            if (drCustomer["CustomerType"].ToString() == "Trade")
                                cmbCustomerType2.SelectedIndex = 1;
                            

                            txtForename2.Text = drCustomer["Forename"].ToString();
                            txtSurname2.Text = drCustomer["Surname"].ToString();
                            txtStreet2.Text = drCustomer["Street"].ToString();
                            txtTown2.Text = drCustomer["Town"].ToString();
                            txtCounty2.Text = drCustomer["County"].ToString();
                            txtPostcode2.Text = drCustomer["Postcode"].ToString();
                            txtContactNo2.Text = drCustomer["ContactNo"].ToString();
                            txtCompanyName2.Text = drCustomer["CompanyName"].ToString();

                            break;

                        }
                    }
            }

        }

        private void getNumber(int noRows)
        {
            drCustomer = dsLimitlessTyres.Tables["Customer"].Rows[noRows - 1];
            lblCustomerNoAdd.Text = (int.Parse(drCustomer["CustomerID"].ToString()) + 1).ToString();
        }

        void AddTabValidate(object sender, CancelEventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                custSelected = false;
                custNoSelected = 0;
            }
            else if (dgvCustomers.SelectedRows.Count == 1)
            {
                custSelected = true;
                custNoSelected = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells[0].Value);
            }
        }

        void EditTabValidate(object sender, CancelEventArgs e)
        {
            if (custSelected == false && custNoSelected == 0)
            //have to do this bit here/////////////
            //reset tab to display and put out message to select a customer
            {
                custSelected = false;
                custNoSelected = 0;
            }
            else if (dgvCustomers.SelectedRows.Count == 1)
            {
                custSelected = true;
                custNoSelected = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells[0].Value);
            }
        }

        private void CustomerFrm_Shown(object sender, EventArgs e)
        {
            tabCustomers.TabPages[0].CausesValidation = true;
            tabCustomers.TabPages[0].Validating += new CancelEventHandler(AddTabValidate);

            tabCustomers.TabPages[2].CausesValidation = true;
            tabCustomers.TabPages[2].Validating += new CancelEventHandler(EditTabValidate);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit Customer")
            {
                cmbCustomerType2.Enabled = true;
                txtForename2.Enabled = true;
                txtSurname2.Enabled = true;
                txtContactNo2.Enabled = true;
                txtStreet2.Enabled = true;
                txtTown2.Enabled = true;
                txtCounty.Enabled = true;
                txtPostcode2.Enabled = true;
                txtCompanyName2.Enabled = true;

                btnEdit.Text = "Save Customer";
            }
            else
            {
                MyCustomer myCustomer = new MyCustomer();
                bool ok = true;
                errP.Clear();

                try
                {
                    myCustomer.CustomerNo = Convert.ToInt32(lblCustomerNoEdit.Text.Trim());
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblCustomerNoEdit, MyEx.toString());
                }
                try
                {
                    myCustomer.CompanyName = txtCompanyName2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtCompanyName2, MyEx.toString());
                }
                try
                {
                    myCustomer.Forename = txtForename2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtForename2, MyEx.toString());
                }
                try
                {
                    myCustomer.Surname = txtSurname2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtSurname2, MyEx.toString());
                }
                try
                {
                    myCustomer.ContactNo = txtContactNo2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtContactNo2, MyEx.toString());
                }
                try
                {
                    myCustomer.Town = txtTown2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtTown2, MyEx.toString());
                }
                try
                {
                    myCustomer.Street = txtStreet2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtStreet2, MyEx.toString());
                }
                try
                {
                    myCustomer.County = txtCounty2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtCounty2, MyEx.toString());
                }
                try
                {
                    myCustomer.Postcode = txtPostcode2.Text.Trim(); //passed to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtPostcode2, MyEx.toString());
                }
                try
                {
                    if (ok)
                    {
                        drCustomer.BeginEdit();

                        drCustomer["CustomerID"] = myCustomer.CustomerNo;
                        drCustomer["CustomerType"] = myCustomer.CustomerType;
                        drCustomer["Surname"] = myCustomer.Surname;
                        drCustomer["Forename"] = myCustomer.Forename;
                        drCustomer["Street"] = myCustomer.Street;
                        drCustomer["Town"] = myCustomer.Town;
                        drCustomer["County"] = myCustomer.County;
                        drCustomer["Postcode"] = myCustomer.Postcode;
                        drCustomer["ContactNo"] = myCustomer.ContactNo;
                        drCustomer["CompanyName"] = myCustomer.CompanyName;

                        drCustomer.EndEdit();
                        daCustomer.Update(dsLimitlessTyres, "Customer");

                        MessageBox.Show("Customer Details Updated", "Customer");

                        cmbCustomerType2.Enabled = false;
                        txtForename2.Enabled = false;
                        txtSurname2.Enabled = false;
                        txtStreet.Enabled = false;
                        txtTown2.Enabled = false;
                        txtCounty2.Enabled = false;
                        txtPostcode2.Enabled = false;
                        txtContactNo2.Enabled = false;
                        txtCompanyName2.Enabled = false;

                        btnEdit.Text = "Edit Customer";
                        tabCustomers.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {

                MessageBox.Show("Please select a customer from the list.", "Select Customer");

            }
            else
            {

                drCustomer = dsLimitlessTyres.Tables["Customer"].Rows.Find(dgvCustomers.SelectedRows[0].Cells[0].Value);
                string tempName = drCustomer["Forename"].ToString() + " " + drCustomer["Surname"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete " + tempName + "details?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drCustomer.Delete();
                    daCustomer.Update(dsLimitlessTyres, "Customer");
                }

            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            
        }      

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            
        }     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of Customer No: " + lblCustomerNoAdd.Text + "?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)

                tabCustomers.SelectedIndex = 0;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDisplay_Click(object sender, EventArgs e)
        {
            tabCustomers.SelectedIndex = 1;
        }

        private void btnEditDisplay_Click(object sender, EventArgs e)
        {
            tabCustomers.SelectedIndex = 2;
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of Customer No: " + lblCustomerNoEdit.Text + "?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabCustomers.SelectedIndex = 0;
        }

    }
}
