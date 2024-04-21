using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

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
            try
            {
                cbxFilter.SelectedIndex = 0;

                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ReceiptNoteView");

                cbxSupplier.DataSource = DataProvider.Instance.ExecuteQuery("SELECT name FROM Supplier");
                cbxSupplier.DisplayMember = "name";
                cbxSupplier.SelectedIndex = -1;
                cbxEmployee.DataSource =
                    DataProvider.Instance.ExecuteQuery("SELECT name FROM Employee WHERE jobID = 'J03'");
                cbxEmployee.DisplayMember = "name";
                cbxEmployee.SelectedIndex = -1;

                tbxID.Text = "";
                dtpDate.Value = DateTime.Now;
                tbxPrice.Text = "0";
                cbxEmployee.Text = "";
                cbxSupplier.Text = "";
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
            }
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
            try
            {
                if (tbxID.Text != "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin đơn nhập hàng mới!");
                    initComponent();
                }

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
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
            }
        }

        private void btnUpdateReceiptNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxID.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn đơn nhập hàng cần sửa trong bảng dữ liệu!");
                }

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
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
            }
        }

        private void btnDeleteReceiptNote_Click(object sender, EventArgs e)
        {
            try
            {
                string id = tbxID.Text;

                DataProvider.Instance.ExecuteNonQuery("EXEC deleteReceiptNote @id",
                    new object[] { id });

                MessageBox.Show("Đã xóa đơn nhập hàng thành công.");
                initComponent();
                loadData();
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
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

                try
                {
                    cbxSearch.DataSource = DataProvider.Instance.ExecuteQuery("SELECT ID FROM ReceiptNoteView");
                }
                catch (SqlException sqlException)
                {
                    MessageBox.Show(sqlException.Message, "Báo lỗi!");
                }

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

                try
                {
                    cbxSearch.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT [Supplier Name] FROM ReceiptNoteView");
                }
                catch (SqlException sqlException)
                {
                    MessageBox.Show(sqlException.Message, "Báo lỗi!");
                }
                
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

                try
                {
                    cbxSearch.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT [Employee Name] FROM ReceiptNoteView");
                }
                catch (SqlException sqlException)
                {
                    MessageBox.Show(sqlException.Message, "Báo lỗi!");
                }
                
                cbxSearch.DisplayMember = "Employee Name";
                cbxSearch.SelectedIndex = 0;
                cbxSearch.Visible = true;
                cbxSearch.Enabled = true;
            }
        }



        //Bắt sự kiện khi nút TÌM được bấm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxFilter.SelectedItem.ToString() == "LỌC")
                {
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ReceiptNoteView");
                    loadData();
                }
                else if (cbxFilter.SelectedItem.ToString() == "ID")
                {
                    string id = cbxSearch.Text;
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteViewByID( @id )",
                        new object[] { id });
                    loadData();
                }
                else if (cbxFilter.SelectedItem.ToString() == "NGÀY")
                {
                    DateTime date = dtpSearch.Value;
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteViewByDate( @date )",
                        new object[] { date });
                    loadData();
                }
                else if (cbxFilter.SelectedItem.ToString() == "NHÀ C.CẤP")
                {
                    string supName = cbxSearch.Text;
                    data = DataProvider.Instance.ExecuteQuery(
                        "SELECT * FROM dbo.filterReceiptNoteViewBySupplier( @supName )", new object[] { supName });
                    loadData();
                }
                else if (cbxFilter.SelectedItem.ToString() == "NHÂN VIÊN")
                {
                    string empName = cbxSearch.Text;
                    data = DataProvider.Instance.ExecuteQuery(
                        "SELECT * FROM dbo.filterReceiptNoteViewByEmployee( @empName )", new object[] { empName });
                    loadData();
                }
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
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
