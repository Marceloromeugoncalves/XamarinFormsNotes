using Notes.Models;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.FileName))
            {
                //Save
                var fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");

                File.WriteAllText(fileName, note.Text);
            }
            else
            {
                //Update
                File.WriteAllText(note.FileName, note.Text);
            }

            await Navigation.PopAsync();
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if(File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }

            await Navigation.PopAsync();
        }
    }
}