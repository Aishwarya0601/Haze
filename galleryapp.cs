using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class galleryapp : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        //List<string> Imagefiles = new List<string>();
        int imageCount = 0;

        public galleryapp()
        {
            InitializeComponent();
        }

       



        
        Bitmap bmg;
        //int i = -1;
        private void galleryapp_Load(object sender, EventArgs e)
        {
            sen.SpeakAsync(Program.username+"select a folder to view the images in Haze's image viewer");
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"gallcmds.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        void recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            //rectimeout = 0;
        }

        

        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "next")
            {
                if (imageCount + 1 == Program.Imagefiles.Count)
                {
                    MessageBox.Show("No Other Images!");
                }
                else
                {
                    string nextImage = Program.Imagefiles[imageCount + 1];
                    pictureBox1.ImageLocation = nextImage;
                    //bmg = (Bitmap)pictureBox1.Image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    imageCount += 1;
                }
               


            }
            if (speech == "previous")
            {
                if (imageCount == 0)
                {
                    MessageBox.Show("No Other Images!");
                }
                else
                {
                    string prevImage = Program.Imagefiles[imageCount - 1];
                    pictureBox1.ImageLocation = prevImage;
                    //bmg = (Bitmap)pictureBox1.Image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    imageCount -= 1;
                }
                

            }
            if (speech == "right")
            {
                bmg = (Bitmap)pictureBox1.Image;
                
                if (bmg != null)
                {
                    bmg.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pictureBox1.Image = bmg;
                }
            }
            if (speech == "left")
            {
                bmg = (Bitmap)pictureBox1.Image;

                if (bmg != null)
                {
                    bmg.RotateFlip(RotateFlipType.Rotate90FlipX);
                    pictureBox1.Image = bmg;
                }

            }
            if (speech == "back")
            {


                recognizer.RecognizeAsyncCancel();
                home f2 = new home();
                f2.Show();
                this.Hide();
                sen.SpeakAsyncCancelAll();
                


            }
            if (speech == "slide show")
            {
                slideshow f4 = new slideshow();
                f4.Show();
            }
            if (speech == "effect")
            {
                Bitmap bmp1;
                int h, w;
                bmp1 = (Bitmap)pictureBox1.Image;
                h = bmp1.Height;
                w = bmp1.Width;
                Color p;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        p = bmp1.GetPixel(x, y);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
                        int avg = (r + g + b) / 3;
                        bmp1.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                        pictureBox1.Image = bmp1;
                    }
                }

            }
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Program.files = Directory.GetFiles(fbd.SelectedPath);
                    foreach (string s in Program.files)
                    {
                        if (s.EndsWith(".jpg") || s.EndsWith(".png")) //add more format files here
                        {
                            Program.Imagefiles.Add(s);
                        }
                    }
                    try
                    {
                        pictureBox1.ImageLocation = Program.Imagefiles.First();
                    }
                    catch { MessageBox.Show("No files found!"); }
                }
            }
        }

       
    }
}
