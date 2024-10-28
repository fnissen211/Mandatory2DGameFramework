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
    public class Warrior : PlayerCreature
    {
        public Warrior(string name) : base(name)
        {
        }

        public override int Hit()
        {
            throw new NotImplementedException();
        }
    }
}
