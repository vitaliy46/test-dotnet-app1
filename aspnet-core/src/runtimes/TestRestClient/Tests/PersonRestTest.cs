
using Kis.General.Api.Constant;
using Kis.General.Api.Dto.Person;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Kis.General.Api.Dto.PersonUser;
using Kis.Users.Dto;
using TestRestClient.Tests;


namespace TestRestClient
{
    static class PersonRestTest
    {
        private static string _baseUrl = "http://localhost:21021";
        private static string _resource = Path.Combine("api", "Person");
        private static string _accessToken; // тут хранится токен, пользователя


        private static RestClient client = new RestClient(_baseUrl);
        private static RestRequest request; // запрос
        private static IRestResponse response; // ответ

        // TODO существующий ИД персоны из базы данных можно вытащить репозиторием
        // private static Guid id = new Guid("bc5b8871-b02c-4710-893d-c2a2c0010366"); 
        private static Guid _id = new Guid("0fbb6ba8-251f-45bd-9a38-7125d228f6d0");

        private static long _idNewUser; //ИД созданного пользователя, нужен будет для его удаления после всех тестов
        private static CreateUserDto _createUserDto = new CreateUserDto()  // Новый пользователь, которого будем регистрировать
        {
            // UserName = "Alex14", //эти данные генерируются ниже
            Surname = "Push",
            Password = "123qwe",
            //  EmailAddress = "Alex14@ya.ru", //эти данные генерируются ниже
            IsActive = true,
            Name = "Userov",
            RoleNames = new[] { "VOTEMANAGER" }
            // RoleNames = new[] { "VOTEMEMBER" }

        };
        public static void Run()
        {
           
            Console.WriteLine("Тестирование PersonRestTest - \n");
            if (GetById())
            {
                Console.WriteLine("GetById(" + _id + ")" + " //получить голосования по ИД -завершено успешно");
            }
            else
            {
                Console.WriteLine("GetById(" + _id + ")" + " //получить голосования по ИД -завершено с ошибкой");
            }

            Console.WriteLine("**************************************************");
            //После выполнения теста, удаляем созданного пользователя.
            _accessToken = Authentication.Login("admin2@defaulttenant.com", "123qwe", "1"); // авторизуемся под админом для удаления
           
        }
        private static bool GetById()
        {
            bool assest = false;
            try
            {
                //Prepare
              
                var request = new RestRequest(Path.Combine(_resource, _id.ToString()), Method.GET);


                //Action
              response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль                  
                    Console.WriteLine(response.Content);
                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PersonDto>>(response.Content);
                    var person = responseContent.result;

                    assest = person.FullName != ""
                             && person.Contacts.Any(x => x.Contact.ContactType == ContactTypes.Email);
                    // && ...

                    // для проверки десериализации
                    Debug.WriteLine("FullName: " + person.FullName);
                }
                else
                {
                     Console.WriteLine(response.StatusCode); 

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при отправке запроса: " + e);
                // throw;
            }

            return assest;

        }
        private static void Delete()
        {
            throw new NotImplementedException();
        }

        private static void Put()
        {
            throw new NotImplementedException();
        }

        private static void Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// For example see - http://restsharp.org/
        /// </summary>

        private static void Post()
        {
            throw new NotImplementedException();
        }

    }

}
