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
    /// Mage class that inherits from PlayerCreature
    /// </summary>
    public class Mage : PlayerCreature
    {
        public override AttackItem? Attack { get; set; }
        public override DefenceItem? Defence { get; set; }
        public Mage(string name) : base(name)
        {

        }

        public override int Hit()
        {
            int baseDamage = 10;

            int extraDamage = this.inventory?
                .OfType<AttackItem>()
                .Sum(item => item.Hit) ?? 0;

            return baseDamage + extraDamage;
        }

        public override string ToString()
        {
            return $"Mage Name: {Name}, HitPoints: {HitPoint}, Attack: {Attack?.Name ?? "None"}, Defence: {Defence?.Name ?? "None"}, Position: ({X},{Y})";
        }
    }
}
