namespace SpeechRecognition_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LstCommands1 = new System.Windows.Forms.ListBox();
            this.TmrSpeaking1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LstCommands1
            // 
            this.LstCommands1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.LstCommands1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstCommands1.ForeColor = System.Drawing.SystemColors.Window;
            this.LstCommands1.FormattingEnabled = true;
            this.LstCommands1.ItemHeight = 16;
            this.LstCommands1.Location = new System.Drawing.Point(0, 0);
            this.LstCommands1.Name = "LstCommands1";
            this.LstCommands1.Size = new System.Drawing.Size(535, 424);
            this.LstCommands1.TabIndex = 0;
            this.LstCommands1.Visible = false;
            this.LstCommands1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // TmrSpeaking1
            // 
            this.TmrSpeaking1.Enabled = true;
            this.TmrSpeaking1.Interval = 1000;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(535, 424);
            this.Controls.Add(this.LstCommands1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstCommands;
        private System.Windows.Forms.Timer TmrSpeaking;
        private System.Windows.Forms.ListBox LstCommands1;
        private System.Windows.Forms.Timer TmrSpeaking1;
    }
}

