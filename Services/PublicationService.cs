using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ABCPublishers.Models;

public class PublicationService
{
    private readonly IWebHostEnvironment _environment;

    public PublicationService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<Publication> LoadPublicationAsync()
    {
        // Use a relative path based on the root of the project
        var filePath = Path.Combine(_environment.ContentRootPath, "Data", "Publications.json");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' was not found.");
        }

        var json = await File.ReadAllTextAsync(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<Publication>(json, options);
    }
}