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
    public partial class name : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        public name()
        {
            InitializeComponent();
            textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
        }

        private void name_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            sen.SpeakAsync("Please enter your name..");
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFile2.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            //timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.username = textBox1.Text;
            sen.SpeakAsync("Hello" + Program.username);
            sen.SpeakAsync("hope you have a good day");


        }
        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //int ranNum;
            string speech = e.Result.Text;
            if (speech == "next")
            {
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
                home h1 = new home();
                h1.Show();
                this.Hide();
            }
            
        }

    }
}
