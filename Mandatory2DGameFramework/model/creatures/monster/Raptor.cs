﻿using Mandatory2DGameFramework.model.creatures.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.creatures.monster
{
    /// <summary>
    /// Class for creating a Raptor monster
    /// </summary>
    public class Raptor : MonsterCreature
    {
        public Raptor() : base("Raptor", 80)
        {
            
        }

        public override int Hit()
        {
            return 10;
        }

        public override string ToString()
        {
            return $"Monster Name: {Name}, HitPoints: {HitPoint}, Position: ({X},{Y})";
        }
    }
}
