using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{
    
    public partial class Form1 : Form
    {
        public decimal columnSlot { get; set; }   //for constrcut of output char array [Row][Column]
        public decimal rowSlot { get; set; }     //for constrcut of output char array [Row][Column]
        public decimal picPxH { get; set; }    // for resize image Height
        public decimal picPxW { get; set; }      // for resize image Widht
        public int charPXHeight { get; set; }
        public int charPXWidth { get; set; }
        public int[,] wowGlobal { get; set; }
        public char[] tmp_characterSet = { 'a', 'b', 'u', 'x', 'c', 'k', 's', 'u', 'd', 'g', 'e', 'z', 'y', 'f', 'o' };
        public Form2 advanceOption { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picturePXSizeCalculate();
            InitializeAdvanceOption();
            advanceOption = new Form2();
            advanceOption.Hide();
           
        }


        private void InitializeAdvanceOption()
        {
            char[] tmp_characterSet = { 'a', 'b', 'u', 'x', 'c', 'k', 's', 'u', 'd', 'g', 'e', 'z', 'y', 'f', 'o' };
            AdvancOptionSet.characterSet = tmp_characterSet;
            AdvancOptionSet.maximumReduceTheshold = 0;
            AdvancOptionSet.minimumAddTheshold = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Please Choose Picture file";
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpg";
            openFileDialog1.ShowDialog();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resizeAndShowControl()
        {
            //resize heigh
            //  richTextBox1.Height = decimal.ToInt32(rowSlot * charPXHeight);
            //richTextBox1.Width = decimal.ToInt32(columnSlot * charPXWidth);
            //   Form1.ActiveForm.Height = '
            //  Form1.
            richTextBox1.Visible = true;

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            


        }

        public String ProcessPicture(out string outputText)
        {
            String result = "";
            outputText = "";
            try
            {
                System.IO.Stream fileStream = openFileDialog1.OpenFile();


                Bitmap in_Image = (Bitmap)Image.FromStream(fileStream);
                Bitmap processedImage;
                //image manipualte
                // resize
                Size size = new Size();
                size.Width = decimal.ToInt32(picPxW);
                size.Height = decimal.ToInt32(picPxH);
                ResizeImage(in_Image, size, out processedImage);
                // pictureBox1.Image = processedImage;  fordebug

                // change to brigness scale
                int y = decimal.ToInt32(picPxH);
                int x = decimal.ToInt32(picPxW);
                int[,] wow = new int[y, x];  // row column 



                for (int row = 0; row < y; row++)
                {   // y
                    for (int col = 0; col < x; col++)  // x
                    {
                        int brightness = Convert.ToInt32(processedImage.GetPixel(col, row).GetBrightness() * 1000);
                        wow[row, col] = brightness;

                    }
                }



                wowGlobal = wow;
                // set threshhold  numericUpDown5.Value
                int range = decimal.ToInt32(numericUpDown5.Value);
                decimal max = 0;
                decimal min = 99999;

                //   rowslot column slot
                // create result group to score slot for decide string from characterSet 
                //      [][][]
                //      [][][]  ==>>[]
                //      [][][]

                int rowS = decimal.ToInt32(rowSlot);
                int colS = decimal.ToInt32(columnSlot);
                decimal[,] resultScore = new decimal[rowS, colS];
                // create result string from characterSet[] 
                for (int col = 0; col < colS; col++)
                {
                    for (int row = 0; row < rowS; row++)
                    {
                        resultScore[row, col] = calculateGroupCellScore(row, col);


                        if (max < resultScore[row, col])
                        {
                            max = resultScore[row, col];
                        }
                        if (min > resultScore[row, col])
                        {
                            min = resultScore[row, col];
                        }

                    }

                }
                // find interval for determine character
                decimal interval = (max - min) / range;
                //from advance option  add /reduce interval
               interval += AdvancOptionSet.minimumAddTheshold * interval /100;
               interval -= AdvancOptionSet.maximumReduceTheshold * interval / 100;

                for (int row = 0; row < rowS; row++)
                {
                    for (int col = 0; col < colS; col++)
                    {

                        int set = decimal.ToInt32(resultScore[row, col] / interval);
                        if (set > (AdvancOptionSet.characterSet.Length - 1))
                        {
                            set = AdvancOptionSet.characterSet.Length - 1;
                        }
                        outputText += AdvancOptionSet.characterSet[set];
                    }
                    outputText += '\n';
                }

            }
            catch (Exception e)
            {

                result = e.Message;
            }

            return result;
        }
        public decimal calculateGroupCellScore(int rowCell, int colCell)
        {

            // charPXWidth
            int result = 0;
            int hLimit = decimal.ToInt32(picPxH) - 1;
            int wLimit = decimal.ToInt32(picPxW) - 1;
            for (int h = 0; h < charPXHeight; h++)
            {
                for (int w = 0; w < charPXWidth; w++)
                {
                    int rowIndicate = ((rowCell * charPXHeight) + h);
                    int colIndicate = ((colCell * charPXWidth) + w);
                    if ((rowIndicate > hLimit) || (colIndicate > wLimit))
                    {

                    }
                    else
                    {
                        result += wowGlobal[rowIndicate, colIndicate];
                    }

                }
            }

            return result;

        }


        public Boolean ResizeImage(Bitmap imgToResize, Size size, out Bitmap result)
        {
            result = new Bitmap(size.Width, size.Height);
            try
            {

                using (Graphics g = Graphics.FromImage((Image)result))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void picturePXSizeCalculate()
        {
            // picPxH  columnSlot   rowSlot
            picPxW = numericUpDown2.Value * numericUpDown3.Value;
            picPxH = numericUpDown1.Value * numericUpDown4.Value;

            pictureSizeW.Text = picPxW.ToString();
            pictureSizeH.Text = picPxH.ToString();

            columnSlot = numericUpDown2.Value;
            rowSlot = numericUpDown1.Value;

            charPXWidth = decimal.ToInt32(numericUpDown3.Value);
            charPXHeight = decimal.ToInt32(numericUpDown4.Value);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            picturePXSizeCalculate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String outputText = "";
            String outputProcess = ProcessPicture(out outputText);
            if (String.IsNullOrEmpty(outputProcess))
            {
                richTextBox1.Text = outputText;
            }
            else
            {
                richTextBox1.Text = outputProcess;
            }
            resizeAndShowControl();


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            richTextBox1.Height = Form1.ActiveForm.Height - 200; // 269 = upper size
            richTextBox1.Width = Form1.ActiveForm.Width - 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
                
                if (advanceOption.Visible)
                { advanceOption.Hide(); }
                else {
                    advanceOption.Show();
                }
        
        }
    }
}
