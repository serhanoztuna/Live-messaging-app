using EasyChat.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyChat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
	    ChatPageViewModel vm;
        string uname = "" ,targetnm= "";
        readonly ServiceManager manager = new ServiceManager();
        public ChatPage (string username,string targetname)
		{
			InitializeComponent ();
            targetnm = targetname;
            uname = username;
            BindingContext = vm = new ChatPageViewModel(username);
		}
  
        private void Button_Clicked(object sender, EventArgs e)
        {
            var collection =  manager.GetAdd(uname, txtMessage.Text, targetnm);
        }

      
    }
}