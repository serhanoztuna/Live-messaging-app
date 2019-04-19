using EasyChat.Models;
using EasyChat.Provider;
using System;
using System.Collections.Generic;
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
    public partial class ListViewPage1 : ContentPage
    {
        string tname = "";
        readonly ServiceManager manager = new ServiceManager();

        public ObservableCollection<string> Items { get; set; }

        public ListViewPage1(string targetname)
        {
            InitializeComponent();
            tname = targetname;
            Items = new ObservableCollection<string>
            {
                "Selam",
                "Merhaba",
                "Item 3",
                "Item 4",
                "Item 5"
            };
            LoadData(tname);
        }
        private async void LoadData(string targetname)
        {
            
            var collection = await manager.GetList(targetname, GlobalVariables.GlobalMail);

            MyListView.ItemsSource = collection;
        }
            async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
