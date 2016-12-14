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
    public partial class Form1 : Form
    {
        private Dictionary<string, Tuple<int, List<string>>> content = new Dictionary<string, Tuple<int, List<string>>>
        {
            { "Pečivo", new Tuple<int, List<string>>(0 , new List<string> { "Rohlík", "Chleba"}) },
            { "Zelenina", new Tuple<int, List<string>>(1, new List<string> { "Cibule", "Česnek"}) }
        };

        
        public Form1()
        {
            InitializeComponent();
            int buttonTop = 5;
            int index = 0;
            foreach (var item in content.OrderBy(x => x.Value.Item1))
            {
                this.checkedListBox1.Items.Add(item.Key, false);                
                Button b = new Button();
                b.Click += ItemButton_Click;
                b.Parent = this;
                b.Text = item.Key;
                b.Left = 150;
                b.Top = buttonTop;
                b.Tag = item.Key;
                buttonTop += b.Height;
                index++;
            }
        }

        internal void SetChecked(string key)
        {
            checkedListBox1.SetItemChecked(content[key].Item1, true);
        }

        private void ItemButton_Click(object sender, EventArgs e)
        {
            string key = (string)((Button)sender).Tag;
            Form2 form2 = new Form2(key, content[key].Item2, this);
            form2.Show();

        }
    }
}
