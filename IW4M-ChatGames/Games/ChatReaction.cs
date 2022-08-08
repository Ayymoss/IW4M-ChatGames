namespace IW4M_ChatGames.Games;

public class ChatReaction
{
    public string Init()
    {
        const int messageLength = Plugin.GameCharacterCount;
        const string charSet = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz123456789";
        var random = new Random();
        var answer = string.Empty;

        for (var i = 0; i < messageLength; i++)
        {
            answer += charSet[random.Next(charSet.Length)];
        }

        Plugin.GameManager.MessageAllServers($"(Color::Yellow)React to win (Color::Green)$1,000: (Color::Accent){answer}");
        
        return answer;
    }
}
