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
    public class TheSpawner : Portal
    {

        public TheSpawner(Vector2 POS, int OWNERID)
            : base("ThePortal", POS, new Vector2(45, 45), OWNERID)
        {

        }

        public override void Update(Vector2 OFFSET)
        {


            base.Update(OFFSET);
        }


        public override void SpawnEnemy()
        {
            int num = Globals.rand.Next(0, 10 + 1);

            TheEnemy tempEnemy = null;

            if(num < 5)
            {
                tempEnemy = new Zombie(new Vector2(pos.X, pos.Y), ownerID);
            }
            else if(num < 6)
            {
                tempEnemy = new Officer(new Vector2(pos.X, pos.Y), ownerID);
            }


            if (tempEnemy != null)
            {
                GameGlobal.PassEnemy(tempEnemy);
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
