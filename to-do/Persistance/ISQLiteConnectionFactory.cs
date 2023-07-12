using System.Data;

namespace to_do.Persistance
{
    public interface ISQLiteConnectionFactory
    {
        public IDbConnection CreateConnection();
    }
}
