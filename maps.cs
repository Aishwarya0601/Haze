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
   
    public partial class maps : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer sen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        public maps()
        {
            InitializeComponent();
        }
        int flag = 0;
        private void maps_Load(object sender, EventArgs e)
        {
            sen.SpeakAsync(Program.username+"click any place in this tamil nadu map and i will give you some information");
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"maps.txt")))));
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
            if (speech == "back")
            {
                home f2 = new home();
                f2.Show();
                this.Hide();
                sen.SpeakAsyncCancelAll();
                recognizer.RecognizeAsyncCancel();
            }
            
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        int j, l;
        string[] files1;
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "DINDIGUL";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\dindigul");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Dindigul, city, central Tamil Nadustate, southern India. It is situated between the Palni and Sirumalai hills on a tributary of the Cauvery River");
            pictureBox8.BorderStyle = BorderStyle.None;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "KANYAKUMARI";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\kanyakumari");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Located at the southernmost tip of the Indian peninsula, Kanyakumari is a coastal town in the state of Tamil Nadu. Earlier known as Cape Comorin, Kanyakumari is surrounded by mountains and bordered by vibrant sea shoresEver since ancient times, Kanyakumari has been one of the major centres of religion, art and culture. ");
            pictureBox1.BorderStyle = BorderStyle.None;       
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "COIMBATORE";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\coimbatore");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("The third largest city of the state Coimbatore is one of the most industrialised cities in tamilnadu, known as the textile capital of South India or the Manchester of South.The city is located on the banks of the river Noyyal");
            pictureBox10.BorderStyle = BorderStyle.None;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "MADURAI";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\madurai");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Madurai, formerly (until 1949) Madura, city, south-central Tamil Nadu state, southern India. It is located on the Vaigai River, about 30 miles (48 km) southeast of Dindigul. Madurai is the third most populous, and probably the oldest, city in the state.The ancient history of the region is associated with the Pandya kings, and Madurai was the site of the Pandya capital ");
            pictureBox9.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "TRICHY";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\trichy");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Trichy, situated on the banks of the river Cauvery is the fourth largest city in Tamil Nadu. It was a citadel of the early Cholas which later fell to the Pallavas. Trichy is a fine blend of tradition and modernity built around the Rock Fort.");
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "TANJORE";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\tanjore");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Tanjore is a city in the Indian state of Tamil Nadu. Thanjavur is an important center of South Indian religion, art, and architecture. ");
            pictureBox6.BorderStyle = BorderStyle.None;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "SALEM";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\salem");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Salem is a Geologist’s paradise,surrounded by hills and the landscape dotted with hillocks.Salem has a vibrant culture dating back to the ancient Kongu Nadu. As a district, Salem has its significance in various aspects. ");
            pictureBox4.BorderStyle = BorderStyle.None;
        }


        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            flag = 1;
            label12.Text = "CHENNAI";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\chennai");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Chennai, formerly Madras, city, capital of Tamil Nadu state, southern India, on the Coromandel Coast of the Bay of Bengal. Known as the “Gateway to South India,” Chennai is a major administrative and cultural centre.");
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pictureBox7.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "ERODE";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\erode");
            l = files1.Length;
            j = 0;
            //pictureBox13.Image=Image.FromFile("C:/Users/AISHWARYA/Documents/Visual Studio 2010/Projects/WindowsFormsApplication2/Images/i4.jpg");
            //pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            sen.SpeakAsync("Erode District was a part of Coimbatore has its history intervened with that of Coimbatore and because of its close linkage with the erstwhile Coimbatore district. It is very difficult to separately deal with the history of Erode region.   ");
            pictureBox7.BorderStyle = BorderStyle.None;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.BorderStyle = BorderStyle.Fixed3D;
            label12.Text = "VELLORE";
            timer1.Enabled = true;
            files1 = Directory.GetFiles(@"C:\Users\AISHWARYA\Downloads\vellore");
            l = files1.Length;
            j = 0;
            sen.SpeakAsync("Vellore is a historical city.the history of the city assumes a great significance and relevance, as we unfold the glorious past.The Monuments found in the city give a vivid picture of the town through the ages");
            pictureBox5.BorderStyle = BorderStyle.None;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (j==l)
            {
                timer1.Enabled = false;
            }
            if (j < l)
            {
                pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox12.Image = Image.FromFile(files1[j]);
                j = j + 1;
            }
        }
    }
}
