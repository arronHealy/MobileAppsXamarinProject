using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppsDev2_XamarinProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsListPage : ContentPage
	{
		public ContactsListPage ()
		{
			InitializeComponent ();
		}

        private void NewContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddContactsPage());
        }
    }
}