using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Logo : Form
    {
        public Logo()
        {
            InitializeComponent(); 
            
        }

        private void Logo_Load(object sender, EventArgs e)
        {
           
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
            this.Dispose();
        }
    }
}
