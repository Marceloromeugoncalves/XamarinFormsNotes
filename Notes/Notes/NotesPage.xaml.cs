using Notes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //Chamar o On Appering da classe base.
            base.OnAppearing();

            //Instanciar uma lista de notas.
            List<Note> notes = new List<Note>();

            //Obter a lista de arquivos.
            IEnumerable<string> files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");

            //Para cada arquivo instanciar um objeto Note.
            foreach (string fileName in files)
            {
                notes.Add(new Note
                {
                    //Obter o nome do arquivo.
                    FileName = fileName,

                    //Obter o texto do arquivo.
                    Text = File.ReadAllText(fileName),

                    //Obter a data de criação do arquivo.
                    Date = File.GetCreationTime(fileName)
                });
            }

            //Exibir na listView as notas ordenadas pela data.
            listView.ItemsSource = notes.OrderBy(d => d.Date).ToList();
        }

        /// <summary>
        /// Adicionar nota.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            //Inserir NoteEntryPage na pilha de páginas.
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        /// <summary>
        /// Seleção de item da lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //Inserir NoteEntryPage na pilha de páginas.
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}