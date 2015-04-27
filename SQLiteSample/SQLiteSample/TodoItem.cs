using System;
using SQLite.Net.Attributes;

namespace SQLiteSample{
    public class TodoItem{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }//作成日時
        public bool Delete { get; set; }//削除フラグ(trueの時、表示しない)
    }
}
