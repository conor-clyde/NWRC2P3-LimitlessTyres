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
    public partial class frmOrder : Form
    {
        Button[] btns = new Button[26];
        DataSet dsLimitlessTyres = new DataSet();
        DataRow drCustomer, drTyre, drOrder, drOrderDet;
        SqlCommand cmdCustomerPar, cmdTyrePar, cmdOrderPar, cmdOrderDetPar;
        SqlCommandBuilder cmdBOrder, cmdBCustomerType, cmdBCustomer, cmdBTyre, cmdBTyreType;
        SqlConnection conn;
        SqlDataAdapter daNames, daCustomerPar, daOrder, daOrderDet, daCustomerType, daCustomer, daTyre, daTyrePar, daTyreType, daOrderPar, daOrderDetPar;
        String sqlNames, sqlCustomerPar, sqlOrder, sqlOrderDet, sqlCustomerType, connStr, sqlCustomer, sqlTyre, sqlTyrePar, sqlTyreType, sqlOrderPar, sqlOrderDetPar;

        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = LimitlessTyres; Integrated Security = true";

            //Set up data adapter with parameters for customer
            sqlCustomerPar = @"Select DISTINCT Customer.CustomerID, Customer.CustomerTypeID, CompanyName, CustomerSurname, CustomerForename, CustomerSurname + ', ' + CustomerForename as Name, CustomerContactNo, CustomerStreet, CustomerTown, CustomerCounty, CustomerPostcode FROM Customer JOIN CustomerType on Customer.CustomerTypeID = CustomerType.CustomerTypeID WHERE CustomerSurname LIKE @letter AND CustomerType.CustomerTypeID = @CustomerTypeID ORDER BY CustomerSurname, CustomerForename";
            conn = new SqlConnection(connStr);
            cmdCustomerPar = new SqlCommand(sqlCustomerPar, conn);
            cmdCustomerPar.Parameters.Add("@Letter", SqlDbType.VarChar);
            cmdCustomerPar.Parameters.Add("@CustomerTypeID", SqlDbType.VarChar);
            daCustomerPar = new SqlDataAdapter(cmdCustomerPar);
            daCustomerPar.FillSchema(dsLimitlessTyres, SchemaType.Source, "CustomerPar");

            //Set up simple dataset with no parameters for customer
            sqlCustomer = @"SELECT * FROM Customer";
            daCustomer = new SqlDataAdapter(sqlCustomer, conn);
            cmdBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsLimitlessTyres, SchemaType.Source, "Customer");
            daCustomer.Fill(dsLimitlessTyres, "Customer");

            //Set up simple dataset with no paramters for customer type
            sqlCustomerType = @"SELECT * FROM CustomerType";
            daCustomerType = new SqlDataAdapter(sqlCustomerType, conn);
            cmdBCustomerType = new SqlCommandBuilder(daCustomerType);
            daCustomerType.FillSchema(dsLimitlessTyres, SchemaType.Source, "CustomerType");
            daCustomerType.Fill(dsLimitlessTyres, "CustomerType");

            //Set up data adapter with a parameter for tyre
            sqlTyrePar = @"Select distinct TyreID, Tyre.TyreTypeCode, Tyre.SupplierID, TyreDesc, TyrePrice, QtyInStock FROM Tyre JOIN TyreType on Tyre.TyreTypeCode = TyreType.TyreTypeCode JOIN Supplier on Tyre.SupplierID = Supplier.SupplierID WHERE TyreType.TyreTypeCode = @TyreTypeCode ORDER BY TyreDesc";
            cmdTyrePar = new SqlCommand(sqlTyrePar, conn);
            cmdTyrePar.Parameters.Add("@TyreTypeCode", SqlDbType.VarChar);
            daTyrePar = new SqlDataAdapter(cmdTyrePar);
            daTyrePar.FillSchema(dsLimitlessTyres, SchemaType.Source, "TyrePar"); ;

            //Set up simple dataset with no parameters for tyre
            sqlTyre = @"SELECT * FROM Tyre";
            daTyre = new SqlDataAdapter(sqlTyre, conn);
            cmdBTyre = new SqlCommandBuilder(daTyre);
            daTyre.FillSchema(dsLimitlessTyres, SchemaType.Source, "Tyre");
            daTyre.Fill(dsLimitlessTyres, "Tyre");

            //Set up simple dataset with no parameters for tyre type
            sqlTyreType = @"SELECT * FROM TyreType ORDER BY TyreTypeCode";
            daTyreType = new SqlDataAdapter(sqlTyreType, conn);
            cmdBTyreType = new SqlCommandBuilder(daTyreType);
            daTyreType.FillSchema(dsLimitlessTyres, SchemaType.Source, "TyreType");
            daTyreType.Fill(dsLimitlessTyres, "TyreType");

            //Set up data adapter with a parameter for order
            sqlOrderPar = @"SELECT * from [Order] where CustomerID LIKE @CustID ORDER BY OrderID";
            daOrderPar = new SqlDataAdapter(sqlOrderPar, conn);
            cmdOrderPar = new SqlCommand(sqlOrderPar, conn);
            cmdOrderPar.Parameters.Add("@CustID", SqlDbType.Int);
            daOrderPar = new SqlDataAdapter(cmdOrderPar);
            daOrderPar.FillSchema(dsLimitlessTyres, SchemaType.Source, "OrderPar");

            //Set up data adapter with a parameter for order detail
            sqlOrderDetPar = @"SELECT * from OrderDetail where OrderID LIKE @OrderID ORDER BY TyreID";
            daOrderDetPar = new SqlDataAdapter(sqlOrderDetPar, conn);
            cmdOrderDetPar = new SqlCommand(sqlOrderDetPar, conn);
            cmdOrderDetPar.Parameters.Add("@OrderID", SqlDbType.Int);
            daOrderDetPar = new SqlDataAdapter(cmdOrderDetPar);
            daOrderDetPar.FillSchema(dsLimitlessTyres, SchemaType.Source, "OrderDetPar");

            //Set up simple dataset with no parameters for order
            sqlOrder = @"SELECT * FROM [Order]";
            daOrder = new SqlDataAdapter(sqlOrder, conn);
            cmdBOrder = new SqlCommandBuilder(daOrder);
            daOrder.FillSchema(dsLimitlessTyres, SchemaType.Source, "Order");
            daOrder.Fill(dsLimitlessTyres, "Order");

            //Set up simple dataset with no parameters for order detail
            sqlOrderDet = @"SELECT * FROM OrderDetail";
            daOrderDet = new SqlDataAdapter(sqlOrderDet, conn);
            cmdBOrder = new SqlCommandBuilder(daOrderDet);
            daOrderDet.FillSchema(dsLimitlessTyres, SchemaType.Source, "OrderDet");
            daOrderDet.Fill(dsLimitlessTyres, "OrderDet");

            FillListBoxDisplayOrder();
        }

        private void tbcOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcOrder.SelectedIndex)
            {
                case 0:
                    ClearDisplayTab();
                    break;
                case 1:
                    ClearAddTab();
                    SetAddAlphabetButtons();
                    SetAddOrderDateID();
                    break;
                case 2:
                    ClearEditTab();
                    SetEditAlphabetButtons();
                    break;
            }
        }

        //Diplay tab
        private void lstDisplayOrder_Click(object sender, EventArgs e)
        {
            //Check if an order is selected
            if (lstDisplayOrder.SelectedIndex != -1)
            {
                DisplayOrderDetails();
                FillListViewDisplayOrder();
                CalcDisplayOrderDiscountCost();
                AutoResizeDisplayListViewCol();
            }
        }

        private void FillListBoxDisplayOrder()
        {
            lstDisplayOrder.DataSource = dsLimitlessTyres.Tables["Order"];
            lstDisplayOrder.DisplayMember = "OrderID";
            lstDisplayOrder.ValueMember = "OrderID";

            lstDisplayOrder.SelectedIndex = -1;
        }

        private void ClearDisplayTab()
        {
            //Clear order details
            lblDisplayOrder0.Text = "";
            lblDisplayOrder1.Text = "";
            lblDisplayOrder2.Text = "";
            lblDisplayOrder3.Text = "";
            lblDisplayOrder4.Text = "";
            lblDisplayOrder5.Text = "";
            lblDisplayOrder6.Text = "";
            lblDisplayOrder7.Text = "";
            lblDisplayOrder8.Text = "";

            //Clear listview
            lvwDisplayTyre.Items.Clear();

            //Remove order selection
            lstDisplayOrder.SelectedIndex = -1;
        }

        private void CalcDisplayOrderDiscountCost()
        {
            double cost = 0;

            foreach (DataRow dr in dsLimitlessTyres.Tables["CustomerType"].Rows)
            {
                if (dr["CustomerTypeID"].ToString() == drCustomer["CustomerTypeID"].ToString())
                {
                    foreach (ListViewItem item in lvwDisplayTyre.Items)
                    {
                        cost += Convert.ToDouble(item.SubItems[4].Text);
                    }

                    lblDisplayOrder7.Text = "Discount:  " + Convert.ToDecimal(dr["DiscountPercentage"]) * 100 + "%";
                    lblDisplayOrder8.Text = String.Format("Order Cost:  £{0:0.00}", cost * (1 - Convert.ToDouble(dr["DiscountPercentage"])));
                }
            }
        }

        private void AutoResizeDisplayListViewCol()
        {
            lvwDisplayTyre.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwDisplayTyre.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void DisplayOrderDetails()
        {
            //Find selected order and assoicated customer
            drOrder = dsLimitlessTyres.Tables["Order"].Rows.Find(lstDisplayOrder.SelectedValue);
            drCustomer = dsLimitlessTyres.Tables["Customer"].Rows.Find(drOrder["CustomerID"]);

            //Display order details
            lblDisplayOrder0.Text = "Order ID: " + drOrder["OrderID"].ToString();
            lblDisplayOrder1.Text = "Order Date: " + drOrder["OrderDate"].ToString().Substring(0, 10);
            lblDisplayOrder2.Text = "Customer Name: " + drCustomer["CustomerForename"].ToString() + " " + drCustomer["CustomerSurname"].ToString();

            switch (drCustomer["CustomerTypeID"].ToString())
            {
                case "T":
                    lblDisplayOrder3.Text = "Customer Type: Trade";
                    break;
                case "G":
                    lblDisplayOrder3.Text = "Customer Type: General";
                    break;
            }

            lblDisplayOrder4.Text = "Contact No: " + drCustomer["CustomerContactNo"];
            lblDisplayOrder5.Text = "Address: " + drCustomer["CustomerStreet"].ToString() + ", " + drCustomer["CustomerTown"].ToString() + ", \nCo. " + drCustomer["CustomerCounty"].ToString() + ", " + drCustomer["CustomerPostcode"].ToString();
            lblDisplayOrder6.Text = "Company Name: " + drCustomer["CompanyName"];
        }

        private void FillListViewDisplayOrder()
        {
            //Clear listview
            lvwDisplayTyre.Items.Clear();

            //Add tyres in order to listview
            foreach (DataRow dr in dsLimitlessTyres.Tables["OrderDet"].Rows)
            {
                if (dr["OrderID"].ToString() == drOrder["OrderID"].ToString())
                {
                    foreach (DataRow dr2 in dsLimitlessTyres.Tables["Tyre"].Rows)
                    {
                        if (dr2["TyreID"].ToString() == dr["TyreID"].ToString())
                        {
                            ListViewItem item = new ListViewItem(dr2["TyreID"].ToString());

                            item.SubItems.Add(dr2["TyreDesc"].ToString());
                            item.SubItems.Add(dr2["TyrePrice"].ToString());
                            item.SubItems.Add(dr["Quantity"].ToString());
                            item.SubItems.Add((Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr2["TyrePrice"])).ToString());

                            lvwDisplayTyre.Items.Add(item);

                            break;
                        }
                    }
                }
            }
        }

        //Button panel
        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tbcOrder.SelectedIndex = 1;
        }

        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            tbcOrder.SelectedIndex = 2;
        }

        private void btnDisplayDelete_Click(object sender, EventArgs e)
        {
            //Check if an order is selected
            if (lstDisplayOrder.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Are you sure that you wish to delete Order ID: " + lstDisplayOrder.SelectedValue + "?", "Delete Order", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    object[] primaryKey = new object[2];

                    //Find and delete all related order detail rows from order detail table
                    foreach (ListViewItem item in lvwDisplayTyre.Items)
                    {
                        //Find order detail row by primary key
                        primaryKey[0] = Convert.ToInt32(lstDisplayOrder.Text);
                        primaryKey[1] = item.SubItems[0].Text;

                        drOrderDet = dsLimitlessTyres.Tables["OrderDet"].Rows.Find(primaryKey);

                        //Remove tyre from listview
                        lvwDisplayTyre.Items.Remove(item);

                        //Delete row from order detail table
                        drOrderDet.Delete();
                        daOrderDet.Update(dsLimitlessTyres, "OrderDet");

                        //Update tyre stock
                        drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(item.SubItems[0].Text);

                        drTyre["QtyInStock"] = Convert.ToInt32(drTyre["QtyInStock"]) + Convert.ToInt32(item.SubItems[3].Text);
                        daTyre.Update(dsLimitlessTyres, "Tyre");
                    }

                    //Find and delete order from order table
                    if (lvwDisplayTyre.Items.Count == 0)
                    {
                        //Find order
                        drOrder = dsLimitlessTyres.Tables["Order"].Rows.Find(primaryKey[0]);

                        //Delete row from order table
                        drOrder.Delete();
                        daOrder.Update(dsLimitlessTyres, "Order");
                    }
                }
            }
            else
                MessageBox.Show("Please select the order that you wish to delete.", "Delete Order");
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
        private void btnAddA_Click(object sender, EventArgs e)
        {
            ClearAddTab();

            //Get surname letter for customer listbox
            Button b = (Button)sender;
            String str = b.Text;

            FillListBoxAddCust(str);
        }

        private void lstAddCust_Click(object sender, EventArgs e)
        {
            //Check if a customer is selected
            if (lstAddCust.SelectedIndex != -1)
            {
                ClearAddTyreDetails();

                //Empty dataset tables tyre type, tyre
                dsLimitlessTyres.Tables["TyreType"].Clear();
                dsLimitlessTyres.Tables["TyrePar"].Clear();

                //Clear and disable numericUpDown
                nudAddQty.Value = 0;
                nudAddQty.Enabled = false;

                //Clear listview
                lvwAddTyre.Items.Clear();

                //Clear order discount and cost
                lblAddDiscount.Text = "";
                lblAddCost.Text = "";

                FillListBoxAddTyreType();

                //Display customer details
                drCustomer = dsLimitlessTyres.Tables["CustomerPar"].Rows.Find(lstAddCust.SelectedValue);

                lblAddCust0.Text = "Customer ID: " + drCustomer["CustomerID"].ToString();
                switch (drCustomer["CustomerTypeID"].ToString())
                {
                    case "T":
                        lblAddCust1.Text = "Type:  Trade";
                        break;
                    case "G":
                        lblAddCust1.Text = "Type:  General";
                        break;
                }

                lblAddCust2.Text = "Name: " + drCustomer["CustomerForename"].ToString() + " " + drCustomer["CustomerSurname"].ToString();
                lblAddCust3.Text = "Contact No: " + drCustomer["CustomerContactNo"].ToString();
                lblAddCust4.Text = "Address: " + drCustomer["CustomerStreet"].ToString() + ", " + drCustomer["CustomerTown"].ToString() + ", \nCo. " + drCustomer["CustomerCounty"].ToString() + ", " + drCustomer["CustomerPostcode"].ToString();
                lblAddCust5.Text = "Company Name: " + drCustomer["CompanyName"].ToString();

                //Enable add tyre panel
                pnlAddTyre1.Enabled = true;
            }
        }

        private void lstAddTyreType_Click(object sender, EventArgs e)
        {
            //Check if a tyre type is selected
            if (lstAddTyreType.SelectedIndex != -1)
            {
                ClearAddTyreDetails();

                //Empty dataset table tyre
                dsLimitlessTyres.Tables["TyrePar"].Clear();

                //Clear and disable numericUpDown
                nudAddQty.Value = 0;
                nudAddQty.Enabled = false;

                //Clear order discount and cost
                lblAddDiscount.Text = "";
                lblAddCost.Text = "";

                FillListBoxAddTyre();
            }
        }

        private void lstAddTyre_Click(object sender, EventArgs e)
        {
            //Check if a tyre is selected
            if (lstAddTyre.SelectedIndex != -1)
            {
                //Reset and enable numericUpDown 
                nudAddQty.Value = 0;
                nudAddQty.Enabled = true;

                //Display tyre details
                drTyre = dsLimitlessTyres.Tables["TyrePar"].Rows.Find(lstAddTyre.Text);

                lblAddTyre0.Text = "Name: " + drTyre["TyreDesc"].ToString();
                lblAddTyre1.Text = "Price: £" + drTyre["TyrePrice"].ToString().Substring(0, drTyre["TyrePrice"].ToString().Length - 2);
                lblAddTyre2.Text = "Width: " + drTyre["TyreID"].ToString().Substring(0, 3);
                lblAddTyre3.Text = "Profile: " + drTyre["TyreID"].ToString().Substring(4, 2);
                lblAddTyre4.Text = "Diameter: " + drTyre["TyreID"].ToString().Substring(7, 2);
                lblAddTyre5.Text = "Speed: " + drTyre["TyreID"].ToString().Substring(10, 1);
            }
        }

        private void rdoAddTradeGeneral_CheckedChanged(object sender, EventArgs e)
        {
            ClearAddTab();
        }

        private void FillListBoxAddCust(String str)
        {
            //Check if trade or general customer selected
            if (rdoAddTrade.Checked)
                cmdCustomerPar.Parameters["@CustomerTypeID"].Value = "T";
            else if (rdoAddGeneral.Checked)
                cmdCustomerPar.Parameters["@CustomerTypeID"].Value = "G";

            cmdCustomerPar.Parameters["@Letter"].Value = str + "%";

            daCustomerPar.Fill(dsLimitlessTyres, "CustomerPar");

            //Fill listbox
            lstAddCust.DataSource = dsLimitlessTyres.Tables["CustomerPar"];
            lstAddCust.DisplayMember = "Name";
            lstAddCust.ValueMember = "CustomerID";

            lstAddCust.SelectedIndex = -1;
        }

        private void ClearAddCustDetails()
        {
            lblAddCust0.Text = "";
            lblAddCust1.Text = "";
            lblAddCust2.Text = "";
            lblAddCust3.Text = "";
            lblAddCust4.Text = "";
            lblAddCust5.Text = "";
        }

        private void ClearAddTyreDetails()
        {
            lblAddTyre0.Text = "";
            lblAddTyre1.Text = "";
            lblAddTyre2.Text = "";
            lblAddTyre3.Text = "";
            lblAddTyre4.Text = "";
            lblAddTyre5.Text = "";
        }

        private void ClearAddTab()
        {
            ClearAddCustDetails();
            ClearAddTyreDetails();

            //Empty dataset tables customer, tyre type, tyre
            dsLimitlessTyres.Tables["CustomerPar"].Clear();
            dsLimitlessTyres.Tables["TyrePar"].Clear();
            dsLimitlessTyres.Tables["TyreType"].Clear();

            //Clear and disable numericUpDown
            nudAddQty.Value = 0;
            nudAddQty.Enabled = false;

            //Clear listview
            lvwAddTyre.Items.Clear();

            //Clear order discount and cost
            lblAddDiscount.Text = "";
            lblAddCost.Text = "";

            //Disable add panel
            pnlAddTyre1.Enabled = false;
        }

        private void SetAddOrderDateID()
        {
            int noRows = dsLimitlessTyres.Tables["Order"].Rows.Count;

            if (noRows == 0)
                lblAddOrderID.Text = "Order ID:  1000";
            else
            {
                drOrder = dsLimitlessTyres.Tables["Order"].Rows[noRows - 1];
                lblAddOrderID.Text = "Order ID: " + (int.Parse(drOrder["OrderID"].ToString()) + 1).ToString();
            }

            lblAddOrderDate.Text = "Order Date:  " + DateTime.Now.ToShortDateString();
        }

        private void FillListBoxAddTyreType()
        {
            daTyreType.Fill(dsLimitlessTyres, "TyreType");

            lstAddTyreType.DataSource = dsLimitlessTyres.Tables["TyreType"];
            lstAddTyreType.DisplayMember = "TyreTypeDesc";
            lstAddTyreType.ValueMember = "TyreTypeCode";

            lstAddTyreType.SelectedIndex = -1;
        }

        private void FillListBoxAddTyre()
        {
            cmdTyrePar.Parameters["@TyreTypeCode"].Value = lstAddTyreType.SelectedValue;

            daTyrePar.Fill(dsLimitlessTyres, "TyrePar");

            lstAddTyre.DataSource = dsLimitlessTyres.Tables["TyrePar"];
            lstAddTyre.DisplayMember = "TyreID";
            lstAddTyre.ValueMember = "TyreID";

            lstAddTyre.SelectedIndex = -1;
        }

        private void CalcAddOrderDiscountCost()
        {
            double cost = 0;
            foreach (DataRow dr in dsLimitlessTyres.Tables["CustomerType"].Rows)
            {
                if (dr["CustomerTypeID"].ToString() == drCustomer["CustomerTypeID"].ToString())
                {
                    foreach (ListViewItem item in lvwAddTyre.Items)
                    {
                        cost += Convert.ToDouble(item.SubItems[4].Text);
                    }

                    lblAddDiscount.Text = "Discount:  " + Convert.ToDecimal(dr["DiscountPercentage"]) * 100 + "%";
                    lblAddCost.Text = String.Format("Order Cost:  £{0:0.00}", cost * (1 - Convert.ToDouble(dr["DiscountPercentage"])));
                }
            }
        }

        private void AutoResizeAddListView()
        {
            lvwAddTyre.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAddTyre.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void SetAddAlphabetButtons()
        {
            //Set text for alphabet buttons
            for (int i = 0; i < 26; i++)
            {
                btns[i] = (Button)pnlAddLetterBtns.Controls[i];
                btns[i].Text = "" + (char)(65 + i);
                btns[i].Enabled = false;
                btns[i].Click += new EventHandler(btnAddA_Click);
            }

            //Get surnames for alphabet buttons
            sqlNames = @"SELECT CustomerSurname FROM customer ORDER BY CustomerSurname";
            daNames = new SqlDataAdapter(sqlNames, connStr);
            daNames.Fill(dsLimitlessTyres, "Names");

            //Enable relevant alphabet buttons
            foreach (DataRow dr in dsLimitlessTyres.Tables["Names"].Rows)
            {
                int no = (int)dr["CustomerSurname"].ToString()[0] - 65;
                btns[no].Enabled = true;
                btns[no].BackColor = Color.White;
            }
        }

        //Button panel
        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            bool exits = false;

            //Checks if customer, tyre type, tyre, and quantity selected
            if (lstAddCust.SelectedIndex == -1)
                MessageBox.Show("Please select a customer.", "Add Tyre");
            else if (lstAddTyreType.SelectedIndex == -1)
                MessageBox.Show("Please select a tyre type.", "Add Tyre");
            else if (lstAddTyre.SelectedIndex == -1)
                MessageBox.Show("Please select a tyre.", "Add Tyre");
            else if (nudAddQty.Text == "0")
            {
                MessageBox.Show("Please enter a quantity.", "Add Tyre");
                nudAddQty.Focus();
            }
            else
            {
                //Check if tyre has stock
                bool stock = false;

                DataRow drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(lstAddTyre.SelectedValue);

                if (Convert.ToInt32(drTyre["QtyInStock"]) > nudAddQty.Value)
                    stock = true;

                if (!stock)
                {
                    MessageBox.Show("Sorry. There is not enough stock of this tyre.", "Add Tyre");
                }
                else
                {
                    //Check if tyre has already been added to this order
                    foreach (ListViewItem item in lvwAddTyre.Items)
                    {
                        if (item.SubItems[0].Text == lstAddTyre.SelectedValue.ToString())
                        {
                            MessageBox.Show("Sorry. This ttyre has already been added to this order.", "Add Tyre");
                            exits = true;
                            break;
                        }
                    }

                    if (!exits)
                    {
                        //Add tyre to listview
                        foreach (DataRow dr in dsLimitlessTyres.Tables["TyrePar"].Rows)
                        {
                            if (dr["TyreID"].ToString() == lstAddTyre.Text)
                            {
                                ListViewItem item = new ListViewItem(dr["TyreID"].ToString());
                                item.SubItems.Add(dr["TyreDesc"].ToString());
                                item.SubItems.Add(dr["TyrePrice"].ToString());

                                item.SubItems.Add(nudAddQty.Text);
                                item.SubItems.Add((nudAddQty.Value * Convert.ToDecimal(dr["TyrePrice"])).ToString());
                                lvwAddTyre.Items.Add(item);
                                break;
                            }
                        }

                        CalcAddOrderDiscountCost();
                    }

                    ClearAddTyreDetails();

                    //Empty dataset table tyre
                    dsLimitlessTyres.Tables["TyrePar"].Clear();

                    //Clear and disable numericUpDown
                    nudAddQty.Value = 0;
                    nudAddQty.Enabled = false;

                    //Remove tyre type selection
                    lstAddTyreType.SelectedIndex = -1;

                    AutoResizeAddListView();
                }
            }
        }

        private void btnAddDelete_Click(object sender, EventArgs e)
        {
            //Check if a tyre is selected
            if (lvwAddTyre.SelectedItems.Count != 0)
            {
                //Remove tyre from listview
                var itemDel = lvwAddTyre.SelectedItems[0];
                lvwAddTyre.Items.Remove(itemDel);

                CalcAddOrderDiscountCost();
                AutoResizeAddListView();
            }
            else
                MessageBox.Show("Please select the tyre that you wish to remove from the order.", "Remove Tyre");
        }

        private void btnAddConfirm_Click(object sender, EventArgs e)
        {
            //Get order ID
            int orderID = Convert.ToInt32(lblAddOrderID.Text.Substring(10));

            //Check if a tyre has been added
            if (lvwAddTyre.Items.Count == 0)
                MessageBox.Show("Please add at least one tyre to the order.", "Confirm Order");
            else
            {
                //Add order to order table
                drOrder = dsLimitlessTyres.Tables["Order"].NewRow();

                drOrder["OrderID"] = orderID;
                drOrder["CustomerID"] = int.Parse(lstAddCust.SelectedValue.ToString());
                drOrder["OrderDate"] = DateTime.Now.ToShortDateString();

                dsLimitlessTyres.Tables["Order"].Rows.Add(drOrder);
                daOrder.Update(dsLimitlessTyres, "Order");

                //Add details to order detail able
                foreach (ListViewItem item in lvwAddTyre.Items)
                {
                    drOrderDet = dsLimitlessTyres.Tables["OrderDet"].NewRow();
                    drOrderDet["OrderID"] = drOrder["OrderID"];
                    drOrderDet["TyreID"] = item.SubItems[0].Text;
                    drOrderDet["Quantity"] = int.Parse(item.SubItems[3].Text);
                    dsLimitlessTyres.Tables["OrderDet"].Rows.Add(drOrderDet);
                    daOrderDet.Update(dsLimitlessTyres, "OrderDet");

                    //Update tyre stock
                    drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(item.SubItems[0].Text);

                    drTyre["QtyInStock"] = Convert.ToInt32(drTyre["QtyInStock"]) - Convert.ToInt32(item.SubItems[3].Text);
                    daTyre.Update(dsLimitlessTyres, "Tyre");
                }

                ClearAddTab();

                if (!(MessageBox.Show("Order ID: " + drOrder["OrderID"].ToString() + " added. Do you want to add another Order?", "Add Order", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes))
                    tbcOrder.SelectedIndex = 0;
                else
                    SetAddOrderDateID();
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to cancel the addition of a new order?", "Cancel Order", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tbcOrder.SelectedIndex = 0;
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

        private void btnAddDelete_MouseEnter(object sender, EventArgs e)
        {
            pcbAddDeleteLine.Visible = true;
        }

        private void btnAddDelete_MouseLeave(object sender, EventArgs e)
        {
            pcbAddDeleteLine.Visible = false;
        }

        private void btnAddConfirm_MouseEnter(object sender, EventArgs e)
        {
            pcbAddConfirmLine.Visible = true;
        }

        private void btnAddConfirm_MouseLeave(object sender, EventArgs e)
        {
            pcbAddConfirmLine.Visible = false;
        }

        private void btnAddCancel_MouseEnter(object sender, EventArgs e)
        {
            pcbAddCancelLine.Visible = true;
        }

        private void btnAddCancel_MouseLeave(object sender, EventArgs e)
        {
            pcbAddCancelLine.Visible = false;
        }

        //Edit tab
        private void btnEditA_Click(object sender, EventArgs e)
        {
            ClearEditTab();

            //Get surname letter for customer listbox
            Button b = (Button)sender;
            String str = b.Text;

            FillListboxEditCust(str);
        }

        private void lstEditCust_Click(object sender, EventArgs e)
        {
            //Check if a customer is selected
            if (lstEditCust.SelectedIndex != -1)
            {
                //Empty dataset tables order, tyre type
                dsLimitlessTyres.Tables["OrderPar"].Clear();
                dsLimitlessTyres.Tables["TyreType"].Clear();

                //Clear tyre type, tyre listbox
                if (lstEditTyreType.Items.Count == 1)
                    lstEditTyreType.Items.Clear();
                lstEditTyre.Items.Clear();

                //Change add/edit button text
                btnEditAdd.Text = "Add Tyre";
                btnEditEdit.Text = "Edit Tyre Qty";

                //Clear and disable numericUpDown
                nudEditQty.Value = 0;
                nudEditQty.Enabled = false;

                //Clear listview
                lvwEditTyre.Items.Clear();

                //Clear order ID, date, discount and cost
                lblEditOrder0.Text = "";
                lblEditOrder1.Text = "";
                lblEditDiscount.Text = "";
                lblEditCost.Text = "";

                //Disable edit tyre panel
                pnlEditTyre1.Enabled = false;

                //Enable buttons
                btnEditAdd.Enabled = true;
                btnEditDelete.Enabled = true;
                btnEditEdit.Enabled = true;

                //Hide add/edit cancel button
                btnEditAddEditCancel.Visible = false;

                //Display customer details
                drCustomer = dsLimitlessTyres.Tables["CustomerPar"].Rows.Find(lstEditCust.SelectedValue);

                lblEditCust0.Text = "Customer ID: " + drCustomer["CustomerID"].ToString();
                switch (drCustomer["CustomerTypeID"].ToString())
                {
                    case "T":
                        lblEditCust1.Text = "Type:  Trade";
                        break;
                    case "G":
                        lblEditCust1.Text = "Type:  General";
                        break;
                }

                lblEditCust2.Text = "Name: " + drCustomer["CustomerForename"].ToString() + " " + drCustomer["CustomerSurname"].ToString();
                lblEditCust3.Text = "Contact No: " + drCustomer["CustomerContactNo"].ToString();
                lblEditCust4.Text = "Address: " + drCustomer["CustomerStreet"].ToString() + ", " + drCustomer["CustomerTown"].ToString() + ", \nCo. " + drCustomer["CustomerCounty"].ToString() + ", " + drCustomer["CustomerPostcode"].ToString();
                lblEditCust5.Text = "Company Name: " + drCustomer["CompanyName"].ToString();

                //Enable edit order panel
                pnlEditOrder1.Enabled = true;

                FillListboxEditOrder();
            }
        }

        private void lstEditOrder_Click(object sender, EventArgs e)
        {
            //Check if a order is selected
            if (lstEditOrder.SelectedIndex != -1)
            {
                //Empty dataset table tyre type
                dsLimitlessTyres.Tables["TyreType"].Clear();

                //Clear tyre type, tyre listbox
                if (lstEditTyreType.Items.Count == 1)
                    lstEditTyreType.Items.Clear();
                lstEditTyre.Items.Clear();

                //Change button text
                btnEditAdd.Text = "Add Tyre";
                btnEditEdit.Text = "Edit Tyre Qty";

                //Clear and disable numericUpDown
                nudEditQty.Value = 0;
                nudEditQty.Enabled = false;

                //Clear listview
                lvwEditTyre.Items.Clear();

                //Disable edit tyre panel
                pnlEditTyre1.Enabled = false;

                //Enable buttons
                btnEditAdd.Enabled = true;
                btnEditDelete.Enabled = true;
                btnEditEdit.Enabled = true;

                //Hide add/edit cancel button
                btnEditAddEditCancel.Visible = false;

                //Find order and set datarow
                drOrder = dsLimitlessTyres.Tables["OrderPar"].Rows.Find(lstEditOrder.SelectedValue);

                //Display order ID and date
                lblEditOrder0.Text = "Order ID: " + drOrder["OrderID"].ToString();
                lblEditOrder1.Text = "Order Date: " + drOrder["OrderDate"].ToString().Substring(0, 10);

                //Add order details to listview
                foreach (DataRow dr in dsLimitlessTyres.Tables["OrderDet"].Rows)
                {
                    if (dr["OrderID"].ToString() == drOrder["OrderID"].ToString())
                    {
                        foreach (DataRow dr2 in dsLimitlessTyres.Tables["Tyre"].Rows)
                        {
                            if (dr2["TyreID"].ToString() == dr["TyreID"].ToString())
                            {
                                ListViewItem item = new ListViewItem(dr2["TyreID"].ToString());
                                item.SubItems.Add(dr2["TyreDesc"].ToString());
                                item.SubItems.Add(dr2["TyrePrice"].ToString());

                                item.SubItems.Add(dr["Quantity"].ToString());
                                item.SubItems.Add((Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr2["TyrePrice"])).ToString());
                                lvwEditTyre.Items.Add(item);
                                break;
                            }
                        }
                    }
                }

                CalcEditOrderDiscountCost();
                AutoResizeEditListView();
            }
        }

        private void lstEditTyreType_Click(object sender, EventArgs e)
        {
            //Check if a tyre type is Selected
            if (lstEditTyreType.SelectedIndex != -1)
            {
                //Empty dataset tables tyre, order
                dsLimitlessTyres.Tables["TyrePar"].Clear();
                dsLimitlessTyres.Tables["OrderDetPar"].Clear();

                //Get tyres that match tyre type
                cmdTyrePar.Parameters["@TyreTypeCode"].Value = lstEditTyreType.SelectedValue;

                daTyrePar.Fill(dsLimitlessTyres, "TyrePar");

                //Clear tyre listbox
                lstEditTyre.Items.Clear();

                //Fill tyre listbox with tyres that haven't been added to the order already
                cmdOrderDetPar.Parameters["@OrderID"].Value = lstEditOrder.SelectedValue;

                daOrderDetPar.Fill(dsLimitlessTyres, "OrderDetPar");

                foreach (DataRow dr in dsLimitlessTyres.Tables["TyrePar"].Rows)
                {
                    bool found = false;

                    foreach (DataRow dr1 in dsLimitlessTyres.Tables["OrderDetPar"].Rows)
                    {
                        if (dr1["TyreID"].ToString() == dr["TyreID"].ToString())
                            found = true;
                    }

                    if (!found)
                    {
                        lstEditTyre.Items.Add(dr["TyreID"].ToString());
                    }
                }
            }
        }

        private void lstEditTyre_Click(object sender, EventArgs e)
        {
            //Check if a tyre is selected
            if (lstEditTyre.SelectedIndex != -1)
            {
                //Enable numericUpDown
                nudEditQty.Enabled = true;
            }
        }

        private void rdoEditTradeGeneral_CheckedChanged(object sender, EventArgs e)
        {
            ClearEditTab();
        }

        private void FillListboxEditCust(String str)
        {
            //Check if a trade or general customer is selected
            if (rdoEditTrade.Checked)
                cmdCustomerPar.Parameters["@CustomerTypeID"].Value = "T";
            else if (rdoEditGeneral.Checked)
                cmdCustomerPar.Parameters["@CustomerTypeID"].Value = "G";

            cmdCustomerPar.Parameters["@Letter"].Value = str + "%";
            daCustomerPar.Fill(dsLimitlessTyres, "CustomerPar");

            //Fill listbox
            lstEditCust.DataSource = dsLimitlessTyres.Tables["CustomerPar"];
            lstEditCust.DisplayMember = "Name";
            lstEditCust.ValueMember = "CustomerID";

            lstEditCust.SelectedIndex = -1;
        }

        private void FillListboxEditOrder()
        {
            //Clear dataset table order
            dsLimitlessTyres.Tables["OrderPar"].Clear();

            //get all orders for listbox
            cmdOrderPar.Parameters["@CustID"].Value = lstEditCust.SelectedValue;

            daOrderPar.Fill(dsLimitlessTyres, "OrderPar");

            //fill order listbox
            lstEditOrder.DataSource = dsLimitlessTyres.Tables["OrderPar"];
            lstEditOrder.DisplayMember = "OrderID";
            lstEditOrder.ValueMember = "OrderID";

            lstEditOrder.SelectedIndex = -1;
        }

        private void ClearEditCustDetails()
        {
            lblEditCust0.Text = "";
            lblEditCust1.Text = "";
            lblEditCust2.Text = "";
            lblEditCust3.Text = "";
            lblEditCust4.Text = "";
            lblEditCust5.Text = "";
        }

        private void ClearEditTab()
        {
            ClearEditCustDetails();

            //Empty dataset tables customer, order, tyre type, tyre
            dsLimitlessTyres.Tables["CustomerPar"].Clear();
            dsLimitlessTyres.Tables["OrderPar"].Clear();
            dsLimitlessTyres.Tables["TyreType"].Clear();

            //Clear tyre type, tyre listbox
            if (lstEditTyreType.Items.Count == 1)
                lstEditTyreType.Items.Clear();
            lstEditTyre.Items.Clear();

            //Change add/edit qty button text
            btnEditAdd.Text = "Add Tyre";
            btnEditEdit.Text = "Edit Tyre Qty";

            //Clear and disable numericUpDown
            nudEditQty.Value = 0;
            nudEditQty.Enabled = false;

            //Clear listview
            lvwEditTyre.Items.Clear();

            //Clear order ID, date, discount and cost
            lblEditOrder0.Text = "";
            lblEditOrder1.Text = "";
            lblEditDiscount.Text = "";
            lblEditCost.Text = "";

            //Disable panels
            pnlEditOrder1.Enabled = false;
            pnlEditTyre1.Enabled = false;

            //Hide add/edit qty cancel button
            btnEditAddEditCancel.Visible = false;

            //Enable buttons
            btnEditAdd.Enabled = true;
            btnEditDelete.Enabled = true;
            btnEditEdit.Enabled = true;
        }

        private void SetEditAlphabetButtons()
        {
            //Set text for alphabet buttons
            for (int i = 0; i < 26; i++)
            {
                btns[i] = (Button)pnlEditLetterBtns.Controls[i];
                btns[i].Text = "" + (char)(65 + i);
                btns[i].Enabled = false;
                btns[i].Click += new EventHandler(btnEditA_Click);
            }

            //Get surnames for alphabet buttons
            sqlNames = @"SELECT CustomerSurname FROM customer ORDER BY CustomerSurname";
            daNames = new SqlDataAdapter(sqlNames, connStr);
            daNames.Fill(dsLimitlessTyres, "Names");

            //Enable relevant alphabet buttons
            foreach (DataRow dr in dsLimitlessTyres.Tables["Names"].Rows)
            {
                int no = (int)dr["CustomerSurname"].ToString()[0] - 65;
                btns[no].Enabled = true;
                btns[no].BackColor = Color.White;
            }
        }

        private void AutoResizeEditListView()
        {
            lvwEditTyre.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwEditTyre.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void CalcEditOrderDiscountCost()
        {
            double cost = 0;

            foreach (DataRow dr in dsLimitlessTyres.Tables["CustomerType"].Rows)
            {
                if (dr["CustomerTypeID"].ToString() == drCustomer["CustomerTypeID"].ToString())
                {
                    foreach (ListViewItem item in lvwEditTyre.Items)
                    {
                        cost += Convert.ToDouble(item.SubItems[4].Text);
                    }

                    lblEditDiscount.Text = "Discount:  " + Convert.ToDecimal(dr["DiscountPercentage"]) * 100 + "%";
                    lblEditCost.Text = String.Format("Order Cost:  £{0:0.00}", cost * (1 - Convert.ToDouble(dr["DiscountPercentage"])));
                }
            }
        }

        //Button panel
        private void btnEditAdd_Click(object sender, EventArgs e)
        {
            //Check if a customer and order is selected
            if (lstEditCust.SelectedIndex == -1)
                MessageBox.Show("Please select a customer", "Add Tyre");
            else if (lstEditOrder.SelectedIndex == -1)
                MessageBox.Show("Please select an order", "Add Tyre");
            else if (btnEditAdd.Text == "Add Tyre")
            {
                //Enable edit tyre panel
                pnlEditTyre1.Enabled = true;

                //Change add button text
                btnEditAdd.Text = "Confirm Add";

                //Disable buttons
                btnEditDelete.Enabled = false;
                btnEditEdit.Enabled = false;

                //Enable listboxes
                lstEditTyreType.Enabled = true;
                lstEditTyre.Enabled = true;

                daTyreType.Fill(dsLimitlessTyres, "TyreType");

                //Fill tyre type listbox
                lstEditTyreType.DataSource = dsLimitlessTyres.Tables["TyreType"];
                lstEditTyreType.DisplayMember = "TyreTypeDesc";
                lstEditTyreType.ValueMember = "TyreTypeCode";

                lstEditTyreType.SelectedIndex = -1;

                //Make visible and change text of add/edit cancel button
                btnEditAddEditCancel.Visible = true;
                btnEditAddEditCancel.Text = "Cancel Addition";
            }
            else
            {
                if (lstEditTyreType.SelectedIndex == -1)
                    MessageBox.Show("Please select a tyre type", "Add Tyre");
                else if (lstEditTyre.SelectedIndex == -1)
                    MessageBox.Show("Please select a tyre", "Add Tyre");
                else if (nudEditQty.Text == "0")
                {
                    MessageBox.Show("Please enter a quantity", "Add Tyre");
                }
                else
                {
                    bool stock = false;

                    //Check if tyre has stock
                    DataRow drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(lstEditTyre.SelectedItem);

                    if (Convert.ToInt32(drTyre["QtyInStock"]) > nudEditQty.Value)
                        stock = true;

                    if (!stock)
                    {
                        MessageBox.Show("Sorry. There is not enough stock of this tyre.", "Add Tyre");
                    }
                    else
                    {
                        //Add new row to order details table
                        DataRow drOrderDet = dsLimitlessTyres.Tables["OrderDet"].NewRow();

                        drOrderDet["OrderID"] = Convert.ToInt32(lstEditOrder.Text);
                        drOrderDet["TyreID"] = lstEditTyre.Text;
                        drOrderDet["Quantity"] = Convert.ToInt32(nudEditQty.Text);

                        dsLimitlessTyres.Tables["OrderDet"].Rows.Add(drOrderDet);

                        daOrderDet.Update(dsLimitlessTyres, "OrderDet");

                        //Clear listview
                        lvwEditTyre.Items.Clear();

                        //get all kennel details for listbox
                        cmdOrderDetPar.Parameters["@OrderID"].Value = lstEditOrder.SelectedValue;

                        daOrderDetPar.Fill(dsLimitlessTyres, "OrderDetPar");

                        //Update listview
                        foreach (DataRow dr in dsLimitlessTyres.Tables["OrderDet"].Rows)
                        {
                            if (dr["OrderID"].ToString() == drOrder["OrderID"].ToString())
                            {
                                foreach (DataRow dr2 in dsLimitlessTyres.Tables["Tyre"].Rows)
                                {
                                    if (dr2["TyreID"].ToString() == dr["TyreID"].ToString())
                                    {
                                        ListViewItem item = new ListViewItem(dr2["TyreID"].ToString());
                                        item.SubItems.Add(dr2["TyreDesc"].ToString());
                                        item.SubItems.Add(dr2["TyrePrice"].ToString());

                                        item.SubItems.Add(dr["Quantity"].ToString());
                                        item.SubItems.Add((Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr2["TyrePrice"])).ToString());
                                        lvwEditTyre.Items.Add(item);

                                        break;
                                    }
                                }
                            }
                        }

                        CalcEditOrderDiscountCost();

                        //Update Tyre stock
                        drTyre["QtyInStock"] = Convert.ToInt32(drTyre["QtyInStock"]) - Convert.ToInt32(nudEditQty.Value);
                        daTyre.Update(dsLimitlessTyres, "Tyre");

                        AutoResizeEditListView();

                        //Empty dataset table tyre type
                        dsLimitlessTyres.Tables["TyreType"].Clear();

                        //Clear tyre type listbox
                        lstEditTyre.Items.Clear();

                        //Disable and reset numericUpDown
                        nudEditQty.Enabled = false;
                        nudEditQty.Text = "0";

                        //Disable panel
                        pnlEditTyre1.Enabled = false;

                        //Change button text
                        btnEditAdd.Text = "Add Tyre";

                        //Enable buttons
                        btnEditDelete.Enabled = true;
                        btnEditEdit.Enabled = true;

                        //Make add/edit cancel buttton and line invisible
                        btnEditAddEditCancel.Visible = false;
                        pcbEditAddEditCancelLine.Visible = false;
                    }
                }
            }
        }

        private void btnEditDelete_Click(object sender, EventArgs e)
        {
            //Check if a tyre is selected
            if (lvwEditTyre.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to remove Tyre ID: " + lvwEditTyre.SelectedItems[0].SubItems[0].Text + " from the order?", "Remove Tyre", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    object[] primaryKey = new object[2];

                    ListViewItem currItem = lvwEditTyre.SelectedItems[0];

                    primaryKey[0] = Convert.ToInt32(lstEditOrder.Text);
                    primaryKey[1] = currItem.SubItems[0].Text;

                    DataRow drOrderDet = dsLimitlessTyres.Tables["OrderDet"].Rows.Find(primaryKey);

                    DataRow drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(drOrderDet["TyreID"]);

                    drTyre["QtyInStock"] = Convert.ToInt32(drTyre["QtyInStock"]) + Convert.ToInt32(lvwEditTyre.SelectedItems[0].SubItems[3].Text);
                    daTyre.Update(dsLimitlessTyres, "Tyre");

                    lvwEditTyre.Items.Remove(currItem);

                    drOrderDet.Delete();
                    daOrderDet.Update(dsLimitlessTyres, "OrderDet");

                    if (lvwEditTyre.Items.Count == 0)
                    {
                        MessageBox.Show("As there are no tyres in this order, Order ID: " + primaryKey[0].ToString() + " will now be deleted.");

                        DataRow drOrder = dsLimitlessTyres.Tables["Order"].Rows.Find(primaryKey[0]);

                        drOrder.Delete();
                        daOrder.Update(dsLimitlessTyres, "Order");

                        //Clear Order Details
                        lblEditOrder0.Text = "";
                        lblEditOrder1.Text = "";
                        lblEditDiscount.Text = "";
                        lblEditCost.Text = "";

                        FillListboxEditOrder();
                    }

                    CalcEditOrderDiscountCost();
                }
            }
            else
                MessageBox.Show("Please select the tyre that you wish to remove from the order.", "Remove Tyre");
        }

        private void btnEditEdit_Click(object sender, EventArgs e)
        {
            //Check if a tyre is selected
            if (lvwEditTyre.SelectedItems.Count != 0)
            {
                if (btnEditEdit.Text == "Edit Tyre Qty")
                {
                    //Make tyre type datasource null
                    lstEditTyreType.DataSource = null;

                    //Enable panel
                    pnlEditTyre1.Enabled = true;

                    //Disable tyre type and tyre listbox
                    lstEditTyreType.Enabled = false;
                    lstEditTyre.Enabled = false;

                    //Change edit button text
                    btnEditEdit.Text = "Save Changes";

                    //Disable other buttons
                    btnEditAdd.Enabled = false;
                    btnEditDelete.Enabled = false;

                    daTyreType.Fill(dsLimitlessTyres, "TyreType");

                    //Display tyre type and tyre in listbox
                    lstEditTyre.Items.Add(lvwEditTyre.SelectedItems[0].SubItems[1].Text);

                    drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(lvwEditTyre.SelectedItems[0].SubItems[0].Text);

                    DataRow drTyreType = dsLimitlessTyres.Tables["TyreType"].Rows.Find(drTyre["TyreTypeCode"]);

                    lstEditTyreType.Items.Add(drTyreType["TyreTypeDesc"]);

                    //Set value and enable numericUpDown
                    nudEditQty.Text = lvwEditTyre.SelectedItems[0].SubItems[3].Text;
                    nudEditQty.Enabled = true;

                    //Enable and change text of add/edit cancel button
                    btnEditAddEditCancel.Visible = true;
                    btnEditAddEditCancel.Text = "Cancel Qty Edit";
                }

                else
                {
                    bool stock = false;

                    //Check if tyre has stock
                    DataRow drTyre = dsLimitlessTyres.Tables["Tyre"].Rows.Find(lvwEditTyre.SelectedItems[0].SubItems[0].Text);

                    if (Convert.ToInt32(drTyre["QtyInStock"]) > nudEditQty.Value)
                        stock = true;

                    if (!stock)
                    {
                        MessageBox.Show("Sorry. There is not enough stock of this tyre.", "Add Tyre");
                    }
                    else
                    {
                        int oldQty, newQty;

                        //Find order detail row by primary key
                        object[] primaryKey = new object[2];

                        ListViewItem currItem = lvwEditTyre.SelectedItems[0];

                        primaryKey[0] = Convert.ToInt32(lstEditOrder.Text);
                        primaryKey[1] = currItem.SubItems[0].Text;

                        drOrderDet = dsLimitlessTyres.Tables["OrderDet"].Rows.Find(primaryKey);

                        oldQty = Convert.ToInt32(drOrderDet["Quantity"]);

                        //Update quantity value
                        drOrderDet["Quantity"] = nudEditQty.Value;

                        daOrderDet.Update(dsLimitlessTyres, "OrderDet");

                        newQty = Convert.ToInt32(drOrderDet["Quantity"]);

                        //Clear listview
                        lvwEditTyre.Items.Clear();

                        //Update listview
                        foreach (DataRow dr in dsLimitlessTyres.Tables["OrderDet"].Rows)
                        {
                            if (dr["OrderID"].ToString() == drOrder["OrderID"].ToString())
                            {
                                foreach (DataRow dr2 in dsLimitlessTyres.Tables["Tyre"].Rows)
                                {
                                    if (dr2["TyreID"].ToString() == dr["TyreID"].ToString())
                                    {
                                        ListViewItem item = new ListViewItem(dr2["TyreID"].ToString());
                                        item.SubItems.Add(dr2["TyreDesc"].ToString());
                                        item.SubItems.Add(dr2["TyrePrice"].ToString());

                                        item.SubItems.Add(dr["Quantity"].ToString());
                                        item.SubItems.Add((Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr2["TyrePrice"])).ToString());
                                        lvwEditTyre.Items.Add(item);
                                        break;
                                    }
                                }
                            }
                        }

                        CalcEditOrderDiscountCost();
                        
                        //Update tyre stock
                        drTyre["QtyInStock"] = Convert.ToInt32(drTyre["QtyInStock"]) + (oldQty - newQty);
                        daTyre.Update(dsLimitlessTyres, "Tyre");

                        AutoResizeEditListView();

                        //Clear listviews
                        lstEditTyreType.Items.Clear();
                        lstEditTyre.Items.Clear();

                        //Enable buttons
                        btnEditAdd.Enabled = true;
                        btnEditDelete.Enabled = true;

                        //Change button ext
                        btnEditEdit.Text = "Edit Tyre Qty";

                        //Disable and reset numericUpDown
                        nudEditQty.Enabled = false;
                        nudEditQty.Text = "0";

                        //Disable panel
                        pnlEditTyre1.Enabled = false;

                        //Make add/edit cancel buttton and line invisible
                        btnEditAddEditCancel.Visible = false;
                        pcbEditAddEditCancelLine.Visible = false;
                    }
                }
            }
            else
                MessageBox.Show("Please select a tyre to edit the quantity ordered.", "Edit Tyre Qty");
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to stop editing orders?", "Stop Editing", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tbcOrder.SelectedIndex = 0;
        }

        private void btnEditAddEditCancel_Click(object sender, EventArgs e)
        {
            if (btnEditAddEditCancel.Text == "Cancel Addition")
            {
                //Empty dataset table tyre type
                dsLimitlessTyres.Tables["TyreType"].Clear();

                //Clear tyre type listbox
                lstEditTyre.Items.Clear();

                //Disable and reset numericUpDown
                nudEditQty.Enabled = false;
                nudEditQty.Text = "0";

                //Disable panel
                pnlEditTyre1.Enabled = false;

                //Change button text
                btnEditAdd.Text = "Add Tyre";

                //Enable buttons
                btnEditDelete.Enabled = true;
                btnEditEdit.Enabled = true;

                //Hide add/edit cancel button
                btnEditAddEditCancel.Visible = false;

                //Hide add/edit cancel button line
                pcbEditAddEditCancelLine.Visible = false;
            }
            else if (btnEditAddEditCancel.Text == "Cancel Qty Edit")
            {
                //Clear listviews
                lstEditTyreType.Items.Clear();
                lstEditTyre.Items.Clear();

                //Enable buttons
                btnEditAdd.Enabled = true;
                btnEditDelete.Enabled = true;

                //Change button ext
                btnEditEdit.Text = "Edit Tyre Qty";

                //Disable and reset numericUpDown
                nudEditQty.Enabled = false;
                nudEditQty.Text = "0";

                //Disable panel
                pnlEditTyre1.Enabled = false;

                //Hide add/edit cancel button
                btnEditAddEditCancel.Visible = false;

                //Hide add/edit cancel button line
                pcbEditAddEditCancelLine.Visible = false;
            }
        }

        //User feedback
        private void btnEditAdd_MouseEnter(object sender, EventArgs e)
        {
            pcbEditAddLine.Visible = true;
        }

        private void btnEditAdd_MouseLeave(object sender, EventArgs e)
        {
            pcbEditAddLine.Visible = false;
        }

        private void btnEditDelete_MouseEnter(object sender, EventArgs e)
        {
            pcbEditDeleteLine.Visible = true;
        }

        private void btnEditDelete_MouseLeave(object sender, EventArgs e)
        {
            pcbEditDeleteLine.Visible = false;
        }

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

        private void btnEditAddEditCancel_MouseEnter(object sender, EventArgs e)
        {
            if (btnEditAddEditCancel.Text == "Cancel Addition" || btnEditAddEditCancel.Text == "Cancel Qty Edit")
                pcbEditAddEditCancelLine.Visible = true;
        }

        private void btnEditAddEditCancel_MouseLeave(object sender, EventArgs e)
        {
            if (btnEditAddEditCancel.Text == "Cancel Addition" || btnEditAddEditCancel.Text == "Cancel Qty Edit")
                pcbEditAddEditCancelLine.Visible = false;
        }
    }
}