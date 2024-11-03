using Mandatory2DGameFramework.model.creatures;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.xml_configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameConsole
{
    public class Game
    {
        protected void ConfigureGame()
        {
            ReadXMLConfiguration readXMLConfiguration = new ReadXMLConfiguration();

            string path = "C:\\Users\\Administrator\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameConsole\\xml-tests\\XMLFileTestGame.xml";

            readXMLConfiguration.ReadXMLDocument(path);

            XmlDocument? xmlDoc = readXMLConfiguration.ReadXMLDocument(path);
            List<Creature>? creatures = readXMLConfiguration.ParseCreatures(xmlDoc);

            World world = new World(10, 10);
            
        }
        public void StartGame()
        {
            ConfigureGame();
        }
    }
}
