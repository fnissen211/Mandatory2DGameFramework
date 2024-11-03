using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.creatures;
using Mandatory2DGameFramework.model.creatures.player;
using Mandatory2DGameFramework.model.defence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.xml_configuration
{
    //TODO: Implement the ReadXMLConfiguration class and make a gameconfiguration class
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
            } catch (Exception ex) {
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
                    // TODO: Handle the case where Class is missing or empty
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
                    // TODO: Handle the case where Class is missing or empty
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

    }
}
