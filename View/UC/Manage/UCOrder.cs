using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WibuCoffee.View.UC.Manage
{
    public partial class UCOrder : UserControl
    {
        private int x = 25;
        private int y = 30;

        private Font font = new Font("Google Sans", 12, FontStyle.Bold);

        private Button btnAddTable = new Button() {
            Width = 75, Height = 75,
            Text = "+",
            Font = new Font("Google Sans", 12, FontStyle.Bold),
            BackColor = Color.LightGray
        };

        private DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
        private DataTable dataBill = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill");
        private DataTable dataProduct = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Product");
        private DataTable dataCategories = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillCategory");
        private DataTable dataEmployee = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employee");

        private List<Button> listButton = new List<Button>();
        private List<Boolean> buttonClick = new List<Boolean>();
        public UCOrder()
        {
            InitializeComponent();
            tbxDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (dataBill.Rows.Count == 0)
            {
                tbxIDBill.Text = "B000001";
            }
            else if (dataBill.Rows.Count < 10)
            {
                tbxIDBill.Text = "B00000" + (dataBill.Rows.Count + 1);
            }
            else
            {
                tbxIDBill.Text = "B0000" + (dataBill.Rows.Count + 1);
            }    
            for (int i = 0; i < dataProduct.Rows.Count; i++)
            {
                cbxProduct.Items.Add(dataProduct.Rows[i]["name"].ToString());
            }
            for (int i = 0; i < dataCategories.Rows.Count; i++)
            {
                cbxCategories.Items.Add(dataCategories.Rows[i]["name"].ToString());
            }
            for (int i = 0; i < dataEmployee.Rows.Count; i++)
            {
                cbxEmp.Items.Add(dataEmployee.Rows[i]["name"].ToString());
            }
            tbxQuantity.Text = "0";
            tbxReceiptMoney.Text = "0";
            lbShowDis.Text = "0 VND";
            lbTotalPrice.Text = "0 VND";
            btnAddTable.Click += btnAddTable_Click;
            paintTable();
            addBtnClick();
        }

        private void paintTable()
        {
            pTable.Controls.Clear();
            listButton.Clear();
            buttonClick.Clear();
            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
            //Tạo ra các button tương ứng với số bàn mỗi button cách nhau 20 và có kích thước 75*75, nếu tableStatus = Occupied thì button màu đỏ, tableStatus = 0 thì button màu xanh
            for (int i = 0; i <= data.Rows.Count; i++)
            {
                if (i == data.Rows.Count)
                {
                    btnAddTable.Location = new Point(x, y);
                    pTable.Controls.Add(btnAddTable);
                }
                else
                {
                    Button btn = new Button() { Width = 75, Height = 75 };
                    btn.Text = data.Rows[i]["ID"].ToString();
                    btn.Font = font; 
                    btn.Location = new Point(x, y);
                    if (data.Rows[i]["status"].ToString() == "Occupied")
                    {
                        btn.BackColor = Color.DodgerBlue;
                    }
                    else
                    {
                        btn.BackColor = Color.LightGray;
                    }
                    x += 85;
                    if (x > 250)
                    {
                        x = 25;
                        y += 100;
                    }
                    listButton.Add(btn);
                    buttonClick.Add(false);
                    pTable.Controls.Add(btn);
                }
            }
            x = 25;
            y = 30;
        }

        //tạo sự kiện click btnAddTable để thêm bàn
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
            int count = data.Rows.Count;
            if (count == 0)
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertTable @ID , @name , @status", new object[] {"T1", "Table1", "Available" }) > 0)
                {
                    paintTable();
                }
            }
            else if (count > 0 && count < 10)
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertTable @ID , @name , @status", new object[] { "T0" + (count + 1), "Table0" + (count + 1), "Available" }) > 0)
                {
                    paintTable();
                }
            }
            else
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertTable @ID , @name , @status", new object[] { "T" + (count + 1), "Table" + (count + 1), "Available" }) > 0)
                {
                    paintTable();
                }
            }
        }
        
        //viết hàm khi click vài một nút bất kì trong listButton thì ButtonList tương ứng sẽ thay đổi giá trị

        private void addBtnClick()
        {
            foreach (Button btn in listButton)
            {
                btn.Click += (sender, e) =>
                {
                    for (int i = 0; i < listButton.Count; i++)
                    {
                        if (sender == listButton[i])
                        {
                            buttonClick[i] = true;
                        }
                    }
                };
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listButton.Count; i++)
            {
                bool check = buttonClick[i];
                if (check && listButton[i].BackColor == Color.DodgerBlue)
                {
                    if (DataProvider.Instance.ExecuteNonQuery("EXEC updateTableStatus @ID ", new object[] { listButton[i].Text }) > 0)
                    {
                        paintTable();
                        addBtnClick();
                        break;
                    }
                }
                else if (check && listButton[i].BackColor == Color.LightGray)
                {
                    MessageBox.Show("Bàn này đang trống");
                    buttonClick[i] = false;
                    break;
                }
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phone = tbxPhone.Text;
            if (phone == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
            }
            string name = DataProvider.Instance.ExecuteScalar("SELECT dbo.checkCustomer ( @phone ) ", new object[] { phone }).ToString();
            if (name == "CUSTOMER DOES NOT EXIST")
            {
                MessageBox.Show("Khách hàng không tồn tại");
            }
            else
            {
                tbxCustomerName.Text = name;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string billID = tbxIDBill.Text;
            string productName = cbxProduct.Text;
            int quantity = Convert.ToInt32(tbxQuantity.Text);

            if (quantity == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }
            else
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC addBillInfo @billID , @productName , @quantity ", new object[] { billID, productName, quantity }) <= 0)
                {
                    MessageBox.Show("Thêm sản phẩm thất bại");
                }
            }
            dgvBillInfo.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfo ( @billID )", new object[] { tbxIDBill.Text });
            dgvBillInfo.Columns[0].HeaderText = "Tên sản phẩm";
            dgvBillInfo.Columns[1].HeaderText = "Số lượng";
            dgvBillInfo.Columns[2].HeaderText = "Giá";

            lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
            lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxCategories.Text == "Loại hóa đơn")
            {
                MessageBox.Show("Vui lòng chọn loại hóa đơn");
            }
            else if (cbxEmp.Text == "Tên nhân viên")
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
            }
            else if (tbxReceiptMoney.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền nhận");
            }
            else if (tbxPhone.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
            }
            else if (tbxPhone.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
            }
            else if (tbxCustomerName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
            else
            {
                int check = 0;
                string billID = tbxIDBill.Text;
                string date = tbxDate.Text;
                string name = tbxCustomerName.Text;
                string categories = cbxCategories.Text;
                string emp = cbxEmp.Text;
                int receipMoney = Convert.ToInt32(tbxReceiptMoney.Text);
                for (int i = 0; i < listButton.Count; i++)
                {
                    if (buttonClick[i])
                    {
                        if (DataProvider.Instance.ExecuteNonQuery("EXEC insertBill @ID , @date , @tableID , @name , @categories , @emp , @receiptMoney ", new object[] { billID, date, listButton[i].Text, name, categories, emp, receipMoney }) <= 0)
                        {
                            MessageBox.Show("Thêm hóa đơn thất bại");
                        }
                        else
                        {
                            lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
                            lbTotalPrice.Text = "0 VND";
                            paintTable();
                            addBtnClick();
                            break;
                        }
                    }
                    else
                        check++;
                }
                if (check == listButton.Count)
                {
                    MessageBox.Show("Vui lòng chọn bàn");
                }
            }    
        }

        private void btdAddCus_Click(object sender, EventArgs e)
        {
            string phone = tbxPhone.Text;
            string name = tbxCustomerName.Text;
            string check = DataProvider.Instance.ExecuteScalar("SELECT dbo.checkCustomer ( @phone ) ", new object[] { phone }).ToString(); 
            if (phone == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
            }
            else if (phone.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
            }
            else if (name == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
            else if (check == "CUSTOMER DOES NOT EXIST")
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertCustomer @phone , @name ", new object[] { phone, name }) > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại");
                }
            }
            else
            {
                MessageBox.Show("Khách hàng đã tồn tại");
            }
        }

        private void dgvBillInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvBillInfo.Rows[e.RowIndex];
                cbxProduct.Text = row.Cells[0].Value.ToString();
                tbxQuantity.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            string billID = tbxIDBill.Text;
            string productName = cbxProduct.Text;
            int quantity = Convert.ToInt32(tbxQuantity.Text);

            if (quantity == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }
            else
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC updateBillInfo @billID , @productName , @quantity ", new object[] { billID, productName, quantity }) <= 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại");
                }
            }
            dgvBillInfo.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfo ( @billID )", new object[] { tbxIDBill.Text });
            dgvBillInfo.Columns[0].HeaderText = "Tên sản phẩm";
            dgvBillInfo.Columns[1].HeaderText = "Số lượng";
            dgvBillInfo.Columns[2].HeaderText = "Giá";

            lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
            lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string billID = tbxIDBill.Text;
            string productName = cbxProduct.Text;

            if (DataProvider.Instance.ExecuteNonQuery("EXEC deleteBillInfoByName @billID , @productName ", new object[] { billID, productName }) <= 0)
            {
                MessageBox.Show("Xóa sản phẩm thất bại");
            }

            dgvBillInfo.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfo ( @billID )", new object[] { tbxIDBill.Text });
            dgvBillInfo.Columns[0].HeaderText = "Tên sản phẩm";
            dgvBillInfo.Columns[1].HeaderText = "Số lượng";
            dgvBillInfo.Columns[2].HeaderText = "Giá";

            lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
            lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categories = cbxCategories.Text;
            lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT discount FROM  dbo.BillCategory WHERE name = @categories ", new object[] { categories }).ToString() + " VND";
        }
    }
}
