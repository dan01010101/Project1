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
using System.Collections.Generic;

namespace Nightmare
{
    public class Player
    {
        public int id;
        public Soldier soldier;
        public List<Unit> units = new List<Unit>();
        public List<Portal> spawnPoints = new List<Portal>();

        public Player(int ID)
        {
            id = ID;
        }

        public virtual void Update(Player ENEMY, Vector2 OFFSET)
        {
            if (soldier != null)
            {
                soldier.Update(OFFSET);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(OFFSET);

                if(spawnPoints[i].dead)
                {
                    spawnPoints.RemoveAt(i);
                    i--;
                }

            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY);

                if (units[i].dead)
                {
                    ChangeScore(1);
                    units.RemoveAt(i);
                    i--;
                }

            }
        }

        public virtual void AddUnit(object INFO)
        {
            Unit tempUnit = (Unit)INFO;
            tempUnit.ownerID = id;
            units.Add(tempUnit);
        }

        public virtual void AddSpawnPoint(object INFO)
        {
            Portal tempSpawnPoint = (Portal)INFO;
            tempSpawnPoint.ownerID = id;
            spawnPoints.Add(tempSpawnPoint);
        }

        public virtual void ChangeScore(int SCORE)
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {

            if (soldier != null)
            {
                soldier.Draw(OFFSET);
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Draw(OFFSET);

            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(OFFSET);

            }


        }
    }
}

