
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Contacts.GetContactsList();
        }

        async void OnContactAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContactsPage
            {
                BindingContext = new Contact()
            });
        }

        async void OnListContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddContactsPage
                {
                    BindingContext = e.SelectedItem as Contact
                });
            }
        }
    }
}