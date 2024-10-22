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
    public abstract class PlayerCreature : ICreature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }

        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }

        public PlayerCreature()
        {
            Name = string.Empty;
            HitPoint = 100;
            Attack = null;
            Defence = null;
        }

        public abstract int Hit();

        public virtual void Loot(WorldObject obj)
        {
            throw new NotImplementedException();
        }

        public virtual void ReceiveHit(int hit)
        {
            HitPoint -= hit;
        }
    }
}
