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
		public NotesListPage ()
		{
			InitializeComponent ();
		}

        private void NewNote_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNotesPage());
        }
    }
}