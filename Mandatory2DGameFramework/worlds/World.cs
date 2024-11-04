using Mandatory2DGameFramework.logging;
using Mandatory2DGameFramework.model.creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.worlds
{
    /// <summary>
    /// World class for creating a world
    /// </summary>
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

        /// <summary>
        /// Adds a creature to the list of creatures
        /// </summary>
        /// <param name="creature">A creature</param>
        public void AddCreature(Creature creature)
        {
            _creatures.Add(creature);
        }

        /// <summary>
        /// Adds a world object to the list of world objects
        /// </summary>
        /// <param name="obj">A world object</param>
        public void AddObject(WorldObject obj)
        {
            _worldObjects.Add(obj);
        }

        /// <summary>
        /// Parses the actions from the XML document
        /// </summary>
        /// <param name="xmlDoc">An XML Document</param>
        public void ParseActions(XmlDocument xmlDoc)
        {
            XmlNodeList actionNodes = xmlDoc.SelectNodes("//action");
            foreach (XmlNode actionNode in actionNodes) {
                string? actionAttacker = actionNode["Attacker"]?.InnerText;
                string? actionReceiver = actionNode["Receiver"]?.InnerText;

                string? actionPlayer = actionNode["Player"]?.InnerText;
                string? actionLoot = actionNode["WorldObject"]?.InnerText;

                string? actionPlayerMove = actionNode["PlayerMove"]?.InnerText;
                string? actionMove = actionNode["Move"]?.InnerText;

                if (!string.IsNullOrEmpty(actionAttacker) && !string.IsNullOrEmpty(actionReceiver)) {
                    Creature? attacker = _creatures.Find(c => c.Name == actionAttacker);
                    Creature? receiver = _creatures.Find(c => c.Name == actionReceiver);
                        if (attacker != null && receiver != null) {
                            receiver.ReceiveHit(attacker.Hit());
                            Console.WriteLine($"{attacker.Name} has attacked {receiver.Name}!");
                            Console.WriteLine($"{attacker.Hit()} damage was dealt. {receiver.Name} now has {receiver.HitPoint} health left.");
                        }
                        else
                        {
                            MyLogger.Instance.LogError("Attacker or receiver not found in the list of creatures");
                        }
                } else if (!string.IsNullOrEmpty(actionPlayer) && !string.IsNullOrEmpty(actionLoot)) {
                    Creature? player = _creatures.Find(c => c.Name == actionPlayer);
                    WorldObject? loot = _worldObjects.Find(obj => obj.Name == actionLoot);
                    if (player != null && loot != null)
                    {
                        player.Loot(loot);
                        Console.WriteLine($"{player.Name} has looted {loot.Name}!");
                    } else {
                        MyLogger.Instance.LogError("Player or loot item not found in the lists");
                    }
                } else if(!string.IsNullOrEmpty(actionPlayerMove) && !string.IsNullOrEmpty(actionMove)) {
                    Creature? player = _creatures.Find(c => c.Name == actionPlayerMove);
                    if (player != null)
                    {
                        if (actionMove == "+Y")
                        {
                            player.Move(true, null);
                            Console.WriteLine($"Moved player up. New position: ({player.X},{player.Y})");
                        }
                        else if (actionMove == "-Y")
                        {
                            player.Move(false, null);
                            Console.WriteLine($"Moved player down. New position: ({player.X},{player.Y})");
                        }
                        else if (actionMove == "-X")
                        {
                            player.Move(null, false);
                            Console.WriteLine($"Moved player left. New position: ({player.X},{player.Y})");
                        }
                        else if (actionMove == "+X")
                        {
                            player.Move(null, true);
                            Console.WriteLine($"Moved player right. New position: ({player.X},{player.Y})");
                        }
                        else
                        {
                            MyLogger.Instance.LogError("Invalid move action in XML file");
                        }
                    }
                    else
                    {
                        MyLogger.Instance.LogError("Player not found in the list of creatures");
                    }
                } else {
                    MyLogger.Instance.LogError("Invalid action configuration in XML file");
                }
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}
