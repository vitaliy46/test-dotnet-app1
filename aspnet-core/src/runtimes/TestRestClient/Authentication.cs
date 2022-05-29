using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace TestRestClient
{
    class Authentication
    {

        private static readonly string _baseUrl = "http://localhost:21021";
        private static readonly string _resource = Path.Combine("api", "TokenAuth", "Authenticate");
      //  private static readonly string _userNameOrEmailAddress = "admin2@defaulttenant.com";
      //  private static readonly string _password = "123qwe";
        public static string accessToken;

       // private static readonly string _tenantId = "1";
        // Авторизация на сервере
        public static string Login(string userNameOrEmailAddress, string password, string tenantId)
        {
           // bool assest = false;
            try
            {
                //Prepare
                var client = new RestClient(_baseUrl);
                var request = new RestRequest(_resource, Method.POST, DataFormat.Json);
                accessToken = "";
                request.AddHeader("Abp.TenantId", tenantId);
                request.AddHeader("Content-Type", "application/json-patch+json");
                request.AddJsonBody(
                    "{\r\n  \"userNameOrEmailAddress\": \""+userNameOrEmailAddress+"\",\r\n  \"password\": \""+password+"\",\r\n  \"rememberClient\": true\r\n}");

                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                  //  Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent =
                        JsonConvert.DeserializeObject<ResponseContent<ResponseAccessToken>>(response.Content);

                    accessToken = responseContent.result.accessToken;
                }
                else
                {
                    client.ExecuteAsync(request, respon => { Console.WriteLine(respon.StatusCode); });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при отправке запроса: " + e);
            }

            return accessToken;


        }
    }
}
