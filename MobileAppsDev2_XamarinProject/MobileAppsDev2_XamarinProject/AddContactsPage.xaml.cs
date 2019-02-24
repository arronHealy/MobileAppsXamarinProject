
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
	public partial class AddContactsPage : ContentPage
	{
		public AddContactsPage ()
		{
			InitializeComponent ();
		}

        async void saveContactClicked(object sender, EventArgs e)
        {
            var contact = (Contact)BindingContext;
            await App.Contacts.SaveContact(contact);
            await Navigation.PopAsync();
        }

        async void deleteContactClicked(object sender, EventArgs e)
        {
            var contact = (Contact)BindingContext;
            await App.Contacts.DeleteContact(contact);
            await Navigation.PopAsync();
        }

        async void cancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}