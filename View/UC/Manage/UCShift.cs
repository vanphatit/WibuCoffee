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
    public partial class UCShift : UserControl
    {
        private static Font font = new Font("Google Sans", 12, FontStyle.Regular);

        DataGridView dgvShiftInfo = new DataGridView()
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
            ColumnHeadersHeight = 65,
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

        DataTable dataShift;
        DataTable dataShiftID;
        DataTable dataEmpInfo;
        

        public UCShift()
        {
            InitializeComponent();
            dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getShiftDetailByWeek");
            reloadShiftInfo(dataShift);
            reload();
        }

        private void reload()
        {
            dataShiftID = DataProvider.Instance.ExecuteQuery("EXEC dbo.getShift");
            dataEmpInfo = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployeeList");

            cbxEmpName.Items.Clear();
            cbxEmpName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxDis.Items.Clear();
            cbxDis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxShift.Items.Clear();
            cbxShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSearch.Items.Clear();
            cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFilter.Items.Clear();
            cbxFilter.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (DataRow row in dataEmpInfo.Rows)
            {
                cbxEmpName.Items.Add(row["name"]);
            }

            tbxIDEmp.Text = "Mã nhân viên.";
            tbxPhone.Text = "Số điện thoại nhân viên.";
            tbxJob.Text = "Công việc.";
            tbxTime.Text = "Thời gian trực.";

            dtpDateOfShift.Value = DateTime.Now;

            cbxDis.Items.Add("Tất cả.");
            cbxDis.Items.Add("Tuần tiếp theo.");
            cbxDis.Items.Add("Tuần này.");

            cbxFilter.Items.Add("Tên nhân viên");
            cbxFilter.Items.Add("Ngày trực");

            cbxDis.Text = "Tuần này.";
            cbxFilter.Text = "Ngày trực";

            dtpDateOfShift.Format = DateTimePickerFormat.Custom;
            dtpDateOfShift.CustomFormat = "yyyy-MM-dd";

            dtpSearch.Format = DateTimePickerFormat.Custom;
            dtpSearch.CustomFormat = "yyyy-MM-dd";

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UCEmployee uCEmployee = new UCEmployee();
            uCEmployee.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(uCEmployee);
            this.Parent.Controls.Remove(this);
        }

        private void cbxShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            // chọn ca trực xong thì tbxTime sẽ hiện thời gian tương ứng
            string shiftID = cbxShift.Text;
            foreach (DataRow row in dataShiftID.Rows)
            {
                if (row["ID"].ToString() == shiftID)
                {
                    string time = row["startTime"].ToString() + " - " + row["endTime"].ToString();
                    tbxTime.Text = time;
                    break;
                }
            }
        }

        private void cbxEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // chọn tên nhân viên xong thì tbxPhone sẽ hiện số điện thoại tương ứng
            string name = cbxEmpName.Text;
            foreach (DataRow row in dataEmpInfo.Rows)
            {
                if (row["name"].ToString() == name)
                {
                    tbxIDEmp.Text = row["ID"].ToString();
                    tbxPhone.Text = row["phone"].ToString();
                    tbxJob.Text = row["jobDetail"].ToString();
                    //Khi chọn nhân viên và lấy được mã nhân viên. Và nếu mã nhân viên có chứa EF thì cbxShift sẽ hiện ca trực có chứ SF
                    if (row["ID"].ToString().Contains("EF"))
                    {
                        cbxShift.Items.Clear();
                        cbxShift.DropDownStyle = ComboBoxStyle.DropDownList;
                        foreach (DataRow shift in dataShiftID.Rows)
                        {
                            if (shift["ID"].ToString().Contains("ShF"))
                            {
                                cbxShift.Items.Add(shift["ID"]);
                            }
                        }
                    }
                    else
                    {
                        cbxShift.Items.Clear();
                        cbxShift.DropDownStyle = ComboBoxStyle.DropDownList;
                        foreach (DataRow shift in dataShiftID.Rows)
                        {
                            if (shift["ID"].ToString().Contains("ShP"))
                            {
                                cbxShift.Items.Add(shift["ID"]);
                            }
                        }
                    }   
                    break;
                }
            }
        }

        private void cbxDis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dis = cbxDis.Text;
            if (dis == "Tất cả.")
            {
                dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getShiftDetail");
                reloadShiftInfo(dataShift);
            }
            else if (dis == "Tuần tiếp theo.")
            {
                dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getNextWeekShiftDetail");
                reloadShiftInfo(dataShift);
            }
            else
            {
                dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getShiftDetailByWeek");
                reloadShiftInfo(dataShift);
            }
        }

        private void dgvShiftInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvShiftInfo.Rows[e.RowIndex];
                cbxShift.Text = row.Cells[2].Value.ToString();
                cbxEmpName.Text = row.Cells[0].Value.ToString();
                dtpDateOfShift.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
            }    
        }

        private void reloadShiftInfo(DataTable dataShift)
        {
            dataShift.Columns[0].ColumnName = "Tên nhân viên";
            dataShift.Columns[1].ColumnName = "Số điện thoại";
            dataShift.Columns[2].ColumnName = "Ca trực";
            dataShift.Columns[3].ColumnName = "Ngày trực";

            dgvShiftInfo.DataSource = dataShift;
            dgvShiftInfo.CellClick += dgvShiftInfo_CellClick;
            pShiftInfo.Controls.Add(dgvShiftInfo);
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFilter.Text == "Tên nhân viên")
            {
                cbxSearch.Items.Clear();
                cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (DataRow row in dataEmpInfo.Rows)
                {
                    cbxSearch.Items.Add(row["name"]);
                    cbxSearch.Visible = true;
                    dtpSearch.Visible = false;
                }
            }
            else
            {
                cbxSearch.Visible = false;
                dtpSearch.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if (cbxFilter.Text == "Tên nhân viên")
           {
                string name = cbxSearch.Text;
                dataShift = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterEmployeeByName ( @name )", new object[] { name });
                reloadShiftInfo(dataShift);
           }
           else
           {
                string date = dtpSearch.Value.ToString("yyyy-MM-dd");
                dataShift = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.filterEmployeeByDate ( @date )", new object[] { date });
                reloadShiftInfo(dataShift);
           }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = tbxPhone.Text;
                string shiftID = cbxShift.Text;
                DateTime date = dtpDateOfShift.Value;

                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.insertEmployeeToShift @phone , @date , @shiftID", new object[] { phone, date, shiftID });
                dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getShiftDetailByWeek");
                reloadShiftInfo(dataShift);
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Thêm thất bại.\n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = tbxPhone.Text;
                string shiftID = cbxShift.Text;
                DateTime date = dtpDateOfShift.Value;

                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.updateEmployeeInShift @phone , @date , @shiftID", new object[] { phone, date, shiftID });
                dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getShiftDetailByWeek");
                reloadShiftInfo(dataShift);
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Cập nhật thất bại.\n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = tbxPhone.Text;

                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.deleteEmployeeInShift @phone ", new object[] { phone });
                dataShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getShiftDetailByWeek");
                reloadShiftInfo(dataShift);
                reload();
            }
            catch (SqlException ev)
            {
                MessageBox.Show("Xóa thất bại.\n" + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
