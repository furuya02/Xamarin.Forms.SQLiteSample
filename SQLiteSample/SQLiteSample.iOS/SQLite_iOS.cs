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
            const string sqliteFilename = "TodoSQLite.db3"; //�f�[�^�x�[�X��
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //Documents�t�H���_            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // ���C�u�����t�H���_
            var path = Path.Combine(libraryPath, sqliteFilename);//DB�t�@�C���̃p�X
            var plat = new SQLitePlatformIOS();
            var conn = new SQLiteConnection(plat, path);
            return conn;
        }
    }
}