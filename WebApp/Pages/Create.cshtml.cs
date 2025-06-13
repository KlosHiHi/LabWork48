using DBLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using WebApiServices;

namespace WebApp.Pages
{
    public class CreateModel(GamesApiService service) : PageModel
    {

        private readonly GamesApiService _service = service;

        [BindProperty]
        public Game Game { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateGameAsync(Game);
            return RedirectToPage("./Index");
        }
    }
}
