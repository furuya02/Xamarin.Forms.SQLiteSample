using SQLite.Net;

namespace SQLiteSample
{
    public interface ISQLite{
        SQLiteConnection GetConnection();
    }
}
