namespace IW4M_ChatGames.Games;

public class Crossword
{
    public string Init()
    {
        var rnd = new Random();
        var randomCrossword = Plugin.CrosswordModel[rnd.Next(0, Plugin.CrosswordModel.Count)];
        
        Plugin.GameManager.MessageAllServers($"(Color::Yellow)Answer to win (Color::Green)$1,000: (Color::Accent){randomCrossword.Question}");

        return randomCrossword.Answer.ToLower();
    }
}
