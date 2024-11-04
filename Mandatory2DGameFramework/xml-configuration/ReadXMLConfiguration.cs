using Mandatory2DGameFramework.logging;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.creatures;
using Mandatory2DGameFramework.model.creatures.player;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.xml_configuration
{
    /// <summary>
    /// Class for reading an XML configuration file
    /// </summary>
    public class ReadXMLConfiguration
    {
        /// <summary>
        /// Reads an XML file from a given path and returns an XML document
        /// </summary>
        /// <param name="path">The path where the file that will be read lies.</param>
        /// <returns>Returns the path-file to a XMLDocument or null if it wasn't a XMLDocument</returns>
        public XmlDocument? ReadXMLDocument(string path)
        {
            XmlDocument configDoc = new XmlDocument();
            try
            {
                configDoc.Load(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading XML file: " + ex.Message);
                return null;
            }

            return configDoc;
        }

        /// <summary>
        /// Takes an xml document and parses the creatures from the XML document and return a list of creatures
        /// </summary>
        /// <param name="xmlDoc">An XML document</param>
        /// <returns>A list of creatures</returns>
        public List<Creature>? ParseCreatures(XmlDocument xmlDoc)
        {
            List<Creature> creatures = new List<Creature>();
            XmlNodeList? playerCreatureNodes = xmlDoc.SelectNodes("//playerCreature");
            XmlNodeList? monsterCreatureNodes = xmlDoc.SelectNodes("//monsterCreature");

            foreach (XmlNode creatureNode in monsterCreatureNodes)
            {
                string? classText = creatureNode["Class"]?.InnerText;
                if (string.IsNullOrEmpty(classText))
                {
                    MyLogger.Instance.LogError("Class is missing or empty");
                    continue;
                }
                CreatureMonster monsterClass = (CreatureMonster)Enum.Parse(
                    typeof(CreatureMonster), creatureNode["Class"]?.InnerText);

                MonsterCreature monster = (MonsterCreature)CreatureFactory.CreateCreatureMonster(monsterClass);
                creatures.Add(monster);

            }

            foreach (XmlNode creatureNode in playerCreatureNodes)
            {
                string? classText = creatureNode["Class"]?.InnerText;
                if (string.IsNullOrEmpty(classText))
                {
                    MyLogger.Instance.LogError("Class is missing or empty");
                    continue;
                }

                CreaturePlayer playerClass = (CreaturePlayer)Enum.Parse(
                    typeof(CreaturePlayer), creatureNode["Class"]?.InnerText);
                string? playerName = creatureNode["Name"]?.InnerText;

                var attackNode = creatureNode["Attack"];
                AttackItem? playerAttackItem = null;

                if (attackNode != null)
                {
                    AttackItem attackItem = new AttackItem
                    {
                        Name = attackNode["Name"]?.InnerText ?? "Unknown Item",
                        Hit = int.Parse(attackNode["Hit"]?.InnerText ?? "0"),
                        Range = int.Parse(attackNode["Range"]?.InnerText ?? "0")
                    };
                    playerAttackItem = attackItem;
                }

                var defenceNode = creatureNode["Defence"];
                DefenceItem? playerDefenceItem = null;


                if (defenceNode != null)
                {
                    DefenceItem defenceItem = new DefenceItem
                    {
                        Name = defenceNode["Name"]?.InnerText ?? "Unknown Item",
                        ReduceHitPoint = int.Parse(defenceNode["Hit"]?.InnerText ?? "0")
                    };
                    playerDefenceItem = defenceItem;
                }

                PlayerCreature player = (PlayerCreature)CreatureFactory.CreateCreaturePlayer(playerClass, playerName);

                player.Attack = playerAttackItem;
                player.Defence = playerDefenceItem;

                creatures.Add(player);
            }
            return creatures;
        }

        /// <summary>
        /// Takes an xml document and parses the world objects from the XML document and return a list of world objects
        /// </summary>
        /// <param name="xmlDoc">An XML document</param>
        /// <returns>A list of world objects</returns>
        public List<WorldObject>? ParseWorldObjects(XmlDocument xmlDoc)
        {
            List<WorldObject> worldObjects = new List<WorldObject>();
            XmlNodeList? worldObjectNodes = xmlDoc.SelectNodes("//worldObject");

            foreach (XmlNode worldObjectNode in worldObjectNodes)
            {
                string? name = worldObjectNode["Name"]?.InnerText ?? "Unknown Object";
                bool lootable = bool.Parse(worldObjectNode["Lootable"]?.InnerText ?? "false");
                bool removeable = bool.Parse(worldObjectNode["Removeable"]?.InnerText ?? "false");
                int x = int.Parse(worldObjectNode["X"]?.InnerText ?? "0");
                int y = int.Parse(worldObjectNode["Y"]?.InnerText ?? "0");

                worldObjects.Add(WorldObjectFactory.CreateWorldObject(name, lootable, removeable, x, y));
            }
            return worldObjects;
        }

        /// <summary>
        /// Parses the world configuration from the XML document and returns the playing world
        /// </summary>
        /// <param name="xmlDoc">An XML document</param>
        /// <returns>Returns the playing world</returns>
        public World ParseWorldConfig(XmlDocument xmlDoc)
        {
            XmlNodeList worldNode = xmlDoc.SelectNodes("//world");

            int maxX = int.Parse(worldNode[0]["MaxX"]?.InnerText ?? "0");
            int maxY = int.Parse(worldNode[0]["MaxY"]?.InnerText ?? "0");
            World world = new World(maxX, maxY);
            return world;
        }
    }
}
