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
    public partial class speakwithme : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        DateTime timenow = DateTime.Now;
        private SoundPlayer sp1,sp2,sp3;
        private int xPos = 0;
        public speakwithme()
        {
            InitializeComponent();
            sp1 = new SoundPlayer("PookkalSatru.wav");
            sp2 = new SoundPlayer("RowdyBaby.wav");
            sp3 = new SoundPlayer("Munbe.wav");

        }

        private void speakwithme_Load(object sender, EventArgs e)
        {
            //label1.Left = this.Width;
            timer1.Start();
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"chatcmds.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"chatcmds.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
            sen.SpeakAsync("hello i am haze..you can now talk with me");
        }
         void recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            //rectimeout = 0;
        }

         void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
         {
             int ranNum;
             string speech = e.Result.Text;
             if (speech == "what is your name")
             {
                 sen.SpeakAsync("my name is haze");
             }
             if (speech == "hi")
             {
                 sen.SpeakAsync("Yes I am here");
             }
             if (speech == "how are you")
             {
                 sen.SpeakAsync("I am fine");
             }
             if (speech == "what is the time")
             {
                 sen.SpeakAsync(DateTime.Now.ToString("h mm tt"));
             }
             //int f=0;
             if (speech == "song")
             {
                 ranNum = rnd.Next(1, 4);
                 if (ranNum == 1)
                 {
                     sp1.Play();
                     var bn=MessageBox.Show("WHEN YOU WANT TO STOP THE SONG CLICK OK", "Stop Song", MessageBoxButtons.OK);
                     if (bn == DialogResult.OK)
                     {
                         sp1.Stop();
                     }

                     //f=1;
                 }
                 else if (ranNum == 2)
                 {
                     sp2.Play();
                     var bn = MessageBox.Show("WHEN YOU WANT TO STOP THE SONG CLICK OK", "Stop Song", MessageBoxButtons.OK);
                     if (bn == DialogResult.OK)
                     {
                         sp2.Stop();
                     }
                     
                 }
                 else
                 {
                     sp3.Play();
                     var bn = MessageBox.Show("When you want to stop the song click OK", "Stop Song", MessageBoxButtons.OK);
                     if (bn == DialogResult.OK)
                     {
                         sp3.Stop();
                     }
                     
                 }
             }
             if (speech == "stop talking")
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
             if (speech == "back")
             {
                 sen.SpeakAsyncCancelAll();
                 recognizer.RecognizeAsyncCancel();
                 home h1 = new home();
                 h1.Show();
                 this.Hide();
             }
             
                 

         }
         void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
         {
             string speech = e.Result.Text;
             /*if (speech == "wake up")
             {
                 //startlistening.RecognizeAsyncCancel();
                 sen.SpeakAsync("Yes I am here");
                 recognizer.RecognizeAsync(RecognizeMode.Multiple);
             }*/
         }

         private void timer1_Tick(object sender, EventArgs e)
         {
             if (this.Width == xPos)
             {
                 //repeat marquee
                 this.label1.Location = new System.Drawing.Point(0, 40);
                 xPos = 0;
             }
             else
             {
                 this.label1.Location = new System.Drawing.Point(xPos, 40);
                 xPos++;
             }
         }
    }
}
