using Archipelago.Core;
using Archipelago.Core.Models;
using Archipelago.Core.Util;
using Archipelago.Core.GameClients;

namespace takpoj_client;

class Program
{
    private ArchipelagoClient _client;
    public static async Task Main()
    {
        Console.WriteLine("Starting TakPoJ Archipelago Client...");
    }

    public async Task Initialize()
    {
        // Setup game client
        var gameClient = new PCSX2Client();
        if (!gameClient.Connect())
        {
            throw new Exception("Could not connect to game");
        }

        // Initialize Archipelago client
        _client = new ArchipelagoClient(gameClient);

        // Setup event handlers
        _client.ItemReceived += OnItemReceived;
        _client.LocationCompleted += OnLocationCompleted;
        _client.Connected += OnConnected;

        // Connect and login
        await _client.Connect("archipelago.gg:38281", "My Game");
        await _client.Login("PlayerName");
    }
    private void OnItemReceived(object sender, ItemReceivedEventArgs e)
    {
        switch (e.Item.Name)
        {
            default:
                Console.WriteLine($"Unknown item: {e.Item.Name}");
                break;
        }
    }
    private void OnLocationCompleted(object sender, LocationCompletedEventArgs e)
    {
        _client.AddOverlayMessage($"Found: {e.CompletedLocation.Name}");
    }
    
    private async void OnConnected(object sender, ConnectionChangedEventArgs e)
    {
        // Load locations and start monitoring
        //_locations = LoadLocationsFromFile();
        //await _client.MonitorLocations(_locations);
        
        // Check game options
        //if (_client.Options.TryGetValue("difficulty", out var difficulty))
        //{
          //  SetGameDifficulty(difficulty.ToString());
        //}
    }
    
    private void GivePlayerSword()
    {
        // Write to game memory to give player a sword
        Memory.WriteByte(0x12345678, 1); // Has sword flag
    }
}