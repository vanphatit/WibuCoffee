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

namespace WibuCoffee.View.UC.Manage
{
    public partial class UCExpenseBill : UserControl
    {
        private DataTable data;

        public UCExpenseBill()
        {
            InitializeComponent();
            initComponent();
            loadData();
        }

        private void initComponent()
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "yyyy-MM-dd";

            cbxFilter.SelectedIndex = 0;

            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ExpenseBillView");
            data.Columns[0].ColumnName = "Mã phiếu chi";
            data.Columns[1].ColumnName = "Ngày nhập";
            data.Columns[2].ColumnName = "Giá trị";
            data.Columns[3].ColumnName = "Chi tiết";
            dgvExpenseBill.DataSource = data;
        }

        private void loadData()
        {
            data.Columns[0].ColumnName = "Mã phiếu chi";
            data.Columns[1].ColumnName = "Ngày nhập";
            data.Columns[2].ColumnName = "Giá trị";
            data.Columns[3].ColumnName = "Chi tiết";

            dgvExpenseBill.DataSource = data;
        }



        //Bắt sự kiện khi nút THÊM được bấm
        private void btnAddExpenseBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxID.Text != "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin phiếu chi mới!", "Thông báo");
                    tbxID.Text = "";
                    dtpDate.Value = DateTime.Now;
                    tbxPrice.Text = "";
                    tbxDetail.Text = "";
                }

                else
                {
                    DateTime date = dtpDate.Value;
                    string price = tbxPrice.Text;
                    string detail = tbxDetail.Text;

                    DataProvider.Instance.ExecuteNonQuery("EXEC addNewExpenseBill @date , @price , @detail",
                        new object[] { date, price, detail });

                    MessageBox.Show("Đã thêm phiếu chi mới thành công.");
                    initComponent();
                }
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
            }
        }


        //Bắt sự kiện khi nút SỬA được bấm
        private void btnUpdateExpenseBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxID.Text == "")
                    MessageBox.Show("Vui lòng chọn phiếu chi cần sửa trong bảng dữ liệu.", "Thông báo");
                else if (!double.TryParse(tbxPrice.Text, out double result))
                    MessageBox.Show("Vui lòng nhập vào giá trị là một số.", "Báo lỗi!");
                else
                {
                    string id = tbxID.Text;
                    DateTime date = dtpDate.Value;
                    string price = tbxPrice.Text;
                    string detail = tbxDetail.Text;

                    DataProvider.Instance.ExecuteNonQuery("EXEC updateExpenseBill @id , @date , @price , @detail",
                        new object[] { id, date, price, detail });

                    MessageBox.Show("Đã sửa phiếu chi thành công.", "Thông báo");
                    initComponent();
                }
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
            }
        }

        //Bắt sự kiện khi nút XÓA được bấm
        private void btnDeleteExpenseBill_Click(object sender, EventArgs e)
        {
            try
            {
                string id = tbxID.Text;

                DataProvider.Instance.ExecuteNonQuery("EXEC deleteExpenseBill @id",
                    new object[] { id });

                MessageBox.Show("Đã xóa phiếu chi thành công.", "Thông báo");
                initComponent();
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "Báo lỗi!");
            }
        }


        //Bắt sự kiện khi nút TÌM được bấm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxFilter.SelectedItem.ToString() == "LỌC")
                {
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ExpenseBillView");
                    loadData();
                }
                else if (cbxFilter.SelectedItem.ToString() == "ID")
                {
                    string id = cbxSearch.Text;
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterExpenseBillByID( @id )",
                        new object[] { id });
                    loadData();
                }
                else if (cbxFilter.SelectedItem.ToString() == "NGÀY")
                {
                    DateTime date = dtpFilterEX.Value;
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterExpenseBillByDate( @date )",
                        new object[] { date });
                    loadData();
                }
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
                dtpFilterEX.Visible = false;

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
                dtpFilterEX.Visible = false;

                cbxSearch.SelectedIndex = -1;
                cbxSearch.DataSource = null;
                cbxSearch.Items.Clear();
                cbxSearch.DataSource = DataProvider.Instance.ExecuteQuery("SELECT ID FROM ExpenseBillView");
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

                dtpFilterEX.Visible = true;
            }
        }

        //Bắt sự kiện cập nhật các ô thông tin bên trái khi click vào dgv
        private void dgvExpenseBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExpenseBill.Rows[e.RowIndex];
                tbxID.Text = row.Cells["Mã phiếu chi"].Value.ToString();

                object date = row.Cells["Ngày nhập"].Value;
                dtpDate.Value = (DateTime)date;

                tbxPrice.Text = row.Cells["Giá trị"].Value.ToString();
                tbxDetail.Text = row.Cells["Chi tiết"].Value.ToString();
            }
        }
    }
}
