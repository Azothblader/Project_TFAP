using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            updateTxtbox();
        }

        private void updateTxtbox()
        {
            List<TextBox> list = new List<TextBox>();
            list.Add(textBox1);
            list.Add(textBox2);
            list.Add(textBox3);
            list.Add(textBox4);
            list.Add(textBox5);
            list.Add(textBox6);
            list.Add(textBox7);
            list.Add(textBox8);
            list.Add(textBox9);
            list.Add(textBox10);
            list.Add(textBox11);
            list.Add(textBox12);
            list.Add(textBox13);
            list.Add(textBox14);
            list.Add(textBox15);

            for (int i = 0; i <= 14; i++)
            {
                ((TextBox)list[i]).Text = AdvancOptionSet.characterSet[i].ToString();
            }
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void updateCharSet(object sender, EventArgs e)
        {
            List<TextBox> list = new List<TextBox>();
            list.Add(textBox1);
            list.Add(textBox2);
            list.Add(textBox3);
            list.Add(textBox4);
            list.Add(textBox5);
            list.Add(textBox6);
            list.Add(textBox7);
            list.Add(textBox8);
            list.Add(textBox9);
            list.Add(textBox10);
            list.Add(textBox11);
            list.Add(textBox12);
            list.Add(textBox13);
            list.Add(textBox14);
            list.Add(textBox15);

            for (int i = 0; i <= 14; i++)
            {
                 AdvancOptionSet.characterSet[i] = ((TextBox)list[i]).Text.ToCharArray()[0] ;
            }

            updateTxtbox();
        }

        private void minAddThesHold(object sender, EventArgs e)
        {
            label6.Text= hScrollBar1.Value.ToString();
            AdvancOptionSet.minimumAddTheshold = hScrollBar1.Value;
        }
        private void maxReduceThesHold(object sender, EventArgs e)
        {
            label7.Text = hScrollBar2.Value.ToString();
            AdvancOptionSet.maximumReduceTheshold = hScrollBar2.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] tmp_characterSet = { 'a', 'b', 'u', 'x', 'c', 'k', 's', 'u', 'd', 'g', 'e', 'z', 'y', 'f', 'o' };
            AdvancOptionSet.characterSet = tmp_characterSet;
        }

     


    }
}
