using DBLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiServices;

namespace WebApp.Pages
{
    public class IndexModel(GamesApiService service) : PageModel
    {
        private readonly GamesApiService _service = service;

        public IEnumerable<Game> Games { get; set; }

        public async Task OnGetAsync()
        {
            Games = await _service.GetGamesAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                _service.DeleteGameAsync(id);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToPage("./Index");
        }
    }
}
