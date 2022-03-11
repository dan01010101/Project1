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
    public class UI
    {

        public SpriteFont font;

        public QuantityDisplay healthBar;

        public UI()
        {
            font = Globals.content.Load<SpriteFont>("TheFont");

            healthBar = new QuantityDisplay(new Vector2(104, 16), 2, Color.Red);
        }

        public void Update(TheWorld WORLD)
        {
            healthBar.Update(WORLD.user.soldier.health, WORLD.user.soldier.healthMax);
        }

        public void Draw(TheWorld WORLD)
        {
            string tempStr = "Kills = " + GameGlobal.score;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight - 40), Color.Black);

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));


            if (WORLD.user.soldier.dead)
            {
                tempStr = "Press Enter to Restart!";
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight / 2), Color.Black);
            }
        }
    }
}
