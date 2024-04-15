using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Cr�er une instance de HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Effectuer la requ�te GET
                HttpResponseMessage response = await client.GetAsync("https://sheets.googleapis.com/v4/spreadsheets/1vuF43Uu95LFAJRXDJdMAChIJoUkWvTNXOkjLcJIjFZk/values/datas!A1:B200?key=AIzaSyBBGVqSmebwDV-Hf7dd53VvXDiqknuVjw4");

                // V�rifier si la requ�te a r�ussi
                if (response.IsSuccessStatusCode)
                {
                    // Lire le contenu de la r�ponse
                    string content = await response.Content.ReadAsStringAsync();

                    // Afficher le contenu de la r�ponse
                    Console.WriteLine(content);
                }
                else
                {
                    // Afficher le code d'erreur
                    Console.WriteLine("Erreur HTTP: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // G�rer les erreurs
                Console.WriteLine("Erreur: " + ex.Message);
            }
        }
    }
}
