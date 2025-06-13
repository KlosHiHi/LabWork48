using Dapper;
using DBLibrary.DataBase;
using DBLibrary.Models;
using System.Data;

namespace DBLibrary.Repository
{
    public class GameRepository(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _connection = factory.CreateConnection();

        public IEnumerable<Game> GetAll()
            => _connection.Query<Game>("SELECT * FROM Game");

        public Game GetById(int id)
            => _connection.QueryFirstOrDefault<Game>("SELECT * FROM Game WHERE Id=@id", new { id });

        public void Create(Game game)
            => _connection.Execute(@"INSERT INTO Game(Title, Description, Price, PublicationYear) 
VALUES(@Title, @Description, @Price, @PublicationYear)", game);

        public void Update(Game game)
            => _connection.Execute(@"UPDATE Game SET Title=@Title, Description=@Description, PublicationYear=@PublicationYear, Price=@Price 
WHERE Id=@Id", game);

        public void Delete(int id)
            => _connection.Execute("DELETE Game WHERE Id=@id", new { id });
    }
}
