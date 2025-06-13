using DBLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiServices;

namespace WebApp.Pages
{
    public class DetailsModel(GamesApiService service) : PageModel
    {
        private readonly GamesApiService _service = service;

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Game = await _service.GetGameAsync(id);

            if (Game is null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateGameAsync(Game);
            return RedirectToPage("./Index");
        }
    }
}
