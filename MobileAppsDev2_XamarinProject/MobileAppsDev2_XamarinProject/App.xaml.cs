
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileAppsDev2_XamarinProject
{
    public partial class App : Application
    {
        //database variables
        static ContactDB contacts;

        static NoteDB notes;
        
        public App()
        {
            InitializeComponent();

            //set main page as navigation page
            MainPage = new NavigationPage(new MainPage());
        }

        //set database variable for contacts
        public static ContactDB Contacts
        {
            get
            {
                if (contacts == null)
                {
                    //new database if null
                    contacts = new ContactDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contacts.db3"));
                }

                return contacts;
            }
            
        }

        //set database for notes
        public static NoteDB Notes
        {
            get
            {
                if(notes == null)
                {
                    //new database if null
                    notes = new NoteDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NotesDB.db3"));
                }

                return notes;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
