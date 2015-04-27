using System.IO;
using Windows.Storage;
using SQLite.Net;
using SQLite.Net.Platform.WindowsPhone8;
using SQLiteSample.WinPhone;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLite_WinPhone))]
namespace SQLiteSample.WinPhone {
    public class SQLite_WinPhone : ISQLite{
        public SQLiteConnection GetConnection(){
            const string sqliteFilename = "TodoSQLite.db3";//データベース名
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);//DBファイルのパス
            var plat = new SQLitePlatformWP8();
            var conn = new SQLiteConnection(plat, path);
            return conn;
        }
    }
}
