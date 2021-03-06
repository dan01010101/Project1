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
    public class QuantityDisplay
    {
        public int boarder;

        public Images bar, barBKG;

        public Color color;

        public QuantityDisplay(Vector2 DIMS, int BOARDER, Color COLOR)
        {
            boarder = BOARDER;
            color = COLOR;

            bar = new Images("solid", new Vector2(0, 0), new Vector2(DIMS.X - boarder * 2, DIMS.Y - boarder * 2));
            barBKG = new Images("shade", new Vector2(0, 0), new Vector2(DIMS.X, DIMS.Y));
        }

        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT / MAX * (barBKG.dims.X - boarder * 2), bar.dims.Y);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            barBKG.Draw(OFFSET, new Vector2(0, 0), Color.Black);
            bar.Draw(OFFSET + new Vector2(boarder, boarder), new Vector2(0, 0), color);
        }
    }
}
