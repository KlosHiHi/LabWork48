using WebApiServices;

var client = new HttpClient()
{
    BaseAddress = new Uri("http://localhost:5042/api/")
};

GamesApiService service = new(client);

var games = await service.GetGamesAsync();
var game = await service.GetGameAsync(10);

try
{
    game.Title = "Helldivers II";
    game.Description = "Пора сражаться за честь Супер-Земли123";
    game.PublicationYear = 2023;
    game.Price = 19.99M;

    await service.UpdateGameAsync(game);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    game = new()
    {
        Title = "Helldivers II1223",
        Description = "Пора сражаться за честь Супер-Земли123",
        PublicationYear = 2023,
        Price = 200.25m
    };

    await service.CreateGameAsync(game);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    await service.DeleteGameAsync(13);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();