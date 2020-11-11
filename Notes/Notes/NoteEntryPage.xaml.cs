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

        /// <summary>
        /// Salvar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.FileName))
            {
                //Save
                string fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");

                File.WriteAllText(fileName, note.Text);
            }
            else
            {
                //Update
                File.WriteAllText(note.FileName, note.Text);
            }

            //Retirar a NoteEntryPage da pilha de páginas.
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Excluir nota.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;

            if(File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }

            //Retirar a NoteEntryPage da pilha de páginas.
            await Navigation.PopAsync();
        }
    }
}