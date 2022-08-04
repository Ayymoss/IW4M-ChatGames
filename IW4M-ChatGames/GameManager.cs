using System.Timers;
using SharedLibraryCore;
using Timer = System.Timers.Timer;

namespace IW4M_ChatGames;

public class GameManager
{
    private Dictionary<GamesSelection, bool> GameState { get; } = new()
    {
        {GamesSelection.Crossword, false},
        {GamesSelection.QuickMaths, false},
        {GamesSelection.ChatReaction, false}
    };

    private string Answer { get; set; } = string.Empty;
    private Timer GameTimeOut { get; set; }
    private List<DateTime> ReactionTime { get; } = new();

    public void OnLoad()
    {
        var timer = new Timer();
        timer.Interval = Plugin.GameDelay;
        timer.Elapsed += InitGame;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private void InitGame(object source, ElapsedEventArgs e)
    {
        var rnd = new Random();
        var game = (GamesSelection) rnd.Next(0, 3);

        Answer = string.Empty;

        switch (game)
        {
            case GamesSelection.ChatReaction:
                GameState[GamesSelection.ChatReaction] = true;
                Answer = Plugin.ChatReaction.Init();
                break;
            case GamesSelection.QuickMaths:
                GameState[GamesSelection.QuickMaths] = true;
                Answer = Plugin.QuickMaths.Init();
                break;
            case GamesSelection.Crossword:
                GameState[GamesSelection.Crossword] = true;
                Answer = Plugin.Crossword.Init();
                break;
        }

        ReactionTime.Clear();
        ReactionTime.Add(DateTime.Now);

        GameTimeOut = new Timer();
        GameTimeOut.Interval = Plugin.GameFailDelay;
        GameTimeOut.Elapsed += FailedGame;
        GameTimeOut.Enabled = true;
    }

    private void FailedGame(object source, ElapsedEventArgs e)
    {
        GameTimeOut.Dispose();

        GameState[GamesSelection.ChatReaction] = false;
        GameState[GamesSelection.Crossword] = false;
        GameState[GamesSelection.QuickMaths] = false;


        MessageAllServers($"(Color::Yellow)Times up! (Color::Accent)The answer was (Color::Green){Answer})");
    }

    public void UserMessageSent(GameEvent gameEvent)
    {
        if (gameEvent.Message == Answer && GameTimeOut is null)
        {
            gameEvent.Origin.Tell("(Color::Red)Unlucky! (Color::Accent)You answered too slow!");
            return;
        }

        if (gameEvent.Message == Answer && GameState[GamesSelection.ChatReaction])
        {
            GameTimeOut.Enabled = false;
            ReactionTime.Add(DateTime.Now);
            var time = ReactionTime.Last().Subtract(ReactionTime.First());

            MessageAllServers($"(Color::Accent){gameEvent.Origin.CleanedName} (Color::White)was the " +
                              $"fastest at (Color::Accent){time.TotalSeconds:N2}s");
            gameEvent.Origin.Tell("(Color::Accent)Congratulations! (Color::Green)You answered the fastest!");
        }
    }

    public void MessageAllServers(string message)
    {
        foreach (var server in Plugin.Manager.GetServers())
        {
            server.Broadcast(message);
        }
    }
}

public enum GamesSelection
{
    ChatReaction,
    QuickMaths,
    Crossword
}
