using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WibuCoffee.View.UC
{
    public partial class UCDashboard : UserControl
    {
        public UCDashboard()
        {
            InitializeComponent();

            // set color #C1FF72 for pnlTodayIncome
            pnlTodayIncome.BackColor = Color.FromArgb(193, 255, 114);

            // set color #FFB5A6 for pnlTodayExpense
            pnlTodayExpense.BackColor = Color.FromArgb(255, 181, 166);

            // set color #FEF375 for pnlTodayRevenue
            pnlTodayRevenue.BackColor = Color.FromArgb(254, 243, 117);

            //set color #5CE1E6 for pnlEmptyTable
            pnlEmptyTable.BackColor = Color.FromArgb(92, 225, 230);
        }

        void loadData()
        {
            // get today date
            DateTime today = DateTime.Now;
            // get today income
            decimal todayIncome = (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.getTotalPriceBillbyDate ( @date )", new object[] { today.Date.ToString("yyyy-MM-dd") });
            decimal todayExpense = (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.getTotalExpensebyDate ( @date )", new object[] { today.Date.ToString("yyyy-MM-dd") });
            decimal monthRevenue = (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.getTotalRevenue1MonthAgo ()");
            int emptyTable = (int)DataProvider.Instance.ExecuteScalar("SELECT dbo.getEmptyTableCount ()");

            lbTodayIncome.Text = "VNĐ " + todayIncome.ToString();
            lbTodayExpense.Text = "VNĐ " + todayExpense.ToString();
            lbTodayRevenue.Text = "VNĐ " + monthRevenue.ToString();
            lbEmptyTable.Text = emptyTable.ToString() + " bàn";

            // get view MostPopularProducts from database and set to dgvTopProducts
            dgvTopProducts.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MostPopularProducts");
            dgvTopProducts.Columns[0].HeaderText = "Mã món";
            dgvTopProducts.Columns[1].HeaderText = "Tên món";
            dgvTopProducts.Columns[2].HeaderText = "Giá";
            dgvTopProducts.Columns[3].HeaderText = "SL đã bán";

            // get view BillExpenseCount7DaysAgo from database and set to dgvMoneyRecents
            dgvMoneyRecents.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillExpenseCount7DaysAgo");
            dgvMoneyRecents.Columns[0].HeaderText = "Ngày";
            dgvMoneyRecents.Columns[1].HeaderText = "Tổng hóa đơn";
            dgvMoneyRecents.Columns[2].HeaderText = "Tổng phiếu chi";

        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
