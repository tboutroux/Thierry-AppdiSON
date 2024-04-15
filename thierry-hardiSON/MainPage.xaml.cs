using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace thierry_hardiSON
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        static async Task Main(string[] args)
        {
            // Créer une instance de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Effectuer la requête GET
                    HttpResponseMessage response = await client.GetAsync("https://sheets.googleapis.com/v4/spreadsheets/1vuF43Uu95LFAJRXDJdMAChIJoUkWvTNXOkjLcJIjFZk/values/datas!A1:B200?key=AIzaSyBBGVqSmebwDV-Hf7dd53VvXDiqknuVjw4");

                    // Vérifier si la requête a réussi
                    if (response.IsSuccessStatusCode)
                    {
                        // Lire le contenu de la réponse
                        string content = await response.Content.ReadAsStringAsync();

                        // Afficher le contenu de la réponse
                        Console.WriteLine(content);
                    }
                    else
                    {
                        // Afficher le code d'erreur
                        Console.WriteLine("Erreur HTTP: " + response.StatusCode);

                        // On envoie le message dans l'app
                        message.Text("Erreur HTTP: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs
                    Console.WriteLine("Erreur: " + ex.Message);

                    // On envoie le message dans l'app
                    await DisplayAlert("Erreur", "Erreur: " + ex.Message, "OK");
                }
            }
        }
    }

}
