using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UiBot
{
    public class TraderResetInfoService
    {
        private const string BaseUrl = "https://api.tarkov.dev/graphql"; 
        private const string JsonFileName = "resetTime.json"; // JSON file name

        public async Task<string> GetAndSaveTraderResetInfoWithLatest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Define a GraphQL query to get trader reset times
                var query = @"
            query {
                traders {
                    name
                    resetTime
                }
            }";

                var requestData = new
                {
                    query
                };

                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        // Update the JSON file with the new response data (replacing the old data)
                        UpdateJsonDataInFile(JsonFileName, responseData);

                        return responseData;
                    }
                    else
                    {
                        string errorData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Failed to execute GraphQL query. Status code: {response.StatusCode}");
                        Console.WriteLine($"Error message: {errorData}");
                        return $"Failed to execute GraphQL query. Status code: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while executing the GraphQL query: {ex.Message}");
                    return $"An error occurred while executing the GraphQL query: {ex.Message}";
                }
            }
        }

        private void UpdateJsonDataInFile(string fileName, string data)
        {
            try
            {
                // Overwrite the data in the JSON file with the new data
                File.WriteAllText(fileName, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data in JSON file: {ex.Message}");
            }
        }

        public string ReadJsonDataFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    // Read data from the JSON file
                    return File.ReadAllText(fileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading data from JSON file: {ex.Message}");
                }
            }

            return null;
        }

        private void WriteJsonDataToFile(string fileName, string data)
        {
            try
            {
                // Write data to the JSON file
                File.WriteAllText(fileName, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing data to JSON file: {ex.Message}");
            }
        }

        public class TraderResetResponse
        {
            public TraderData Data { get; set; }
        }

        public class TraderData
        {
            public List<TraderResetInfo> Traders { get; set; }
        }

        public class TraderResetInfo
        {
            public string Name { get; set; }
            public string ResetTime { get; set; }

            public DateTime GetLocalResetTime()
            {
                // Parse the reset time as a DateTime in UTC
                if (DateTime.TryParse(ResetTime, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime resetDateTime))
                {
                    // Get the local time zone
                    TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

                    // Convert the reset time from UTC to local time
                    return TimeZoneInfo.ConvertTimeFromUtc(resetDateTime, localTimeZone);
                }

                // Return DateTime.MinValue in case of parsing failure
                return DateTime.MinValue;
            }
        }
    }
}
