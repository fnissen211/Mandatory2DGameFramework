using Mandatory2DGameFramework.model.creatures.monster;
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
        public static ICreature CreateCreaturePlayer(CreaturePlayer type)
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

        public static ICreature CreateCreatureMonster(CreatureMonster type)
        {
            switch (type)
            {
                case CreatureMonster.Dragon:
                    return new Dragon();
                case CreatureMonster.Boar:
                    return new Boar();
                case CreatureMonster.Raptor:
                    return new Raptor();
                default:
                    throw new ArgumentException("Invalid creature type or missing monster type");
            }
        }
    }
}
