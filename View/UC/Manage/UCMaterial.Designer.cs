using System;

namespace WibuCoffee.View.UC.Manage
{
    partial class UCMaterial
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
            this.label3 = new System.Windows.Forms.Label();
            this.lbBillInfo = new System.Windows.Forms.Label();
            this.mainOrderPanel = new System.Windows.Forms.Panel();
            this.pBillDetail = new System.Windows.Forms.Panel();
            this.pListTable = new System.Windows.Forms.Panel();
            this.pBill = new System.Windows.Forms.Panel();
            this.btnEditMaterial = new System.Windows.Forms.PictureBox();
            this.btnAddMaterial = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbxStatusMaterial = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbxNameMaterial = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxIDMaterial = new System.Windows.Forms.TextBox();
            this.pBillInfo = new System.Windows.Forms.Panel();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.mainOrderPanel.SuspendLayout();
            this.pListTable.SuspendLayout();
            this.pBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddMaterial)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pBillInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "THÔNG TIN NGUYÊN LIỆU:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBillInfo
            // 
            this.lbBillInfo.AutoSize = true;
            this.lbBillInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBillInfo.Location = new System.Drawing.Point(50, 268);
            this.lbBillInfo.Name = "lbBillInfo";
            this.lbBillInfo.Size = new System.Drawing.Size(217, 20);
            this.lbBillInfo.TabIndex = 10;
            this.lbBillInfo.Text = "DANH SÁCH CÁC MÓN:";
            this.lbBillInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainOrderPanel
            // 
            this.mainOrderPanel.BackColor = System.Drawing.Color.White;
            this.mainOrderPanel.Controls.Add(this.pBillDetail);
            this.mainOrderPanel.Controls.Add(this.pListTable);
            this.mainOrderPanel.Location = new System.Drawing.Point(-4, 3);
            this.mainOrderPanel.Name = "mainOrderPanel";
            this.mainOrderPanel.Size = new System.Drawing.Size(1507, 727);
            this.mainOrderPanel.TabIndex = 2;
            // 
            // pBillDetail
            // 
            this.pBillDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBillDetail.Location = new System.Drawing.Point(842, 22);
            this.pBillDetail.Name = "pBillDetail";
            this.pBillDetail.Size = new System.Drawing.Size(631, 680);
            this.pBillDetail.TabIndex = 1;
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
            // pBill
            // 
            this.pBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBill.Controls.Add(this.btnEditMaterial);
            this.pBill.Controls.Add(this.btnAddMaterial);
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
            // btnEditMaterial
            // 
            this.btnEditMaterial.Image = global::WibuCoffee.Properties.Resources.edit;
            this.btnEditMaterial.Location = new System.Drawing.Point(508, 116);
            this.btnEditMaterial.Name = "btnEditMaterial";
            this.btnEditMaterial.Size = new System.Drawing.Size(65, 62);
            this.btnEditMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEditMaterial.TabIndex = 29;
            this.btnEditMaterial.TabStop = false;
            this.btnEditMaterial.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Image = global::WibuCoffee.Properties.Resources.plus;
            this.btnAddMaterial.Location = new System.Drawing.Point(228, 116);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(65, 62);
            this.btnAddMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddMaterial.TabIndex = 28;
            this.btnAddMaterial.TabStop = false;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(568, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "TRẠNG THÁI NGUYÊN LIỆU:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "TÊN NGUYÊN LIỆU:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "MÃ NGUYÊN LIỆU:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tbxStatusMaterial);
            this.panel5.Location = new System.Drawing.Point(548, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(233, 62);
            this.panel5.TabIndex = 1;
            // 
            // tbxStatusMaterial
            // 
            this.tbxStatusMaterial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxStatusMaterial.BackColor = System.Drawing.Color.White;
            this.tbxStatusMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxStatusMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStatusMaterial.ForeColor = System.Drawing.Color.Black;
            this.tbxStatusMaterial.Location = new System.Drawing.Point(14, 7);
            this.tbxStatusMaterial.Multiline = true;
            this.tbxStatusMaterial.Name = "tbxStatusMaterial";
            this.tbxStatusMaterial.Size = new System.Drawing.Size(202, 46);
            this.tbxStatusMaterial.TabIndex = 22;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tbxNameMaterial);
            this.panel6.Location = new System.Drawing.Point(282, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(233, 62);
            this.panel6.TabIndex = 1;
            // 
            // tbxNameMaterial
            // 
            this.tbxNameMaterial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxNameMaterial.BackColor = System.Drawing.Color.White;
            this.tbxNameMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxNameMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNameMaterial.ForeColor = System.Drawing.Color.Black;
            this.tbxNameMaterial.Location = new System.Drawing.Point(14, 7);
            this.tbxNameMaterial.Multiline = true;
            this.tbxNameMaterial.Name = "tbxNameMaterial";
            this.tbxNameMaterial.Size = new System.Drawing.Size(202, 40);
            this.tbxNameMaterial.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxIDMaterial);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(16, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 62);
            this.panel1.TabIndex = 0;
            // 
            // tbxIDMaterial
            // 
            this.tbxIDMaterial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxIDMaterial.BackColor = System.Drawing.Color.White;
            this.tbxIDMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxIDMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIDMaterial.ForeColor = System.Drawing.Color.Black;
            this.tbxIDMaterial.Location = new System.Drawing.Point(14, 10);
            this.tbxIDMaterial.Multiline = true;
            this.tbxIDMaterial.Name = "tbxIDMaterial";
            this.tbxIDMaterial.Size = new System.Drawing.Size(202, 40);
            this.tbxIDMaterial.TabIndex = 22;
            // 
            // pBillInfo
            // 
            this.pBillInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBillInfo.Controls.Add(this.dgvMaterial);
            this.pBillInfo.Location = new System.Drawing.Point(19, 278);
            this.pBillInfo.Name = "pBillInfo";
            this.pBillInfo.Size = new System.Drawing.Size(800, 385);
            this.pBillInfo.TabIndex = 2;
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.AllowUserToResizeColumns = false;
            this.dgvMaterial.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMaterial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaterial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgvMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterial.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMaterial.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterial.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMaterial.GridColor = System.Drawing.Color.Black;
            this.dgvMaterial.Location = new System.Drawing.Point(34, 34);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.RowHeadersVisible = false;
            this.dgvMaterial.RowHeadersWidth = 50;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMaterial.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMaterial.RowTemplate.Height = 24;
            this.dgvMaterial.Size = new System.Drawing.Size(735, 328);
            this.dgvMaterial.TabIndex = 0;
            this.dgvMaterial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterial_CellContentClick);
            // 
            // UCMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainOrderPanel);
            this.Name = "UCMaterial";
            this.Size = new System.Drawing.Size(1499, 730);
            this.Load += new System.EventHandler(this.UCMaterial_Load);
            this.mainOrderPanel.ResumeLayout(false);
            this.pListTable.ResumeLayout(false);
            this.pListTable.PerformLayout();
            this.pBill.ResumeLayout(false);
            this.pBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddMaterial)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pBillInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbBillInfo;
        private System.Windows.Forms.Panel mainOrderPanel;
        private System.Windows.Forms.Panel pBillDetail;
        private System.Windows.Forms.Panel pListTable;
        private System.Windows.Forms.Panel pBill;
        private System.Windows.Forms.PictureBox btnEditMaterial;
        private System.Windows.Forms.PictureBox btnAddMaterial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbxStatusMaterial;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbxNameMaterial;
        private System.Windows.Forms.Panel pBillInfo;
        private System.Windows.Forms.DataGridView dgvMaterial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxIDMaterial;
    }
  
}
