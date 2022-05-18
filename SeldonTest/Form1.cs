using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeldonTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void ShowMonthDialog()
        {
            MonthSelector monthSelector = new MonthSelector();
            if (monthSelector.ShowDialog() == DialogResult.OK)
            {
                string checkedMonths = "Выбранные пункты: " + Environment.NewLine;
                foreach (string item in monthSelector.CheckedItems)
                {
                    checkedMonths += $"{item}, ";
                }               
                checkedMonths = checkedMonths.TrimEnd(',', ' ') + Environment.NewLine;
                checkedMonths += $"Больше не показывать: {monthSelector.NeverShowAgain}";
                MessageBox.Show(checkedMonths);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMonthDialog();
        }
    }
}
