using SharedLibraryCore.Interfaces;

namespace IW4M_ChatGames.Models;

public class CrosswordModel
{
    public string Question { get; set; }
    public string Answer { get; set; }
}

public class CrosswordSeedData : IBaseConfiguration
{
    public List<CrosswordModel> Crosswords { get; set; } = new()
    {
        new CrosswordModel
        {
            Answer = "Era",
            Question = "A distinct period of history with a unique characteristic"
        },
        new CrosswordModel
        {
            Answer = "Area",
            Question = "A region or part of the world; the extent or measurement of a surface"
        },
        new CrosswordModel
        {
            Answer = "Ere",
            Question = "An old English word meaning \"before\""
        },
        new CrosswordModel
        {
            Answer = "One",
            Question = "Half of two; a specific person or thing"
        },
        new CrosswordModel
        {
            Answer = "Eli",
            Question = "A Hebrew name meaning \"High\" or \"elevated\""
        },
        new CrosswordModel
        {
            Answer = "Ore",
            Question = "A naturally occurring solid material from which a mineral can be extracted"
        },
        new CrosswordModel
        {
            Answer = "Ale",
            Question = "A type of beer which has a high alcoholic content and bitter flavor"
        },
        new CrosswordModel
        {
            Answer = "Ate",
            Question = "Having consumed food"
        },
        new CrosswordModel
        {
            Answer = "Erie",
            Question =
                "A member of the Native American community living south of the lake with the same name, Lake Erie"
        },
        new CrosswordModel
        {
            Answer = "Ali",
            Question = "An Arabic name meaning \"High\" or \"elevated\""
        },
        new CrosswordModel
        {
            Answer = "Odor",
            Question = "A distinctive smell, often unpleasant in nature"
        },
        new CrosswordModel
        {
            Answer = "Oboe",
            Question =
                "A woodwind instrument with a double,reed mouthpiece, a slender tubular body, and holes stopped by keys"
        },
        new CrosswordModel
        {
            Answer = "Aloe",
            Question = "A succulent plant with fleshy leaves and bell,shaped flowers on long stems"
        },
        new CrosswordModel
        {
            Answer = "Aria",
            Question = "A long, accompanied song for a solo voice in an opera or oratorio"
        },
        new CrosswordModel
        {
            Answer = "Else",
            Question = "In addition; besides"
        },
        new CrosswordModel
        {
            Answer = "Idea",
            Question = "A thought as to a possible course of action"
        },
        new CrosswordModel
        {
            Answer = "Eden",
            Question = "From the Biblical Garden meaning \"delight\""
        },
        new CrosswordModel
        {
            Answer = "Oral",
            Question = "By word of mouth; spoken rather than written"
        },
        new CrosswordModel
        {
            Answer = "Ante",
            Question = "A stake put up by a player in poker and similar games before receiving cards"
        },
        new CrosswordModel
        {
            Answer = "Oreo",
            Question = "A brand of chocolate sandwich cookie with a creamy white filling"
        }
    };

    public string Name() => "Crosswords";
    public IBaseConfiguration Generate() => new CrosswordSeedData();
}
