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
    public partial class windowsapps : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0;
        public windowsapps()
        {
            InitializeComponent();
        }

        

        private void windowsapps_Load(object sender, EventArgs e)
        {
            sen.SpeakAsync(Program.username+"Please tell me the microsoft application you want to open");
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"wincmds.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
            
            /*startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"wincmds.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);*/
        }
        void recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            //rectimeout = 0;
        }

        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "microsoft word")
            {
                f5 = 1;
                pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                sen.SpeakAsync("We are opening Microsoft Word for you..");
                Process.Start("winword");
                pictureBox3.BorderStyle = BorderStyle.None;
                
            }
            if (speech == "sheets")
            {
                f1 = 1;
                pictureBox5.BorderStyle = BorderStyle.Fixed3D;
                sen.SpeakAsync("We are opening Microsoft Excel for you..");
                Process.Start("excel");
                pictureBox5.BorderStyle = BorderStyle.None;
                
            }
            if (speech == "paint")
            {
                f2 = 1;
                pictureBox4.BorderStyle = BorderStyle.Fixed3D;
                sen.SpeakAsync("We are opening Paint for you..");
                Process.Start("mspaint");
                pictureBox4.BorderStyle = BorderStyle.None;
                
                
            }
            if (speech == "notepad")
            {
                f3 = 1;
                pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                sen.SpeakAsync("We are opening Notepad for you..");
                Process.Start("notepad");
                pictureBox2.BorderStyle = BorderStyle.None;
                

            }
            if (speech == "calci")
            {
                f4 = 1;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                sen.SpeakAsync("We are opening calculator for you..");
                Process.Start("calc");
                pictureBox1.BorderStyle = BorderStyle.None;
                
            }
            if (speech == "back")
            {
                pictureBox6.BorderStyle = BorderStyle.Fixed3D;
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
                home f2 = new home();
                f2.Show();
                this.Hide();
                pictureBox6.BorderStyle = BorderStyle.None;
                

            }
            
            if (speech == "close")
            {
                MessageBox.Show("Are you sure you want to close all apps");
                if (f1 == 1)
                {
                    foreach (var process in Process.GetProcessesByName(excel.Name))
                    {
                        process.Kill();
                    }
                }
                if (f2 == 1)
                {
                    foreach (var process in Process.GetProcessesByName(mspaint.Name))
                    {
                        process.Kill();
                    }
                }
                if (f3 == 1)
                {
                    foreach (var process in Process.GetProcessesByName(notepad.Name))
                    {
                        process.Kill();
                    }
                }
                if (f4 == 1)
                {
                    foreach (var process in Process.GetProcessesByName(calc.Name))
                    {
                        process.Kill();
                    }
                }
                if (f5 == 1)
                {
                    foreach (var process in Process.GetProcessesByName(winword.Name))
                    {
                        process.Kill();
                    }
                }

            }
           
            /**else if (speech == "Close word")
            {
                var p = "winword";
                p.Kill();
            }**/
        }

        

       
        /*void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Wake up")
            {
                startlistening.RecognizeAsyncCancel();
                sen.SpeakAsync("Yes I am here");
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }*/
    }
}
