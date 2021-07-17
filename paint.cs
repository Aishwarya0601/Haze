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
    public partial class paint : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        //Brush b;
        public paint()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            //b = new Brush("Solid",Color.Blue);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        void recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            //rectimeout = 0;
        }

        int f = 0;

        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            pictureBox17.BackColor = pen.Color;
            f = 0;
            string speech = e.Result.Text;
            if (speech == "navy")
            {
                MessageBox.Show("Navy blue colour","Pen colour");
                pen.Color = Color.Navy;
                //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                //Brush
                
                
            }
            if (speech == "black")
            {
                MessageBox.Show("Black colour","Pen colour");
                pen.Color = Color.Black;
            }
            if (speech == "purple")
            {
                MessageBox.Show("Purple colour","Pen colour");
                pen.Color = Color.Purple;
            }
            if (speech == "green")
            {
                MessageBox.Show("Green colour","Pen colour");
                pen.Color = Color.ForestGreen;
            }
            if (speech == "red")
            {
                MessageBox.Show("Red colour","Pen colour");
                pen.Color = Color.Red;
            }
            if (speech == "brown")
            {
                MessageBox.Show("Brown colour","Pen colour");
                pen.Color = Color.SaddleBrown;
            }
            if (speech == "light green")
            {
                MessageBox.Show("Light green colour","Pen colour");
                pen.Color = Color.GreenYellow;
            }
            if (speech == "yellow")
            {
                MessageBox.Show("Yellow colour","Pen colour");
                pen.Color = Color.Yellow;
            }
            if (speech == "pink")
            {
                MessageBox.Show("Pink colour","Pen colour");
                pen.Color = Color.DeepPink;
            }
            if (speech == "aqua")
            {
                MessageBox.Show("Aqua colour","Pen colour");
                pen.Color = Color.Aqua;
            }
            if (speech == "solid")
            {
                MessageBox.Show("Solid style","Pen style");
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }
            if (speech == "dot")
            {
                MessageBox.Show("Dot style","Pen style");
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }
            if (speech == "dash")
            {
                MessageBox.Show("Dash style","Pen style");
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            if (speech == "clean")
            {
                //g.Clear();
                MessageBox.Show("Clear","Clear");
                g.Clear(Color.White);
            }
            if(speech=="rect")
            {
                MessageBox.Show("Rectangle","Shape");
                f=1;
            }
            if (speech == "sheets")
            {
                MessageBox.Show("Circle","Shape");
                f = 2;
            }
            if (speech == "go back")
            {
                home f2 = new home();
                f2.Show();
                this.Hide();
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
            }
            
            pictureBox17.BackColor = pen.Color;

        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                if (f == 0)
                {
                    g.DrawLine(pen, new Point(x, y), e.Location);
                    x = e.X;
                    y = e.Y;
                }
                else if(f==1)
                {
                    Rectangle r=new Rectangle(x,y,100,50);
                    g.DrawRectangle(pen,r);
                    //f = 0;
                    //x=e.X;
                    //y=e.Y;
                }
                else if (f == 2)
                {
                    Rectangle c = new Rectangle(x, y, 100, 100);
                    g.DrawEllipse(pen, c);
                    //f = 0;
                }
                    
            }


        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;


        }

        private void paint_Load(object sender, EventArgs e)
        {
            sen.SpeakAsync(Program.username+"this is haze's sketch book..have fun ");
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"paintcmds.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}
