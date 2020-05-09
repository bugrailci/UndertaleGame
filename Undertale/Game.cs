using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Undertale {
    public class Game {
        public List<Enemy> Enemies;
        public Weapon WeaponInRoom;

        public Player player;
        public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public Size PlayerSpriteSize { get { return player.SpriteSize; } }
        public List<string> PlayerWeapons { get { return player.Weapons; } }

        public int level = 0;
        public int Level { get { return level; } }

        public Rectangle boundaries;
        public Rectangle Boundaries { get { return boundaries; } }

        public Game(Rectangle boundaries) {
            this.boundaries = boundaries;
            player = new Player(this,
                new Point(boundaries.Left + 10, boundaries.Top + 70),
                new Size(30, 30));
        }

        public void Move(Direction direction, Random random){
            player.Move(direction);
            foreach (Enemy enemy in Enemies) {
                enemy.Move(random);
            }
        }

        public void Equip(string weaponName) {
            player.Equip(weaponName);
        }

        public bool CheckPlayerInventory(string weaponName) {
            return player.Weapons.Contains(weaponName);
        }

        public bool CheckPotionUsed(string potionName) {
            return player.CheckPotionUsed(potionName);
        }

        public void HitPlayer(int maxDamage, Random random) {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random) {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Direction direction, Random random) {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies) {
                if (!enemy.Dead) {
                    enemy.Move(random);
                }
            }
        }

        public Point GetRandomLocation(Random random) 
        {
            int randomi = random.Next(300, 550);
            return new Point(
                boundaries.Left
                    + (randomi / 10) * 10,
                boundaries.Top
                    + random.Next(boundaries.Bottom / 10 - boundaries.Top / 10)
                    * 10) ;
        }
        public Point GetRandomLocationForWeapon(Random random)
        {
            int randomi = random.Next(10, 300);
            return new Point(
                boundaries.Left
                    + (randomi / 10) * 10,
                boundaries.Top
                    + random.Next(boundaries.Bottom / 10 - boundaries.Top / 10)
                    * 10);
        }

        public void NewLevel(Random random) {
            level++;
            switch (level) {
                case 0:
                    Application.Exit();
                    break;
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Floweyface(this, GetRandomLocation(random), new Size(60, 50)));
                    WeaponInRoom = new Sword(this, GetRandomLocationForWeapon(random));
                    break;
                case 2:
                    Enemies.Clear();
                    Enemies.Add(new Hybat(this, GetRandomLocation(random), new Size(50, 50)));
                    WeaponInRoom = new GreenPotion(this, GetRandomLocationForWeapon(random));
                    break;
                case 3:
                    Enemies.Clear();
                    Enemies.Add(new Error(this, GetRandomLocation(random), new Size(60, 50)));
                    WeaponInRoom = new Soulfire(this, GetRandomLocationForWeapon(random));
                    break;
                case 4:
                    Enemies.Clear();
                    Enemies.Add(new Hybat(this, GetRandomLocation(random), new Size(50, 50)));
                    Enemies.Add(new Floweyface(this, GetRandomLocation(random), new Size(60, 50)));
                    WeaponInRoom = null;
                    if (CheckPlayerInventory("Soulfire")) {
                        if (!CheckPlayerInventory(" Green Potion") 
                                || (CheckPlayerInventory(" Green Potion") 
                                    && CheckPotionUsed(" Green Potion"))) {
                            WeaponInRoom = new GreenPotion(this, GetRandomLocationForWeapon(random));
                        }
                    } else {
                        WeaponInRoom = new Soulfire(this, GetRandomLocationForWeapon(random));
                    }
                    break;
                case 5:
                    Enemies.Clear();
                    Enemies.Add(new Floweyface(this, GetRandomLocation(random), new Size(60, 50)));
                    Enemies.Add(new Error(this, GetRandomLocation(random), new Size(60, 60)));
                    WeaponInRoom = new RedPotion(this, GetRandomLocationForWeapon(random));
                    break;
                case 6:
                    Enemies.Clear();
                    Enemies.Add(new Hybat(this, GetRandomLocation(random), new Size(50, 50)));
                    Enemies.Add(new Error(this, GetRandomLocation(random), new Size(60, 60)));
                    WeaponInRoom = new Paintbrush(this, GetRandomLocationForWeapon(random));
                    break;
                case 7:
                    Enemies.Clear();
                    Enemies.Add(new Hybat(this, GetRandomLocation(random), new Size(50, 50)));
                    Enemies.Add(new Floweyface(this, GetRandomLocation(random), new Size(60, 50)));
                    Enemies.Add(new Error(this, GetRandomLocation(random), new Size(60, 50)));
                    WeaponInRoom = null;
                    if (CheckPlayerInventory("Paintbrush")) {
                        if (!CheckPlayerInventory("Red Potion")
                                || (CheckPlayerInventory("Red Potion")
                                    && CheckPotionUsed("Red Potion"))) {
                            WeaponInRoom = new RedPotion(this, GetRandomLocationForWeapon(random));
                        }
                    } else {
                        WeaponInRoom = new Paintbrush(this, GetRandomLocationForWeapon(random));
                    }
                    level = -1;
                    break;
            }
        }
    }
}
