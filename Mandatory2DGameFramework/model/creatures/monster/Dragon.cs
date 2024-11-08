﻿using Mandatory2DGameFramework.model.creatures.player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.creatures.monster
{
    /// <summary>
    /// Class for creating a dragon monster
    /// </summary>
    public class Dragon : MonsterCreature
    {
        public Dragon() : base("Dragon", 150)
        {
            
        }

        public override int Hit()
        {
            return 15;
        }

        public override string ToString()
        {
            return $"Monster Name: {Name}, HitPoints: {HitPoint}, Position: ({X},{Y})";
        }
    }
}
