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
    public partial class slideshow : Form
    {
        public slideshow()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void slideshow_Load(object sender, EventArgs e)
        {
            
        }
        int j = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (j == Program.files.Length)
            {
                timer1.Enabled = false;
  
               
            }
            if (j < Program.files.Length)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Image.FromFile(Program.files[j]);
                j = j + 1;
            }
        }
    }
}
