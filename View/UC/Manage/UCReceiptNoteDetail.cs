using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace WibuCoffee.View.UC.Manage
{
    public partial class UCReceiptNoteDetail : UserControl
    {
        private DataTable dataRN, dataRNDetail;
        public UCReceiptNoteDetail()
        {
            InitializeComponent();
            initComponent();
            loadDataRN();
        }

        private void initComponent()
        {
            cbxFilter.SelectedIndex = 0;

            dataRN = DataProvider.Instance.ExecuteQuery("SELECT * FROM ReceiptNoteListView");

            cbxMaterial.DataSource = DataProvider.Instance.ExecuteQuery("SELECT name FROM Material");
            cbxMaterial.DisplayMember = "name";
            cbxMaterial.SelectedIndex = -1;
            tbxQuantity.Text = "0";
            tbxUnitPrice.Text = "0";
            dgvRNDetail.DataSource = null;


        }

        private void loadDataRN()
        {
            dataRN.Columns[0].ColumnName = "Mã đơn";
            dataRN.Columns[1].ColumnName = "Ngày nhập";
            dataRN.Columns[2].ColumnName = "Nhân viên nhập";
            dataRN.Columns[3].ColumnName = "Nhà cung cấp";

            dgvRN.DataSource = dataRN;
        }

        private void loadDataRNDetail()
        {
            dataRNDetail.Columns[0].ColumnName = "Tên ng.liệu";
            dataRNDetail.Columns[1].ColumnName = "Số lượng";
            dataRNDetail.Columns[2].ColumnName = "Đơn giá";
            dgvRNDetail.DataSource = dataRNDetail;
        }

        //Bắt sự kiện cập nhật các component thông tin bên trái khi click vào dgv
        private void dgvRN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRN.Rows[e.RowIndex];
                string id = row.Cells["Mã đơn"].Value.ToString();

                dataRNDetail =
                    DataProvider.Instance.ExecuteQuery("SELECT * from dbo.seeReceiptNoteDetail( @id )",
                        new object[] { id });
                loadDataRNDetail();

                decimal price =
                    (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.calReceiptNotePrice( @id )", new object[] { id });
                lblPrice.Text = price.ToString() + " VND";
            }
        }

        

        //Bắt sự kiện cập nhật các ô thông tin bên trên khi click vào dgv
        private void dgvRNDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRNDetail.Rows[e.RowIndex];
                cbxMaterial.Text = row.Cells[0].Value.ToString();
                tbxQuantity.Text = row.Cells[1].Value.ToString();
                tbxUnitPrice.Text = row.Cells[2].Value.ToString();
            }
        }


        //Bắt sự kiện khi nhấn vào nút thêm
        private void btnAddRNDetail_Click(object sender, EventArgs e)
        {
            if (cbxMaterial.Text == "")
                MessageBox.Show("Vui lòng chọn nguyên liệu cần nhập!");
            else if (double.TryParse(tbxQuantity.Text, out double result1) && result1 <= 0)
                MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0!");
            else if (double.TryParse(tbxUnitPrice.Text, out double result2) && result2 <= 0)
                MessageBox.Show("Vui lòng nhập đơn giá lớn hơn 0!");

            else
            {
                string rnID = dgvRN.Rows[dgvRN.SelectedCells[0].RowIndex].Cells[0].Value.ToString(); //Lấy ID trong dgvRN

                string mID =
                    (string)DataProvider.Instance.ExecuteQuery(
                        "SELECT ID FROM Material WHERE name = '" + cbxMaterial.Text + "'").Rows[0]["ID"];
                decimal quantity = decimal.Parse(tbxQuantity.Text);
                decimal unitPrice = decimal.Parse(tbxUnitPrice.Text);

                DataProvider.Instance.ExecuteNonQuery("EXEC addReceiptNoteDetail @rnNoteID , @materialID , @quantity , @unitPrice",
                    new object[] { rnID, mID, quantity, unitPrice });

                MessageBox.Show("Đã thêm chi tiết đơn nhập hàng mới thành công.");

                dataRNDetail =
                    DataProvider.Instance.ExecuteQuery("SELECT * from dbo.seeReceiptNoteDetail( @id )",
                        new object[] { rnID });
                loadDataRNDetail();

                decimal price =
                    (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.calReceiptNotePrice( @id )", new object[] { rnID });
                lblPrice.Text = price.ToString() + " VND";
            }
        }

        //Bắt sự kiện khi nhấn vào nút sửa
        private void btnUpdateRNDetail_Click(object sender, EventArgs e)
        {
            if (cbxMaterial.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin chi tiết đơn nhập hàng cần sửa!");
            }
            else if (double.TryParse(tbxQuantity.Text, out double result1) && result1 <= 0)
                MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0!");
            else if (double.TryParse(tbxUnitPrice.Text, out double result2) && result2 <= 0)
                MessageBox.Show("Vui lòng nhập đơn giá lớn hơn 0!");

            else
            {
                string rnID = dgvRN.Rows[dgvRN.SelectedCells[0].RowIndex].Cells[0].Value.ToString(); //Lấy ID trong dgvRN

                string mID =
                    (string)DataProvider.Instance.ExecuteQuery(
                        "SELECT ID FROM Material WHERE name = '" + cbxMaterial.Text + "'").Rows[0]["ID"];
                decimal quantity = decimal.Parse(tbxQuantity.Text);
                decimal unitPrice = decimal.Parse(tbxUnitPrice.Text);

                DataProvider.Instance.ExecuteNonQuery("EXEC updateReceiptNoteDetail @rnNoteID , @materialID , @quantity , @unitPrice",
                    new object[] { rnID, mID, quantity, unitPrice });

                MessageBox.Show("Đã sửa chi tiết đơn nhập hàng thành công.");

                dataRNDetail =
                    DataProvider.Instance.ExecuteQuery("SELECT * from dbo.seeReceiptNoteDetail( @id )",
                        new object[] { rnID });
                loadDataRNDetail();

                decimal price =
                    (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.calReceiptNotePrice( @id )", new object[] { rnID });
                lblPrice.Text = price.ToString() + " VND";

            }
        }


        //Bắt sự kiện khi nhấn vào nút xóa
        private void btnDeleteRNDetail_Click(object sender, EventArgs e)
        {
            if (cbxMaterial.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin chi tiết đơn nhập hàng cần xóa!");
            }

            else
            {
                string rnID = dgvRN.Rows[dgvRN.SelectedCells[0].RowIndex].Cells[0].Value.ToString(); //Lấy ID trong dgvRN

                string mID =
                    (string)DataProvider.Instance.ExecuteQuery(
                        "SELECT ID FROM Material WHERE name = '" + cbxMaterial.Text + "'").Rows[0]["ID"];
                

                DataProvider.Instance.ExecuteNonQuery("EXEC deleteReceiptNoteDetail @rnNoteID , @materialID",
                    new object[] { rnID, mID });

                MessageBox.Show("Đã xóa chi tiết đơn nhập hàng thành công.");

                dataRNDetail =
                    DataProvider.Instance.ExecuteQuery("SELECT * from dbo.seeReceiptNoteDetail( @id )",
                        new object[] { rnID });
                loadDataRNDetail();

                decimal price =
                    (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.calReceiptNotePrice( @id )", new object[] { rnID });
                lblPrice.Text = price.ToString() + " VND";
            }
        }

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
                dataRN = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ReceiptNoteListView");
                loadDataRN();
            }
            else if (cbxFilter.SelectedItem.ToString() == "ID")
            {
                string id = cbxSearch.Text;
                dataRN = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteListViewByID( @id )", new object[] { id });
                loadDataRN();
            }
            else if (cbxFilter.SelectedItem.ToString() == "NGÀY")
            {
                DateTime date = dtpSearch.Value;
                dataRN = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteListViewByDate( @date )", new object[] { date });
                loadDataRN();
            }
            else if (cbxFilter.SelectedItem.ToString() == "NHÀ C.CẤP")
            {
                string supName = cbxSearch.Text;
                dataRN = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteListViewBySupplier( @supName )", new object[] { supName });
                loadDataRN();
            }
            else if (cbxFilter.SelectedItem.ToString() == "NHÂN VIÊN")
            {
                string empName = cbxSearch.Text;
                dataRN = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterReceiptNoteListViewByEmployee( @empName )", new object[] { empName });
                loadDataRN();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UCReceiptNote ucReceiptNote = new UCReceiptNote();
            ucReceiptNote.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(ucReceiptNote);
            this.Parent.Controls.Remove(this);
        }
    }
}
