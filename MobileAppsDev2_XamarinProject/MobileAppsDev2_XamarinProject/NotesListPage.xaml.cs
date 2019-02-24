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
    public partial class NotesListPage : ContentPage
    {
        private List<Note> noteList;

        public NotesListPage()
        {
            InitializeComponent();
        }

        //override lifecycle method
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //populate list from database
            noteList = await App.Notes.GetNotesList();

            //check if database has items display message to page 
            if(noteList.Count == 0)
            {
                listHeader.Text = "No Notes Saved Yet! Click Toolbar Tab to Create New Note...";  
            }
            else
            {
                listHeader.Text = "Notes - " + noteList.Count + " Currently Saved";
            }

            //assign list items to xaml list view
            listView.ItemsSource = noteList;

        }


        async void OnNoteAdded(object sender, EventArgs e)
        {
            //push new notes page bind new note object 
            await Navigation.PushAsync(new AddNotesPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListNoteSelected(object sender, SelectedItemChangedEventArgs e)
        {
           //check selected list view item not empty
            if (e.SelectedItem != null)
            {
                //push new notes page bind selected list view item as note object
                await Navigation.PushAsync(new AddNotesPage
                {
                    BindingContext = e.SelectedItem as Note
                });

            }
        }

        
    }
}