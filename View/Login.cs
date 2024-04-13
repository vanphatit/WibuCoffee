using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WibuCoffee.View;

namespace WibuCoffee
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            // find the servername.txt file in the same directory as the executable file, if not found, enable the txbServerName to input the server name
            if (!System.IO.File.Exists("servername.txt"))
            {
                pnlServerName.Enabled = true;
            }
            else
            {
                pnlServerName.Enabled = false;
            }

            if(System.IO.File.Exists("servername.txt") && System.IO.File.ReadAllText("servername.txt").Length > 0)
            {
                txbServerName.Text = System.IO.File.ReadAllText("servername.txt");
            }
            else if(System.IO.File.Exists("servername.txt") && System.IO.File.ReadAllText("servername.txt").Length == 0)
            {
                pnlServerName.Enabled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string password = txbPassword.Text;
            bool isAdmin = false;
            object result;

            try
            {
                if (pnlServerName.Enabled)
                {
                    string serverName = txbServerName.Text;
                    // write the server name to the servername.txt file
                    System.IO.File.WriteAllText("servername.txt", serverName);
                }

                if (System.IO.File.Exists("servername.txt") && System.IO.File.ReadAllText("servername.txt").Length > 0)
                {
                    result = DataProvider.Instance.ExecuteScalar("SELECT dbo.checkLogin( @username , @password )", new object[] { username, password });
                    if (result.ToString() != "Invalid")
                    {
                        if(result.Equals("0"))
                        {
                            isAdmin = true;
                        }
                        else if (result.Equals("1"))
                        {
                            isAdmin = false;
                        }
                        this.Hide();
                        MainWindow mainWindow = new MainWindow(isAdmin);
                        mainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file servername.txt");
                    return;
                }
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu! Vui lòng xem lại server name");
                // delete the servername.txt file
                System.IO.File.Delete("servername.txt");
                pnlServerName.Enabled = true;
                return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pnlServerName.Enabled = true;
            // delete the servername.txt file
            System.IO.File.Delete("servername.txt");
        }
    }
}
