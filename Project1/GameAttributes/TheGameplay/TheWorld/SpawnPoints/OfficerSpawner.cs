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
    public class OfficerSpawner : Portal
    {
        int maxSpawn, totalSpawns;

        public OfficerSpawner(Vector2 POS, int OWNERID)
            : base("Spawner", POS, new Vector2(40, 40), OWNERID)
        {
            totalSpawns = 0;
            maxSpawn = 2;
        }

        public override void Update(Vector2 OFFSET)
        {


            base.Update(OFFSET);
        }


        public override void SpawnEnemy()
        {
            TheEnemy tempEnemy = new Spider(new Vector2(pos.X, pos.Y), ownerID);

            if (tempEnemy != null)
            {
                GameGlobal.PassEnemy(tempEnemy);

                totalSpawns++;
                if (totalSpawns >= maxSpawn)
                {
                    dead = true;
                }
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
