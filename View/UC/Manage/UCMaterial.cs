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
    public partial class UCMaterial : UserControl
    {
        private DataTable dtMaterial;
        string IDMaterial = "";

        public UCMaterial()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dtMaterial = DataProvider.Instance.ExecuteQuery("SELECT * FROM MaterialDetailss");
            dgvMaterial.DataSource = dtMaterial;
            dgvMaterial.Columns["id"].HeaderText = "Mã";
            dgvMaterial.Columns["name"].HeaderText = "Tên";
            dgvMaterial.Columns["status"].HeaderText = "Trạng thái";
        }


        private void UCMaterial_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void dgvMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvMaterial.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvMaterial.Rows[index];
            IDMaterial = tbxIDMaterial.Text = selectedRow.Cells["id"].Value.ToString();
            tbxNameMaterial.Text = selectedRow.Cells["name"].Value.ToString();
            tbxStatusMaterial.Text = selectedRow.Cells["status"].Value.ToString();
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            // Check empty
            if (tbxNameMaterial.Text == "" || tbxStatusMaterial.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Add Supplier
                DataProvider.Instance.ExecuteNonQuery("EXEC AddMaterial @id , @name , @status"
                                   , new object[] { "M00", tbxNameMaterial.Text, tbxStatusMaterial.Text});
                MessageBox.Show("Thêm nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (SqlException err)
            {
                MessageBox.Show("Thêm nguyên liệu thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (tbxNameMaterial.Text == "" || tbxStatusMaterial.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Edit product
                DataProvider.Instance.ExecuteNonQuery("EXEC UpdateMaterial @id , @name , @status"
                                                      , new object[] { IDMaterial, tbxNameMaterial.Text, tbxStatusMaterial.Text }) ;
                MessageBox.Show("Sửa thông tin nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (SqlException err)
            {
                MessageBox.Show("Sửa thông tin nhà cung cấp thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}

