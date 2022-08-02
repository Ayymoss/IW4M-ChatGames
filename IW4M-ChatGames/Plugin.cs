using IW4M_ChatGames.Games;
using SharedLibraryCore;
using SharedLibraryCore.Interfaces;

namespace IW4M_ChatGames;

public class Plugin : IPlugin
{
    public string Name => "IW4M Chat Games";
    public float Version => 20220731f;
    public string Author => "Amos";

    public const int GameDelay = 300_000;
    public const int GameFailDelay = 20_000;
    public const int GameCharacterCount = 12;

    public static IManager Manager { get; set; }
    public static GameManager GameManager { get; } = new();
    public static ChatReaction ChatReaction { get; } = new();
    public static Crossword Crossword { get; } = new();
    public static QuickMaths QuickMaths { get; } = new();

    public Task OnEventAsync(GameEvent gameEvent, Server server)
    {
        switch (gameEvent.Type)
        {
            case GameEvent.EventType.Say:
                GameManager.UserMessageSent(gameEvent);
                break;
        }

        return Task.CompletedTask;
    }

    public Task OnLoadAsync(IManager manager)
    {
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
