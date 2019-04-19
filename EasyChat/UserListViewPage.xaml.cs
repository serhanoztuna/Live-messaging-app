using EasyChat.Models;
using EasyChat.Provider;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static EasyChat.MainPage;

namespace EasyChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListViewPage : ContentPage
    { 
      
        readonly ServiceManager manager = new ServiceManager();

        public ObservableCollection<string> Items { get; set; }

        public UserListViewPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            LoadData();
        }
        private async void LoadData()
        {
            var collection = await manager.UserList();

            MyListView.ItemsSource = collection;
        }
        string usnm = "";
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selecteditem = e.Item;
            User collection = (User)selecteditem;
           usnm = collection.Username;
            ShowExitDialog(usnm);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        private async void ShowExitDialog(string targetusnm)
        {
            var answer = await DisplayAlert("Seçim", "Geçmiş Konuşma(1) Konuşma Başlatmak için(2)?", "1", "2");
            if (answer == true)
            {
                Navigation.PushAsync(new ListViewPage1(targetusnm));

            }
            else
            {
                string myusername= GlobalVariables.GlobalMail;
                Navigation.PushAsync(new ChatPage(myusername, usnm));

            }
        }
    }
}
