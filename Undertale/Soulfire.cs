using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Undertale {
    public class Soulfire : Weapon {
        public Soulfire(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Soulfire"; } }
        public override void Attack(Direction direction, Random random) {
            DamageEnemy(direction, 100, 1, random);
        }
    }
}
