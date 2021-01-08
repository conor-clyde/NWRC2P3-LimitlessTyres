namespace LimitlessTyres
{
    partial class CustomerFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabCustomers = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDeleteDisplay = new System.Windows.Forms.Button();
            this.btnEditDisplay = new System.Windows.Forms.Button();
            this.btnAddDisplay = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtForename = new System.Windows.Forms.TextBox();
            this.lblCustomerNoAdd = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCounty2 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lblCustomerNoEdit = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCompanyName2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPostcode2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTown2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContactNo2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSurname2 = new System.Windows.Forms.TextBox();
            this.cmbCustomerType2 = new System.Windows.Forms.ComboBox();
            this.txtForename2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabCustomers.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.tabPage1);
            this.tabCustomers.Controls.Add(this.tabPage2);
            this.tabCustomers.Controls.Add(this.tabPage3);
            this.tabCustomers.Location = new System.Drawing.Point(28, 10);
            this.tabCustomers.Margin = new System.Windows.Forms.Padding(1);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.SelectedIndex = 0;
            this.tabCustomers.Size = new System.Drawing.Size(704, 496);
            this.tabCustomers.TabIndex = 0;
            this.tabCustomers.SelectedIndexChanged += new System.EventHandler(this.tabCustomers_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.dgvCustomers);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(696, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Display";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Controls.Add(this.btnDeleteDisplay);
            this.panel5.Controls.Add(this.btnEditDisplay);
            this.panel5.Controls.Add(this.btnAddDisplay);
            this.panel5.Location = new System.Drawing.Point(5, 431);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(686, 35);
            this.panel5.TabIndex = 2;
            // 
            // btnDeleteDisplay
            // 
            this.btnDeleteDisplay.FlatAppearance.BorderSize = 0;
            this.btnDeleteDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDisplay.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDisplay.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteDisplay.Location = new System.Drawing.Point(326, 2);
            this.btnDeleteDisplay.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeleteDisplay.Name = "btnDeleteDisplay";
            this.btnDeleteDisplay.Size = new System.Drawing.Size(135, 30);
            this.btnDeleteDisplay.TabIndex = 5;
            this.btnDeleteDisplay.Text = "Delete Customer";
            this.btnDeleteDisplay.UseVisualStyleBackColor = true;
            // 
            // btnEditDisplay
            // 
            this.btnEditDisplay.FlatAppearance.BorderSize = 0;
            this.btnEditDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDisplay.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDisplay.ForeColor = System.Drawing.Color.Black;
            this.btnEditDisplay.Location = new System.Drawing.Point(162, 2);
            this.btnEditDisplay.Margin = new System.Windows.Forms.Padding(1);
            this.btnEditDisplay.Name = "btnEditDisplay";
            this.btnEditDisplay.Size = new System.Drawing.Size(135, 30);
            this.btnEditDisplay.TabIndex = 4;
            this.btnEditDisplay.Text = "Edit Customer";
            this.btnEditDisplay.UseVisualStyleBackColor = true;
            this.btnEditDisplay.Click += new System.EventHandler(this.btnEditDisplay_Click);
            // 
            // btnAddDisplay
            // 
            this.btnAddDisplay.FlatAppearance.BorderSize = 0;
            this.btnAddDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDisplay.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDisplay.ForeColor = System.Drawing.Color.Black;
            this.btnAddDisplay.Location = new System.Drawing.Point(0, 2);
            this.btnAddDisplay.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddDisplay.Name = "btnAddDisplay";
            this.btnAddDisplay.Size = new System.Drawing.Size(135, 30);
            this.btnAddDisplay.TabIndex = 2;
            this.btnAddDisplay.Text = "Add Customer";
            this.btnAddDisplay.UseVisualStyleBackColor = true;
            this.btnAddDisplay.Click += new System.EventHandler(this.btnAddDisplay_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(5, 5);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(1);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 123;
            this.dgvCustomers.RowTemplate.Height = 46;
            this.dgvCustomers.Size = new System.Drawing.Size(686, 424);
            this.dgvCustomers.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.ForeColor = System.Drawing.Color.Transparent;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage2.Size = new System.Drawing.Size(696, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnDeleteCustomer);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(4, 427);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 39);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.FlatAppearance.BorderSize = 0;
            this.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(157, 3);
            this.btnDeleteCustomer.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(135, 30);
            this.btnDeleteCustomer.TabIndex = 4;
            this.btnDeleteCustomer.Text = "Cancel";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(0, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Customer";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txtStreet);
            this.panel2.Controls.Add(this.txtCompanyName);
            this.panel2.Controls.Add(this.txtPostcode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCounty);
            this.panel2.Controls.Add(this.txtTown);
            this.panel2.Controls.Add(this.txtContactNo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtSurname);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtForename);
            this.panel2.Controls.Add(this.lblCustomerNoAdd);
            this.panel2.Controls.Add(this.cmbCustomerType);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 421);
            this.panel2.TabIndex = 33;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(207, 219);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(1);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(204, 20);
            this.txtStreet.TabIndex = 32;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(207, 393);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(1);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(204, 20);
            this.txtCompanyName.TabIndex = 26;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(207, 351);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(1);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(204, 20);
            this.txtPostcode.TabIndex = 25;
            this.txtPostcode.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 219);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Street: ";
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(207, 307);
            this.txtCounty.Margin = new System.Windows.Forms.Padding(1);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(204, 20);
            this.txtCounty.TabIndex = 24;
            this.txtCounty.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtTown
            // 
            this.txtTown.Location = new System.Drawing.Point(207, 262);
            this.txtTown.Margin = new System.Windows.Forms.Padding(1);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(204, 20);
            this.txtTown.TabIndex = 23;
            this.txtTown.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(207, 177);
            this.txtContactNo.Margin = new System.Windows.Forms.Padding(1);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(204, 20);
            this.txtContactNo.TabIndex = 22;
            this.txtContactNo.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 393);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Company Name:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(207, 135);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(1);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(204, 20);
            this.txtSurname.TabIndex = 21;
            this.txtSurname.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer No: ";
            // 
            // txtForename
            // 
            this.txtForename.Location = new System.Drawing.Point(207, 92);
            this.txtForename.Margin = new System.Windows.Forms.Padding(1);
            this.txtForename.Name = "txtForename";
            this.txtForename.Size = new System.Drawing.Size(204, 20);
            this.txtForename.TabIndex = 20;
            this.txtForename.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblCustomerNoAdd
            // 
            this.lblCustomerNoAdd.AutoSize = true;
            this.lblCustomerNoAdd.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNoAdd.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerNoAdd.Location = new System.Drawing.Point(204, 11);
            this.lblCustomerNoAdd.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCustomerNoAdd.Name = "lblCustomerNoAdd";
            this.lblCustomerNoAdd.Size = new System.Drawing.Size(13, 17);
            this.lblCustomerNoAdd.TabIndex = 1;
            this.lblCustomerNoAdd.Text = "-";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] {
            "Trade",
            "General"});
            this.cmbCustomerType.Location = new System.Drawing.Point(207, 50);
            this.cmbCustomerType.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(204, 21);
            this.cmbCustomerType.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Customer Type ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(17, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Forename: ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(17, 135);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Surname:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(17, 177);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Contact No:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(17, 351);
            this.label18.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 17);
            this.label18.TabIndex = 16;
            this.label18.Text = "Postcode:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(17, 262);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Town: ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(17, 307);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "County: ";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.ForeColor = System.Drawing.Color.Black;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage3.Size = new System.Drawing.Size(696, 470);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Edit";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Controls.Add(this.txtCounty2);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.lblCustomerNoEdit);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.txtStreet2);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.txtCompanyName2);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.txtPostcode2);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txtTown2);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtContactNo2);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtSurname2);
            this.panel4.Controls.Add(this.cmbCustomerType2);
            this.panel4.Controls.Add(this.txtForename2);
            this.panel4.Location = new System.Drawing.Point(5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(686, 426);
            this.panel4.TabIndex = 54;
            // 
            // txtCounty2
            // 
            this.txtCounty2.Location = new System.Drawing.Point(207, 307);
            this.txtCounty2.Margin = new System.Windows.Forms.Padding(1);
            this.txtCounty2.Name = "txtCounty2";
            this.txtCounty2.Size = new System.Drawing.Size(204, 20);
            this.txtCounty2.TabIndex = 44;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(17, 11);
            this.label24.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 17);
            this.label24.TabIndex = 28;
            this.label24.Text = "Customer No: ";
            // 
            // lblCustomerNoEdit
            // 
            this.lblCustomerNoEdit.AutoSize = true;
            this.lblCustomerNoEdit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNoEdit.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerNoEdit.Location = new System.Drawing.Point(204, 11);
            this.lblCustomerNoEdit.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCustomerNoEdit.Name = "lblCustomerNoEdit";
            this.lblCustomerNoEdit.Size = new System.Drawing.Size(13, 17);
            this.lblCustomerNoEdit.TabIndex = 29;
            this.lblCustomerNoEdit.Text = "-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(17, 50);
            this.label22.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 17);
            this.label22.TabIndex = 30;
            this.label22.Text = "Customer Type ID:";
            // 
            // txtStreet2
            // 
            this.txtStreet2.Location = new System.Drawing.Point(207, 217);
            this.txtStreet2.Margin = new System.Windows.Forms.Padding(1);
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(204, 20);
            this.txtStreet2.TabIndex = 48;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(17, 393);
            this.label21.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 17);
            this.label21.TabIndex = 31;
            this.label21.Text = "Company Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Street: ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(17, 92);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 17);
            this.label19.TabIndex = 32;
            this.label19.Text = "Forename: ";
            // 
            // txtCompanyName2
            // 
            this.txtCompanyName2.Location = new System.Drawing.Point(207, 393);
            this.txtCompanyName2.Margin = new System.Windows.Forms.Padding(1);
            this.txtCompanyName2.Name = "txtCompanyName2";
            this.txtCompanyName2.Size = new System.Drawing.Size(204, 20);
            this.txtCompanyName2.TabIndex = 46;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(17, 135);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 17);
            this.label17.TabIndex = 33;
            this.label17.Text = "Surname:";
            // 
            // txtPostcode2
            // 
            this.txtPostcode2.Location = new System.Drawing.Point(207, 351);
            this.txtPostcode2.Margin = new System.Windows.Forms.Padding(1);
            this.txtPostcode2.Name = "txtPostcode2";
            this.txtPostcode2.Size = new System.Drawing.Size(204, 20);
            this.txtPostcode2.TabIndex = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(17, 177);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 17);
            this.label15.TabIndex = 34;
            this.label15.Text = "Contact No:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(17, 262);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 35;
            this.label13.Text = "Town: ";
            // 
            // txtTown2
            // 
            this.txtTown2.Location = new System.Drawing.Point(207, 262);
            this.txtTown2.Margin = new System.Windows.Forms.Padding(1);
            this.txtTown2.Name = "txtTown2";
            this.txtTown2.Size = new System.Drawing.Size(204, 20);
            this.txtTown2.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(17, 307);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "County: ";
            // 
            // txtContactNo2
            // 
            this.txtContactNo2.Location = new System.Drawing.Point(207, 177);
            this.txtContactNo2.Margin = new System.Windows.Forms.Padding(1);
            this.txtContactNo2.Name = "txtContactNo2";
            this.txtContactNo2.Size = new System.Drawing.Size(204, 20);
            this.txtContactNo2.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 351);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 37;
            this.label9.Text = "Postcode:";
            // 
            // txtSurname2
            // 
            this.txtSurname2.Location = new System.Drawing.Point(207, 135);
            this.txtSurname2.Margin = new System.Windows.Forms.Padding(1);
            this.txtSurname2.Name = "txtSurname2";
            this.txtSurname2.Size = new System.Drawing.Size(204, 20);
            this.txtSurname2.TabIndex = 41;
            // 
            // cmbCustomerType2
            // 
            this.cmbCustomerType2.FormattingEnabled = true;
            this.cmbCustomerType2.Location = new System.Drawing.Point(207, 50);
            this.cmbCustomerType2.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCustomerType2.Name = "cmbCustomerType2";
            this.cmbCustomerType2.Size = new System.Drawing.Size(204, 21);
            this.cmbCustomerType2.TabIndex = 39;
            // 
            // txtForename2
            // 
            this.txtForename2.Location = new System.Drawing.Point(207, 92);
            this.txtForename2.Margin = new System.Windows.Forms.Padding(1);
            this.txtForename2.Name = "txtForename2";
            this.txtForename2.Size = new System.Drawing.Size(204, 20);
            this.txtForename2.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnCancel2);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Location = new System.Drawing.Point(5, 433);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(686, 34);
            this.panel3.TabIndex = 53;
            // 
            // btnCancel2
            // 
            this.btnCancel2.FlatAppearance.BorderSize = 0;
            this.btnCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel2.ForeColor = System.Drawing.Color.Black;
            this.btnCancel2.Location = new System.Drawing.Point(157, 2);
            this.btnCancel2.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(135, 30);
            this.btnCancel2.TabIndex = 4;
            this.btnCancel2.Text = "Cancel";
            this.btnCancel2.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(0, 2);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(135, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit Customer";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // CustomerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(810, 530);
            this.Controls.Add(this.tabCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CustomerFrm";
            this.Text = "`";
            this.Load += new System.EventHandler(this.CustomerFrm_Load);
            this.Shown += new System.EventHandler(this.CustomerFrm_Shown);
            this.tabCustomers.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCustomers;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtForename;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCustomerNoAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyName2;
        private System.Windows.Forms.TextBox txtPostcode2;
        private System.Windows.Forms.TextBox txtCounty2;
        private System.Windows.Forms.TextBox txtTown2;
        private System.Windows.Forms.TextBox txtContactNo2;
        private System.Windows.Forms.TextBox txtSurname2;
        private System.Windows.Forms.TextBox txtForename2;
        private System.Windows.Forms.ComboBox cmbCustomerType2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCustomerNoEdit;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStreet2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnDeleteDisplay;
        private System.Windows.Forms.Button btnEditDisplay;
        private System.Windows.Forms.Button btnAddDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnAdd;
    }
}

