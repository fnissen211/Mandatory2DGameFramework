using Mandatory2DGameFramework.model.creatures.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mandatory2DGameFramework.model.creatures
{
    public static class CreatureFactory
    {
        public static ICreature CreateCreature(CreaturePlayer type, CreatureMonster? creatureMonster = null)
        {
            switch (type)
            {
                case CreaturePlayer.Warrior:
                    return new Warrior(); // Assuming you have a Warrior class that implements ICreature
                case CreaturePlayer.Mage:
                    return new Mage(); // Assuming you have a Mage class that implements ICreature
                case CreaturePlayer.Warlock:
                    return new Warlock();
                default:
                    throw new ArgumentException("Invalid creature type or missing monster type");
            }
        }
    }
}
