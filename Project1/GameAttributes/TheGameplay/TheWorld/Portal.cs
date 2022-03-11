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
    public class Portal : AttackableObject
    {

        public TheTimer spawnTimer = new TheTimer(2200);

        public Portal(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID)
            : base(PATH, POS, DIMS, OWNERID)
        {
            dead = false;

            health = 3;
            healthMax = health;

            hitDist = 35.0f;
        }

        public override void Update(Vector2 OFFSET)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnEnemy();
                spawnTimer.ResetToZero();
            }

            base.Update(OFFSET);
        }


        public virtual void SpawnEnemy()
        {
            GameGlobal.PassEnemy(new Zombie(new Vector2(pos.X, pos.Y), ownerID));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
