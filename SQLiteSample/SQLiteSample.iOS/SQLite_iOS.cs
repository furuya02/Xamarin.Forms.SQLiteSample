using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using SQLiteSample.iOS;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLite_iOS))]
namespace SQLiteSample.iOS{
    public class SQLite_iOS : ISQLite{
        public SQLiteConnection GetConnection(){
            const string sqliteFilename = "TodoSQLite.db3"; //データベース名
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //Documentsフォルダ            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // ライブラリフォルダ
            var path = Path.Combine(libraryPath, sqliteFilename);//DBファイルのパス
            var plat = new SQLitePlatformIOS();
            var conn = new SQLiteConnection(plat, path);
            return conn;
        }
    }
}