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
    public abstract class MonsterCreature : Creature
    {

        private static Random random = new Random();

        public MonsterCreature(string name, int hitPoint) : base(name, hitPoint)
        {
            X = random.Next(0, 100);
            Y = random.Next(0, 100);
        }

        /// <summary>
        /// An abstract method that will be implemented in the subclasses, for determining the hit points of the creature
        /// </summary>
        /// <returns>
        /// Returns the hit value
        /// </returns>
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

