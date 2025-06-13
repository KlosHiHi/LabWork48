using WebApiServices;

var client = new HttpClient()
{
    //BaseAddress = new Uri("http://localhost:5185/api/")
    BaseAddress = new Uri("http://localhost:5042/api/")
};

GamesApiService service = new(client);

try
{
    var games = await service.GetGamesAsync();
    var game = await service.GetGameAsync(5);

    game.Title = "Helldrivers ll";
    await service.UpdateGameAsync(game);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();