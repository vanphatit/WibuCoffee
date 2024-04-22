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

        DataTable data = new DataTable();
        DataTable dataProduct = new DataTable();
        DataTable dataCategories = new DataTable();
        DataTable dataShift = new DataTable();
        DataTable dataShiftInfo = new DataTable();


        private List<Button> listButton = new List<Button>();
        private List<Boolean> buttonClick = new List<Boolean>();
        public UCOrder()
        {
            InitializeComponent();
            reload();
        }

        private void reload()
        {
            try
            {
                data.Clear();
                dataProduct.Clear();
                dataCategories.Clear();

                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
                dataProduct = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllProduct");
                dataCategories = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillCategory");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };


            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                tbxDate.Clear();
                tbxDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            };
            timer.Start();

            tbxDate.Enabled = false;

            try
            {
                tbxIDBill.Clear();
                tbxIDBill.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.createBillID ()").ToString();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Tạo ID hóa đơn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbxIDBill.Enabled = false;

            cbxCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCategories.Items.Clear();
            cbxEmp.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEmp.Items.Clear();
            cbxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProduct.Items.Clear();

            for (int i = 0; i < dataProduct.Rows.Count; i++)
            {
                cbxProduct.Items.Add(dataProduct.Rows[i]["name"].ToString());
            }
            for (int i = 0; i < dataCategories.Rows.Count; i++)
            {
                cbxCategories.Items.Add(dataCategories.Rows[i]["name"].ToString());
            }

            insertDataToEmployee();

            tbxPhone.Text = "";
            tbxCustomerName.Text = "";
            cbxCategories.Text = "Loại hóa đơn";
            cbxEmp.Text = "Tên nhân viên";
            tbxReceiptMoney.Text = "0";

            tbxReceiptMoney.Enabled = false;
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

            btnAdd.Enabled = true;
            btnAddCus.Enabled = true;
            btnSearch.Enabled = true;

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

            try
            {
                data.Clear();
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            try
            {
                dataShift.Clear();
                dataShiftInfo.Clear();

                dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.findEmployeeShift");
                dataShiftInfo = DataProvider.Instance.ExecuteQuery("EXEC dbo.selectAllShift");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            try
            {
                data.Clear();
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int count = data.Rows.Count;
            try
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertTable") > 0)
                {
                    paintTable();
                }
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Thêm bàn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                paintTable();
            }
        }

        //tạo sự kiện click btnDeleteTable để xóa bàn

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                data.Clear();
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableStatusView");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int count = data.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("Không có bàn để xóa");
            }
            else
            {
                try
                {
                    if (DataProvider.Instance.ExecuteNonQuery("EXEC deleteTableByID @ID", new object[] { data.Rows[count - 1]["ID"].ToString() }) > 0)
                    {
                        paintTable();
                    }
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Xóa bàn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Button clickedButton = (Button)sender;

                    // Lặp qua tất cả các nút trong danh sách
                    for (int i = 0; i < listButton.Count; i++)
                    {
                        if (listButton[i] == clickedButton)
                        {
                            // Nếu nút đang xem xét là nút được nhấp, đặt giá trị tương ứng trong mảng là true
                            buttonClick[i] = true;
                        }
                        else
                        {
                            // Nếu nút không được nhấp, đặt giá trị tương ứng trong mảng là false
                            buttonClick[i] = false;
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
                try
                {
                    if (check)
                    {
                        if (DataProvider.Instance.ExecuteNonQuery("EXEC updateTableStatus @ID ", new object[] { listButton[i].Text }) > 0)
                        {
                            paintTable();
                            addBtnClick();
                            break;
                        }
                    }
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Cập nhật trạng thái bàn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
             try
             {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC updateReceiptMoney @ID , @receiptMoney ", new object[] { tbxIDBill.Text, tbxReceiptMoney.Text }) > 0)
                {
                    string billID = tbxIDBill.Text;
                    string phone = tbxPhone.Text;
                    try
                    {
                        if (DataProvider.Instance.ExecuteNonQuery("EXEC updateCustomerPoint @billID , @phone ", new object[] { billID, phone }) > 0)
                        {
                            MessageBox.Show("Cập nhật số tiền nhận thành công");
                            tbxReceiptMoney.Enabled = false;
                        }
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Cập nhật số tiền nhận thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Cập nhật số tiền nhận thành công");
                    tbxReceiptMoney.Enabled = false;
                }
             }
             catch (SqlException ev)
             {
                MessageBox.Show("Cập nhật số tiền nhận thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phone = tbxPhone.Text;
            if (phone == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
            }
            else if (phone.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
            }
            else
            {
                try
                {
                    tbxCustomerName.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.checkCustomer ( @phone ) ", new object[] { phone }).ToString();
                    if (tbxCustomerName.Text == "CUSTOMER DOES NOT EXIST")
                    {
                        btnAddCus.Enabled = true;
                        btnSearch.Enabled = true;
                        tbxCustomerName.Enabled = true;
                        tbxPhone.Enabled = true;
                    }
                    else
                    {
                        btnAddCus.Enabled = false;
                        btnSearch.Enabled = false;
                        tbxCustomerName.Enabled = false;
                        tbxPhone.Enabled = false;
                    }
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Tìm kiếm thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string billID = tbxIDBill.Text;
            string productName = cbxProduct.Text;
            string quantity = tbxQuantity.Text;

            try
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC addBillInfo @billID , @productName , @quantity ", new object[] { billID, productName, quantity }) > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    tbxAvai.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getProductStatus ( @productName )", new object[] { productName }).ToString();
                    tbxQuantity.Text = "0";
                }
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Thêm sản phẩm thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string billID = tbxIDBill.Text;
            string date = tbxDate.Text;
            string tableID = "";
            string name = tbxCustomerName.Text;
            string categories = cbxCategories.Text;
            string emp = cbxEmp.Text;
            int receipMoney = Convert.ToInt32(tbxReceiptMoney.Text);
            if (categories == "In place")
            {
                for (int i = 0; i <= listButton.Count; i++)
                {
                    if (i == listButton.Count)
                    {
                        tableID = "";
                    }
                    else if (buttonClick[i])
                    {
                        tableID = listButton[i].Text;
                    }
                    else
                    {
                        continue;
                    }
                    try
                    {
                        if (DataProvider.Instance.ExecuteNonQuery("EXEC insertBill @ID , @date , @tableID , @name , @categories , @emp , @receiptMoney ", new object[] { billID, date, tableID, name, categories, emp, receipMoney }) > 0)
                        {
                            MessageBox.Show("Thêm hóa đơn thành công");

                            lbShowDis.Text = "0 VND";
                            lbTotalPrice.Text = "0 VND";

                            cbxCategories.Enabled = false;
                            tbxIDBill.Enabled = false;
                            tbxDate.Enabled = false;
                            tbxPhone.Enabled = false;
                            tbxCustomerName.Enabled = false;
                            cbxEmp.Enabled = false;

                            btnAdd.Enabled = false;

                            tbxReceiptMoney.Enabled = true;

                            paintTable();
                            addBtnClick();
                            break;
                        }
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }    
            else if (categories != "In place")
            {
                tableID = "NA";
                try
                {
                    if (DataProvider.Instance.ExecuteNonQuery("EXEC insertBill @ID , @date , @tableID , @name , @categories , @emp , @receiptMoney ", new object[] { billID, date, tableID, name, categories, emp, receipMoney }) > 0)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công");

                        lbShowDis.Text = "0 VND";
                        lbTotalPrice.Text = "0 VND";

                        cbxCategories.Enabled = false;
                        tbxIDBill.Enabled = false;
                        tbxDate.Enabled = false;
                        tbxPhone.Enabled = false;
                        tbxCustomerName.Enabled = false;
                        cbxEmp.Enabled = false;

                        btnAdd.Enabled = false;

                        tbxReceiptMoney.Enabled = true;

                        paintTable();
                        addBtnClick();
                    }
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Thêm hóa đơn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            string quantity = tbxQuantity.Text;

            try
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC updateBillInfo @billID , @productName , @quantity ", new object[] { billID, productName, quantity }) > 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công");
                    tbxAvai.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getProductStatus ( @productName )", new object[] { productName }).ToString();
                    tbxQuantity.Text = "0";
                }
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvBillInfo.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfo ( @billID )", new object[] { tbxIDBill.Text });
            dgvBillInfo.Columns[0].HeaderText = "Tên sản phẩm";
            dgvBillInfo.Columns[1].HeaderText = "Số lượng";
            dgvBillInfo.Columns[2].HeaderText = "Giá";

            try
            {
                lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString();
                lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @billID )", new object[] { tbxIDBill.Text }).ToString();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Cập nhật giá trị thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string billID = tbxIDBill.Text;
            string productName = cbxProduct.Text;
            string quantity = tbxQuantity.Text;

            try
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC deleteBillInfoByName @billID , @productName , @quantity ", new object[] { billID, productName, quantity }) > 0)
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                    tbxAvai.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getProductStatus ( @productName )", new object[] { productName }).ToString();
                    tbxQuantity.Text = "0";
                }
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Xóa sản phẩm thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            dgvBillInfo.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getBillInfo ( @billID )", new object[] { tbxIDBill.Text });
            dgvBillInfo.Columns[0].HeaderText = "Tên sản phẩm";
            dgvBillInfo.Columns[1].HeaderText = "Số lượng";
            dgvBillInfo.Columns[2].HeaderText = "Giá";

            try
            {
                lbShowDis.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillDiscount ( @billID )", new object[] { tbxIDBill.Text }).ToString();
                lbTotalPrice.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getBillTotalPrice ( @billID )", new object[] { tbxIDBill.Text }).ToString();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Cập nhật giá trị thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            string billID = tbxIDBill.Text;
            int check = 0;

            try
            {
                check = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT dbo.checkBillID ( @billID )", new object[] { billID }));
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Kiểm tra hóa đơn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (tbxReceiptMoney.Text == "0" && dgvBillInfo.Rows.Count == 0 && check == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn tạo hóa đơn mới không?\n Hóa đơn trước đó chưa được order!\n Máy sẽ xóa hóa đơn trước đó!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        DataProvider.Instance.ExecuteNonQuery("EXEC deleteBillByID @billID ", new object[] { tbxIDBill.Text });
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Xóa hóa đơn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //chuyển sang form lịch sử hóa đơn
                    UCBillHistory orderHistory = new UCBillHistory();
                    changeUC(orderHistory);
                }
            }
            else if (tbxReceiptMoney.Text != "0" && dgvBillInfo.Rows.Count != 0 && check == 1)
            {
                //chuyển sang form lịch sử hóa đơn
                UCBillHistory orderHistory = new UCBillHistory();
                changeUC(orderHistory);
            }
            else if (check == 0)
            {
                //chuyển sang form lịch sử hóa đơn
                UCBillHistory orderHistory = new UCBillHistory();
                changeUC(orderHistory);
            }
            else
            {
                MessageBox.Show("Hóa đơn đang được order!");
            }
        }

        private void changeUC (UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            string billID = tbxIDBill.Text;

            int check = 0;

            try
            {
                check = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT dbo.checkBillID ( @billID )", new object[] { billID }));
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Kiểm tra hóa đơn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (tbxReceiptMoney.Text == "0" && dgvBillInfo.Rows.Count == 0 && check == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn tạo hóa đơn mới không?\n Hóa đơn trước đó chưa được order!\n Máy sẽ xóa hóa đơn trước đó!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        DataProvider.Instance.ExecuteNonQuery("EXEC deleteBillByID @billID ", new object[] { tbxIDBill.Text });
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Xóa hóa đơn thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reload();
                }
            }
            else if ( tbxReceiptMoney.Text != "0" && dgvBillInfo.Rows.Count != 0 && check == 1)
            {
                reload();
            }
            else if (check == 0)
            {
                reload();
            }
            else
            {
                MessageBox.Show("Hóa đơn đang được order!");
            }

        }

        private void cbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productName = cbxProduct.Text;
            try
            {
                tbxAvai.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getProductStatus ( @productName )", new object[] { productName }).ToString();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxCustomerName_Click(object sender, EventArgs e)
        {
            tbxCustomerName.Clear();
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            string phone = tbxPhone.Text;
            string name = tbxCustomerName.Text;
            try
            {
                if (DataProvider.Instance.ExecuteNonQuery("EXEC insertCustomer @name , @phone ", new object[] { name, phone }) > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                    btnAddCus.Enabled = false;
                    btnSearch.Enabled = false;
                    tbxCustomerName.Enabled = false;
                    tbxPhone.Enabled = false;
                }
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Thêm khách hàng thất bại! \n Do: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
