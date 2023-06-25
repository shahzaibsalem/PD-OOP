using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Form1 : Form
    {
        public List<string> All_Names = new List<string>();
        public Form1()
        {
            InitializeComponent();

            All_Names.Add("Talha");
            All_Names.Add("Mursaleen");
            All_Names.Add("Faizan");
            All_Names.Add("Ali");
            All_Names.Add("Hamid");

            foreach(string item in All_Names)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show.Text = comboBox1.Text;
        }
    }
}
