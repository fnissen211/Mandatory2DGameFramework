﻿using Mandatory2DGameFramework.model.creatures.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.creatures.monster
{
    /// <summary>
    /// Class for creating a Boar monster
    /// </summary>
    public class Boar : MonsterCreature
    {
        public Boar() : base("Boar", 100)
        {
            
        }

        public override int Hit()
        {
            return 8;
        }

        public override string ToString()
        {
            return $"Monster Name: {Name}, HitPoints: {HitPoint}, Position: ({X},{Y})";
        }
    }
}
