using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using RestSharp;

namespace LstPkr.WeatherApp.Api.OpenWeatherApi
{
    public class BaseApiClient
    {
        protected string _baseUrl = "";
        private string _apiKey = "";
        string ErrorMessage = string.Empty;
        private HttpContext _context;
        private IConfiguration _configuration;
        

        
        static BaseApiClient()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }
        

        public RestRequest GetNewRequest(string url)
        {
            var request = new RestRequest(url);
            return request;
        }

        protected BaseApiClient(IConfiguration configuration)
        {
            _apiKey = configuration.GetSection("Keys:OpenWeatherKey").Value;
            _baseUrl = configuration.GetSection("Urls:OpenWeatherApiUrl").Value;
            _configuration = configuration;

        }

       
        public IRestResponse<T> Execute<T>(RestRequest request) where T : new()
        {
            request.Resource += $"&units=metric&APPID={_apiKey}";
            var client = new RestClient();
            Uri convertedUri = new Uri(_baseUrl);
            client.BaseUrl = convertedUri;
            request.RequestFormat = DataFormat.Json; // Or DataFormat.Xml, if you prefer

            IRestResponse<T> response = client.Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
               
                return response;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ErrorMessage = "Unauthorized request";
                throw new ApplicationException(ErrorMessage, null);
            }
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                response = client.Execute<T>(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response;
                }
            }
            if (response.Content.Contains("errors"))
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            if (response.ErrorException != null)
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            return response;
        }

        public IRestResponse Execute(RestRequest request)
        {
            request.Resource += $"&units=metric&APPID={_apiKey}";

            var client = new RestClient();
            
            Uri convertedUri = new Uri(_baseUrl);
            client.BaseUrl = convertedUri;
            request.RequestFormat = DataFormat.Json; 

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
               
                return response;
            }
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response;
                }
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ErrorMessage = "Unauthorized request";
                throw new ApplicationException(ErrorMessage, null);
            }
            if (response.Content.Contains("errors"))
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            if (response.ErrorException != null)
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            return response;
        }

   
    }
}