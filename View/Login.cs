using Microsoft.VisualBasic.ApplicationServices;
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
                    try
                    {
                        string username = txbUserName.Text;
                        string password = txbPassword.Text;

                        // write the user name to the username.txt file
                        System.IO.File.WriteAllText("username.txt", username);
                        // write the password to the password.txt file
                        System.IO.File.WriteAllText("password.txt", password);

                        bool isAdmin = false;
                        result = DataProvider.Instance.ExecuteScalar("SELECT dbo.checkLogin( @username , @password )", new object[] { username, password });
                        if (result.ToString() != "Invalid")
                        {
                            if (result.Equals("0"))
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
                    catch (SqlException err)
                    {
                        MessageBox.Show(Text = "Error from SQL!\n" + err.Message);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file servername.txt");
                    return;
                }
                
            }
            catch (SqlException err)
            {
                MessageBox.Show("Error from SQL!\n" + err.Message);
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
