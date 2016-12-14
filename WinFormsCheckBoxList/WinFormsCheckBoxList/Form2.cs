using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCheckBoxList
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private string key;
        private Button b;
        public Form2(string key, List<string> items, Form1 form1)
        {
            InitializeComponent();

            this.form1 = form1;
            this.key = key;

            foreach (var item in items)
            {
                checkedListBox1.Items.Add(item);
            }

            checkedListBox1.MouseUp += CheckedListBox1_MouseUp;

            b = new Button();
            b.Text = "Ok";
            b.Click += Ok_Click;
            b.Top = 150;
            b.Left = 50;
            b.Parent = this;
            b.Enabled = false;    
        }

        private void CheckedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            b.Enabled = checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            form1.SetChecked(this.key);
            this.Close();
        }
    }
}
