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

        DataTable dataEmpShift;
        DataTable dataJob;
    
        public UCEmployee()
        {
            InitializeComponent();
            reload();
        }

        private void reload()
        {
            dataEmpShift = DataProvider.Instance.ExecuteQuery("EXEC dbo.getEmployee");
            dataJob = DataProvider.Instance.ExecuteQuery("EXEC dbo.getJob");

            dataEmpShift.Columns[0].ColumnName = "Tên nhân viên";
            dataEmpShift.Columns[1].ColumnName = "Công việc";
            dataEmpShift.Columns[2].ColumnName = "Số ca trực";
            dataEmpShift.Columns[3].ColumnName = "Lương";

            cbxJob.Items.Clear();
            cbxJobDetail.Items.Clear();
            cbxCateEmp.Items.Clear();
            foreach (DataRow row in dataJob.Rows)
            {
                cbxJob.Items.Add(row[0].ToString());
                cbxJobDetail.Items.Add(row[0].ToString());
            }
            cbxCateEmp.Items.Add("Fulltime");
            cbxCateEmp.Items.Add("Parttime");
            cbxCateEmp.Text = "Fulltime";

            dtpBirth.Format = DateTimePickerFormat.Custom;
            dtpBirth.CustomFormat = "yyyy/MM/dd";
            dtpRecruitment.Format = DateTimePickerFormat.Custom;
            dtpRecruitment.CustomFormat = "yyyy/MM/dd";

            tbxEmpName.Text = "";
            tbxPhone.Text = "";
            tbxAddress.Text = "";

            tbxNumberOfShift.Text = "0";
            tbxBonusPoint.Text = "0";
            tbxPenatyPoint.Text = "0";
            tbxCurentSalary.Text = "0";
            tbxNewSalary.Text = "0";

            string cate = cbxCateEmp.Text;
            tbxIDEmp.Text = DataProvider.Instance.ExecuteScalar("select dbo.createID ( @cate )", new object[] { cate }).ToString();
            tbxIDEmp.Enabled = false;

            dgvEmployee.DataSource = dataEmpShift;
            pEmpShift.Controls.Add(dgvEmployee);
        }

        private void cbxCateEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cate = cbxCateEmp.Text;
            tbxIDEmp.Text = DataProvider.Instance.ExecuteScalar("select dbo.createID ( @cate )", new object[] { cate }).ToString();
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            if (name == "" || address == "" || phone == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC dbo.createEmployee @id , @name , @birth , @address , @phone , @recruitment , @job , @numberOfShift , @bonusPoint , @penatyPoint", new object[] { id, name, birth, address, phone, recruitment, job, numberOfShift, bonusPoint, penatyPoint });
                reload();
            }
        }
    }
}
