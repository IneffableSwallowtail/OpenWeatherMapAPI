using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using static System.Net.WebRequestMethods;
//Put in logic so user can enter a city

var client = new HttpClient();
string city = "Boston";
string stateCode = "MA";
string countryCode = "US";

//string geocodingURL = $"http://api.openweathermap.org/geo/1.0/direct?q={city},{stateCode},{countryCode}&limit=5&appid=116e26889fc49d48d20ee9e826a3d127";
//var response = client.GetStringAsync(geocodingURL).Result;

//var bostonLat = response["lat"];
//String keyVal = jsn.getString("key1");
//"lat":42.3554334,"lon":-71.060511,
//String value = (String)getKey(array, "key1")

//var bostonCoords = JObject.Parse(response).GetValue("coord").ToString(0);
//how to do it when there is an object named "coord"

string weatherCall = "https://api.openweathermap.org/data/2.5/weather?lat=42.3554334&lon=-71.060511&appid=116e26889fc49d48d20ee9e826a3d127";
var response = client.GetStringAsync(weatherCall).Result;
var coord = JObject.Parse(response).GetValue("coord");
var weather = JObject.Parse(response).GetValue("weather");
var main = JObject.Parse(response).GetValue("main");
var wind = JObject.Parse(response).GetValue("wind");
var weatherCallObject = JObject.Parse(response);

string weatherMain = weatherCallObject["weather"][0]["main"].ToString();
string description = weatherCallObject["weather"][0]["description"].ToString();
double tempKelvin = main.Value<double>("temp");
double tempFahrenheit = (tempKelvin - 273.15) * 9 / 5 + 32;
double feelsLikeKelvin = main.Value<double>("feels_like");
double feelsLikeFahrenheit = (feelsLikeKelvin - 273.15) * 9 / 5 + 32;
double tempMinKelvin = main.Value<double>("temp_min");
double tempMinFahrenheit = (tempMinKelvin - 273.15) *9 / 5 + 32;
double tempMaxKelvin = main.Value<double>("temp_max");
double tempMaxFahrenheit = (tempMaxKelvin - 273.15) * 9 / 5 + 32;
string humidity = main.Value<string>("humidity");
string windSpeed = wind.Value<string>("speed");
double windDeg = wind.Value<double>("deg");
string direction;
if (windDeg > 348.75 && windDeg <= 11.25) direction = "N";
else if (windDeg > 11.25 && windDeg <= 33.75) direction = "NNE";
else if (windDeg > 33.75 && windDeg <= 56.25) direction = "NE";
else if (windDeg > 56.25 && windDeg <= 78.75) direction = "ENE";
else if (windDeg > 78.75 && windDeg <= 101.25) direction = "E";
else if (windDeg > 101.25 && windDeg <= 123.75) direction = "ESE";
else if (windDeg > 123.75 && windDeg <= 146.25) direction = "SE";
else if (windDeg > 146.25 && windDeg <= 168.75) direction = "SSE";
else if (windDeg > 168.75 && windDeg <= 191.25) direction = "S";
else if (windDeg > 191.25 && windDeg <= 213.75) direction = "SSW";
else if (windDeg > 213.75 && windDeg <= 236.25) direction = "SW";
else if (windDeg > 236.25 && windDeg <= 258.75) direction = "WSW";
else if (windDeg > 258.75 && windDeg <= 281.25) direction = "W";
else if (windDeg > 281.25 && windDeg <= 303.75) direction = "WNW";
else if (windDeg > 303.75 && windDeg <= 326.25) direction = "NW";
else if (windDeg > 326.25 && windDeg <= 348.75) direction = "NNW";
else direction = "";
var name = JObject.Parse(response).GetValue("name").ToString();

//NNE 11.25 - 33.75
//NE 33.75 - 56.25
//ENE 56.25 - 78.75
//E 78.75 - 101.25
//ESE 101.25 - 123.75
//SE 123.75 - 146.25
//SSE 146.25 - 168.75
//S 168.75 - 191.25
//SSW 191.25 - 213.75
//SW 213.75 - 236.25
//WSW 236.25 - 258.75
//W 258.75 - 281.25
//WNW 281.25 - 303.75
//NW 303.75 - 326.25
//NNW 326.25 - 348.75

Console.WriteLine($"{name} Weather");
//Insert code to turn state code into state, and country code into country
Console.WriteLine($"{stateCode}, {countryCode}");
Console.WriteLine($"\n{Math.Round(tempFahrenheit)} degrees");
Console.WriteLine($"Feels like {Math.Round(feelsLikeFahrenheit)} degrees");
Console.WriteLine(description);
Console.WriteLine($"{humidity}% humidity");
Console.WriteLine($"\nWind speed: {windSpeed} knots");
Console.WriteLine($"Wind direction: {direction}");



//{ "coord":{ "lon":-71.0589,"lat":42.3601},
//"weather":[{ "id":804,"main":"Clouds","description":"overcast clouds","icon":"04d"}],
//"base":"stations","main":{ "temp":290.51,"feels_like":290.34,"temp_min":288.81,"temp_max":291.77,"pressure":1016,"humidity":78},
//"visibility":10000,
//"wind":{ "speed":5.66,"deg":160},
//"clouds":{ "all":100},
//"dt":1665678357,"sys":{ "type":2,"id":2013408,"country":"US","sunrise":1665658471,"sunset":1665698765},
//"timezone":-14400,
//"id":4930956,
//"name":"Boston",
//"cod":200}