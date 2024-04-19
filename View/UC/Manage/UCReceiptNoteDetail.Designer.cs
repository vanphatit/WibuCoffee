namespace WibuCoffee.View.UC.Manage
{
    partial class UCReceiptNoteDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pListTable = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbListBill = new System.Windows.Forms.Label();
            this.pListBill = new System.Windows.Forms.Panel();
            this.dgvRN = new System.Windows.Forms.DataGridView();
            this.lbSearch = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvRNDetail = new System.Windows.Forms.DataGridView();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxUnitPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxMaterial = new System.Windows.Forms.ComboBox();
            this.btnDeleteRNDetail = new System.Windows.Forms.Button();
            this.btnUpdateRNDetail = new System.Windows.Forms.Button();
            this.btnAddRNDetail = new System.Windows.Forms.Button();
            this.pListTable.SuspendLayout();
            this.pListBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRN)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRNDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pListTable
            // 
            this.pListTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pListTable.Controls.Add(this.btnBack);
            this.pListTable.Controls.Add(this.lbListBill);
            this.pListTable.Controls.Add(this.pListBill);
            this.pListTable.Controls.Add(this.lbSearch);
            this.pListTable.Controls.Add(this.searchPanel);
            this.pListTable.Location = new System.Drawing.Point(42, 38);
            this.pListTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pListTable.Name = "pListTable";
            this.pListTable.Size = new System.Drawing.Size(1260, 1061);
            this.pListTable.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBack.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(18, 979);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(225, 72);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "TRỞ VỀ";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbListBill
            // 
            this.lbListBill.AutoSize = true;
            this.lbListBill.Font = new System.Drawing.Font("Google Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListBill.Location = new System.Drawing.Point(44, 166);
            this.lbListBill.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbListBill.Name = "lbListBill";
            this.lbListBill.Size = new System.Drawing.Size(438, 36);
            this.lbListBill.TabIndex = 19;
            this.lbListBill.Text = "DANH SÁCH ĐƠN NHẬP HÀNG:";
            this.lbListBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pListBill
            // 
            this.pListBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pListBill.Controls.Add(this.dgvRN);
            this.pListBill.Location = new System.Drawing.Point(18, 187);
            this.pListBill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pListBill.Name = "pListBill";
            this.pListBill.Padding = new System.Windows.Forms.Padding(20);
            this.pListBill.Size = new System.Drawing.Size(1217, 782);
            this.pListBill.TabIndex = 18;
            // 
            // dgvRN
            // 
            this.dgvRN.AllowUserToAddRows = false;
            this.dgvRN.AllowUserToDeleteRows = false;
            this.dgvRN.AllowUserToResizeColumns = false;
            this.dgvRN.AllowUserToResizeRows = false;
            this.dgvRN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRN.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRN.ColumnHeadersHeight = 85;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRN.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRN.Location = new System.Drawing.Point(20, 20);
            this.dgvRN.Name = "dgvRN";
            this.dgvRN.ReadOnly = true;
            this.dgvRN.RowHeadersVisible = false;
            this.dgvRN.RowHeadersWidth = 82;
            this.dgvRN.RowTemplate.Height = 33;
            this.dgvRN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRN.Size = new System.Drawing.Size(1175, 740);
            this.dgvRN.TabIndex = 2;
            this.dgvRN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRN_CellClick);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Google Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(44, 21);
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
            this.searchPanel.Controls.Add(this.cbxFilter);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Location = new System.Drawing.Point(18, 39);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1217, 93);
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
            this.cbxSearch.Location = new System.Drawing.Point(277, 19);
            this.cbxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(715, 49);
            this.cbxSearch.TabIndex = 18;
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
            this.dtpSearch.Location = new System.Drawing.Point(277, 20);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(715, 47);
            this.dtpSearch.TabIndex = 19;
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
            this.cbxFilter.Location = new System.Drawing.Point(21, 19);
            this.cbxFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(249, 49);
            this.cbxFilter.TabIndex = 17;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1000, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 62);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "TÌM";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1310, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 1061);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Google Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 36);
            this.label1.TabIndex = 20;
            this.label1.Text = "CHI TIẾT ĐƠN NHẬP HÀNG:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.lblPrice);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnDeleteRNDetail);
            this.panel2.Controls.Add(this.btnUpdateRNDetail);
            this.panel2.Controls.Add(this.btnAddRNDetail);
            this.panel2.Location = new System.Drawing.Point(20, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 1000);
            this.panel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Google Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 427);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(557, 36);
            this.label7.TabIndex = 20;
            this.label7.Text = "DANH SÁCH CHI TIẾT ĐƠN NHẬP HÀNG:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvRNDetail);
            this.panel5.Location = new System.Drawing.Point(14, 450);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(20);
            this.panel5.Size = new System.Drawing.Size(817, 478);
            this.panel5.TabIndex = 23;
            // 
            // dgvRNDetail
            // 
            this.dgvRNDetail.AllowUserToAddRows = false;
            this.dgvRNDetail.AllowUserToDeleteRows = false;
            this.dgvRNDetail.AllowUserToResizeColumns = false;
            this.dgvRNDetail.AllowUserToResizeRows = false;
            this.dgvRNDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRNDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRNDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRNDetail.ColumnHeadersHeight = 85;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRNDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRNDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRNDetail.Location = new System.Drawing.Point(20, 20);
            this.dgvRNDetail.Name = "dgvRNDetail";
            this.dgvRNDetail.ReadOnly = true;
            this.dgvRNDetail.RowHeadersVisible = false;
            this.dgvRNDetail.RowHeadersWidth = 82;
            this.dgvRNDetail.RowTemplate.Height = 33;
            this.dgvRNDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRNDetail.Size = new System.Drawing.Size(775, 436);
            this.dgvRNDetail.TabIndex = 3;
            this.dgvRNDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRNDetail_CellClick);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Google Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Red;
            this.lblPrice.Location = new System.Drawing.Point(576, 944);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(233, 36);
            this.lblPrice.TabIndex = 22;
            this.lblPrice.Text = "xxx.xxx.xxx VND";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Google Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(445, 944);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 36);
            this.label3.TabIndex = 21;
            this.label3.Text = "TỔNG:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 281);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 27);
            this.label2.TabIndex = 18;
            this.label2.Text = "ĐƠN GIÁ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tbxUnitPrice);
            this.panel4.Location = new System.Drawing.Point(31, 293);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(558, 96);
            this.panel4.TabIndex = 17;
            // 
            // tbxUnitPrice
            // 
            this.tbxUnitPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxUnitPrice.BackColor = System.Drawing.Color.White;
            this.tbxUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxUnitPrice.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUnitPrice.ForeColor = System.Drawing.Color.Black;
            this.tbxUnitPrice.Location = new System.Drawing.Point(21, 11);
            this.tbxUnitPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxUnitPrice.Multiline = true;
            this.tbxUnitPrice.Name = "tbxUnitPrice";
            this.tbxUnitPrice.Size = new System.Drawing.Size(517, 72);
            this.tbxUnitPrice.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 27);
            this.label5.TabIndex = 16;
            this.label5.Text = "SỐ LƯỢNG:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Google Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 27);
            this.label4.TabIndex = 15;
            this.label4.Text = "TÊN NGUYÊN LIỆU:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tbxQuantity);
            this.panel6.Location = new System.Drawing.Point(31, 169);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(558, 96);
            this.panel6.TabIndex = 14;
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxQuantity.BackColor = System.Drawing.Color.White;
            this.tbxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxQuantity.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuantity.ForeColor = System.Drawing.Color.Black;
            this.tbxQuantity.Location = new System.Drawing.Point(21, 11);
            this.tbxQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxQuantity.Multiline = true;
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.Size = new System.Drawing.Size(517, 72);
            this.tbxQuantity.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cbxMaterial);
            this.panel3.Location = new System.Drawing.Point(31, 44);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(558, 96);
            this.panel3.TabIndex = 13;
            // 
            // cbxMaterial
            // 
            this.cbxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaterial.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaterial.FormattingEnabled = true;
            this.cbxMaterial.ItemHeight = 41;
            this.cbxMaterial.Location = new System.Drawing.Point(21, 20);
            this.cbxMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxMaterial.Name = "cbxMaterial";
            this.cbxMaterial.Size = new System.Drawing.Size(517, 49);
            this.cbxMaterial.TabIndex = 1;
            // 
            // btnDeleteRNDetail
            // 
            this.btnDeleteRNDetail.BackColor = System.Drawing.Color.Red;
            this.btnDeleteRNDetail.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRNDetail.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRNDetail.Location = new System.Drawing.Point(622, 293);
            this.btnDeleteRNDetail.Name = "btnDeleteRNDetail";
            this.btnDeleteRNDetail.Size = new System.Drawing.Size(202, 96);
            this.btnDeleteRNDetail.TabIndex = 7;
            this.btnDeleteRNDetail.Text = "XÓA";
            this.btnDeleteRNDetail.UseVisualStyleBackColor = false;
            this.btnDeleteRNDetail.Click += new System.EventHandler(this.btnDeleteRNDetail_Click);
            // 
            // btnUpdateRNDetail
            // 
            this.btnUpdateRNDetail.BackColor = System.Drawing.Color.Gold;
            this.btnUpdateRNDetail.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRNDetail.ForeColor = System.Drawing.Color.White;
            this.btnUpdateRNDetail.Location = new System.Drawing.Point(622, 169);
            this.btnUpdateRNDetail.Name = "btnUpdateRNDetail";
            this.btnUpdateRNDetail.Size = new System.Drawing.Size(202, 96);
            this.btnUpdateRNDetail.TabIndex = 6;
            this.btnUpdateRNDetail.Text = "SỬA";
            this.btnUpdateRNDetail.UseVisualStyleBackColor = false;
            this.btnUpdateRNDetail.Click += new System.EventHandler(this.btnUpdateRNDetail_Click);
            // 
            // btnAddRNDetail
            // 
            this.btnAddRNDetail.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddRNDetail.Font = new System.Drawing.Font("Google Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRNDetail.ForeColor = System.Drawing.Color.White;
            this.btnAddRNDetail.Location = new System.Drawing.Point(622, 44);
            this.btnAddRNDetail.Name = "btnAddRNDetail";
            this.btnAddRNDetail.Size = new System.Drawing.Size(202, 96);
            this.btnAddRNDetail.TabIndex = 5;
            this.btnAddRNDetail.Text = "THÊM";
            this.btnAddRNDetail.UseVisualStyleBackColor = false;
            this.btnAddRNDetail.Click += new System.EventHandler(this.btnAddRNDetail_Click);
            // 
            // UCReceiptNoteDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pListTable);
            this.Name = "UCReceiptNoteDetail";
            this.Size = new System.Drawing.Size(2248, 1141);
            this.pListTable.ResumeLayout(false);
            this.pListTable.PerformLayout();
            this.pListBill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRN)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRNDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pListTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbListBill;
        private System.Windows.Forms.Panel pListBill;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeleteRNDetail;
        private System.Windows.Forms.Button btnUpdateRNDetail;
        private System.Windows.Forms.Button btnAddRNDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbxUnitPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.ComboBox cbxSearch;
        private System.Windows.Forms.DateTimePicker dtpSearch;
        private System.Windows.Forms.DataGridView dgvRN;
        private System.Windows.Forms.DataGridView dgvRNDetail;
    }
}
