﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WibuCoffee.View.UC.Manage
{
    public partial class UCBillHistory : UserControl
    {
        DataGridView dgvListBill = new DataGridView();
        DataGridView dgvBillInfo = new DataGridView();

        DataTable dataBill;
 
        Font font = new Font("Google Sans", 12, FontStyle.Regular);
        Font fontSmall = new Font("Google Sans", 12, FontStyle.Regular);

        public UCBillHistory()
        {
            InitializeComponent();
            reload();
            reloadDGV(dataBill);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //trở về UCOrder
            UCOrder uCOrder = new UCOrder();
            this.Controls.Clear();
            this.Controls.Add(uCOrder);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxFilter.Text == "Mã hóa đơn")
            {
                string id = cbxSearch.Text;

                try
                {
                    dataBill = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterBillByID ( @id )", new object[] { id });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reloadDGV(dataBill);
            }  
            else if (cbxFilter.Text == "Ngày lập")
            {
                DateTime date = dtpSearch.Value;

                try
                {
                    dataBill = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterBillByDate ( @date )", new object[] { date });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reloadDGV(dataBill);
            }
            else if (cbxFilter.Text == "Loại hóa đơn")
            {
                string category = cbxSearch.Text;
                
                try
                {
                    dataBill = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterBillByCategory ( @category )", new object[] { category });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reloadDGV(dataBill);
            }
            else
            {
                try
                {
                    dataBill = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllBillView");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reloadDGV(dataBill);
            }
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            if (cbxFilter.Text == "Tất cả")
            {
                dtpSearch.Visible = true;
                cbxSearch.Visible = false;

                try
                {
                    dataBill = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllBillView");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reloadDGV(dataBill);
            }
            else if (cbxFilter.Text == "Mã hóa đơn")
            {
                cbxSearch.Visible = true;
                dtpSearch.Visible = false;
                cbxSearch.Items.Clear();
                cbxSearch.Text = "Chọn mã hóa đơn";

                try
                {
                    data = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllBillID");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataRow item in data.Rows)
                {
                    cbxSearch.Items.Add(item["ID"]);
                }

            }
            else if (cbxFilter.Text == "Ngày lập")
            {
                dtpSearch.Visible = true;
                cbxSearch.Visible = false;
                cbxSearch.Items.Clear();
            }
            else if (cbxFilter.Text == "Loại hóa đơn")
            {
                cbxSearch.Visible = true;
                dtpSearch.Visible = false;
                cbxSearch.Items.Clear();
                cbxSearch.Text = "Chọn loại hóa đơn";

                try
                {
                    data = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllBillCategory");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataRow item in data.Rows)
                {
                    cbxSearch.Items.Add(item["name"]);
                }
            }
            else
            {
                dtpSearch.Visible = true;
                cbxSearch.Visible = false;

                try
                {
                    dataBill = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllBillView");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reloadDGV(dataBill);
            }
        }

        public void dgvListBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dataBillView = new DataTable();
            DataTable data = new DataTable();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListBill.SelectedRows[0];

                string id = row.Cells[0].Value.ToString();

                tbxCategories.Text = row.Cells[2].Value.ToString();

                try
                {
                    dataBillView = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfoViewByID ( @id )", new object[] { id });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tbxCategories.Text = dataBillView.Rows[0]["categoryName"].ToString();
                tbxIDBill.Text = dataBillView.Rows[0]["ID"].ToString();
                tbxEmp.Text = dataBillView.Rows[0]["empName"].ToString();
                tbxDate.Text = dataBillView.Rows[0]["dateTime"].ToString();
                tbxPhone.Text = dataBillView.Rows[0]["phone"].ToString();
                tbxCustomerName.Text = dataBillView.Rows[0]["customerName"].ToString();
                lbTableID.Text = dataBillView.Rows[0]["tableID"].ToString();

                tbxCategories.Enabled = false;
                tbxIDBill.Enabled = false;
                tbxEmp.Enabled = false;
                tbxDate.Enabled = false;
                tbxPhone.Enabled = false;
                tbxCustomerName.Enabled = false;

                try
                {
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillDetail ( @id )", new object[] { id });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                data.Columns["billID"].ColumnName = "Mã hóa đơn";
                data.Columns["name"].ColumnName = "Tên sản phẩm";
                data.Columns["quantity"].ColumnName = "Số lượng";
                data.Columns["totalPrice"].ColumnName = "Đơn giá";

                dgvBillInfo.DataSource = data;
                pListBillInfo.Controls.Clear();
                pListBillInfo.Controls.Add(dgvBillInfo);

                try
                {
                    lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @id )", new object[] { id }).ToString();
                    lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @id )", new object[] { id }).ToString();
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void reloadDGV(DataTable data)
        {
            pListBill.Controls.Clear();
            dgvListBill.DataSource = data;

            dgvListBill.Dock = DockStyle.Fill;
            dgvBillInfo.Dock = DockStyle.Fill;
            dgvListBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListBill.RowHeadersVisible = false;
            dgvBillInfo.RowHeadersVisible = false;
            dgvListBill.AllowUserToResizeRows = false;
            dgvBillInfo.AllowUserToResizeRows = false;
            dgvListBill.BackgroundColor = Color.White;
            dgvBillInfo.BackgroundColor = Color.White;
            dgvListBill.GridColor = Color.Black;
            dgvBillInfo.GridColor = Color.Black;

            dgvListBill.BorderStyle = BorderStyle.FixedSingle;
            dgvBillInfo.BorderStyle = BorderStyle.FixedSingle;

            dgvListBill.ColumnHeadersDefaultCellStyle.Font = font;
            dgvBillInfo.ColumnHeadersDefaultCellStyle.Font = fontSmall;
            dgvListBill.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvBillInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvListBill.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBillInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBillInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvBillInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvListBill.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvBillInfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvListBill.ColumnHeadersHeight = 50;
            dgvBillInfo.ColumnHeadersHeight = 65;

            dgvListBill.AllowDrop = false;
            dgvBillInfo.AllowDrop = false;
            dgvListBill.AllowUserToAddRows = false;
            dgvBillInfo.AllowUserToAddRows = false;
            dgvListBill.AllowUserToDeleteRows = false;
            dgvBillInfo.AllowUserToDeleteRows = false;
            dgvListBill.AllowUserToOrderColumns = false;
            dgvBillInfo.AllowUserToOrderColumns = false;
            dgvListBill.AllowUserToResizeColumns = true;
            dgvBillInfo.AllowUserToResizeColumns = true;
            dgvListBill.AllowUserToResizeRows = false;
            dgvBillInfo.AllowUserToResizeRows = false;
            dgvListBill.ReadOnly = true;
            dgvListBill.ReadOnly = true;

            dgvListBill.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = font,
                ForeColor = Color.Black,
                BackColor = Color.White,
                SelectionForeColor = Color.White,
                SelectionBackColor = Color.Gray,
            };
            dgvBillInfo.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = fontSmall,
                ForeColor = Color.Black,
                BackColor = Color.White,
                SelectionForeColor = Color.White,
                SelectionBackColor = Color.Gray,
            };

            dtpSearch.Format = DateTimePickerFormat.Custom;
            dtpSearch.CustomFormat = "dd/MM/yyyy";

            pListBillInfo.Controls.Add(dgvBillInfo);
            pListBill.Controls.Add(dgvListBill);

        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            if (dgvListBill.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvListBill.SelectedRows[0];
                string id = row.Cells[0].Value.ToString();

                try
                {
                    DataProvider.Instance.ExecuteNonQuery("EXEC dbo.deleteBillByID @id", new object[] { id });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Xóa hóa đơn thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    dataBill = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllBillView");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                dgvBillInfo.DataSource = null;
                
                reloadDGV(dataBill);
                reloadDGV();
            }
        }

        private void reloadDGV()
        {
            tbxCategories.Text = "";
            tbxIDBill.Text = "";
            tbxEmp.Text = "";
            tbxDate.Text = "";
            tbxPhone.Text = "";
            tbxCustomerName.Text = "";
            lbTableID.Text = "";
            lbTotalPrice.Text = "";
            lbShowDis.Text = "";
        }

        private void reload ()
        {
            try
            {
                dataBill = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllBillView");
            }
            catch (SqlException ev)
            {
                MessageBox.Show(" Load dữ liệu thất bại! \n Do: \n " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvListBill.CellClick += new DataGridViewCellEventHandler(dgvListBill_CellClick);

            cbxFilter.Items.Clear();
            cbxSearch.Items.Clear();
            cbxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxFilter.Items.Add("Tất cả");
            cbxFilter.Items.Add("Mã hóa đơn");
            cbxFilter.Items.Add("Ngày lập");
            cbxFilter.Items.Add("Loại hóa đơn");

            dataBill.Columns["ID"].ColumnName = "Mã hóa đơn";
            dataBill.Columns["dateTime"].ColumnName = "Ngày lập";
            dataBill.Columns["name"].ColumnName = "Loại hóa đơn";
            dataBill.Columns["receiptMoney"].ColumnName = "Tiền nhận";
        }
    }
}
