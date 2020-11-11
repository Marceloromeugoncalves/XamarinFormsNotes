using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    public partial class App : Application
    {
        /// <summary>
        /// Caminho do diretório Local Application Data.
        /// </summary>
        public static string FolderPath { get; set; }

        public App()
        {
            InitializeComponent();

            //Obter o local application data.
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            //Definir NotesPage como página principal.
            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
