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
    /// <summary>
    /// Warlock class that inherits from PlayerCreature
    /// </summary>
    public class Warlock : PlayerCreature
    {
        public override AttackItem? Attack { get; set; }
        public override DefenceItem? Defence { get; set; }

        public Warlock(string name) : base(name)
        {
        }

        public override int Hit()
        {
            int baseDamage = 13;

            int extraDamage = this.inventory?
                .OfType<AttackItem>()
                .Sum(item => item.Hit) ?? 0;

            return baseDamage + extraDamage;
        }

        public override string ToString()
        {
            return $"Warlock Name: {Name}, HitPoints: {HitPoint}, Attack: {Attack?.Name ?? "None"}, Defence: {Defence?.Name ?? "None"}, Position: ({X},{Y})";
        }
    }
}
