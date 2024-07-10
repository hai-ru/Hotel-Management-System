using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ApiResponse
{
    public bool status { get; set; }
    public string message { get; set; }

    [System.Text.Json.Serialization.JsonConverter(typeof(DataConverter))]
    public Data data { get; set; }
}

public class Data
{
    public string token { get; set; }
}

public class DataConverter : System.Text.Json.Serialization.JsonConverter<HttpData>
{
    public override HttpData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            // Deserialize as Data object
            return System.Text.Json.JsonSerializer.Deserialize<HttpData>(ref reader, options);
        }
        else if (reader.TokenType == JsonTokenType.StartArray)
        {
            // Skip the array (empty array case)
            reader.Skip();
            return null;
        }

        throw new System.Text.Json.JsonException();
    }

    public override void Write(Utf8JsonWriter writer, HttpData value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Serialization not implemented.");
    }
}

public class HttpData
{
    public Boolean status { get; set; }
    public String message { get; set; }

    public dynamic data { get; set; }
}

namespace Hotel_Management_System
{
    internal class HttpConnection
    {

        private const string BaseUrl = "https://development.norapos.com/api";

        public async Task<HttpData> GetAccessToken(string username, string password)
        {

            HttpData resultData = new HttpData();

            resultData.status = false;
            resultData.message = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

                    HttpResponseMessage response = await client.PostAsync(BaseUrl+"/login", content);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {

                        dynamic data = JsonConvert.DeserializeObject(responseContent);

                        resultData.data = data;
                        resultData.status = data.status;
                        if (resultData.status)
                        {
                            resultData.message = data.data.token;
                        } else
                        {
                            resultData.message = data.message;
                        }

                    }
                    catch (Newtonsoft.Json.JsonException ex)
                    {
                        resultData.status = false;
                        resultData.message = ex.Message;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                resultData.status = false;
                resultData.message = ex.Message;
            }

            return resultData;
        }

        public async Task<HttpData> GetHotelDetails()
        {

            HttpData resultData = new HttpData();

            resultData.status = false;
            resultData.message = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string token = Properties.Settings.Default.Token;
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.PostAsync(BaseUrl+ "/business", null);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {

                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.data = data.data;

                    }
                    catch (Newtonsoft.Json.JsonException ex)
                    {
                        resultData.status = false;
                        resultData.message = ex.Message;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                resultData.status = false;
                resultData.message = ex.Message;
            }

            return resultData;
        }

        public async Task<HttpData> GetCustomerList()
        {

            HttpData resultData = new HttpData();

            resultData.status = false;
            resultData.message = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string token = Properties.Settings.Default.Token;
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/customers", null);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {

                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.data = data.data;

                    }
                    catch (Newtonsoft.Json.JsonException ex)
                    {
                        resultData.status = false;
                        resultData.message = ex.Message;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                resultData.status = false;
                resultData.message = ex.Message;
            }

            return resultData;
        }

        
    }


}
