using System.Data;

namespace DBLibrary.DataBase
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
