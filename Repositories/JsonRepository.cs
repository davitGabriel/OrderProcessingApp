using OrderProcessingApp.Models;
using System.Text.Json;

namespace OrderProcessingApp.Repositories
{
    public class JsonRepository
    {
        public List<T> LoadData<T>(string fileName) where T : BaseEntity
        {
            try
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);

                if (!File.Exists(filePath))
                    return new List<T>();

                var json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading {fileName}: {ex.Message}");
                throw;
            }
        } 
    }
}
