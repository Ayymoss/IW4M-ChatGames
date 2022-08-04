using Data.Models.Client;
using Data.Models.Client.Stats;
using SharedLibraryCore.Interfaces;

namespace IW4M_ChatGames;

public class PlayerData
{
    public PlayerData(IMetaServiceV2 metaService)
    {
        _metaService = metaService;
    }
    
    private readonly IMetaServiceV2 _metaService;
    
    public async void OnDisconnect(EFClient client) => await _metaService.SetPersistentMeta(Plugin.WinsKey,
        client.GetAdditionalProperty<int>(Plugin.WinsKey).ToString(), client.ClientId);
    
    public async void OnJoin(EFClient client)
    {
        var totalWins = (await _metaService.GetPersistentMeta(Plugin.WinsKey, client.ClientId))?.Value ?? "0";
        client.SetAdditionalProperty(Plugin.WinsKey, int.Parse(totalWins));
    }
}
