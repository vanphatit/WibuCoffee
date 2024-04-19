﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using WibuCoffee.Model;

namespace WibuCoffee.View.UC.Manage
{
    public partial class UCReceiptNote : UserControl
    {
        private DataTable data;
        public UCReceiptNote()
        {
            InitializeComponent();

            initComponent();
            loadData();
        }

        private void initComponent()
        {
            cbxFilter.SelectedIndex = 0;

            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ReceiptNoteView");

            cbxSupplier.DataSource = DataProvider.Instance.ExecuteQuery("SELECT name FROM Supplier");
            cbxSupplier.DisplayMember = "name";
            cbxSupplier.SelectedIndex = -1;
            cbxEmployee.DataSource = DataProvider.Instance.ExecuteQuery("SELECT name FROM Employee WHERE jobID = 'J03'");
            cbxEmployee.DisplayMember = "name";
            cbxEmployee.SelectedIndex = -1;
        }

        private void loadData()
        {
            data.Columns[0].ColumnName = "Mã đơn";
            data.Columns[1].ColumnName = "Ngày nhập";
            data.Columns[2].ColumnName = "Nhà cung cấp";
            data.Columns[3].ColumnName = "Nhân viên nhập";
            data.Columns[4].ColumnName = "Giá trị";

            dgvReceiptNote.DataSource = data;
        }

        //Bắt sự kiện cập nhật các ô thông tin bên trái khi click vào dgv
        private void dgvReceiptNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReceiptNote.Rows[e.RowIndex];
                tbxID.Text = row.Cells["Mã đơn"].Value.ToString();

                object date = row.Cells["Ngày nhập"].Value;
                dtpDate.Value = (DateTime)date;

                cbxSupplier.Text = row.Cells["Nhà cung cấp"].Value.ToString();
                cbxEmployee.Text = row.Cells["Nhân viên nhập"].Value.ToString();
                tbxPrice.Text = row.Cells["Giá trị"].Value.ToString();
            }
        }

        private void btnAddReceiptNote_Click(object sender, EventArgs e)
        {
            if (tbxID.Text != "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đơn nhập hàng mới!");
                tbxID.Text = "";
                dtpDate.Value = DateTime.Now;
                cbxSupplier.SelectedIndex = -1;
                cbxEmployee.SelectedIndex = -1;
                tbxPrice.Text = "0";
            }
            else if (DateTime.Now < dtpDate.Value)
                MessageBox.Show("Vui lòng chọn ngày nhập đơn hàng hợp lệ!");
            else if (cbxSupplier.Text == "")
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
            else if (cbxEmployee.Text == "")
                MessageBox.Show("Vui lòng chọn nhân viên!");

            else
            {
                DateTime date = dtpDate.Value;
                string supName = cbxSupplier.Text;
                string empName = cbxEmployee.Text;

                DataProvider.Instance.ExecuteNonQuery("EXEC addNewReceiptNote @date , @empName , @supName",
                    new object[] { date, empName, supName });

                MessageBox.Show("Đã thêm đơn nhập hàng mới thành công.");
                initComponent();
                loadData();
            }
        }

        private void btnUpdateReceiptNote_Click(object sender, EventArgs e)
        {
            if (tbxID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn nhập hàng cần sửa trong bảng dữ liệu!");
            }
            else if (DateTime.Now < dtpDate.Value)
                MessageBox.Show("Vui lòng chọn ngày nhập đơn hàng hợp lệ!");
            else if (cbxSupplier.Text == "")
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
            else if (cbxEmployee.Text == "")
                MessageBox.Show("Vui lòng chọn nhân viên!");

            else
            {
                string id = tbxID.Text;
                DateTime date = dtpDate.Value;
                string supName = cbxSupplier.Text;
                string empName = cbxEmployee.Text;

                DataProvider.Instance.ExecuteNonQuery("EXEC updateNewReceiptNote @id , @date , @empName , @supName",
                    new object[] { id, date, empName, supName });

                MessageBox.Show("Đã sửa đơn nhập hàng thành công.");
                initComponent();
                loadData();
            }
        }

        private void btnDeleteReceiptNote_Click(object sender, EventArgs e)
        {
            if (tbxID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn nhập hàng cần xóa trong bảng dữ liệu!");
            }

            else
            {
                string id = tbxID.Text;

                DataProvider.Instance.ExecuteNonQuery("EXEC deleteReceiptNote @id",
                    new object[] { id });

                MessageBox.Show("Đã xóa đơn nhập hàng thành công.");
                initComponent();
                loadData();
            }
        }



        //Bắt sự kiện ComboBox loại lọc thay đổi thì ComboBox Lọc sẽ thay đổi theo
        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFilter.SelectedItem.ToString() == "LỌC")
            {
                dtpSearch.Visible = false;

                cbxSearch.SelectedIndex = -1;
                cbxSearch.DataSource = null;
                cbxSearch.Items.Clear();
                cbxSearch.Items.Add("TÌM KIẾM");
                cbxSearch.SelectedIndex = 0;
                cbxSearch.Visible = true;
                cbxSearch.Enabled = false;
            }
            else if (cbxFilter.SelectedItem.ToString() == "ID")
            {
                dtpSearch.Visible = false;

                cbxSearch.SelectedIndex = -1;
                cbxSearch.DataSource = null;
                cbxSearch.Items.Clear();
                cbxSearch.DataSource = DataProvider.Instance.ExecuteQuery("SELECT ID FROM ReceiptNoteView");
                cbxSearch.DisplayMember = "ID";
                cbxSearch.SelectedIndex = 0;
                cbxSearch.Visible = true;
                cbxSearch.Enabled = true;
            }
            else if (cbxFilter.SelectedItem.ToString() == "NGÀY")
            {
                cbxSearch.SelectedIndex = -1;
                cbxSearch.DataSource = null;
                cbxSearch.Items.Clear();
                cbxSearch.Visible = false;

                dtpSearch.Visible = true;
            }
            else if (cbxFilter.SelectedItem.ToString() == "NHÀ C.CẤP")
            {
                dtpSearch.Visible = false;

                cbxSearch.SelectedIndex = -1;
                cbxSearch.DataSource = null;
                cbxSearch.Items.Clear();
                cbxSearch.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT [Supplier Name] FROM ReceiptNoteView");
                cbxSearch.DisplayMember = "Supplier Name";
                cbxSearch.SelectedIndex = 0;
                cbxSearch.Visible = true;
                cbxSearch.Enabled = true;
            }
            else if (cbxFilter.SelectedItem.ToString() == "NHÂN VIÊN")
            {
                dtpSearch.Visible = false;

                cbxSearch.SelectedIndex = -1;
                cbxSearch.DataSource = null;
                cbxSearch.Items.Clear();
                cbxSearch.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT [Employee Name] FROM ReceiptNoteView");
                cbxSearch.DisplayMember = "Employee Name";
                cbxSearch.SelectedIndex = 0;
                cbxSearch.Visible = true;
                cbxSearch.Enabled = true;
            }
        }



        //Bắt sự kiện khi nút TÌM được bấm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxFilter.SelectedItem.ToString() == "LỌC")
            {
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ReceiptNoteView");
                loadData();
            }
            else if (cbxFilter.SelectedItem.ToString() == "ID")
            {
                string id = cbxSearch.Text;
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteViewByID( @id )", new object[] { id });
                loadData();
            }
            else if (cbxFilter.SelectedItem.ToString() == "NGÀY")
            {
                DateTime date = dtpSearch.Value;
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteViewByDate( @date )", new object[] { date });
                loadData();
            }
            else if (cbxFilter.SelectedItem.ToString() == "NHÀ C.CẤP")
            {
                string supName = cbxSearch.Text;
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteViewBySupplier( @supName )", new object[] { supName });
                loadData();
            }
            else if (cbxFilter.SelectedItem.ToString() == "NHÂN VIÊN")
            {
                string empName = cbxSearch.Text;
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteViewByEmployee( @empName )", new object[] { empName });
                loadData();
            }
        }





        //Bắt sự kiện khi nhấn vào nút Chi tiết sẽ hiện ra UC chi tiết phiếu nhập
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            UCReceiptNoteDetail ucReceiptNoteDetail = new UCReceiptNoteDetail();
            ucReceiptNoteDetail.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(ucReceiptNoteDetail);
            this.Parent.Controls.Remove(this);
        }
    }
}
