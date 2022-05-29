using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Kis.Users.Dto;
using Kis.Voting.Api.Dto;
using Newtonsoft.Json;
using RestSharp;

namespace TestRestClient.Tests
{
    class UserTest
    {
        private static long _id;// ИД нового Пользователя в базе данных
        private static string _baseUrl = "http://localhost:21021";
        //  private static string _resource = Path.Combine("api", "services", "app", "User", "Create");

        private static RestClient client = new RestClient(_baseUrl);
        private static RestRequest request; // запрос
        private static IRestResponse response; // ответ
        private static string _accessToken; // токен пользователей
        private static long _idNewUser; //ИД нового пользователя в БД, для последующего удаления по ИД

       

        public static void Run()
        {
           
            Console.WriteLine("Тестирование User - \n");

           // PostCreate();  // cоздаем нового пользователя

            Console.WriteLine("**************************************************");
           // Delete(); // удаляем созданного пользователя
           
            Console.WriteLine("**************************************************");
        }
        // Создание нового пользователя
        public static string PostCreate(string [] roleNames)
        {

             // bool assest = false;
         

            try
            {
                _accessToken = Authentication.Login("admin2@defaulttenant.com", "123qwe", "1"); // авторизуемся сперва под админом для создания нового пользователя

                //Prepare
               
                CreateUserDto _createUserDto = new CreateUserDto() //Данные gользователя, которого создаем при тестировании этого теста
                {
            // UserName = "Alex14", //эти данные генерируются ниже
            Surname = "Push",
            Password = "123qwe",
            //  EmailAddress = "Alex14@ya.ru", //эти данные генерируются ниже
            IsActive = true,
            Name = "Userov",
            RoleNames = roleNames//new[] { "VOTEMANAGER" }
        };
        string randomEmailAddress = DateTime.Now.ToString(); // генерация новго емайла и UserName
                randomEmailAddress = randomEmailAddress.Replace(":", ""); //удаляем ненужные символы
                randomEmailAddress = randomEmailAddress.Replace(".", "");
                randomEmailAddress = randomEmailAddress.Replace(" ", "");
                _createUserDto.EmailAddress = "Alex" + randomEmailAddress + "@ya.ru";
                _createUserDto.UserName = "Alex" + randomEmailAddress;


                request = new RestRequest(Path.Combine("api", "services", "app", "User", "Create"), Method.POST,
                    DataFormat.Json);

                request.AddJsonBody(_createUserDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);
               // _accessToken = null;

                //Action

                response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    // Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent =
                        JsonConvert.DeserializeObject<ResponseContent<UserDto>>(response.Content);
                    var userDto = responseContent.result;
                    _idNewUser = userDto.Id;
                    if (userDto.Id != null) // если получен ИД нового пользователя, авторизуемся
                    {

                        Console.WriteLine(
                            "Создание нового пользователя" + " -завершено успешно: " + response.StatusCode+ "\n");
                        // cразу авторизуемся
                        _accessToken = Authentication.Login(_createUserDto.EmailAddress, _createUserDto.Password, "1");
                    }
                }
                else
                {
                    Console.WriteLine("Создание нового пользователя" + " -завершено c ошибкой: " + response.StatusCode+ "\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при отправке запроса: " + e);
            }

            return _accessToken;
        }

        //Удаление нового пользователя
        public static void Delete()
        {
            bool assest = false;
            try
            {
                _accessToken = Authentication.Login("admin2@defaulttenant.com", "123qwe", "1"); // авторизуемся сперва под админом для удаления пользователя
                //Prepare

                request = new RestRequest(Path.Combine("api", "services", "app", "User", "Delete?Id="+_idNewUser.ToString()), Method.DELETE);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);
                //Action
                response = client.Execute(request);
                // проверим статус код
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Удаление созданного пользователя(Id=" + _idNewUser + ")" + " -завершено успешно: " + response.StatusCode+ "\n");

                }
                else
                {
                    Console.WriteLine("Удаление созданного пользователя(Id=" + _idNewUser + ")" + "-завершено с ошибкой: " + response.StatusCode+ "\n");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при отправке запроса: " + e);
            }


        }
    }
}
