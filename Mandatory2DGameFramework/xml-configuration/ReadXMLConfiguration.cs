using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.creatures;
using Mandatory2DGameFramework.model.defence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.xml_configuration
{
    public class ReadXMLConfiguration
    {
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

        public List<Creature>? ParseCreatures(XmlDocument xmlDoc)
        {
            List<Creature> creatures = new List<Creature>();
            XmlNodeList? creatureNodes = xmlDoc.SelectNodes("//creature");

            foreach (XmlNode creatureNode in creatureNodes)
            {
                Creature creature = new Creature();

                // Access child nodes and map them to the Creature class
                creature.Name = creatureNode["Name"]?.InnerText;
                creature.HitPoint = int.Parse(creatureNode["HitPoint"]?.InnerText ?? "0");

                // Access nested nodes inside <Attack> and <Defence>
                var attackNode = creatureNode["Attack"];
                creature.Attack = new AttackItem
                {
                    Name = attackNode?["Name"]?.InnerText ?? "Unknown Item",
                    Hit = int.Parse(attackNode?["Hit"]?.InnerText ?? "0"),
                    Range = int.Parse(attackNode?["Range"]?.InnerText ?? "0")
                };

                var defenceNode = creatureNode["Defence"];
                creature.Defence = new DefenceItem
                {
                    Name = defenceNode?["Name"]?.InnerText ?? "Unknown Item",
                    ReduceHitPoint = int.Parse(defenceNode?["ReduceHitPoint"]?.InnerText ?? "0")
                };

                creatures.Add(creature);
            }
            return creatures;
        }

    }
}
