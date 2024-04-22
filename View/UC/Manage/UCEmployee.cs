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
    public partial class UCEmployee : UserControl
    {
        private static Font font = new Font("Google Sans", 12, FontStyle.Regular);

        DataGridView dgvEmployee = new DataGridView()
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            RowHeadersVisible = false,
            AllowUserToResizeRows = false,
            BackgroundColor = Color.White,
            GridColor = Color.Black,
            BorderStyle = BorderStyle.FixedSingle,
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = font,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
            },
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing,
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
            ColumnHeadersHeight = 85,
            AllowDrop = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToOrderColumns = false,
            AllowUserToResizeColumns = false,
            ReadOnly = true,
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = font,
                ForeColor = Color.Black,
                BackColor = Color.White,
                SelectionForeColor = Color.White,
                SelectionBackColor = Color.Gray
            }
        };

        DataTable dataEmpShift;
        DataTable dataEmp;
        DataTable dataJob;
    
        public UCEmployee()
        {
            InitializeComponent();

            try
            {
                dataEmpShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployee");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reloadEmpShift(dataEmpShift);
            reload();
        }

        private void reload()
        {
            try
            {
                dataEmp = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployeeList");
                dataJob = DataProvider.Instance.ExecuteQuery("EXEC dbo.getJob");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbxJob.Items.Clear();
            cbxJob.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxJobDetail.Items.Clear();
            cbxJobDetail.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCateEmp.Items.Clear();
            cbxCateEmp.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFilter.Items.Clear();
            cbxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSearch.Items.Clear();
            cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (DataRow row in dataJob.Rows)
            {
                cbxJob.Items.Add(row[0].ToString());
                cbxJobDetail.Items.Add(row[0].ToString());
            }
            cbxCateEmp.Items.Add("Fulltime");
            cbxCateEmp.Items.Add("Parttime");
            cbxFilter.Items.Add("Tất cả");
            cbxFilter.Items.Add("Loại nhân viên");
            cbxFilter.Items.Add("Tên nhân viên");
            cbxFilter.Items.Add("Công việc");
            cbxFilter.Items.Add("Ngày tuyển dụng");
            cbxCateEmp.Text = "Fulltime";
            cbxFilter.Text = "Tất cả";

            dtpBirth.Format = DateTimePickerFormat.Custom;
            dtpBirth.CustomFormat = "yyyy-MM-dd";
            dtpBirth.Value = DateTime.Now;
            dtpRecruitment.Format = DateTimePickerFormat.Custom;
            dtpRecruitment.CustomFormat = "yyyy-MM-dd";
            dtpRecruitment.Value = DateTime.Now;
            dtpSearch.Format = DateTimePickerFormat.Custom;
            dtpSearch.CustomFormat = "yyyy-MM-dd";
            dtpSearch.Value = DateTime.Now;

            tbxEmpName.Text = "";
            tbxPhone.Text = "";
            tbxAddress.Text = "";

            tbxNumberOfShift.Text = "0";
            tbxNumberOfShift.Enabled = false;
            tbxBonusPoint.Text = "0";
            tbxBonusPoint.Enabled = false;
            tbxPenatyPoint.Text = "0";
            tbxPenatyPoint.Enabled = false;

            tbxCurentSalary.Text = "0";
            tbxNewSalary.Text = "0";

            string cate = cbxCateEmp.Text;

            try
            {
                tbxIDEmp.Text = DataProvider.Instance.ExecuteScalar("select dbo.createID ( @cate )", new object[] { cate }).ToString();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tbxIDEmp.Enabled = false;

        }
        
        private void DgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNumberOfShift.Enabled = true;
            tbxBonusPoint.Enabled = true;
            tbxPenatyPoint.Enabled = true;
            DataTable data = new DataTable();

            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvEmployee.Rows[index];
                string name = row.Cells[0].Value.ToString();
                string job = row.Cells[1].Value.ToString();

                try
                {
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getEmployeeInfo ( @name , @job )", new object[] { name, job });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tbxIDEmp.Text = data.Rows[0][0].ToString();

                if (tbxIDEmp.Text.Contains("EF"))
                {
                    cbxCateEmp.Text = "Fulltime";
                }
                else
                {
                    cbxCateEmp.Text = "Parttime";
                }
                tbxEmpName.Text = data.Rows[0][1].ToString();
                 dtpBirth.Value = (DateTime) data.Rows[0][2];
                tbxAddress.Text = data.Rows[0][3].ToString();
                tbxPhone.Text = data.Rows[0][4].ToString();
                dtpRecruitment.Value = DateTime.Parse(data.Rows[0][5].ToString());

                try
                {
                    cbxJob.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getJobDetail ( @job )", new object[] { data.Rows[0][6].ToString() }).ToString();
                    tbxPenatyPoint.Text = data.Rows[0][7].ToString();
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tbxBonusPoint.Text = data.Rows[0][8].ToString();
                tbxNumberOfShift.Text = data.Rows[0][9].ToString();
            }
        }

        private void reloadEmpShift(DataTable dataEmpShift)
        {
            dataEmpShift.Columns[0].ColumnName = "Tên nhân viên";
            dataEmpShift.Columns[1].ColumnName = "Công việc";
            dataEmpShift.Columns[2].ColumnName = "Số ca trực";
            dataEmpShift.Columns[3].ColumnName = "Lương";


            dgvEmployee.DataSource = dataEmpShift;

            dgvEmployee.CellClick += DgvEmployee_CellClick;
            pEmpShift.Controls.Add(dgvEmployee);
        }

        private void cbxCateEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cate = cbxCateEmp.Text;

            try
            {
                tbxIDEmp.Text = DataProvider.Instance.ExecuteScalar("select dbo.createID ( @cate )", new object[] { cate }).ToString();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Tạo ID nhân viên thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = tbxIDEmp.Text;
            string name = tbxEmpName.Text;
            DateTime birth = dtpBirth.Value;
            string address = tbxAddress.Text;
            string phone = tbxPhone.Text;
            DateTime recruitment = dtpRecruitment.Value;
            string job = cbxJob.Text;
            int numberOfShift = int.Parse(tbxNumberOfShift.Text);
            int bonusPoint = int.Parse(tbxBonusPoint.Text);
            int penatyPoint = int.Parse(tbxPenatyPoint.Text);

            try
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.insertEmployee @id , @name , @birth , @address , @phone , @recruitment , @job ,  @penatyPoint , @bonusPoint , @numberOfShift ", new object[] { id, name, birth, address, phone, recruitment, job, penatyPoint, bonusPoint, numberOfShift });
                MessageBox.Show("Thêm nhân viên thành công! \n  Vui lòng vào LỊCH TRỰC xếp ca trực cho nhân viên " + name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Thêm nhân viên thất bại! \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reload();
                return;
            }
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            //CHUYỂN TỚI UC SHIFT
            UCShift ucShift = new UCShift();
            ucShift.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(ucShift);
            this.Parent.Controls.Remove(this);
        }

        private void cbxFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxFilter.Text == "Tất cả")
            {
                try
                {
                    dataEmpShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployee");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                reloadEmpShift(dataEmpShift);
                cbxSearch.Visible = true;
                dtpSearch.Visible = false;
            }
            else if (cbxFilter.Text == "Loại nhân viên")
            {
                cbxSearch.Items.Clear();
                cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
                cbxSearch.Items.Add("Fulltime");
                cbxSearch.Items.Add("Parttime");
                cbxSearch.Visible = true;
                dtpSearch.Visible = false;
            }
            else if (cbxFilter.Text == "Tên nhân viên")
            {
                cbxSearch.Items.Clear();
                cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;

                try
                {
                    dataEmp = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployeeList");
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataRow row in dataEmp.Rows)
                {
                    cbxSearch.Items.Add(row[1].ToString());
                }
                cbxSearch.Visible = true;
                dtpSearch.Visible = false;
            }
            else if (cbxFilter.Text == "Công việc")
            {
                cbxSearch.Items.Clear();
                cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (DataRow row in dataJob.Rows)
                {
                    cbxSearch.Items.Add(row[0].ToString());
                }
                cbxSearch.Visible = true;
                dtpSearch.Visible = false;
            }
            else if (cbxFilter.Text == "Ngày tuyển dụng")
            {
                cbxSearch.Visible = false;
                dtpSearch.Visible = true;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dataName = new DataTable();
            DataTable data = new DataTable();

            if (cbxFilter.Text == "Loại nhân viên")
            {
                string cate = cbxSearch.Text;

                try
                {
                    dataName.Clear();
                    dataName = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getEmployeeID ( @cate )", new object[] { cate });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Tìm kiếm nhân viên thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dataEmpShift.Clear();
                foreach (DataRow row in dataName.Rows)
                {
                    string name = row[0].ToString();

                    try
                    {
                        data.Clear();
                        data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getEmployeeInfoByName ( @name )", new object[] { name });
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Tìm kiếm nhân viên thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (data.Rows.Count > 0)
                    {
                        dataEmpShift.Rows.Add(data.Rows[0][0].ToString(), data.Rows[0][1].ToString(), data.Rows[0][2].ToString(), data.Rows[0][3].ToString());
                    }
                    else
                    {
                        continue;
                    }

                }
                if (dataEmpShift.Rows.Count > 0)
                {
                    reloadEmpShift(dataEmpShift);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    try
                    {
                        dataEmpShift.Clear();
                        dataEmpShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployee");
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    reloadEmpShift(dataEmpShift);
                    return;
                }
            }
            else if (cbxFilter.Text == "Tên nhân viên")
            {
                string name = cbxSearch.Text;

                try
                {
                    dataEmpShift.Clear();
                    dataEmpShift = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getEmployeeInfoByName ( @name )", new object[] { name });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Tìm kiếm nhân viên thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataEmpShift.Rows.Count > 0)
                {
                    reloadEmpShift(dataEmpShift);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    try
                    {
                        dataEmpShift.Clear();
                        dataEmpShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployee");
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    reloadEmpShift(dataEmpShift);
                    return;
                }
            }
            else if (cbxFilter.Text == "Công việc")
            {
                string job = cbxSearch.Text;

                try
                {
                    dataEmpShift.Clear();
                    dataEmpShift = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getEmployeeInfoByJob ( @job )", new object[] { job });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Tìm kiếm nhân viên thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataEmpShift.Rows.Count > 0)
                {
                    reloadEmpShift(dataEmpShift);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    try
                    {
                        dataEmpShift.Clear();
                        dataEmpShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployee");
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    reloadEmpShift(dataEmpShift);
                    return;
                }
            }
            else if (cbxFilter.Text == "Ngày tuyển dụng")
            {
                DateTime date = dtpSearch.Value;

                try
                {
                    data.Clear();
                    data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getEmployeeNameByRecruitmentDate ( @date )", new object[] { date });
                }
                catch (SqlException ev)
                {
                    MessageBox.Show("Tìm kiếm nhân viên thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dataEmpShift.Clear();
                foreach (DataRow row in data.Rows)
                {
                    DataTable data1 = new DataTable();
                    string name = row[0].ToString();
                    
                    try
                    {
                       data1.Clear();
                       data1  = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.getEmployeeInfoByName ( @name )", new object[] { name });
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Tìm kiếm nhân viên thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (data1.Rows.Count > 0)
                    {
                        dataEmpShift.Rows.Add(data1.Rows[0][0].ToString(), data1.Rows[0][1].ToString(), data1.Rows[0][2].ToString(), data1.Rows[0][3].ToString());
                    }
                    else
                    {
                        continue;
                    }

                }
                if (dataEmpShift.Rows.Count > 0)
                {
                    reloadEmpShift(dataEmpShift);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    try
                    {
                        dataEmpShift.Clear();
                        dataEmpShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployee");
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    reloadEmpShift(dataEmpShift);
                    return;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = tbxIDEmp.Text;
            string name = tbxEmpName.Text;
            DateTime birth = dtpBirth.Value;
            string address = tbxAddress.Text;
            string phone = tbxPhone.Text;
            DateTime recruitment = dtpRecruitment.Value;
            string job = cbxJob.Text;
            int numberOfShift = int.Parse(tbxNumberOfShift.Text);
            int bonusPoint = int.Parse(tbxBonusPoint.Text);
            int penatyPoint = int.Parse(tbxPenatyPoint.Text);

            try
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.updateEmployee @id , @name , @birth , @address , @phone , @recruitment , @job ,  @penatyPoint , @bonusPoint , @numberOfShift ", new object[] { id, name, birth, address, phone, recruitment, job, penatyPoint, bonusPoint, numberOfShift });
                MessageBox.Show("Sửa thông tin nhân viên thành công " + name + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Sửa nhân viên thất bại! \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reload();
                return;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = tbxIDEmp.Text;
            try
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.deleteEmployeeByID @id ", new object[] { id });
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Xóa nhân viên thất bại! \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reload();
                return;
            }
        }
        
        private void cbxJobDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxCurentSalary.Enabled = false;

            try
            {
                dataJob.Clear();
                dataJob = DataProvider.Instance.ExecuteQuery("EXEC dbo.getJob");
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow row in dataJob.Rows)
            {
                if (cbxJobDetail.Text == row[0].ToString())
                {
                    try
                    {
                        tbxCurentSalary.Text = DataProvider.Instance.ExecuteScalar("SELECT dbo.getSalary ( @job )", new object[] { row[0].ToString() }).ToString();
                    }
                    catch (SqlException ev)
                    {
                        MessageBox.Show("Load dữ liệu thất bại! \nDo: \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Decimal salary = Decimal.Parse(tbxNewSalary.Text);
            string job = cbxJobDetail.Text;

            try
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.updateSalary @job , @salary ", new object[] { job, salary });
                MessageBox.Show("Thay đổi lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Thay đổi lương thất bại! \n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reload();
                return;
            }
        }
    }
}
