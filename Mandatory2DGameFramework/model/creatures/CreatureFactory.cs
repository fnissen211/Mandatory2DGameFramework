using Mandatory2DGameFramework.model.attack;
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
    //TODO: XML Documentation
    public static class CreatureFactory
    {
        /// <summary>
        /// Static method for creating a player creature
        /// </summary>
        /// <param name="type">What type of class the player is</param>
        /// <param name="name">The name of the player</param>
        /// <returns>A new CreaturePlayer object</returns>
        /// <exception cref="ArgumentException"></exception>
        public static ICreature CreateCreaturePlayer(CreaturePlayer type, string name)
        {
            switch (type)
            {
                case CreaturePlayer.Warrior:
                    return new Warrior(name);
                case CreaturePlayer.Mage:
                    return new Mage(name);
                case CreaturePlayer.Warlock:
                    return new Warlock(name);
                default:
                    throw new ArgumentException("Invalid creature type or missing monster type");
            }
        }

        /// <summary>
        /// Static method for creating a monster creature
        /// </summary>
        /// <param name="type">What type of monster needs to be created</param>
        /// <returns>A CreatureMonster objects</returns>
        /// <exception cref="ArgumentException"></exception>
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
