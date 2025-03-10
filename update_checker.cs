using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string currentVersion = "2025.03.08.002";
        string latestVersion = await CheckForUpdatesAsync();

        if (latestVersion != currentVersion)
        {
            Console.WriteLine($"A new version {latestVersion} is available. Please update!");
        }
        else
        {
            Console.WriteLine("You are using the latest version.");
        }
    }

    static async Task<string> CheckForUpdatesAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("https://api.fakeapi.com/latest-version");
            response.EnsureSuccessStatusCode();
            string latestVersion = await response.Content.ReadAsStringAsync();
            return latestVersion;
        }
    }
}
