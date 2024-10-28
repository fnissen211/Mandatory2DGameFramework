using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.creatures
{
    public abstract class Creature : ICreature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }

        protected Creature(string name, int hitPoint)
        {
            Name = name;
            HitPoint = hitPoint;
        }

        public abstract int Hit();

        public virtual void Loot(WorldObject obj)
        {
            //TODO: Implement loot system
        }

        public virtual void ReceiveHit(int hit)
        {
            HitPoint -= hit;
            if (HitPoint < 0)
            {
                HitPoint = 0;
            }
        }
    }
}
