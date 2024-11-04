using Mandatory2DGameFramework.model.creatures;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.xml_configuration;
using System.Xml;

namespace Mandatory2DGameConsole
{
    public class Game
    {
        private World world;
        private List<Creature> creatures;
        private List<WorldObject> worldObjects;

        /// <summary>
        /// Configures the game by reading the XML file and creating the creatures
        /// </summary>
        protected void ConfigureGame()
        {
            ReadXMLConfiguration readXMLConfiguration = new ReadXMLConfiguration();

            string path = "C:\\Users\\Administrator\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameConsole\\xml-tests\\XMLFileTestGame.xml";
            XmlDocument? xmlDoc = readXMLConfiguration.ReadXMLDocument(path);

            creatures = readXMLConfiguration.ParseCreatures(xmlDoc);

            worldObjects = readXMLConfiguration.ParseWorldObjects(xmlDoc);


            world = readXMLConfiguration.ParseWorldConfig(xmlDoc);

            foreach (var creature in creatures)
            {
                world.AddCreature(creature);
                Console.WriteLine($"Added: {creature}");
            }

            foreach (var worldObject in worldObjects)
            {
                world.AddObject(worldObject);
                Console.WriteLine($"Added: {worldObject}");
            }
            Console.WriteLine(world);
            Console.WriteLine("Game configured successfully.");

        }

        /// <summary>
        /// Starts the game
        /// </summary>
        public void StartGame()
        {
            ConfigureGame();
        }
    }
}
