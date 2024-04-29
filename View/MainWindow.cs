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
using WibuCoffee.View.UC;

namespace WibuCoffee.View
{
    public partial class MainWindow : Form
    {
        bool mouseDown;
        public Point mouseLocation;

        bool isDashboard = true;

        public MainWindow(bool isAdmin)
        {
            InitializeComponent();

            customComponents();
        }

        private void customComponents()
        {
            //set color #004AAD for panel2
            panel2.BackColor = Color.FromArgb(0, 74, 173);
            btnClose.TabStop = false;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            btnDashboard.TabStop = false;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            btnManage.TabStop = false;
            btnManage.FlatStyle = FlatStyle.Flat;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            checkIsDashboard();
        }

        private void checkIsDashboard()
        {
            if(isDashboard)
            {
                //set color #14213D for btnDashboard
                btnDashboard.BackColor = Color.FromArgb(20, 33, 61);
                btnManage.BackColor = Color.FromArgb(0, 74, 173);

                //load uc dashboard to panel3
                panel3.Controls.Clear();
                UCDashboard dashboard = new UCDashboard();
                dashboard.Dock = DockStyle.Fill;
                panel3.Controls.Add(dashboard);
            }
            else
            {
                //set color #14213D for btnManage
                btnManage.BackColor = Color.FromArgb(20, 33, 61);
                btnDashboard.BackColor = Color.FromArgb(0, 74, 173);

                //load uc manage to panel3
                panel3.Controls.Clear();
                UCManage manage = new UCManage();
                manage.Dock = DockStyle.Fill;
                panel3.Controls.Add(manage);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // delete the username.txt, password.txt file
            System.IO.File.Delete("username.txt");
            System.IO.File.Delete("password.txt");
            this.Close();
            Application.Exit();
        }

        #region Dragable settings

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point mousePose = Control.MousePosition;
                    mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                    Location = mousePose;
                }
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            isDashboard = true;
            checkIsDashboard();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            isDashboard = false;
            checkIsDashboard();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery("SELECT * FROM dbo.Account");
            }
            catch (SqlException err)
            {
                if (err.Number == 229)
                    MessageBox.Show("Lỗi phân quyền!\n" + err.Message);
                return;
            }

            // call the AddUser form
            AddUser addUser = new AddUser();
            addUser.ShowDialog();

        }
    }
}
