using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WibuCoffee.Model;

namespace WibuCoffee.View.UC.Manage
{
    public partial class UCSupplier : UserControl
    {
        private DataTable dtSupplier;
        string IDSupplier = "";

        public UCSupplier()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dtSupplier = DataProvider.Instance.ExecuteQuery("SELECT * FROM SupplierList");
            dgvsupplier.DataSource = dtSupplier;
            dgvsupplier.Columns["ID"].HeaderText = "Mã";
            dgvsupplier.Columns["name"].HeaderText = "Tên";
            dgvsupplier.Columns["address"].HeaderText = "Địa chỉ";
            dgvsupplier.Columns["phone"].HeaderText = "Số điện thoại";
        }

        private void UCSupplier_Load(object sender, EventArgs e)
        {
            LoadData();
        }

       

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            // Check empty
            if (tbxNameSupplier.Text == "" || tbxPhoneSupplier.Text == "" || tbxAddressSupplier.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Add Supplier
                DataProvider.Instance.ExecuteNonQuery("EXEC AddSupplier @ID , @name , @phone , @address"
                                   , new object[] { "SP00", tbxNameSupplier.Text, tbxPhoneSupplier.Text, tbxAddressSupplier.Text});
                MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (tbxNameSupplier.Text == "" || tbxPhoneSupplier.Text == "" || tbxAddressSupplier.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Edit product
                DataProvider.Instance.ExecuteNonQuery("EXEC UpdateSupplier @ID , @name , @phone , @address"
                                                      , new object[] { IDSupplier, tbxNameSupplier.Text, tbxPhoneSupplier.Text, tbxAddressSupplier.Text });
                MessageBox.Show("Sửa thông tin nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                // show confirm dialog
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Delete product
                DataProvider.Instance.ExecuteNonQuery("EXEC DeleteSupplier @id"
                                                                         , new object[] { tbxIDSupplier.Text });
                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dgvsupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvsupplier.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvsupplier.Rows[index];
            IDSupplier = tbxIDSupplier.Text = selectedRow.Cells["ID"].Value.ToString();
            tbxNameSupplier.Text = selectedRow.Cells["name"].Value.ToString();
            tbxPhoneSupplier.Text = selectedRow.Cells["phone"].Value.ToString();
            tbxAddressSupplier.Text = selectedRow.Cells["address"].Value.ToString();
        }

        private void pBill_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
