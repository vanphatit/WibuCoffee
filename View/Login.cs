using System;
using System.Windows.Forms;
using WibuCoffee.View;

namespace WibuCoffee
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string password = txbPassword.Text;
            bool isAdmin = false;

            object result = DataProvider.Instance.ExecuteScalar("SELECT dbo.checkLogin( @username , @password )", new object[] { username, password });

            if (result.ToString() != "Invalid")
            {
                if(result.Equals("0"))
                {
                    isAdmin = true;
                }
                else if(result.Equals("1"))
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
    }
}
