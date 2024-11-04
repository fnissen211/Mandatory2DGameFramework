using Mandatory2DGameFramework.model.creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    //TODO: XML Documentation
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        private List<WorldObject> _worldObjects;
        private List<Creature> _creatures;

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        public void AddCreature(Creature creature)
        {
            _creatures.Add(creature);
        }

        public void AddObject(WorldObject obj)
        {
            _worldObjects.Add(obj);
        }

        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}
