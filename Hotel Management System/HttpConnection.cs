using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;

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

        public async Task<HttpData> GetRoomList()
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

                    string jsonPayload = "{\"business_type\":\"hotel\"}";
                    HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/products/list", content);

                    var responseContent = await response.Content.ReadAsStringAsync() ;
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
            } catch (HttpRequestException ex)
            {
                resultData.status= false;
                resultData.message = ex.Message;
            }
            return resultData;
        }
        public async Task<HttpData> GetReservationList(string date = null)
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

                    dynamic content = null;

                    if (date != null)
                    {
                        var valContent = new Dictionary<string, string>();
                        valContent.Add("date", date);
                    }

                    HttpResponseMessage response = await client.GetAsync(BaseUrl + "/hotel/reservasi/list");

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
        public async Task<HttpData> GetCustomerList(string search = "")
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

                    var valContent = new Dictionary<string, string>();
                    valContent.Add("hotel", "1");
                    valContent.Add("q", search);

                    var content = new FormUrlEncodedContent(valContent);

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/customers", content);

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

        public async Task<HttpData> StoreCustomer(
            string type, 
            string name, 
            string phone, 
            string nik,
            string address_line_1 = null,
            string city = null,
            string state= null,
            string id = null
        )
        {

            HttpData resultData = new HttpData();

            resultData.status = false;
            resultData.message = "";

            if(
                (
                    type == "update" ||
                    type == "delete"
                ) &&
                id == null
            )
            {
                resultData.message = "ID tidak ada...";
                return resultData;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string token = Properties.Settings.Default.Token;
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var valContent = new Dictionary<string, string>();
                    valContent.Add("name", name);
                    valContent.Add("mobile", phone);
                    valContent.Add("address_line_1", address_line_1 ?? "");
                    valContent.Add("city", city ?? "");
                    valContent.Add("state", state ?? "");
                    valContent.Add("nik", nik ?? "");

                    switch (type)
                    {
                        case "update":
                            valContent.Add("id", id);
                            valContent.Add("update", "1");
                            break;
                        case "delete":
                            valContent.Add("id", id);
                            valContent.Add("delete", "1");
                            break;
                        default:
                            valContent.Add("insert", "1");
                            break;
                    }


                    var content = new FormUrlEncodedContent(valContent);

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/customers/store", content);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {

                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.message = data.message;
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

        public async Task<HttpData> GetOTAList()
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

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/hotel/ota", null);

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
        public async Task<HttpData> GetPaymentList()
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

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/hotel/payment", null);

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
        public async Task<HttpData> StoreCheckin(string contact_id, string lamainap, string room_product_id, string harga_total, string payment_amount, string payment_method, string ota, string deposit, string staff_note="")
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

                    // Calculate deposit from payment_amount - harga_total
                    //int deposit = int.Parse(payment_amount) - int.Parse(harga_total);

                    // Construct JSON payload
                    var payload = new
                    {
                        hotel = 1,
                        print = 1,
                        is_direct_sale = 1,
                        location_id = 0,
                        sub_type = (string)null,
                        contact_id,
                        search_product = (object)null,
                        pay_term_number = int.Parse(lamainap),
                        pay_term_type = "days",
                        price_group = 0,
                        sell_price_tax = "includes",
                        products = new[] {
                    new {
                        quantity = 1,
                        product_id = room_product_id,
                        name = "Room 101",
                        type = "single",
                        enable_stock = 0,
                        product_type = "single",
                        variation_id = 17469,
                        selling_price = "200.000",
                        unit_price = "200000.0000",
                        unit_price_inc_tax = "200000.0000",
                        sub_sku = "101",
                        unit = "Unit"
                    }
                },
                        discount_type = "percentage",
                        discount_amount = 0.00,
                        rp_redeemed = 0,
                        rp_redeemed_amount = 0,
                        tax_rate_id = (object)null,
                        tax_calculation_amount = 0.00,
                        shipping_details = (object)null,
                        shipping_address = (object)null,
                        shipping_status = (object)null,
                        delivered_to = (object)null,
                        shipping_charges = 0.00,
                        advance_balance = 0.0000,
                        payment = new[] {
                    new {
                        amount = payment_amount,
                        method = "cash",
                        card_number = "",
                        card_holder_name = "",
                        card_transaction_number = "",
                        card_type = "",
                        card_month = "",
                        card_year = "",
                        card_security = "",
                        cheque_number = "",
                        bank_account_number = "",
                        transaction_no_1 = "",
                        transaction_no_2 = "",
                        transaction_no_3 = "",
                        note = ""
                    }
                },
                        sale_note = "",
                        staff_note,
                        change_return = 0.00,
                        additional_notes = "",
                        is_suspend = 0,
                        recur_interval = 1,
                        recur_interval_type = "days",
                        recur_repetitions = (object)null,
                        subscription_repeat_on = "",
                        is_enabled_stock = (object)null,
                        is_credit_sale = 0,
                        final_total = harga_total,
                        discount_type_modal = "percentage",
                        discount_amount_modal = 0.00,
                        rp_redeemed_modal = (object)null,
                        order_tax_modal = (object)null,
                        shipping_details_modal = (object)null,
                        shipping_address_modal = (object)null,
                        shipping_charges_modal = 0,
                        shipping_status_modal = (object)null,
                        delivered_to_modal = (object)null,
                        status = "final",
                        service_custom_field_1 = payment_method,
                        service_custom_field_2 = ota,
                        service_custom_field_3 = deposit.ToString()
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/pos", content);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.message = data.message;
                        resultData.data = data.data;

                        Console.WriteLine(data);
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
        public async Task<HttpData> UpdateCheckin(string id, string amount, string productId, string notes, string service_custom_field_3)
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

                    // Calculate deposit from payment_amount - harga_total
                    //int deposit = int.Parse(payment_amount) - int.Parse(harga_total);

                    // Construct JSON payload
                    var payload = new
                    {
                        id,
                        amount,
                        productId,
                        notes,
                        service_custom_field_3
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/hotel/reservasi/store", content);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.message = data.message;
                        resultData.data = data.data;

                        Console.WriteLine(data);
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
        public async Task<HttpData> StoreReservation(string harga, string checkin, string checkout, string durasi, string contact_id, string ota)
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

                    // Calculate deposit from payment_amount - harga_total
                    //int deposit = int.Parse(payment_amount) - int.Parse(harga_total);

                    // Construct JSON payload
                    var payload = new
                    {
                        insert = 1,
                        harga,
                        checkin,
                        checkout,
                        durasi,
                        contact_id,
                        ota
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/hotel/reservasi/store", content);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.message = data.message;
                        resultData.data = data.data;

                        Console.WriteLine(data);
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
        public async Task<HttpData> UpdateReservation(string harga, string checkin, string checkout, string durasi, string contact_id, string ota)
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

                    // Calculate deposit from payment_amount - harga_total
                    //int deposit = int.Parse(payment_amount) - int.Parse(harga_total);

                    // Construct JSON payload
                    var payload = new
                    {
                        update = 1,
                        harga,
                        checkin,
                        checkout,
                        durasi,
                        contact_id,
                        ota
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/hotel/reservasi/store", content);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.message = data.message;
                        resultData.data = data.data;

                        Console.WriteLine(data);
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
        public async Task<HttpData> GetCheckinList(string date = null,string status = null)
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

                    dynamic content = null;

                    if (date != null)
                    {
                        var valContent = new Dictionary<string, string>();
                        valContent.Add("date", date);
                        if(status != null)
                        {
                            valContent.Add("status", status);
                        }
                        content = new FormUrlEncodedContent(valContent);
                    }

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/checkin/list", content);

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


        public async Task<HttpData> StoreCheckout(string id, string amount, string notes, string depositReturn)
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

                    var valContent = new Dictionary<string, string>();
                    valContent.Add("id", id);
                    valContent.Add("amount", amount);
                    valContent.Add("notes", notes);
                    valContent.Add("deposit_return", depositReturn);

                    var content = new FormUrlEncodedContent(valContent);

                    HttpResponseMessage response = await client.PostAsync(BaseUrl + "/checkout/store", content);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {

                        dynamic data = JsonConvert.DeserializeObject(responseContent);
                        resultData.status = data.status;
                        resultData.data = data.data;
                        resultData.message = data.message;

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
