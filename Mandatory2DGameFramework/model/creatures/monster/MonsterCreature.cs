using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.creatures.player
{
    public abstract class MonsterCreature : Creature
    {
        public MonsterCreature(string name, int hitPoint) : base(name, hitPoint)
        {
        }

        public MonsterCreature() : this(string.Empty, 100)
        {
        }

        public abstract override int Hit();

        public override void Loot(WorldObject obj)
        {
            throw new NotImplementedException();
        }

        public override void ReceiveHit(int hit)
        {
            HitPoint -= hit;
        }
    }
}

