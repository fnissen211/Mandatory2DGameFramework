using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    /// <summary>
    /// Class for creating defence items
    /// </summary>
    public class DefenceItem:WorldObject
    {
        public string Name { get; set; }
        public int ReduceHitPoint { get; set; }

        public DefenceItem()
        {
            Name = string.Empty;
            ReduceHitPoint = 0;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
        
    }
}
