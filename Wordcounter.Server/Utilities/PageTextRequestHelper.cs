public class PageTextRequestHelper
{
    public static async Task<string> GetTextAsync(string url)
    {
        var clien = new HttpClient();

        clien.BaseAddress = new Uri(url);

        var text = await clien.GetStringAsync(string.Empty);

        return text;
    }
}