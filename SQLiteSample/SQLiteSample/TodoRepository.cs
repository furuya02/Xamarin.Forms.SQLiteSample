using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace SQLiteSample{
    class TodoRepository{
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public TodoRepository(){
			_db = DependencyService.Get<ISQLite> ().GetConnection ();//データベース接続
			_db.CreateTable<TodoItem>();//テーブル作成
		}
        //一覧
        public IEnumerable<TodoItem> GetItems(){
            lock (Locker){
                
                //Delete==falseの一覧を取得する(削除フラグが立っているものは対象外)
                return _db.Table<TodoItem>().Where(m => m.Delete == false);
            }
        }
        //更新・追加
        public int SaveItem(TodoItem item){
            lock (Locker){
                if (item.ID != 0){//IDが0で無い場合は、更新
                    _db.Update(item);
                    return item.ID;
                }
                return _db.Insert(item);//追加
            }
        }
    }
}
