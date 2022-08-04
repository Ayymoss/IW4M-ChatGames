using System.Reflection;
using IW4M_ChatGames.Games;
using IW4M_ChatGames.Models;
using SharedLibraryCore;
using SharedLibraryCore.Interfaces;

namespace IW4M_ChatGames;

public class Plugin : IPlugin
{
    public Plugin(IMetaServiceV2 metaService)
    {
        PlayerData = new PlayerData(metaService);
    }

    public string Name => "IW4M Chat Games";
    public float Version => 20220804f;
    public string Author => "Amos";

    public const int GameDelay = 300_000;
    public const int GameFailDelay = 20_000;
    public const int GameCharacterCount = 12;

    public const string WinsKey = "IW4MChatGames_Wins";

    public static IManager? Manager { get; set; }
    private static PlayerData PlayerData;
    private static ConfigurationManager ConfigurationManager { get; } = new();
    public static GameManager GameManager { get; } = new();
    public static ChatReaction ChatReaction { get; } = new();
    public static Crossword Crossword { get; } = new();
    public static List<CrosswordModel>? CrosswordModel { get; set; } = new();
    public static QuickMaths QuickMaths { get; } = new();

    public Task OnEventAsync(GameEvent gameEvent, Server server)
    {
        switch (gameEvent.Type)
        {
            case GameEvent.EventType.Join:
                PlayerData.OnJoin(gameEvent.Origin);
                break;
            case GameEvent.EventType.Disconnect:
                PlayerData.OnDisconnect(gameEvent.Origin);
                break;
            case GameEvent.EventType.Say:
                GameManager.UserMessageSent(gameEvent);
                break;
        }

        return Task.CompletedTask;
    }

    public Task OnLoadAsync(IManager manager)
    {
        ConfigurationManager.Configuration();
        Console.ReadKey();
        Environment.Exit(0);

        Manager = manager;
        GameManager.OnLoad();

        Console.WriteLine($"{Name} v{Version} by {Author} loaded");
        return Task.CompletedTask;
    }

    public Task OnUnloadAsync()
    {
        Console.WriteLine($"{Name} unloaded");
        return Task.CompletedTask;
    }

    public Task OnTickAsync(Server server)
    {
        return Task.CompletedTask;
    }
}
