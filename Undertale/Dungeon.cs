using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Undertale {
    public partial class Dungeon : Form {
        private Game game;
        private Random random = new Random();
        

        public Dungeon() {
            InitializeComponent();
        }

        private void Dungeon_Load(object sender, EventArgs e) {
            game = new Game(new Rectangle(10, 179, 575, 80));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void SwordInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(SwordInvSprite, "Sword", "weapon");
        }

        private void RedPotionInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(RedPotionInvSprite, "Red Potion", "potion");
        }

        private void SoulfireInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(SoulfireInvSprite, "Soulfire", "weapon");
        }

        private void GreenPotionInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(GreenPotionInvSprite, " Green Potion", "potion");
        }

        private void PaintbrushInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(PaintbrushInvSprite, "Paintbrush", "weapon");
        }

        private void SelectInventoryItem(PictureBox itemSprite, string itemName, string weaponType) {
            if (game.CheckPlayerInventory(itemName)) {
                game.Equip(itemName);
                RemoveInventorySpriteBorders();
                itemSprite.BorderStyle = BorderStyle.FixedSingle;
                Soulfirerangebox.Location = PlayerSprite.Location;
                Soulfirerangebox.Visible = true;
                SetupAttackButtons(weaponType);
                if (itemName == "Sword")
                {
                    Soulfirerangebox.Height = 75;
                    Soulfirerangebox.Width = 75;
                }
                else if (itemName == "Soulfire")
                {
                    Soulfirerangebox.Height = 250;
                    Soulfirerangebox.Width = 250;
                }
                else if (itemName == " Green Potion")
                {
                    Soulfirerangebox.Visible = false;
                }
                else if (itemName == "Red Potion")
                {
                    Soulfirerangebox.Visible = false;
                }
                else if (itemName == "Paintbrush")
                {
                    Soulfirerangebox.Height = 125;
                    Soulfirerangebox.Width = 125;
                }
                Soulfirerangebox.Location = new Point((PlayerSprite.Location.X + ((PlayerSprite.Width / 2) - (Soulfirerangebox.Width / 2))), ((PlayerSprite.Location.Y + (PlayerSprite.Height / 2) - (Soulfirerangebox.Height / 2))));
            }
        }

        private void RemoveInventorySpriteBorders() {
            SwordInvSprite.BorderStyle = BorderStyle.None;
            RedPotionInvSprite.BorderStyle = BorderStyle.None;
            SoulfireInvSprite.BorderStyle = BorderStyle.None;
            GreenPotionInvSprite.BorderStyle = BorderStyle.None;
            PaintbrushInvSprite.BorderStyle = BorderStyle.None;
        }

        private void SetupAttackButtons(string weaponType) {
            switch (weaponType.ToLower()) {
                case "weapon":
                    AttackUp.Text = "Up";
                    AttackUp.Visible = true;
                    AttackRight.Visible = true;
                    AttackDown.Visible = true;
                    AttackLeft.Visible = true;
                    break;
                case "potion":
                    AttackUp.Text = "Drink";
                    AttackRight.Visible = false;
                    AttackDown.Visible = false;
                    AttackLeft.Visible = false;
                    break;
            }
        }

        private void MoveUp_Click(object sender, EventArgs e) {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void MoveRight_Click(object sender, EventArgs e) {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void MoveDown_Click(object sender, EventArgs e) {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void MoveLeft_Click(object sender, EventArgs e) {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void AttackUp_Click(object sender, EventArgs e) {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
            if(AttackUp.Text=="Drink")
            {
                SetupAttackButtons("weapon");
            }
        }

        private void AttackRight_Click(object sender, EventArgs e) {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void AttackDown_Click(object sender, EventArgs e) {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void AttackLeft_Click(object sender, EventArgs e) {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }
        
        public bool UpdateEnemySprite(Enemy enemy, PictureBox enemySprite, Label enemyHitPoints){
            bool enemySpriteUpdated = false;
            
            enemyHitPoints.Text = enemy.HitPoints.ToString();

            if (enemy.HitPoints > 0) {
                enemySprite.Location = enemy.Location;
                enemySprite.Visible = true;
                enemySpriteUpdated = true;
            } else {
                enemySprite.Visible = false;
            }

            return enemySpriteUpdated;
        }

        public void UpdateCharacters() {
            PlayerSprite.Location = game.PlayerLocation;
            PlayerHitPoints.Text = game.PlayerHitPoints.ToString();
            Soulfirerangebox.Location = new Point((PlayerSprite.Location.X + ((PlayerSprite.Width / 2) - (Soulfirerangebox.Width / 2))), ((PlayerSprite.Location.Y + (PlayerSprite.Height / 2) - (Soulfirerangebox.Height / 2))));
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies) {
                if (enemy is Hybat) {
                    if (UpdateEnemySprite(enemy, HybatSprite, HybatHitPoints)) {
                        enemiesShown++;
                    }
                }
                if(enemy is Floweyface){
                    if (UpdateEnemySprite(enemy, FloweyfaceSprite, FloweyfaceHitPoints)) {
                        enemiesShown++;
                    }
                }
                if (enemy is Error) {
                    if (UpdateEnemySprite(enemy, ErrorSprite, ErrorHitPoints)) {
                        enemiesShown++;
                    }
                }
            }

            SwordSprite.Visible = false;
            SoulfireSprite.Visible = false;
            PaintbrushSprite.Visible = false;
            RedPotionSprite.Visible = false;
            GreenPotionSprite.Visible = false;

            if (game.WeaponInRoom != null) {
                Control weaponControl = null;
                switch (game.WeaponInRoom.Name) {
                    case "Sword":
                        weaponControl = SwordSprite;
                        break;
                    case "Soulfire":
                        weaponControl = SoulfireSprite;
                        break;
                    case "Paintbrush":
                        weaponControl = PaintbrushSprite;
                        break;
                    case "Red Potion":
                        weaponControl = RedPotionSprite;
                        break;
                    case " Green Potion":
                        weaponControl = GreenPotionSprite;
                        break;
                }

                if (game.WeaponInRoom.PickedUp) {
                    weaponControl.Visible = false;
                } else {
                    weaponControl.Visible = true;
                    weaponControl.Location = game.WeaponInRoom.Location;
                }
            }
            SwordInvSprite.Visible = false;
            SoulfireInvSprite.Visible = false;
            PaintbrushInvSprite.Visible = false;
            RedPotionInvSprite.Visible = false;
            GreenPotionInvSprite.Visible = false;

            if (game.CheckPlayerInventory("Sword")) {
                SwordInvSprite.Visible = true;
            }

            if (game.CheckPlayerInventory("Soulfire")) {
                SoulfireInvSprite.Visible = true;
            }

            if (game.CheckPlayerInventory("Paintbrush")) {
                PaintbrushInvSprite.Visible = true;
            }

            if (game.CheckPlayerInventory("Red Potion")) {
                if (!game.CheckPotionUsed("Red Potion")) {
                    RedPotionInvSprite.Visible = true;
                }
            }

            if (game.CheckPlayerInventory(" Green Potion")) {
                if (!game.CheckPotionUsed(" Green Potion")) {
                    GreenPotionInvSprite.Visible = true;
                }
            }

            if (game.PlayerHitPoints <= 0) {
                MessageBox.Show("WASTED");
                MessageBox.Show("Game over");
                Application.Exit();
            }

            if (enemiesShown < 1) {
                if(game.level<8  && game.level>0)
                {
                    MessageBox.Show("Congrats, LEVEL CLEAR");
                }
                else if(game.level==-1)
                {
                    MessageBox.Show("Congrats, You WON the UNDERTALE");
                }                           
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void Dungeon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                game.Move(Direction.Up, random);
                UpdateCharacters();

            }
            else if (e.KeyCode == Keys.A)
            {
                game.Move(Direction.Left, random);
                UpdateCharacters();

            }
            else if (e.KeyCode == Keys.D)
            {
                game.Move(Direction.Right, random);
                UpdateCharacters();

            }
            else if (e.KeyCode == Keys.S)
            {
                game.Move(Direction.Down, random);
                UpdateCharacters();
            }
            else if (e.KeyCode == Keys.I)
            {
                game.Attack(Direction.Up, random);
                UpdateCharacters();

            }
            else if (e.KeyCode == Keys.J)
            {
                game.Attack(Direction.Left, random);
                UpdateCharacters();

            }
            else if (e.KeyCode == Keys.L)
            {
                game.Attack(Direction.Right, random);
                UpdateCharacters();

            }
            else if (e.KeyCode == Keys.K)
            {
                game.Attack(Direction.Down, random);
                UpdateCharacters();

            }
        }
    }
}
