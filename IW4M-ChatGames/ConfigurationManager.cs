using System.Reflection;
using System.Text.Json;
using IW4M_ChatGames.Models;

namespace IW4M_ChatGames;

public class ConfigurationManager
{
    public void Configuration()
    {
        const string fileName = "Crosswords.json";
        var configurationPath =
            Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"..\Configuration", fileName));
        if (!File.Exists(configurationPath))
        {
            var jsonData =
                "[{'Answer':'Era','Question':'a distinct period of history with a unique characteristic.'},{'Answer':'Area','Question':'a region or part of the world; the extent or measurement of a surface.'},{'Answer':'Ere','Question':'an old English word meaning “before.”'},{'Answer':'One','Question':'half of two; a specific person or thing.'},{'Answer':'Eli','Question':'a Hebrew name meaning “High” or “elevated.”'},{'Answer':'Ore','Question':'a naturally occurring solid material from which a mineral can be extracted.'},{'Answer':'Ale','Question':'a type of beer which has a high alcoholic content and bitter flavor.'},{'Answer':'Ate','Question':'having consumed food.'},{'Answer':'Erie','Question':'a member of the Native American community living south of the lake with the same name, Lake Erie.'},{'Answer':'Ali','Question':'an Arabic name meaning “High” or “elevated.”'},{'Answer':'Odor','Question':'a distinctive smell, often unpleasant in nature.'},{'Answer':'Oboe','Question':'a woodwind instrument with a double,reed mouthpiece, a slender tubular body, and holes stopped by keys.'},{'Answer':'Aloe','Question':'a succulent plant with fleshy leaves and bell,shaped flowers on long stems.'},{'Answer':'Aria','Question':'a long, accompanied song for a solo voice in an opera or oratorio.'},{'Answer':'Else','Question':'in addition; besides.'},{'Answer':'Idea','Question':'a thought as to a possible course of action.'},{'Answer':'Eden','Question':'from the Biblical Garden meaning “delight.”'},{'Answer':'Oral','Question':'by word of mouth; spoken rather than written.'},{'Answer':'Ante','Question':'a stake put up by a player in poker and similar games before receiving cards.'},{'Answer':'Oreo','Question':'a brand of chocolate sandwich cookie with a creamy white filling.'}]"
                    .Replace("'", "\"");
            var jsonOptions = new JsonSerializerOptions {WriteIndented = true};
            var jsonSerialised = JsonSerializer.Serialize(jsonData, jsonOptions);

            File.WriteAllText(configurationPath, jsonSerialised);
        }

        var crosswordJson = JsonSerializer.Deserialize<List<CrosswordModel>>(File.ReadAllText(configurationPath));
        if (crosswordJson == null)
        {
            Console.WriteLine(
                "Error reading configuration file! Please check its content. It should be a valid JSON array.");
        }

        Plugin.CrosswordModel = crosswordJson;
    }
}
