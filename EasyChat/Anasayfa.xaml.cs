using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static EasyChat.MainPage;

namespace EasyChat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Anasayfa : ContentPage
	{
		public Anasayfa ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
          string username=  GlobalVariables.GlobalMail;
             Navigation.PushAsync(new ChatPage(username,"1"));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
             Navigation.PushAsync(new ListViewPage1("1"));
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
             Navigation.PushAsync(new UserListViewPage());
        }
    }
}