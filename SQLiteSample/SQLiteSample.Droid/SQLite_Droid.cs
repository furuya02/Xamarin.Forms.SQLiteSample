using System.IO;
using SQLiteSample.Droid;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLite_Android))]
namespace SQLiteSample.Droid{
    public class SQLite_Android : ISQLite{
        public SQLite.Net.SQLiteConnection GetConnection() {
            const string sqliteFilename = "TodoSQLite.db3"; //�f�[�^�x�[�X��
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);//Documents�t�H���_
            var path = Path.Combine(documentsPath, sqliteFilename);//DB�t�@�C���̃p�X
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            return conn;
        }
    }
}
