using Data.Models.Client;
using SharedLibraryCore;
using SharedLibraryCore.Commands;
using SharedLibraryCore.Configuration;
using SharedLibraryCore.Interfaces;

namespace IW4M_ChatGames.Commands;

public class WinsCommand : Command
{
    public WinsCommand(CommandConfiguration config, ITranslationLookup translationLookup) :
        base(config, translationLookup)
    {
        Name = "wins";
        Description = "Check your winnings!";
        Alias = "win";
        Permission = EFClient.Permission.User;
        RequiresTarget = false;
        Arguments = new[]
        {
            new CommandArgument
            {
                Name = "Player",
                Required = false
            }
        };
    }

    public override Task ExecuteAsync(GameEvent gameEvent)
    {
        if (gameEvent.Type != GameEvent.EventType.Command) return Task.CompletedTask;

        // Get argument from command.
        var argPlayer = gameEvent.Data;
        gameEvent.Target = gameEvent.Owner.GetClientByName(argPlayer).FirstOrDefault();

        // Check for valid target.
        if (gameEvent.Data.Length != 0 && gameEvent.Target == null)
        {
            gameEvent.Origin.Tell("(Color::Yellow)Error trying to find user");
            return Task.CompletedTask;
        }

        // Return player's credits
        if (gameEvent.Target != null)
        {
            gameEvent.Origin.Tell(
                $"{gameEvent.Target.Name} (Color::White)has (Color::Cyan)${gameEvent.Target.GetAdditionalProperty<int>(Plugin.WinsKey) * 1_000:N0} (Color::White)in wins!");
            return Task.CompletedTask;
        }

        // If no target specified
        gameEvent.Origin.Tell(
            $"You have (Color::Cyan)${gameEvent.Origin.GetAdditionalProperty<int>(Plugin.WinsKey) * 1_000:N0} (Color::White)in wins!");
        return Task.CompletedTask;
    }
}
