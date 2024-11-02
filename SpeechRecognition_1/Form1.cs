using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace SpeechRecognition_1
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Alyzen = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int RecTimeOut = 0;
        DateTime TimeNow = DateTime.Now;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            startlistening.SetInputToDefaultAudioDevice();
            Choices choices = new Choices(File.ReadAllLines(@"DefaultCommands.txt"));

            GrammarBuilder grammarBuilder = new GrammarBuilder(choices);

            Grammar grammar = new Grammar(grammarBuilder);

            startlistening.LoadGrammarAsync(grammar);
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);


        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;

            if (speech == "Hello")
            {
                Alyzen.SpeakAsync("Hello, I am here");
            }
            if (speech == "How are you")
            {
                Alyzen.SpeakAsync("I am working normally");
            }
            if (speech == "What time is it")
            {
                Alyzen.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }
            if (speech == "Stop talking")
            {
                Alyzen.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1, 2);
                if (ranNum == 1)
                {
                    Alyzen.SpeakAsync("Yes sir");
                }
                if (ranNum == 2)
                {
                    Alyzen.SpeakAsync("I am sorry i will be quiet");
                }
            }
            if (speech == "Stop Listening")
            {
                Alyzen.SpeakAsync("if you need me just ask");
                _recognizer.RecognizeAsyncCancel();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);

            }
            if (speech == "Show Commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));
                LstCommands1.Items.Clear();
                LstCommands1.SelectionMode = SelectionMode.None;
                LstCommands1.Visible = true;
                foreach (string command in commands)
                {
                    LstCommands1.Items.Add(command);
                }
            }
            if (speech == "Hide Commands")
            {
                LstCommands1.Visible = false;
            }
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        private void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Wake up")
            {
                startlistening.RecognizeAsyncCancel();
                Alyzen.SpeakAsync("Yes, I am here");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void TmrSpeaking1_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();

            }
            else if (RecTimeOut == 11)
            {
                TmrSpeaking1.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}