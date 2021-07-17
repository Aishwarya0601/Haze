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
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int rectimeout = 0;
        DateTime timenow = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFile1.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFile1.txt")))));
            startlistening.SpeechRecognized+=new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
        }

        void recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            rectimeout = 0;
        }

        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;
            if (speech == "Hello")
            {
                sen.SpeakAsync("Hello , I am here");
            }
            if (speech == "How are you")
            {
                sen.SpeakAsync("I am fine");
            }
            if (speech == "What time is it")
            {
                sen.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }
            if (speech == "Stop talking")
            {
                sen.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1,2);
                if (ranNum == 1)
                {
                    sen.SpeakAsync("Yes Mam");
                }
                if (ranNum == 2)
                {
                    sen.SpeakAsync("I am sorry I will be quiet");
                }
            }
            if (speech == "Stop listening")
            {
                sen.SpeakAsync("If you need me just ask");
                recognizer.RecognizeAsyncCancel();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                
            }
            if (speech == "Show commands")
            {
                string[] cmds = (File.ReadAllLines(@"TextFile1.txt"));
                listBox1.Items.Clear();
                listBox1.SelectionMode = SelectionMode.None;
                listBox1.Visible = true;
                foreach (string command in cmds)
                {
                    listBox1.Items.Add(command);
                }
            }
            if (speech == "Hide commands")
            {
                listBox1.Visible = false;
            }
            if (speech == "Open word")
            {
                Process.Start("winword");
            }
            if (speech == "Open excel")
            {
                Process.Start("excel");
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

        private void tmrspeaking_Tick(object sender, EventArgs e)
        {
            if (rectimeout == 10)
            {
                recognizer.RecognizeAsyncCancel();
            }
            else if (rectimeout == 11)
            {
                tmrspeaking.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                rectimeout = 0;
            }
        }
    }
}
