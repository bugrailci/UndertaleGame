using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Undertale {
    public class Hybat : Enemy {
        public Hybat(Game game, Point location, Size spriteSize)
            : base(game, location, 5, spriteSize) { }

        public override void Move(Random random) {
            if (random.Next(1, 3) == 1) {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            } else {
                location = Move((Direction)random.Next(1, 4), game.Boundaries);
            }
            if (NearPlayer()) {
                game.HitPlayer(1, random);
            }
        }
    }
}
