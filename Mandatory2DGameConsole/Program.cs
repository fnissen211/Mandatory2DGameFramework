using Mandatory2DGameFramework.model.creatures;
using Mandatory2DGameFramework.xml_configuration;
using System.Xml;

ReadXMLConfiguration readXMLConfiguration = new ReadXMLConfiguration();

string path = "C:\\Users\\Administrator\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameConsole\\xml-tests\\XMLFileTestGame.xml";

readXMLConfiguration.ReadXMLDocument(path);

XmlDocument? xmlDoc = readXMLConfiguration.ReadXMLDocument(path);
List<Creature>? creatures = readXMLConfiguration.ParseCreatures(xmlDoc);

Console.WriteLine("Hello, Frederik!");

foreach (var creature in creatures)
{
    Console.WriteLine(creature.ToString());
}

Console.ReadKey();
