using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
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
using System.Windows.Media.Media3D;

namespace WibuCoffee.View
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();

            // load roles to cbbRoles
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Account");
            cbbRoles.DataSource = data;
            cbbRoles.DisplayMember = "userRole";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txbUserName.Text.ToString();
                string password = txbPassword.Text.ToString();
                string role = cbbRoles.Text;

                // thực thi với Windows Authentication (Integrated Security = True)
                int rs = ExcuteNonQuery("EXEC dbo.AddAccount @userName , @pass , @userRole ", new object[] { username, password, role });
                MessageBox.Show("Add user successfully!");
            }
            catch (SqlException err)
            {
                MessageBox.Show("Error from SQL!\n" + err.Message);
                return;
            }
        }

        int ExcuteNonQuery(string query, object[] para = null)
        {
            int data = 0;

            string dataSource = System.IO.File.ReadAllText("servername.txt");

            string connectionString = "Data Source=" + dataSource + ";Initial Catalog=WibuCoffee; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (para != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, para[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }
    }
}
