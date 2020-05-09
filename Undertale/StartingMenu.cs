using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace Undertale
{
    public partial class StartingMenu : Form
    {
        SoundPlayer music = new SoundPlayer(Undertale.Properties.Resources.maintheme);
        private int counter=1;
        private int textcounter = 0;


        public StartingMenu()
        {
            InitializeComponent();
            music.PlayLooping();
            timer.Enabled = true;
            texttimer.Enabled = true;
        }
        private void Backgroundchanger()
        {
            if (counter == 0)
            { Backgroundbox.Image = Undertale.Properties.Resources.main1;
                textlabel.ForeColor = Color.Red;
                Infotext.ForeColor = Color.Red;
                startbutton.BackgroundImage = Undertale.Properties.Resources.startpng;
                startbutton.BackgroundImageLayout = ImageLayout.Stretch;
                exitbox.BackgroundImage = Undertale.Properties.Resources.exitico;
                exitbox.BackgroundImageLayout = ImageLayout.Stretch;
                counter =1;
            }
            else
            { Backgroundbox.Image = Undertale.Properties.Resources.main2;
                textlabel.ForeColor = Color.Blue;
                Infotext.ForeColor = Color.Blue;
                startbutton.BackgroundImage = Undertale.Properties.Resources.startbuttonblue;
                startbutton.BackgroundImageLayout = ImageLayout.Stretch;
                exitbox.BackgroundImage = Undertale.Properties.Resources.exiticoblue;
                exitbox.BackgroundImageLayout = ImageLayout.Stretch;
                counter =0;
            }
        }
        private void Textchanger()
        {
            IList<string> textlist = new List<string>();
            textlist.Add("The undertale is a pretty simple game. \nAll you have to do is overcome each level.");
            textlist.Add("There are 3 types of enemies:\n\n Floweyface \n Hybat \n and Error");
            textlist.Add("You have to beat them and proceed through the dungeon.");
            textlist.Add("You can move your character with W,A,S,D and attack with  I,J,K,L");
            textlist.Add("Have fun and survive...");

            textlabel.Text = textlist[textcounter];
            textcounter++;
            if (textcounter >= 5) {startbutton.Visible = true; textcounter = 0;}

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Backgroundchanger();
        }

        private void texttimer_Tick(object sender, EventArgs e)
        {
            Textchanger();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            Dungeon letsgo = new Dungeon();
            letsgo.Show();
            
        }

        private void exitbox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
