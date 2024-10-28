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
    public abstract class PlayerCreature : Creature
    {
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }

        public PlayerCreature(string name) : base(name, 100)
        {
            Attack = null;
            Defence = null;
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
