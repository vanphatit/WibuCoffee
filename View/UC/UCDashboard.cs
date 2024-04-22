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
using System.Windows.Media.Media3D;

namespace WibuCoffee.View.UC
{
    public partial class UCDashboard : UserControl
    {
        DataTable top5Products = new DataTable();
        DataTable moneyRecents = new DataTable();
        DataTable incomeMonthly = new DataTable();

        List<Button> btnMoneyChart_Income;
        List<Button> btnMoneyChart_Expense;
        List<Button> btnIncomeChart;
        List<Point> btnIncomeChart_point;
        List<Label> lbIncomeChart;

        // Declare the ToolTip at the class level so it's accessible throughout the class
        private ToolTip btnToolTip = new ToolTip();

        public UCDashboard()
        {
            InitializeComponent();
            InitializeToolTip();
            customComponents();
        }

        private void InitializeToolTip()
        {
            // Set up the delays for the ToolTip.
            btnToolTip.AutoPopDelay = 5000;    // The time interval in milliseconds the ToolTip remains visible if the pointer is stationary on a control with specified ToolTip text.
            btnToolTip.InitialDelay = 1000;    // The time delay in milliseconds before the ToolTip appears.
            btnToolTip.ReshowDelay = 500;      // The time interval in milliseconds it takes subsequent ToolTip windows to appear as the pointer moves from one control to another.
            btnToolTip.ShowAlways = true;      // Force the ToolTip text to be displayed whether or not the form is active.
        }

        void customComponents()
        {
            btnMoneyChart_Income = new List<Button> 
            { 
                 btnDate1_Income, btnDate2_Income, btnDate3_Income, btnDate4_Income, btnDate5_Income,
                 btnDate6_Income, btnDate7_Income
            };

            btnMoneyChart_Expense = new List<Button>
            {
                 btnDate1_Expense, btnDate2_Expense, btnDate3_Expense, btnDate4_Expense, btnDate5_Expense,
                 btnDate6_Expense, btnDate7_Expense
            };

            btnIncomeChart = new List<Button>
            {
                btnT1_Income, btnT2_Income, btnT3_Income, btnT4_Income, btnT5_Income, btnT6_Income, 
                btnT7_Income, btnT8_Income, btnT9_Income, btnT10_Income, btnT11_Income, btnT12_Income
            };

            btnIncomeChart_point = new List<Point>
            {
                new Point(53, 696), new Point(173, 696), new Point(293, 696), new Point(413, 696), 
                new Point(533, 696), new Point(653, 696), new Point(773, 696), new Point(893, 696),
                new Point(1013, 696), new Point(1133, 696), new Point(1253, 696), new Point(1373, 696)
            };

            lbIncomeChart = new List<Label>
            {
                lbT1_Income, lbT2_Income, lbT3_Income, lbT4_Income, lbT5_Income, lbT6_Income, 
                lbT7_Income, lbT8_Income, lbT9_Income, lbT10_Income, lbT11_Income, lbT12_Income
            };

            foreach (Button btn in btnMoneyChart_Income)
            {
                btn.BackColor = Color.FromArgb(193, 255, 114);
                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            }

            foreach (Button btn in btnMoneyChart_Expense)
            {
                btn.BackColor = Color.FromArgb(255, 181, 166);
                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            }

            foreach (Button btn in btnIncomeChart)
            {
                btn.BackColor = Color.FromArgb(254, 243, 117);
                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            }

            // set color #C1FF72 for pnlTodayIncome
            pnlTodayIncome.BackColor = Color.FromArgb(193, 255, 114);

            // set color #FFB5A6 for pnlTodayExpense
            pnlTodayExpense.BackColor = Color.FromArgb(255, 181, 166);

            // set color #FEF375 for pnlTodayRevenue
            pnlTodayRevenue.BackColor = Color.FromArgb(254, 243, 117);

            //set color #5CE1E6 for pnlEmptyTable
            pnlEmptyTable.BackColor = Color.FromArgb(92, 225, 230);

            //set the text align right for lbTop1, lbTop2, lbTop3, lbTop4, lbTop5
            lbTop1.TextAlign = ContentAlignment.MiddleRight;
            lbTop2.TextAlign = ContentAlignment.MiddleRight;
            lbTop3.TextAlign = ContentAlignment.MiddleRight;
            lbTop4.TextAlign = ContentAlignment.MiddleRight;
            lbTop5.TextAlign = ContentAlignment.MiddleRight;
        }

        void loadData()
        {
            // get today date
            DateTime today = DateTime.Now;

            decimal todayIncome = 0;
            decimal todayExpense = 0;
            decimal monthRevenue = 0;
            int emptyTable = 0;
            try
            {
                // get today income
                todayIncome = (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.getTotalPriceBillbyDate ( @date )", new object[] { today.Date.ToString("yyyy-MM-dd") });
                todayIncome = (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.getTotalExpensebyDate ( @date )", new object[] { today.Date.ToString("yyyy-MM-dd") });
                monthRevenue = (decimal)DataProvider.Instance.ExecuteScalar("SELECT dbo.getTotalRevenue1MonthAgo ()");
                emptyTable = (int)DataProvider.Instance.ExecuteScalar("SELECT dbo.getEmptyTableCount ()");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
            

            lbTodayIncome.Text = "VNĐ " + todayIncome.ToString();
            lbTodayExpense.Text = "VNĐ " + todayExpense.ToString();
            lbTodayRevenue.Text = "VNĐ " + monthRevenue.ToString();
            lbEmptyTable.Text = emptyTable.ToString() + " bàn";

            try
            {
                // get view MostPopularProducts from database and set to topProducts
                top5Products = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MostPopularProducts");
                // Check if there are enough rows returned
                if (top5Products.Rows.Count >= 5)
                {
                    // Set the text for lbTop1, lbTop2, lbTop3, lbTop4, lbTop5 from top5Products with format: "Quantity - Price - Product Name"
                    lbTop1.Text = top5Products.Rows[0]["ID"] + " - " + top5Products.Rows[0]["name"].ToString() + " - "
                        + top5Products.Rows[0]["price"] + "VNĐ - Đã bán: " + top5Products.Rows[0]["totalQuantity"].ToString();
                    lbTop2.Text = top5Products.Rows[1]["ID"] + " - " + top5Products.Rows[1]["name"].ToString() + " - "
                        + top5Products.Rows[1]["price"] + "VNĐ - Đã bán: " + top5Products.Rows[1]["totalQuantity"].ToString();
                    lbTop3.Text = top5Products.Rows[2]["ID"] + " - " + top5Products.Rows[2]["name"].ToString() + " - "
                        + top5Products.Rows[2]["price"] + "VNĐ - Đã bán: " + top5Products.Rows[2]["totalQuantity"].ToString();
                    lbTop4.Text = top5Products.Rows[3]["ID"] + " - " + top5Products.Rows[3]["name"].ToString() + " - "
                        + top5Products.Rows[3]["price"] + "VNĐ - Đã bán: " + top5Products.Rows[3]["totalQuantity"].ToString();
                    lbTop5.Text = top5Products.Rows[4]["ID"] + " - " + top5Products.Rows[4]["name"].ToString() + " - "
                        + top5Products.Rows[4]["price"] + "VNĐ - Đã bán:  " + top5Products.Rows[4]["totalQuantity"].ToString();
                }
                else
                {
                    // Handle the case where less than 5 products are returned
                    // You may want to clear the labels or set them to a default text like "N/A"
                    lbTop1.Text = lbTop2.Text = lbTop3.Text = lbTop4.Text = lbTop5.Text = "N/A";
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }

            try
            {
                moneyRecents = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillExpenseCount7DaysAgo");

                if (moneyRecents.Rows.Count >= 7)
                {
                    // get the Date of the first row in moneyRecents and set to lbDate1, lbDate2, lbDate3, lbDate4, lbDate5, lbDate6, lbDate7
                    lbDate1.Text = ((DateTime)moneyRecents.Rows[0]["Date"]).ToString("dd/MM/yyyy");
                    lbDate2.Text = ((DateTime)moneyRecents.Rows[1]["Date"]).ToString("dd/MM/yyyy");
                    lbDate3.Text = ((DateTime)moneyRecents.Rows[2]["Date"]).ToString("dd/MM/yyyy");
                    lbDate4.Text = ((DateTime)moneyRecents.Rows[3]["Date"]).ToString("dd/MM/yyyy");
                    lbDate5.Text = ((DateTime)moneyRecents.Rows[4]["Date"]).ToString("dd/MM/yyyy");
                    lbDate6.Text = ((DateTime)moneyRecents.Rows[5]["Date"]).ToString("dd/MM/yyyy");
                    lbDate7.Text = ((DateTime)moneyRecents.Rows[6]["Date"]).ToString("dd/MM/yyyy");

                    int max = 550;
                    for (int i = 0; i < 7; i++)
                    {
                        decimal totalBill = Convert.ToDecimal(moneyRecents.Rows[i]["TotalBill"]);
                        decimal totalExpense = Convert.ToDecimal(moneyRecents.Rows[i]["TotalExpense"]);
                        decimal total = totalBill + totalExpense;

                        int incomeWidth = (total > 0) ? (int)((totalBill / total) * max) : 0;
                        int expenseWidth = (total > 0) ? (int)((totalExpense / total) * max) : 0;

                        if (incomeWidth + expenseWidth >= max)
                        {
                            double scaleFactor = (double)max / (incomeWidth + expenseWidth);
                            incomeWidth = (int)(incomeWidth * scaleFactor);
                            expenseWidth = (int)(expenseWidth * scaleFactor);
                        }

                        string tooltipText = $"Total Bill: {totalBill} VNĐ\nTotal Expense: {totalExpense} VNĐ";
                        btnToolTip.SetToolTip(btnMoneyChart_Income[i], tooltipText);
                        btnToolTip.SetToolTip(btnMoneyChart_Expense[i], tooltipText);

                        // Set width and position of income button
                        btnMoneyChart_Income[i].Width = incomeWidth;

                        // Set width and position of expense button
                        btnMoneyChart_Expense[i].Width = expenseWidth;
                        btnMoneyChart_Expense[i].Left = btnMoneyChart_Income[i].Left + btnMoneyChart_Income[i].Width;
                    }
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }

            try
            {
                incomeMonthly = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MonthlyTotalPriceBillView");

                //find max value of incomeMonthly
                decimal maxIncome = 0;
                for (int i = 0; i < 12; i++)
                {
                    decimal total = Convert.ToDecimal(incomeMonthly.Rows[i]["TotalPrice"]);
                    if (total > maxIncome)
                    {
                        maxIncome = total;
                    }
                }
                if (incomeMonthly.Rows.Count >= 12)
                {
                    int max = 200;
                    for (int i = 0; i < 12; i++)
                    {
                        decimal total = Convert.ToDecimal(incomeMonthly.Rows[i]["TotalPrice"]);
                        int height = (maxIncome > 0) ? (int)(total / maxIncome * max) : 0;
                        btnIncomeChart[i].Location = new Point(btnIncomeChart_point[i].X, 726 - height);
                        btnIncomeChart[i].Height = height;

                        if (height == 0)
                        {
                            lbIncomeChart[i].Location = btnIncomeChart_point[i];
                            lbIncomeChart[i].Text = "0 VNĐ";
                        }
                        else
                        {
                            // Set the location of the lbIncomeChart[i] to the top of the btnIncomeChart[i]
                            lbIncomeChart[i].Top = btnIncomeChart[i].Top - lbIncomeChart[i].Height;
                            lbIncomeChart[i].Text = ((int)(total / 100)).ToString() + "k";
                        }
                    }
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
