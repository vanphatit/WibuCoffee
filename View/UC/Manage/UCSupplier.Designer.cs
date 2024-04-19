using System;
using System.Windows.Forms;

namespace WibuCoffee.View.UC.Manage
{
    partial class UCSupplier
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
            this.dgvsupplier = new System.Windows.Forms.DataGridView();
            this.tbxNameSupplier = new System.Windows.Forms.TextBox();
            this.tbxPhoneSupplier = new System.Windows.Forms.TextBox();
            this.pBillInfo = new System.Windows.Forms.Panel();
            this.btnDeleteSupplier = new System.Windows.Forms.PictureBox();
            this.btnEditSupplier = new System.Windows.Forms.PictureBox();
            this.btnAddSupplier = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pBillDetail = new System.Windows.Forms.Panel();
            this.mainOrderPanel = new System.Windows.Forms.Panel();
            this.pListTable = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pBill = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxAddressSupplier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxIDSupplier = new System.Windows.Forms.TextBox();
            this.lbBillInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsupplier)).BeginInit();
            this.pBillInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSupplier)).BeginInit();
            this.mainOrderPanel.SuspendLayout();
            this.pListTable.SuspendLayout();
            this.pBill.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvsupplier
            // 
            this.dgvsupplier.AllowUserToAddRows = false;
            this.dgvsupplier.AllowUserToDeleteRows = false;
            this.dgvsupplier.AllowUserToResizeColumns = false;
            this.dgvsupplier.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvsupplier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgvsupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvsupplier.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsupplier.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvsupplier.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvsupplier.GridColor = System.Drawing.Color.Black;
            this.dgvsupplier.Location = new System.Drawing.Point(34, 34);
            this.dgvsupplier.Name = "dgvsupplier";
            this.dgvsupplier.RowHeadersVisible = false;
            this.dgvsupplier.RowHeadersWidth = 50;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvsupplier.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvsupplier.RowTemplate.Height = 24;
            this.dgvsupplier.Size = new System.Drawing.Size(735, 328);
            this.dgvsupplier.TabIndex = 0;
            this.dgvsupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsupplier_CellClick);
            // 
            // tbxNameSupplier
            // 
            this.tbxNameSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxNameSupplier.BackColor = System.Drawing.Color.White;
            this.tbxNameSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxNameSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNameSupplier.ForeColor = System.Drawing.Color.Black;
            this.tbxNameSupplier.Location = new System.Drawing.Point(14, 7);
            this.tbxNameSupplier.Multiline = true;
            this.tbxNameSupplier.Name = "tbxNameSupplier";
            this.tbxNameSupplier.Size = new System.Drawing.Size(202, 40);
            this.tbxNameSupplier.TabIndex = 21;
            // 
            // tbxPhoneSupplier
            // 
            this.tbxPhoneSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxPhoneSupplier.BackColor = System.Drawing.Color.White;
            this.tbxPhoneSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPhoneSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhoneSupplier.ForeColor = System.Drawing.Color.Black;
            this.tbxPhoneSupplier.Location = new System.Drawing.Point(14, 7);
            this.tbxPhoneSupplier.Multiline = true;
            this.tbxPhoneSupplier.Name = "tbxPhoneSupplier";
            this.tbxPhoneSupplier.Size = new System.Drawing.Size(202, 46);
            this.tbxPhoneSupplier.TabIndex = 22;
            // 
            // pBillInfo
            // 
            this.pBillInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBillInfo.Controls.Add(this.dgvsupplier);
            this.pBillInfo.Location = new System.Drawing.Point(19, 278);
            this.pBillInfo.Name = "pBillInfo";
            this.pBillInfo.Size = new System.Drawing.Size(800, 385);
            this.pBillInfo.TabIndex = 2;
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Image = global::WibuCoffee.Properties.Resources.delete;
            this.btnDeleteSupplier.Location = new System.Drawing.Point(659, 118);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(65, 62);
            this.btnDeleteSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteSupplier.TabIndex = 30;
            this.btnDeleteSupplier.TabStop = false;
            this.btnDeleteSupplier.Click += new System.EventHandler(this.btnDeleteSupplier_Click);
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Image = global::WibuCoffee.Properties.Resources.edit;
            this.btnEditSupplier.Location = new System.Drawing.Point(504, 118);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(65, 62);
            this.btnEditSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEditSupplier.TabIndex = 29;
            this.btnEditSupplier.TabStop = false;
            this.btnEditSupplier.Click += new System.EventHandler(this.btnEditSupplier_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Image = global::WibuCoffee.Properties.Resources.plus;
            this.btnAddSupplier.Location = new System.Drawing.Point(363, 118);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(65, 62);
            this.btnAddSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddSupplier.TabIndex = 28;
            this.btnAddSupplier.TabStop = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(568, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "SỐ ĐIỆN THOẠI ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBillDetail
            // 
            this.pBillDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBillDetail.Location = new System.Drawing.Point(842, 22);
            this.pBillDetail.Name = "pBillDetail";
            this.pBillDetail.Size = new System.Drawing.Size(631, 680);
            this.pBillDetail.TabIndex = 1;
            // 
            // mainOrderPanel
            // 
            this.mainOrderPanel.BackColor = System.Drawing.Color.White;
            this.mainOrderPanel.Controls.Add(this.pBillDetail);
            this.mainOrderPanel.Controls.Add(this.pListTable);
            this.mainOrderPanel.Location = new System.Drawing.Point(-4, 0);
            this.mainOrderPanel.Name = "mainOrderPanel";
            this.mainOrderPanel.Size = new System.Drawing.Size(1507, 730);
            this.mainOrderPanel.TabIndex = 3;
            // 
            // pListTable
            // 
            this.pListTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pListTable.Controls.Add(this.label3);
            this.pListTable.Controls.Add(this.pBill);
            this.pListTable.Controls.Add(this.lbBillInfo);
            this.pListTable.Controls.Add(this.pBillInfo);
            this.pListTable.Location = new System.Drawing.Point(0, 22);
            this.pListTable.Name = "pListTable";
            this.pListTable.Size = new System.Drawing.Size(845, 680);
            this.pListTable.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "THÔNG TIN NHÀ CUNG CẤP:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBill
            // 
            this.pBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBill.Controls.Add(this.label1);
            this.pBill.Controls.Add(this.panel2);
            this.pBill.Controls.Add(this.btnDeleteSupplier);
            this.pBill.Controls.Add(this.btnEditSupplier);
            this.pBill.Controls.Add(this.btnAddSupplier);
            this.pBill.Controls.Add(this.label6);
            this.pBill.Controls.Add(this.label5);
            this.pBill.Controls.Add(this.label4);
            this.pBill.Controls.Add(this.panel5);
            this.pBill.Controls.Add(this.panel6);
            this.pBill.Controls.Add(this.panel1);
            this.pBill.Location = new System.Drawing.Point(17, 26);
            this.pBill.Name = "pBill";
            this.pBill.Size = new System.Drawing.Size(800, 198);
            this.pBill.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "ĐỊA CHỈ NHÀ CUNG CẤP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbxAddressSupplier);
            this.panel2.Location = new System.Drawing.Point(16, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 62);
            this.panel2.TabIndex = 31;
            // 
            // tbxAddressSupplier
            // 
            this.tbxAddressSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxAddressSupplier.BackColor = System.Drawing.Color.White;
            this.tbxAddressSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxAddressSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddressSupplier.ForeColor = System.Drawing.Color.Black;
            this.tbxAddressSupplier.Location = new System.Drawing.Point(19, 10);
            this.tbxAddressSupplier.Multiline = true;
            this.tbxAddressSupplier.Name = "tbxAddressSupplier";
            this.tbxAddressSupplier.Size = new System.Drawing.Size(202, 40);
            this.tbxAddressSupplier.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "TÊN NHÀ CUNG CẤP:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "MÃ NHÀ CUNG CẤP:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tbxPhoneSupplier);
            this.panel5.Location = new System.Drawing.Point(548, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(233, 62);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tbxNameSupplier);
            this.panel6.Location = new System.Drawing.Point(282, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(233, 62);
            this.panel6.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxIDSupplier);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(16, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 62);
            this.panel1.TabIndex = 0;
            // 
            // tbxIDSupplier
            // 
            this.tbxIDSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxIDSupplier.BackColor = System.Drawing.Color.White;
            this.tbxIDSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxIDSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIDSupplier.ForeColor = System.Drawing.Color.Black;
            this.tbxIDSupplier.Location = new System.Drawing.Point(14, 10);
            this.tbxIDSupplier.Name = "tbxIDSupplier";
            this.tbxIDSupplier.Size = new System.Drawing.Size(202, 23);
            this.tbxIDSupplier.TabIndex = 22;
            // 
            // lbBillInfo
            // 
            this.lbBillInfo.AutoSize = true;
            this.lbBillInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBillInfo.Location = new System.Drawing.Point(50, 268);
            this.lbBillInfo.Name = "lbBillInfo";
            this.lbBillInfo.Size = new System.Drawing.Size(272, 20);
            this.lbBillInfo.TabIndex = 10;
            this.lbBillInfo.Text = "DANH SÁCH NHÀ CUNG CẤP:";
            this.lbBillInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainOrderPanel);
            this.Name = "UCSupplier";
            this.Size = new System.Drawing.Size(1499, 730);
            this.Load += new System.EventHandler(this.UCSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsupplier)).EndInit();
            this.pBillInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSupplier)).EndInit();
            this.mainOrderPanel.ResumeLayout(false);
            this.pListTable.ResumeLayout(false);
            this.pListTable.PerformLayout();
            this.pBill.ResumeLayout(false);
            this.pBill.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

      

     
     

        #endregion

        private System.Windows.Forms.DataGridView dgvsupplier;
        private System.Windows.Forms.TextBox tbxNameSupplier;
        private System.Windows.Forms.TextBox tbxPhoneSupplier;
        private System.Windows.Forms.Panel pBillInfo;
        private System.Windows.Forms.PictureBox btnDeleteSupplier;
        private System.Windows.Forms.PictureBox btnEditSupplier;
        private System.Windows.Forms.PictureBox btnAddSupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pBillDetail;
        private System.Windows.Forms.Panel mainOrderPanel;
        private System.Windows.Forms.Panel pListTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbBillInfo;
        private TextBox tbxAddressSupplier;
        private TextBox tbxIDSupplier;
    }
}
