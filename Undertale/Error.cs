using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Undertale {
    public class Error : Enemy, ISprite {
        public Error(Game game, Point location, Size spriteSize)
            : base(game, location, 20, spriteSize) { }

        public override void Move(Random random) {
            if (random.Next(1, 5) != 1) {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }

            if (NearPlayer()) {
                game.HitPlayer(5, random);
            }
        }
    }
}
