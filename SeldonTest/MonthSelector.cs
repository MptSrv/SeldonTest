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
    public partial class MonthSelector : Form
    {
        public MonthSelector()
        {
            InitializeComponent();
        }

        private const double _percentage = 0.33; // треть чекбоксов

        public List<string> CheckedItems { get; private set; }

        public bool NeverShowAgain { get; private set; }       

        private void chkNotShowAgain_CheckedChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = chkNotShowAgain.Checked || (checkedListBox1.CheckedItems.Count >= _percentage * checkedListBox1.Items.Count);
        }

        private void MonthSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckedItems = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                CheckedItems.Add(item.ToString());
            }
            NeverShowAgain = chkNotShowAgain.Checked;
        }     

        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Text = $"Выбрано пунктов: {checkedListBox1.CheckedItems.Count}";

            btnOK.Enabled = chkNotShowAgain.Checked || (checkedListBox1.CheckedItems.Count >= Math.Ceiling(_percentage * checkedListBox1.Items.Count));
        }
    }
}
