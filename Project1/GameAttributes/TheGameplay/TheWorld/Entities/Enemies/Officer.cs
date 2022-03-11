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
    public class Officer : TheEnemy
    {

        public TheTimer spawnTimer;

        public Officer(Vector2 POS, int OWNERID)
            : base("Officer", POS, new Vector2(30, 30), OWNERID)
        {
            speed = 1.0f;

            health = 3;
            healthMax = health;

            spawnTimer = new TheTimer(10000);
            spawnTimer.AddToTimer(3000);
        }
        
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnThePortal();
                spawnTimer.ResetToZero();

                
            }
            base.Update(OFFSET, ENEMY);
        }

        public virtual void SpawnThePortal()
        {
            GameGlobal.PassSpawnPoint(new OfficerSpawner(new Vector2(pos.X, pos.Y), ownerID));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
