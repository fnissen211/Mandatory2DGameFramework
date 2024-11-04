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
    //TODO: XML Documentation
    public abstract class PlayerCreature : Creature
    {
        public abstract AttackItem? Attack { get; set; }
        public abstract DefenceItem? Defence { get; set; }

        private static Random random = new Random();


        public PlayerCreature(string name) : base(name, 100)
        {
            X = random.Next(0, 100);
            Y = random.Next(0, 100);
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
