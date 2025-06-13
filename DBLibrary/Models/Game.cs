namespace DBLibrary.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
    }
}
