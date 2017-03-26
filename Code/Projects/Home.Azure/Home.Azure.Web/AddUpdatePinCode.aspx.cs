using Home.Azure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Home.Azure.Web
{
    public partial class AddUpdatePinCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddUpdatePinCode_Click(object sender, EventArgs e)
        {
            Weather w = GetWeather(txtCity.Text);

            StringBuilder sb = new StringBuilder();

            sb.Append("Name: " + w.location.name + "<br/>");
            sb.Append("Region: " + w.location.region + "<br/>");
            sb.Append("Country: " + w.location.country + "<br/>");
            sb.Append("Time Zone: " + w.location.tz_id + "<br/>");
            sb.Append("Local Time: " + w.location.localtime + "<br/>");
            sb.Append("<br/>");
            sb.Append("Temperature (Celcius): " + w.current.temp_c + "<br/>");
            sb.Append("Condition: " + w.current.condition.text + "<br/>");
            sb.Append("Wind Direction: " + w.current.wind_dir + "<br/>");
            sb.Append("Wind Speed (Kmhr): " + w.current.wind_kph + "<br/>");

            lblMessage.Text = sb.ToString();
        }

        public Weather GetWeather(string city)
        {
            Weather weather = new Weather();

            try
            {
                if (string.IsNullOrEmpty(txtCity.Text))
                {
                    lblMessage.Text = "Please enter city!";
                    return weather;
                }

                string url = "http://api.apixu.com/v1/current.json?key=eb2a0633229b456ba6093557151106&q=" +
                    txtCity.Text;

                string weatherinfo = string.Empty;
                string urlParameters = "";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    weatherinfo = response.Content.ReadAsStringAsync().Result;

                }
                else
                {
                    weatherinfo = "No weather information found!";
                }

                weather = Newtonsoft.Json.JsonConvert.DeserializeObject<Weather>(weatherinfo);

                
                //{"location":{"name":"Mumbai","region":"Maharashtra","country":"India","lat":18.98,"lon":72.83,"tz_id":"Asia/Kolkata","localtime_epoch":1488642712,"localtime":"2017-03-04 21:21"},"current":{"last_updated_epoch":1488642712,"last_updated":"2017-03-04 21:21","temp_c":27.0,"temp_f":80.6,"is_day":0,"condition":{"text":"Overcast","icon":"//cdn.apixu.com/weather/64x64/night/122.png","code":1009},"wind_mph":5.6,"wind_kph":9.0,"wind_degree":310,"wind_dir":"NW","pressure_mb":1008.0,"pressure_in":30.2,"precip_mm":0.0,"precip_in":0.0,"humidity":62,"cloud":0,"feelslike_c":28.5,"feelslike_f":83.3,"vis_km":3.0,"vis_miles":1.0}}
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

            return weather;
        }
    }
}