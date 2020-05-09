using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Undertale {
    public class Paintbrush : Weapon {
        public Paintbrush(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Paintbrush"; } }
        public override void Attack(Direction direction, Random random) {
            if (!DamageEnemy(direction, 20, 6, random)) {
                Direction nextAttackDirection = CounterClockWiseDirection(direction);
                for (int i = 0; i < 3; i++) {
                    if (DamageEnemy(nextAttackDirection, 50, 6, random)) {
                        break;
                    }
                    nextAttackDirection = CounterClockWiseDirection(direction);
                }
            }
        }
    }
}
