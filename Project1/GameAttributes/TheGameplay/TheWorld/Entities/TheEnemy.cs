using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Nightmare
{
    public class TheEnemy : Unit
    {

        public TheEnemy(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID)
            : base(PATH, POS, DIMS, OWNERID)
        {
            speed = 2.0f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            AI(ENEMY.soldier);

            base.Update(OFFSET);
        }


        public virtual void AI(Soldier SOLDIER)
        {
            pos += Globals.RadialMovement(SOLDIER.pos, pos, speed);
            rot = Globals.RotateTowards(pos, SOLDIER.pos);


            if (Globals.GetDistance(pos, SOLDIER.pos) < 15)
            {
                SOLDIER.GetHit(1);
                dead = true;
            }
        }



        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
