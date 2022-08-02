namespace IW4M_ChatGames.Games;

public class ChatReaction
{
    public string Init()
    {
        
        
        
        const int messageLength = Plugin.GameCharacterCount;
        const string charSet = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz123456789";
        var random = new Random();
        var message = string.Empty;
        
        for (var i = 0; i < messageLength; i++)
        {
            message += charSet[random.Next(charSet.Length)];
        }

        Plugin.GameManager.MessageAllServers($"(Color::Yellow)First to type: (Color::Accent){message}");
        return message;
    }
}
