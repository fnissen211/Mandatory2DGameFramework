using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    /// <summary>
    /// Factory class for creating WorldObjects
    /// </summary>
    public static class WorldObjectFactory
    {
        /// <summary>
        /// Creates a new WorldObject with the given parameters
        /// </summary>
        /// <param name="name">Name of the world object</param>
        /// <param name="lootable">Boolean, that determines if the object is lootable</param>
        /// <param name="removeable">Boolean, that determines if the object is removable</param>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        /// <returns>Returns a world object</returns>
        public static WorldObject CreateWorldObject(string name, bool? lootable, bool? removeable, int x, int y)
        {
            WorldObject worldObject = new WorldObject();
            worldObject.Name = name;
            worldObject.Lootable = lootable ?? false;
            worldObject.Removeable = removeable ?? false;
            worldObject.X = x;
            worldObject.Y = y;
            return worldObject;
        }
    }
}
