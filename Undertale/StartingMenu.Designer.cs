namespace Undertale
{
    partial class StartingMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingMenu));
            this.Infotext = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.texttimer = new System.Windows.Forms.Timer(this.components);
            this.textlabel = new System.Windows.Forms.Label();
            this.exitbox = new System.Windows.Forms.PictureBox();
            this.startbutton = new System.Windows.Forms.Button();
            this.Undertalepicbox = new System.Windows.Forms.PictureBox();
            this.Backgroundbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Undertalepicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Backgroundbox)).BeginInit();
            this.SuspendLayout();
            // 
            // Infotext
            // 
            this.Infotext.AutoSize = true;
            this.Infotext.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Infotext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Infotext.Location = new System.Drawing.Point(719, 479);
            this.Infotext.Name = "Infotext";
            this.Infotext.Size = new System.Drawing.Size(113, 17);
            this.Infotext.TabIndex = 2;
            this.Infotext.Text = "By Bugra Ilci";
            // 
            // timer
            // 
            this.timer.Interval = 7000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // texttimer
            // 
            this.texttimer.Interval = 5200;
            this.texttimer.Tick += new System.EventHandler(this.texttimer_Tick);
            // 
            // textlabel
            // 
            this.textlabel.AllowDrop = true;
            this.textlabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textlabel.Location = new System.Drawing.Point(654, 103);
            this.textlabel.Name = "textlabel";
            this.textlabel.Size = new System.Drawing.Size(173, 229);
            this.textlabel.TabIndex = 3;
            this.textlabel.Text = "Loading the game...";
            // 
            // exitbox
            // 
            this.exitbox.BackgroundImage = global::Undertale.Properties.Resources.exitico;
            this.exitbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitbox.Location = new System.Drawing.Point(823, 3);
            this.exitbox.Name = "exitbox";
            this.exitbox.Size = new System.Drawing.Size(22, 21);
            this.exitbox.TabIndex = 5;
            this.exitbox.TabStop = false;
            this.exitbox.Click += new System.EventHandler(this.exitbox_Click);
            // 
            // startbutton
            // 
            this.startbutton.BackColor = System.Drawing.Color.Transparent;
            this.startbutton.BackgroundImage = global::Undertale.Properties.Resources.startpng;
            this.startbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startbutton.Location = new System.Drawing.Point(666, 346);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(149, 47);
            this.startbutton.TabIndex = 4;
            this.startbutton.UseVisualStyleBackColor = false;
            this.startbutton.Visible = false;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // Undertalepicbox
            // 
            this.Undertalepicbox.BackColor = System.Drawing.Color.Transparent;
            this.Undertalepicbox.BackgroundImage = global::Undertale.Properties.Resources.underlogo;
            this.Undertalepicbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Undertalepicbox.Location = new System.Drawing.Point(657, 30);
            this.Undertalepicbox.Name = "Undertalepicbox";
            this.Undertalepicbox.Size = new System.Drawing.Size(172, 50);
            this.Undertalepicbox.TabIndex = 0;
            this.Undertalepicbox.TabStop = false;
            // 
            // Backgroundbox
            // 
            this.Backgroundbox.BackColor = System.Drawing.Color.Transparent;
            this.Backgroundbox.Image = ((System.Drawing.Image)(resources.GetObject("Backgroundbox.Image")));
            this.Backgroundbox.ImageLocation = "";
            this.Backgroundbox.Location = new System.Drawing.Point(-2, 3);
            this.Backgroundbox.Name = "Backgroundbox";
            this.Backgroundbox.Size = new System.Drawing.Size(643, 499);
            this.Backgroundbox.TabIndex = 1;
            this.Backgroundbox.TabStop = false;
            // 
            // StartingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(844, 505);
            this.Controls.Add(this.exitbox);
            this.Controls.Add(this.startbutton);
            this.Controls.Add(this.textlabel);
            this.Controls.Add(this.Infotext);
            this.Controls.Add(this.Undertalepicbox);
            this.Controls.Add(this.Backgroundbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartingMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Undertale";
            ((System.ComponentModel.ISupportInitialize)(this.exitbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Undertalepicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Backgroundbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Undertalepicbox;
        private System.Windows.Forms.PictureBox Backgroundbox;
        private System.Windows.Forms.Label Infotext;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer texttimer;
        private System.Windows.Forms.Label textlabel;
        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.PictureBox exitbox;
    }
}