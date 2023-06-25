using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        List<Students> Stu = new List<Students>();
        public Form1()
        {
            InitializeComponent();

            Students s = new Students("abc", "123", "lahore");
            Students p = new Students("def", "456", "multan");
            Students q = new Students("ghi", "789", "lahore");

            Stu.Add(s);
            Stu.Add(p);
            Stu.Add(q);
            dataGridView1.DataSource = Stu;
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Students student = (Students)dataGridView1.CurrentRow.DataBoundItem;
            Stu.Remove(student);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Stu;
            dataGridView1.Refresh();
        }
    }
}
