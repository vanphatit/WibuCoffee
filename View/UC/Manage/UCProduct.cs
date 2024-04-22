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
    public partial class UCProduct : UserControl
    {
        private DataTable dtProductCategory = new DataTable();
        private DataTable dtProduct;
        private DataTable dtMaterial;
        private DataTable dtProductMaterial;

        string IDProduct = "";

        public UCProduct()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtProductCategory = DataProvider.Instance.ExecuteQuery("SELECT * FROM ProductCategoryView");
                foreach (DataRow row in dtProductCategory.Rows)
                {
                    cbbProductCategories.Items.Add(row["Name"]);
                }
                dgvProductCategory.DataSource = dtProductCategory;
                dgvProductCategory.Columns["id"].HeaderText = "Mã";
                dgvProductCategory.Columns["name"].HeaderText = "Tên";

                dtProduct = DataProvider.Instance.ExecuteQuery("SELECT * FROM ProductView");
                dgvProduct.DataSource = dtProduct;
                dgvProduct.Columns["id"].HeaderText = "Mã";
                dgvProduct.Columns["name"].HeaderText = "Tên";
                dgvProduct.Columns["price"].HeaderText = "Giá";
                dgvProduct.Columns["productcategory"].HeaderText = "Loại";
                dgvProduct.Columns["status"].HeaderText = "Trạng thái";


                dtMaterial = DataProvider.Instance.ExecuteQuery("SELECT * FROM Material");
                foreach (DataRow row in dtMaterial.Rows)
                {
                    cbbMaterialName.Items.Add(row["Name"]);
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void UCProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadProductMaterial();
        }

        void LoadProductMaterial()
        {
            // Get selected row
            int index = dgvProduct.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvProduct.Rows[index];
            IDProduct = tbxIDProduct.Text = selectedRow.Cells["id"].Value.ToString();
            tbxNameProduct.Text = selectedRow.Cells["name"].Value.ToString();
            tbxPriceProduct.Text = selectedRow.Cells["price"].Value.ToString();
            cbbProductCategories.Text = selectedRow.Cells["productcategory"].Value.ToString();
            tbxStatusProduct.Text = selectedRow.Cells["status"].Value.ToString();

            dtProductMaterial = DataProvider.Instance.ExecuteQuery("SELECT * FROM GetMaterials ( @productID )"
                , new object[] { selectedRow.Cells["id"].Value.ToString() });
            dgvMaterialProduct.DataSource = dtProductMaterial;
            dgvMaterialProduct.Columns["materialname"].HeaderText = "Tên";
            dgvMaterialProduct.Columns["quantity"].HeaderText = "SL";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Check empty
            if (tbxNameProduct.Text == "" || tbxPriceProduct.Text == "" || cbbProductCategories.Text == "" || tbxStatusProduct.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check price
            if (!decimal.TryParse(tbxPriceProduct.Text, out decimal price))
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check status
            if (String.IsNullOrEmpty(tbxStatusProduct.Text))
            {
                MessageBox.Show("Trạng thái sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check product category
            string productCategoryID = "";
            foreach (DataRow row in dtProductCategory.Rows)
            {
                if (row["Name"].ToString() == cbbProductCategories.Text)
                {
                    productCategoryID = row["ID"].ToString();
                    break;
                }
            }
            if (String.IsNullOrEmpty(productCategoryID) || productCategoryID == "Loại món")
            {
                MessageBox.Show("Loại sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Add product
                DataProvider.Instance.ExecuteNonQuery("EXEC AddProduct @id , @name , @categoryID , @price , @status"
                                   , new object[] { "P00", tbxNameProduct.Text, productCategoryID, price, tbxStatusProduct.Text });
                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            } catch (SqlException err)
            {
                MessageBox.Show("Thêm sản phẩm thất bại \n " + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            // Check empty
            if (tbxNameProduct.Text == "" || tbxPriceProduct.Text == "" || cbbProductCategories.Text == "" || tbxStatusProduct.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check price
            if (!decimal.TryParse(tbxPriceProduct.Text, out decimal price))
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check status
            if (String.IsNullOrEmpty(tbxStatusProduct.Text))
            {
                MessageBox.Show("Trạng thái sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check product category
            string productCategoryID = "";
            foreach (DataRow row in dtProductCategory.Rows)
            {
                if (row["Name"].ToString() == cbbProductCategories.Text)
                {
                    productCategoryID = row["ID"].ToString();
                    break;
                }
            }
            if (String.IsNullOrEmpty(productCategoryID) || productCategoryID == "Loại món")
            {
                MessageBox.Show("Loại sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Edit product
                DataProvider.Instance.ExecuteNonQuery("EXEC UpdateProductByID @id , @name , @categoryID , @price , @status"
                                                      , new object[] { tbxIDProduct.Text, tbxNameProduct.Text, productCategoryID, price, tbxStatusProduct.Text });
                MessageBox.Show("Sửa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (SqlException err)
            {
                MessageBox.Show("Sửa sản phẩm thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // show confirm dialog
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Delete product
                DataProvider.Instance.ExecuteNonQuery("EXEC DeleteProductByID @id"
                                                                         , new object[] { tbxIDProduct.Text });
                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (SqlException err)
            {
                MessageBox.Show("Xóa sản phẩm thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dgvProductCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get selected row
            int index = dgvProductCategory.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvProductCategory.Rows[index];
            tbxIDCate.Text = selectedRow.Cells["id"].Value.ToString();
            tbxNameCate.Text = selectedRow.Cells["name"].Value.ToString();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            // Check empty
            if (tbxNameCate.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Add product category
                DataProvider.Instance.ExecuteNonQuery("EXEC AddProductCategory @id , @name"
                                                      , new object[] { "C00", tbxNameCate.Text });
                MessageBox.Show("Thêm loại món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (SqlException err)
            {
                MessageBox.Show("Thêm loại món thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            // Check empty
            if (tbxNameCate.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Edit product category
                DataProvider.Instance.ExecuteNonQuery("EXEC updateProductCategoryByID @id , @name"
                                                                         , new object[] { tbxIDCate.Text, tbxNameCate.Text });
                MessageBox.Show("Sửa loại món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (SqlException err)
            {
                MessageBox.Show("Sửa loại món thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            // Check empty
            if (cbbMaterialName.SelectedItem.ToString() == "" || txbMaterialCount.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check count
            if (!Int32.TryParse(txbMaterialCount.Text, out int count) && count <= 0)
            {
                MessageBox.Show("Đơn vị không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check product
            if (String.IsNullOrEmpty(IDProduct))
            {
                MessageBox.Show("Sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string materialID = "";
                foreach (DataRow row in dtMaterial.Rows)
                {
                    if (row["Name"].ToString() == cbbMaterialName.SelectedItem.ToString())
                    {
                        materialID = row["ID"].ToString();
                        break;
                    }
                }

                // Add material
                DataProvider.Instance.ExecuteNonQuery("EXEC addProductMaterial @productID , @materialID , @quantity"
                                                                         , new object[] { IDProduct, materialID, txbMaterialCount.Text });
                MessageBox.Show("Thêm nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LoadProductMaterial();
            }
            catch (SqlException err)
            {
                MessageBox.Show("Thêm nguyên liệu thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnEditMaterial_Click(object sender, EventArgs e)
        {
            // Check empty
            if (cbbMaterialName.SelectedItem.ToString() == "" || txbMaterialCount.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check unit
            if (Int32.TryParse(txbMaterialCount.Text, out int count) && count <= 0)
            {
                MessageBox.Show("Đơn vị không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check product
            if (String.IsNullOrEmpty(IDProduct))
            {
                MessageBox.Show("Sản phẩm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string materialID = "";
                foreach (DataRow row in dtMaterial.Rows)
                {
                    if (row["Name"].ToString() == cbbMaterialName.SelectedItem.ToString())
                    {
                        materialID = row["ID"].ToString();
                        break;
                    }
                }

                // Edit material
                DataProvider.Instance.ExecuteNonQuery("EXEC updateProductMaterialByID @productID , @materialID , @quantity"
                                                                                            , new object[] { IDProduct, materialID, txbMaterialCount.Text });
                MessageBox.Show("Sửa nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LoadProductMaterial();
            }
            catch (SqlException err)
            {
                MessageBox.Show("Sửa nguyên liệu thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                // show confirm dialog
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                string materialID = "";
                foreach (DataRow row in dtMaterial.Rows)
                {
                    if (row["Name"].ToString() == cbbMaterialName.SelectedItem.ToString())
                    {
                        materialID = row["ID"].ToString();
                        break;
                    }
                }

                // Delete material
                DataProvider.Instance.ExecuteNonQuery("EXEC deleteProductMaterialByID @productID , @materialID"
                                                      , new object[] { IDProduct, materialID });
                MessageBox.Show("Xóa nguyên liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LoadProductMaterial();
            }
            catch (SqlException err)
            {
                MessageBox.Show("Xóa nguyên liệu thất bại\n" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dgvMaterialProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get selected row
            int index = dgvMaterialProduct.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dgvMaterialProduct.Rows[index];
            cbbMaterialName.Text = selectedRow.Cells["materialname"].Value.ToString();
            txbMaterialCount.Text = selectedRow.Cells["quantity"].Value.ToString();
        }
    }
}
