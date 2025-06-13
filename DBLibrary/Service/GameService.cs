using DBLibrary.Models;
using DBLibrary.Repository;
using Microsoft.IdentityModel.Tokens;

namespace DBLibrary.Service
{
    public class GameService(GameRepository repository)
    {
        private readonly GameRepository _repository = repository;

        public IEnumerable<Game> GetAll()
        {
            Console.WriteLine("начало получение всех строк из таблицы Game");

            var games = _repository.GetAll();

            Console.WriteLine("конец получение всех строк из таблицы Game");

            return games;
        }

        public Game GetById(int id)
        {
            Console.WriteLine("начало получения записи из таблицы Game по Id");

            var game = _repository.GetById(id) ?? throw new KeyNotFoundException();

            Console.WriteLine("конец получения записи из таблицы Game по Id");

            return game;
        }

        public void Create(Game game)
        {
            Console.WriteLine("Выполняется добавление строки в таблицу Game");

            if (IsIncorrectData(game))
                return;

            _repository.Create(game);

            Console.WriteLine("Добавление строки прошло успешно");
        }

        public void Update(Game game)
        {
            Console.WriteLine("Выполняется обновление строки в таблицы Game");

            if (game.Id < 1 || IsIncorrectData(game))
                return;

            _repository.Update(game);

            Console.WriteLine("Обновление строки прошло успешно");
        }

        public void Delete(int id)
        {
            Console.WriteLine("Выполняется удаление строки из таблицы Game");

            _repository.Delete(id);

            Console.WriteLine("Удаление строки прошло успешно");
        }

        private static bool IsIncorrectData(Game game)
        {
            return game.Title.IsNullOrEmpty()
                || game.Price < 0
                || game.PublicationYear > DateTime.Now.Year;
        }
    }
}
