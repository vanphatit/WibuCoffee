namespace WibuCoffee.View.UC.Manage
{
    partial class UCReceiptNote
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvReceiptNote = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbxEmployee = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cbxSupplier = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.tbxID = new System.Windows.Forms.TextBox();
            this.btnDeleteReceiptNote = new System.Windows.Forms.Button();
            this.btnUpdateReceiptNote = new System.Windows.Forms.Button();
            this.btnAddReceiptNote = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNote)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnViewDetail);
            this.panel2.Controls.Add(this.lbSearch);
            this.panel2.Controls.Add(this.searchPanel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(634, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1585, 1088);
            this.panel2.TabIndex = 3;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewDetail.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetail.ForeColor = System.Drawing.Color.White;
            this.btnViewDetail.Location = new System.Drawing.Point(1299, 68);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(219, 93);
            this.btnViewDetail.TabIndex = 17;
            this.btnViewDetail.Text = "CHI TIẾT";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Google Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(105, 50);
            this.lbSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(148, 36);
            this.lbSearch.TabIndex = 16;
            this.lbSearch.Text = "TÌM KIẾM:";
            this.lbSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchPanel
            // 
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.cbxSearch);
            this.searchPanel.Controls.Add(this.dtpSearch);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.cbxFilter);
            this.searchPanel.Location = new System.Drawing.Point(54, 68);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1229, 93);
            this.searchPanel.TabIndex = 15;
            // 
            // cbxSearch
            // 
            this.cbxSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSearch.BackColor = System.Drawing.Color.White;
            this.cbxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearch.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSearch.ForeColor = System.Drawing.Color.Black;
            this.cbxSearch.FormattingEnabled = true;
            this.cbxSearch.Location = new System.Drawing.Point(301, 17);
            this.cbxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(684, 49);
            this.cbxSearch.TabIndex = 16;
            // 
            // dtpSearch
            // 
            this.dtpSearch.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpSearch.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpSearch.CalendarTitleBackColor = System.Drawing.Color.Gray;
            this.dtpSearch.CalendarTitleForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpSearch.CustomFormat = " yyyy - MM - dd";
            this.dtpSearch.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearch.Location = new System.Drawing.Point(301, 18);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(684, 47);
            this.dtpSearch.TabIndex = 17;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(994, 17);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 49);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "TÌM";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxFilter
            // 
            this.cbxFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxFilter.BackColor = System.Drawing.Color.White;
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFilter.ForeColor = System.Drawing.Color.Black;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "LỌC",
            "ID",
            "NGÀY",
            "NHÀ C.CẤP",
            "NHÂN VIÊN"});
            this.cbxFilter.Location = new System.Drawing.Point(15, 17);
            this.cbxFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(279, 49);
            this.cbxFilter.TabIndex = 15;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Google Sans", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(113, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(448, 35);
            this.label7.TabIndex = 3;
            this.label7.Text = "BẢNG DỮ LIỆU ĐƠN NHẬP HÀNG:";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvReceiptNote);
            this.panel5.Location = new System.Drawing.Point(27, 241);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(20);
            this.panel5.Size = new System.Drawing.Size(1526, 811);
            this.panel5.TabIndex = 2;
            // 
            // dgvReceiptNote
            // 
            this.dgvReceiptNote.AllowUserToAddRows = false;
            this.dgvReceiptNote.AllowUserToDeleteRows = false;
            this.dgvReceiptNote.AllowUserToResizeColumns = false;
            this.dgvReceiptNote.AllowUserToResizeRows = false;
            this.dgvReceiptNote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceiptNote.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceiptNote.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceiptNote.ColumnHeadersHeight = 85;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceiptNote.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceiptNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptNote.Location = new System.Drawing.Point(20, 20);
            this.dgvReceiptNote.Name = "dgvReceiptNote";
            this.dgvReceiptNote.ReadOnly = true;
            this.dgvReceiptNote.RowHeadersVisible = false;
            this.dgvReceiptNote.RowHeadersWidth = 82;
            this.dgvReceiptNote.RowTemplate.Height = 33;
            this.dgvReceiptNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptNote.Size = new System.Drawing.Size(1484, 769);
            this.dgvReceiptNote.TabIndex = 1;
            this.dgvReceiptNote.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptNote_CellClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnDeleteReceiptNote);
            this.panel1.Controls.Add(this.btnUpdateReceiptNote);
            this.panel1.Controls.Add(this.btnAddReceiptNote);
            this.panel1.Location = new System.Drawing.Point(29, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 1088);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Google Sans", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÔNG TIN ĐƠN NHẬP HÀNG:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Location = new System.Drawing.Point(12, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(555, 805);
            this.panel3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 635);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 27);
            this.label2.TabIndex = 30;
            this.label2.Text = "GIÁ TRỊ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tbxPrice);
            this.panel6.Location = new System.Drawing.Point(58, 647);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(437, 96);
            this.panel6.TabIndex = 29;
            // 
            // tbxPrice
            // 
            this.tbxPrice.BackColor = System.Drawing.Color.White;
            this.tbxPrice.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPrice.Location = new System.Drawing.Point(20, 17);
            this.tbxPrice.Multiline = true;
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.ReadOnly = true;
            this.tbxPrice.Size = new System.Drawing.Size(394, 60);
            this.tbxPrice.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 483);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 27);
            this.label6.TabIndex = 28;
            this.label6.Text = "NHÂN VIÊN NHẬP:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cbxEmployee);
            this.panel4.Location = new System.Drawing.Point(58, 495);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(437, 96);
            this.panel4.TabIndex = 27;
            // 
            // cbxEmployee
            // 
            this.cbxEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxEmployee.BackColor = System.Drawing.Color.White;
            this.cbxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmployee.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEmployee.ForeColor = System.Drawing.Color.Black;
            this.cbxEmployee.FormattingEnabled = true;
            this.cbxEmployee.Items.AddRange(new object[] {
            "Chọn nhân viên"});
            this.cbxEmployee.Location = new System.Drawing.Point(16, 23);
            this.cbxEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxEmployee.Name = "cbxEmployee";
            this.cbxEmployee.Size = new System.Drawing.Size(403, 49);
            this.cbxEmployee.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 332);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 27);
            this.label4.TabIndex = 26;
            this.label4.Text = "NHÀ CUNG CẤP:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.cbxSupplier);
            this.panel10.Location = new System.Drawing.Point(58, 344);
            this.panel10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(437, 96);
            this.panel10.TabIndex = 25;
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSupplier.BackColor = System.Drawing.Color.White;
            this.cbxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSupplier.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSupplier.ForeColor = System.Drawing.Color.Black;
            this.cbxSupplier.FormattingEnabled = true;
            this.cbxSupplier.Items.AddRange(new object[] {
            "Chọn nhà cung cấp"});
            this.cbxSupplier.Location = new System.Drawing.Point(17, 19);
            this.cbxSupplier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(403, 49);
            this.cbxSupplier.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(85, 183);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 27);
            this.label8.TabIndex = 24;
            this.label8.Text = "NGÀY NHẬP:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.dtpDate);
            this.panel11.Location = new System.Drawing.Point(59, 195);
            this.panel11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(437, 96);
            this.panel11.TabIndex = 23;
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.CustomFormat = " yyyy - MM - dd";
            this.dtpDate.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(20, 26);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(394, 47);
            this.dtpDate.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(84, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 27);
            this.label9.TabIndex = 22;
            this.label9.Text = "MÃ ĐƠN:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.tbxID);
            this.panel12.Location = new System.Drawing.Point(58, 48);
            this.panel12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(437, 96);
            this.panel12.TabIndex = 21;
            // 
            // tbxID
            // 
            this.tbxID.BackColor = System.Drawing.Color.White;
            this.tbxID.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxID.Location = new System.Drawing.Point(20, 17);
            this.tbxID.Multiline = true;
            this.tbxID.Name = "tbxID";
            this.tbxID.ReadOnly = true;
            this.tbxID.Size = new System.Drawing.Size(394, 60);
            this.tbxID.TabIndex = 0;
            // 
            // btnDeleteReceiptNote
            // 
            this.btnDeleteReceiptNote.BackColor = System.Drawing.Color.Red;
            this.btnDeleteReceiptNote.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteReceiptNote.ForeColor = System.Drawing.Color.White;
            this.btnDeleteReceiptNote.Location = new System.Drawing.Point(388, 912);
            this.btnDeleteReceiptNote.Name = "btnDeleteReceiptNote";
            this.btnDeleteReceiptNote.Size = new System.Drawing.Size(143, 102);
            this.btnDeleteReceiptNote.TabIndex = 4;
            this.btnDeleteReceiptNote.Text = "XÓA";
            this.btnDeleteReceiptNote.UseVisualStyleBackColor = false;
            this.btnDeleteReceiptNote.Click += new System.EventHandler(this.btnDeleteReceiptNote_Click);
            // 
            // btnUpdateReceiptNote
            // 
            this.btnUpdateReceiptNote.BackColor = System.Drawing.Color.Gold;
            this.btnUpdateReceiptNote.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateReceiptNote.ForeColor = System.Drawing.Color.White;
            this.btnUpdateReceiptNote.Location = new System.Drawing.Point(218, 912);
            this.btnUpdateReceiptNote.Name = "btnUpdateReceiptNote";
            this.btnUpdateReceiptNote.Size = new System.Drawing.Size(143, 102);
            this.btnUpdateReceiptNote.TabIndex = 3;
            this.btnUpdateReceiptNote.Text = "SỬA";
            this.btnUpdateReceiptNote.UseVisualStyleBackColor = false;
            this.btnUpdateReceiptNote.Click += new System.EventHandler(this.btnUpdateReceiptNote_Click);
            // 
            // btnAddReceiptNote
            // 
            this.btnAddReceiptNote.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddReceiptNote.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReceiptNote.ForeColor = System.Drawing.Color.White;
            this.btnAddReceiptNote.Location = new System.Drawing.Point(45, 912);
            this.btnAddReceiptNote.Name = "btnAddReceiptNote";
            this.btnAddReceiptNote.Size = new System.Drawing.Size(143, 102);
            this.btnAddReceiptNote.TabIndex = 2;
            this.btnAddReceiptNote.Text = "THÊM";
            this.btnAddReceiptNote.UseVisualStyleBackColor = false;
            this.btnAddReceiptNote.Click += new System.EventHandler(this.btnAddReceiptNote_Click);
            // 
            // UCReceiptNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCReceiptNote";
            this.Size = new System.Drawing.Size(2248, 1141);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNote)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.ComboBox cbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteReceiptNote;
        private System.Windows.Forms.Button btnUpdateReceiptNote;
        private System.Windows.Forms.Button btnAddReceiptNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DateTimePicker dtpSearch;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.DataGridView dgvReceiptNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.ComboBox cbxEmployee;
        private System.Windows.Forms.ComboBox cbxSupplier;
    }
}
