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
    public class Warrior : PlayerCreature
    {
        public override AttackItem? Attack { get; set; }
        public override DefenceItem? Defence { get; set; }

        public Warrior(string name) : base(name)
        {
        }

        public override int Hit()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Warrior Name: {Name}, HitPoints: {HitPoint}, Attack: {Attack?.Name ?? "None"}, Defence: {Defence?.Name ?? "None"}, Position: ({X},{Y})";
        }
    }
}
