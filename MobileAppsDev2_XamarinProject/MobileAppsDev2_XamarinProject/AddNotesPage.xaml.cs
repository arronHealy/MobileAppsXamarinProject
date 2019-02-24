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
	public partial class AddNotesPage : ContentPage
	{
        //validation vars
        private bool title, note;

		public AddNotesPage()
		{
			InitializeComponent();
            setDefaultValues();
		}

        //set default values method
        private void setDefaultValues()
        {
            title = note = false;
            saveButton.IsEnabled = false;
        }

        //override lifecycle method
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //enable delete button only when fields populated from selected list view
            if (titleField.Text != null && noteField.Text != null)
            {
                saveButton.Text = "Update Note";
                deleteButton.IsEnabled = true;
            }
            else
            {
                deleteButton.IsEnabled = false;
            }
        }

        //save note to database
        async void saveNoteClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Notes.SaveNote(note);
            await Navigation.PopAsync();
        }

        //delete note from database
        async void deleteNoteClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Notes.DeleteNote(note);
            await Navigation.PopAsync();
        }

        //validate text fields method
        private void NoteField_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            //check for title field text
            if (titleField.Text == "" || titleField.Text == null)
            {
                title = false;
                saveButton.IsEnabled = false;

                //error message display
                titleError.TextColor = Color.Red;
                titleError.FontAttributes = FontAttributes.Bold;
                titleError.Text = "Title Field is Required!";
            }
            else
            {
                //set if text is populated
                title = true;
                titleError.Text = "";
            }

            //check for notes content text
            if (noteField.Text == "" || noteField.Text == null)
            {
                note = false;
                saveButton.IsEnabled = false;

                //error message display
                noteError.TextColor = Color.Red;
                noteError.FontAttributes = FontAttributes.Bold;
                noteError.Text = "Note Field is Required!";
            }
            else
            {
                //set if text is populated
                note = true;
                noteError.Text = "";
            }

            //if fields populated enable save button
            if(title && note)
            {
                saveButton.IsEnabled = true;
            }
        }

        //cancel button click
        async void cancelClicked(object sender, EventArgs e)
        {
            //pop page
            await Navigation.PopAsync();
        }
    }
}