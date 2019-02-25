
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
        private List<Contact> contactList;

		public ContactsListPage ()
		{
			InitializeComponent ();
		}

        private void NewContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddContactsPage());
        }

        //override lifecycle method
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //populate list from database
            contactList = await App.Contacts.GetContactsList();

            //check if database has items display message to page 
            if (contactList.Count == 0)
            {
                listHeader.Text = "No Contacts Saved Yet! Click Toolbar Tab to Create New Note...";
            }
            else
            {
                listHeader.Text = "Contacts - " + contactList.Count + " Currently Saved";
            }

            //assign list items to xaml list view
            listView.ItemsSource = contactList;

        }

        async void OnContactAdded(object sender, EventArgs e)
        {
            //push new contacts page bind new contact object
            await Navigation.PushAsync(new AddContactsPage
            {
                BindingContext = new Contact()
            });
        }

        async void OnListContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //check selected list view item not empty
            if (e.SelectedItem != null)
            {
                //push new contacts page bind selected list view item as contact object
                await Navigation.PushAsync(new AddContactsPage
                {
                    BindingContext = e.SelectedItem as Contact
                });
            }
        }
    }
}