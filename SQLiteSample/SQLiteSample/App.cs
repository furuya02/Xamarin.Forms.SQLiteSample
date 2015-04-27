using System;
using Xamarin.Forms;

namespace SQLiteSample
{
    public class App : Application{
        public App(){
            MainPage = new MyPage();
        }
        protected override void OnStart(){}
        protected override void OnSleep(){}
        protected override void OnResume(){}
    }
    class MyPage : ContentPage{

        readonly TodoRepository _db = new TodoRepository();

        public MyPage(){
            
            //データ表示用リストボックス
            var listView = new ListView{
                ItemsSource = _db.GetItems(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Text");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, new Binding("CreatedAt", stringFormat: "{0:yyy/MM/dd hh:mm}"));
            listView.ItemTapped += async (s, a) =>{//リストがタップされた時の処理
                var item = (TodoItem)a.Item;
                if (await DisplayAlert("削除してい宜しいですか", item.Text, "OK", "キャンセル")){
                    item.Delete = true;//削除フラグを有効にして
                    _db.SaveItem(item);//DB更新
                    listView.ItemsSource = _db.GetItems();//リスト更新
                }
            };
            //文字列入力
            var entry = new Entry{
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            //追加ボタン
            var buttonAdd = new Button{
                WidthRequest = 60,
                TextColor = Color.White,
                Text = "Add"
            };
            buttonAdd.Clicked += (s, a) =>{//追加ボタンが押された時の処理
                if (!String.IsNullOrEmpty(entry.Text)){//Entryに文字列が入力されている場合に処理する
                    var item = new TodoItem { Text = entry.Text, CreatedAt = DateTime.Now, Delete = false };
                    _db.SaveItem(item);
                    listView.ItemsSource = _db.GetItems();//リスト更新
                    entry.Text = "";
                }
            };

            Content = new StackLayout{
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children = {
                    new StackLayout {
                        BackgroundColor = Color.Navy,//入力部の背景色はネイビー
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {entry, buttonAdd}//Entryコントロールとボタンコントロールを横に並べる
                    },
                    listView//その下にリストボックスを置く
                }
            };
        }

    }
}
