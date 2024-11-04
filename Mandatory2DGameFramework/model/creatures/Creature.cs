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
    /// <summary>
    /// Superclass for creating creatures
    /// </summary>
    public abstract class Creature : ICreature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        protected Creature(string name, int hitPoint)
        {
            Name = name;
            HitPoint = hitPoint;
        }

        /// <summary>
        /// An abstract method that will be implemented in the subclasses, for determining the hit points of the creature
        /// </summary>
        /// <returns>Returns the hit value</returns>
        public abstract int Hit();

        /// <summary>
        /// Loot method that will be implemented in the subclasses, for looting the world object
        /// </summary>
        /// <param name="obj">A worldobject</param>
        public virtual void Loot(WorldObject obj)
        {
            
        }

        /// <summary>
        /// A method that will be implemented in the subclasses, for receiving a hit from another creature
        /// </summary>
        /// <param name="hit">The hitpoint value that the creature will recieve</param>
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
