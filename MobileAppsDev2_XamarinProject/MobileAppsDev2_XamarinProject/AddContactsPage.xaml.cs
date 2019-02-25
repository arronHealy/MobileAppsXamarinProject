
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
        private bool name, number, email, address; 

		public AddContactsPage ()
		{
			InitializeComponent ();
            setDefaultValues();
		}

        //set default values method
        private void setDefaultValues()
        {
            name = number = email = address = false;
            saveButton.IsEnabled = false;
        }

        //override lifecycle method
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //enable delete button only when fields populated from selected list view
            if (nameField.Text != null && phoneNumberField.Text != null && emailField.Text != null && addressField.Text != null)
            {
                saveButton.Text = "Update Contact";
                deleteButton.IsEnabled = true;
            }
            else
            {
                deleteButton.IsEnabled = false;
            }
        }

        //validate text fields method
        private void NameField_TextChanged(object sender, TextChangedEventArgs e)
        {

            //check for name field text
            if (nameField.Text == "" || nameField.Text == null)
            {
                name = false;
                saveButton.IsEnabled = false;

                //error message display
                nameError.TextColor = Color.Red;
                nameError.FontAttributes = FontAttributes.Bold;
                nameError.Text = "Name Field is Required!";
            }
            else
            {
                //set if text is populated
                name = true;
                nameError.Text = "";
            }

            //check for phone number text
            if (phoneNumberField.Text == "" || phoneNumberField.Text == null)
            {
                number = false;
                saveButton.IsEnabled = false;

                //error message display
                phoneNumberError.TextColor = Color.Red;
                phoneNumberError.FontAttributes = FontAttributes.Bold;
                phoneNumberError.Text = "Phone Number Field is Required!";
            }
            else
            {
                //set if text is populated
                number = true;
                phoneNumberError.Text = "";
            }

            //check for notes content text
            if (emailField.Text == "" || emailField.Text == null)
            {
                email = false;
                saveButton.IsEnabled = false;

                //error message display
                emailError.TextColor = Color.Red;
                emailError.FontAttributes = FontAttributes.Bold;
                emailError.Text = "Email Field is Required!";
            }
            else
            {
                //set if text is populated
                email = true;
                emailError.Text = "";
            }

            //check for address text
            if (addressField.Text == "" || addressField.Text == null)
            {
                address = false;
                saveButton.IsEnabled = false;

                //error message display
                addressError.TextColor = Color.Red;
                addressError.FontAttributes = FontAttributes.Bold;
                addressError.Text = "Address Field is Required!";
            }
            else
            {
                //set if text is populated
                address = true;
                addressError.Text = "";
            }

            //if fields populated enable save button
            if (name && number && email && address)
            {
                saveButton.IsEnabled = true;
            }
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