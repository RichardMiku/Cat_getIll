using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rm.json;

namespace spin100_Keaimao_SDK
{
    public partial class spin100 : Form
    {
       
        public spin100()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Get g = new Get();
            this.textBox1.Text = g.Getjson("云南");
        }
    }
}
