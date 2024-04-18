﻿using System;
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
    public partial class UCOrder : UserControl
    {
        private int x = 25;
        private int y = 30;
        private static int w = 85;
        private static int h = 85;

        private Font font = new Font("Google Sans", 12, FontStyle.Bold);

        private Button btnAddTable = new Button() {
            Width = w, Height = h,
            Text = "+",
            Font = new Font("Google Sans", 12, FontStyle.Bold),
            BackColor = Color.LightGray
        };

        private Button btnDeleteTable = new Button()
        {
            Width = w,
            Height = h,
            Text = "-",
            Font = new Font("Google Sans", 12, FontStyle.Bold),
            BackColor = Color.Red
        };

        private DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
        private DataTable dataProduct = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllProduct");
        private DataTable dataCategories = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillCategory");

        private List<Button> listButton = new List<Button>();
        private List<Boolean> buttonClick = new List<Boolean>();
        public UCOrder()
        {
            InitializeComponent();
            reload();
        }

        private void reload()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                tbxDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            };
            timer.Start();
            tbxDate.Enabled = false;

            tbxIDBill.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.createBillID ()").ToString();
            tbxIDBill.Enabled = false;

            for (int i = 0; i < dataProduct.Rows.Count; i++)
            {
                cbxProduct.Items.Add(dataProduct.Rows[i]["name"].ToString());
            }
            for (int i = 0; i < dataCategories.Rows.Count; i++)
            {
                cbxCategories.Items.Add(dataCategories.Rows[i]["name"].ToString());
            }

            cbxCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEmp.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            insertDataToEmployee();
            tbxQuantity.Text = "0";
            tbxReceiptMoney.Text = "0";
            lbShowDis.Text = "0 VND";
            lbTotalPrice.Text = "0 VND";
            btnAddTable.Click += btnAddTable_Click;
            btnDeleteTable.Click += btnDeleteTable_Click;
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
            for (int i = 1; i <= data.Rows.Count + 1; i++)
            {
                if (i == data.Rows.Count)
                {
                    btnAddTable.Location = new Point(x, y);
                    pTable.Controls.Add(btnAddTable);
                    x += 110;
                    if (x > 300)
                    {
                        x = 25;
                        y += 100;
                    }
                }
                else if (i == data.Rows.Count + 1)
                {
                    btnDeleteTable.Location = new Point(x, y);
                    pTable.Controls.Add(btnDeleteTable);
                }
                else
                {
                    Button btn = new Button() { Width = w, Height = h };
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
                    x += 110;
                    if (x > 300)
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

        private void insertDataToEmployee()
        {
            DataTable dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.findEmployeeShift");
            DataTable dataShiftInfo = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllShift");
            // Lấy giờ hiện tại không lấy ngày tháng năm
            string time = DateTime.Now.ToString("HH:mm:ss");
            // So sánh giờ hiện tại với giờ bắt đầu và kết thúc của ca, giờ bắt đầu và kết thúc của ca làm trong bảng dataShiftInfo ứng với từng shiftID trong bảng dataShift
            for (int i = 0; i < dataShift.Rows.Count; i++)
            {
                string shiftID = dataShift.Rows[i]["ID"].ToString();
                string startTime = dataShiftInfo.Select("ID = '" + shiftID + "'")[0]["startTime"].ToString();
                string endTime = dataShiftInfo.Select("ID = '" + shiftID + "'")[0]["endTime"].ToString();
                if (DateTime.Parse(time) >= DateTime.Parse(startTime) && DateTime.Parse(time) <= DateTime.Parse(endTime))
                {
                    cbxEmp.Items.Add(dataShift.Rows[i]["name"].ToString());
                }
            }
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
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertTable @ID , @name , @status", new object[] { "T0" + (count), "Table0" + (count), "Available" }) > 0)
                {
                    paintTable();
                }
            }
            else
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertTable @ID , @name , @status", new object[] { "T" + (count), "Table" + (count), "Available" }) > 0)
                {
                    paintTable();
                }
            }
        }

        //tạo sự kiện click btnDeleteTable để xóa bàn

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
            int count = data.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("Không có bàn để xóa");
            }
            else
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC deleteTableByID @ID", new object[] { data.Rows[count - 1]["ID"].ToString() }) > 0)
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
            int receiptMoney = Convert.ToInt32(tbxReceiptMoney.Text);
            if (receiptMoney > 0)
            {
                if(DataProvider.Instance.ExecuteNonQuery("EXEC dbo.updateReceiptMoney @ID , @receiptMoney ", new object[] { tbxIDBill.Text, receiptMoney }) <= 0)
                {
                    MessageBox.Show("Cập nhật số tiền nhận không thành công");
                }
                else
                    tbxReceiptMoney.Enabled = false;
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
                try
                {
                    if (DataProvider.Instance.ExecuteNonQuery("EXEC addBillInfo @billID , @productName , @quantity ", new object[] { billID, productName, quantity }) > 0)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công");
                        tbxAvai.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getProductStatus ( @productName )", new object[] { productName }).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại");
                    }
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Thêm sản phẩm thất bại! \n Do: \n" + ev.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dgvBillInfo.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfo ( @billID )", new object[] { tbxIDBill.Text });
            dgvBillInfo.Columns[0].HeaderText = "Tên sản phẩm";
            dgvBillInfo.Columns[1].HeaderText = "Số lượng";
            dgvBillInfo.Columns[2].HeaderText = "Giá";

            lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString();
            lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @billID )", new object[] { tbxIDBill.Text }).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbxDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

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
                        if (listButton[i].BackColor == Color.DodgerBlue)
                        {
                            MessageBox.Show("Bàn này đang được sử dụng!");                
                        }    
                        else if (DataProvider.Instance.ExecuteNonQuery("EXEC insertBill @ID , @date , @tableID , @name , @categories , @emp , @receiptMoney ", new object[] { billID, date, listButton[i].Text, name, categories, emp, receipMoney }) <= 0)
                        {
                            MessageBox.Show("Thêm hóa đơn thất bại");
                        }
                        else
                        {
                            lbShowDis.Text = "0 VND";
                            lbTotalPrice.Text = "0 VND";

                            cbxCategories.Enabled = false;
                            tbxIDBill.Enabled = false;
                            tbxDate.Enabled = false;
                            tbxPhone.Enabled = false;
                            tbxCustomerName.Enabled = false;
                            cbxEmp.Enabled = false;

                            paintTable();
                            addBtnClick();
                            break;
                        }
                    }
                    else
                        check++;
                }
                if (check == listButton.Count && categories == "In place")
                {
                    MessageBox.Show("Vui lòng chọn bàn");
                }
                else if (categories != "In place")
                {
                    string tableID = "NA";
                    if (DataProvider.Instance.ExecuteNonQuery("EXEC insertBill @ID , @date , @tableID , @name , @categories , @emp , @receiptMoney ", new object[] { billID, date, tableID, name, categories, emp, receipMoney }) <= 0)
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại");
                    }
                    else
                    {
                        lbShowDis.Text = "0 VND";
                        lbTotalPrice.Text = "0 VND";

                        cbxCategories.Enabled = false;
                        tbxIDBill.Enabled = false;
                        tbxDate.Enabled = false;
                        tbxPhone.Enabled = false;
                        tbxCustomerName.Enabled = false;
                        cbxEmp.Enabled = false;

                        paintTable();
                        addBtnClick();
                    }
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
               try
                {
                    if (DataProvider.Instance.ExecuteNonQuery("EXEC insertCustomer @name , @phone ", new object[] { name, phone }) > 0)
                    {
                        MessageBox.Show("Thêm khách hàng thành công");
                    }
               }
               catch (SqlException ev)
                {
                    MessageBox.Show("Thêm khách hàng thất bại! \n Do: \n" + ev.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    if (DataProvider.Instance.ExecuteNonQuery("EXEC updateBillInfo @billID , @productName , @quantity ", new object[] { billID, productName, quantity }) > 0)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công");
                    }
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại! \n Do: \n" + ev.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC deleteBillInfoByName @billID , @productName ", new object[] { billID, productName }) > 0)
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                }
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Xóa sản phẩm thất bại! \n Do: \n" + ev.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            dgvBillInfo.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfo ( @billID )", new object[] { tbxIDBill.Text });
            dgvBillInfo.Columns[0].HeaderText = "Tên sản phẩm";
            dgvBillInfo.Columns[1].HeaderText = "Số lượng";
            dgvBillInfo.Columns[2].HeaderText = "Giá";

            lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
            lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @billID )", new object[] { tbxIDBill.Text }).ToString() + "\nVND";
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            //chuyển sang form lịch sử hóa đơn
            UCBillHistory orderHistory = new UCBillHistory();
            orderHistory.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(orderHistory);
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            tbxIDBill.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.createBillID ()").ToString();

            tbxPhone.Text = "";
            tbxCustomerName.Text = "";
            cbxCategories.Text = "Loại hóa đơn";
            cbxEmp.Text = "Tên nhân viên";
            tbxReceiptMoney.Text = "0";
            tbxReceiptMoney.Enabled = true;
            tbxPhone.Enabled = true;
            tbxCustomerName.Enabled = true;
            cbxCategories.Enabled = true;
            cbxEmp.Enabled = true;
            dgvBillInfo.DataSource = null;
            dgvBillInfo.Rows.Clear();
            dgvBillInfo.Refresh();
            lbShowDis.Text = "0 VND";
            lbTotalPrice.Text = "0 VND";
            tbxQuantity.Text = "0";
            tbxAvai.Text = "0";
            cbxProduct.Text = "";
            cbxCategories.Text = "Loại hóa đơn";
            cbxEmp.Text = "Tên nhân viên";

        }

        private void cbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productName = cbxProduct.Text;
            tbxAvai.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getProductStatus ( @productName )", new object[] { productName }).ToString();
        }
    }
}
