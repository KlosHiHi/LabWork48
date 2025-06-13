using DBLibrary.Models;
using System.Net.Http.Json;

namespace WebApiServices
{
    public class GamesApiService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Game>?> GetGamesAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Game>>("Games");

        public async Task<Game?> GetGameAsync(int id)
            => await _client.GetFromJsonAsync<Game?>($"Games/{id}");

        public async Task CreateGameAsync(Game Game)
        {
            var response = await _client.PostAsJsonAsync($"Games", Game);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateGameAsync(Game Game)
        {
            var response = await _client.PutAsJsonAsync($"Games/{Game.Id}", Game);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGameAsync(int id)
        {
            var response = await _client.DeleteAsync($"Games/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
