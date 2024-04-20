using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WibuCoffee.View.UC.Manage;

namespace WibuCoffee.View.UC
{
    public partial class UCManage : UserControl
    {
        private List<Button> listButton;

        // get user name from username.txt file
        private string user = System.IO.File.ReadAllText("username.txt");

        public UCManage()
        {
            InitializeComponent();

            listButton = new List<Button>();
            listButton.Add(btnOrder);
            listButton.Add(btnEmployee);
            listButton.Add(btnProduct);
            listButton.Add(btnMaterial);
            listButton.Add(btnSupplier);
            listButton.Add(btnReceiptNote);
            listButton.Add(btnExpenseBill);

            customButton();

            if(user == "emp")
            {
                btnEmployee.Enabled = false;
                btnProduct.Enabled = false;
                btnSupplier.Enabled = false;
                btnReceiptNote.Enabled = false;
                btnExpenseBill.Enabled = false;
            }

            //set color #737373 for btnOrder
            btnOrder.BackColor = Color.FromArgb(115, 115, 115);
            btnOrder.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for panel1
            panel1.BackColor = Color.FromArgb(217, 217, 217);

            UCOrder ucOrder = new UCOrder();
            ucOrder.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucOrder);
        }

        private void customButton()
        {
            foreach (Button btn in listButton)
            {
                btn.BackColor = Color.FromArgb(217, 217, 217);
                btn.FlatAppearance.BorderSize = 0;
                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //set color #737373 for btnOrder
            btnOrder.BackColor = Color.FromArgb(115, 115, 115);
            btnOrder.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for other buttons
            foreach (Button btn in listButton)
            {
                if (btn != btnOrder)
                {
                    btn.BackColor = Color.FromArgb(217, 217, 217);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }

            UCOrder ucOrder = new UCOrder();
            ucOrder.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucOrder);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            btnEmployee.BackColor = Color.FromArgb(115, 115, 115);
            btnEmployee.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for other buttons
            foreach (Button btn in listButton)
            {
                if (btn != btnEmployee)
                {
                    btn.BackColor = Color.FromArgb(217, 217, 217);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }

            UCEmployee ucEmployee = new UCEmployee();
            ucEmployee.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucEmployee);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            btnProduct.BackColor = Color.FromArgb(115, 115, 115);
            btnProduct.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for other buttons
            foreach (Button btn in listButton)
            {
                if (btn != btnProduct)
                {
                    btn.BackColor = Color.FromArgb(217, 217, 217);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }

            UCProduct ucProduct = new UCProduct();
            ucProduct.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucProduct);
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            btnMaterial.BackColor = Color.FromArgb(115, 115, 115);
            btnMaterial.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for other buttons
            foreach (Button btn in listButton)
            {
                if (btn != btnMaterial)
                {
                    btn.BackColor = Color.FromArgb(217, 217, 217);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }

            UCMaterial ucMaterial = new UCMaterial();
            ucMaterial.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucMaterial);
        }

        private void btnReceiptNote_Click(object sender, EventArgs e)
        {
            btnReceiptNote.BackColor = Color.FromArgb(115, 115, 115);
            btnReceiptNote.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for other buttons
            foreach (Button btn in listButton)
            {
                if (btn != btnReceiptNote)
                {
                    btn.BackColor = Color.FromArgb(217, 217, 217);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }

            UCReceiptNote ucReceiptNote = new UCReceiptNote();
            ucReceiptNote.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucReceiptNote);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            btnSupplier.BackColor = Color.FromArgb(115, 115, 115);
            btnSupplier.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for other buttons
            foreach (Button btn in listButton)
            {
                if (btn != btnSupplier)
                {
                    btn.BackColor = Color.FromArgb(217, 217, 217);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }

            UCSupplier ucSupplier = new UCSupplier();
            ucSupplier.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucSupplier);
        }

        private void btnExpenseBill_Click(object sender, EventArgs e)
        {
            btnExpenseBill.BackColor = Color.FromArgb(115, 115, 115);
            btnExpenseBill.ForeColor = Color.FromArgb(255, 255, 255);

            //set color #D9D9D9 for other buttons
            foreach (Button btn in listButton)
            {
                if (btn != btnExpenseBill)
                {
                    btn.BackColor = Color.FromArgb(217, 217, 217);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }

            UCExpenseBill ucExpenseBill = new UCExpenseBill();
            ucExpenseBill.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(ucExpenseBill);
        }
    }
}
