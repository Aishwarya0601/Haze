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
using System.Media;

namespace WindowsFormsApplication2
{

    public partial class home : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        DateTime timenow = DateTime.Now;
        private SoundPlayer sp;
        
        public home()
        {
            InitializeComponent();
            sp = new SoundPlayer("ChillingMusic.wav");
            /*System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(pictureBox1.DisplayRectangle);
            pictureBox1.Region = new Region(gp);
            pictureBox2.Region = new Region(gp);
            pictureBox3.Region = new Region(gp);
            pictureBox4.Region = new Region(gp);
            pictureBox5.Region = new Region(gp);*/
        }

        private void home_Load(object sender, EventArgs e)
        {
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFile1.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFile1.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
            sen.SpeakAsync("Welcome"+Program.username);
            sen.SpeakAsync("How can haze help you?");

        }
        void recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            //rectimeout = 0;
        }

        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;
            /*if (speech == "Hello")
            {
                sen.SpeakAsync("Hey i am haze..how can i help you?");
            }
            if (speech == "How are you")
            {
                sen.SpeakAsync("I am fine");
            }
            if (speech == "What time is it")
            {
                sen.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }*/
           if (speech == "microsoft shortcuts")
            {
                //pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                windowsapps f1 = new windowsapps();
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
                f1.Show();
                this.Hide();
                //pictureBox1.BorderStyle = BorderStyle.None;
            }
            if (speech == "paint")
            {
                //pictureBox4.BorderStyle = BorderStyle.Fixed3D;
                paint f2 = new paint();
                f2.Show();
                this.Hide();
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
                //this.Hide();
                //pictureBox4.BorderStyle = BorderStyle.None;
            }
            if (speech == "maps")
            {
                //pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                maps f3 = new maps();
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
                f3.Show();
                this.Hide();
               
                //pictureBox3.BorderStyle = BorderStyle.None;
            }
            if (speech == "images")
            {
                //pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                galleryapp f3 = new galleryapp();
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
                f3.Show();
                this.Hide();
                
                //pictureBox2.BorderStyle = BorderStyle.None;
            }
            if (speech == "Stop talking")
            {
                sen.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1, 2);
                if (ranNum == 1)
                {
                    sen.SpeakAsync("Yes Mam");
                }
                if (ranNum == 2)
                {
                    sen.SpeakAsync("I am sorry I will be quiet");
                }
            }
            
            if (speech == "talk to you")
            {
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
                speakwithme f9 = new speakwithme();
                f9.Show();
                this.Hide();
            }

        }
        void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Wake up")
            {
                startlistening.RecognizeAsyncCancel();
                sen.SpeakAsync("Yes I am here");
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
