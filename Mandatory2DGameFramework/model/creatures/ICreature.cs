using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.creatures
{
    public enum CreaturePlayer
    {
        Warrior,
        Mage,
        Warlock
    }
    public enum CreatureMonster
    {
        Dragon,
        Boar,
        Raptor
    }
    public interface ICreature
    {
        int Hit();
        void ReceiveHit(int hit);
        void Loot(WorldObject obj);
        void Move(bool? x, bool? y);
    }
}
