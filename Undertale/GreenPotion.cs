using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Undertale {
    public class GreenPotion : Weapon, IPotion {
        public GreenPotion(Game game, Point location)
            : base(game, location) { Used = false; }

        public bool Used { get; private set; }

        public override string Name { get { return " Green Potion"; } }
        public override void Attack(Direction direction, Random random) {
            if(!Used)
            {
                game.IncreasePlayerHealth(30, random);
                Used = true;
            }
        }
    }
}
