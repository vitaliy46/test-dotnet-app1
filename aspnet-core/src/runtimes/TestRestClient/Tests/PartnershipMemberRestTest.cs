using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Organizations;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Dto.PersonUser;
using Kis.Investors.Api.Dto;
using Kis.Organization.Api.Dto;
using Kis.Users.Dto;
using Newtonsoft.Json;
using RestSharp;

namespace TestRestClient
{
    class PartnershipMemberRestTest
    {
        private static string _baseUrl = "http://localhost:21021";
        private static string _resource = Path.Combine("api", "PartnershipMember");
        private static string _accessToken;

        // TODO существующий ИД  из базы данных, для метода Get по ID
        private static Guid id; //id нового partnershipMemberDto в базе данных после post()
        private static Guid maleId; // maleId нового partnershipMemberDto в базе данных после post()
        private static Guid phoneId;// phoneId нового partnershipMemberDto в базе данных после post()

        private static string randomMail; // переменная в которой сгенерированный email. date.Now+@ya.ru

        private static CreatePartnershipMemberDto createPartnershipMemberDto = new CreatePartnershipMemberDto()
        {
            Name = "MMM",
            Inn = "7866884722",
            Ogrn = "1011453259432",
            Address = "171224, г. Северск, ул. Досфлота Проезд, дом 63, квартира 163",
            HeaderFio = "Пиманов Игорь Петрович",
           // Mail = "uuu34543@ya.ru",
            Phone = "8 (912) 231-22-24",
           // Login = "uuu34566",
            ContactorFio = "Королева Наталья Николаевна",
            IsAllowSmsNotification = true
        };
    
       
        public static void Run(string accessToken)
        {
            _accessToken = accessToken;
            Console.WriteLine("Тестирование PartnershipMember - \n");
           
            if (Post())
            {
                Console.WriteLine("Post() -завершено успешно");
            }
            else
            {
                Console.WriteLine("Post() -завершено с ошибкой");
            }
            Console.WriteLine("**************************************************");
            if (GetById())
            {
                Console.WriteLine("GetById(" + id + ")" + " -завершено успешно");
            }
            else
            {
                Console.WriteLine("GetById(" + id + ")" + "-завершено с ошибкой");
            }
            Console.WriteLine("**************************************************");
            if (Get())
            {
                Console.WriteLine("Get()" + " -завершено успешно");
            }
            else
            {
                Console.WriteLine("Get()" + "-завершено с ошибкой");
            }
            Console.WriteLine("**************************************************");
            if (Put())
            {
                Console.WriteLine("Put("+id+")" + " -завершено успешно");
            }
            else
            {
                Console.WriteLine("Put("+id+")" + "-завершено с ошибкой");
            }
            Console.WriteLine("**************************************************");
           if (Delete())
           {
                Console.WriteLine("Delete(" + id + ")" + " -завершено успешно");
           }
            else
            {
                Console.WriteLine("Delete(" + id + ")" + "-завершено с ошибкой");
           }
            Console.WriteLine("**************************************************");
        }
        // Post запрос, добавляем данные в базу данных
        private static bool Post()
        {
            bool assest = false;
            try
            {
                //Prepare
                var client = new RestClient(_baseUrl);
                var request = new RestRequest(Path.Combine(_resource), Method.POST, DataFormat.Json);

                randomMail = DateTime.Now.ToString(); // генерация новго емайла
                randomMail = randomMail.Replace(":", ""); //удаляем ненужные символы
                randomMail = randomMail.Replace(".", "");
                randomMail = randomMail.Replace(" ", "");
                createPartnershipMemberDto.Mail = randomMail+"@ya.ru";

                request.AddJsonBody(createPartnershipMemberDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                //   Console.WriteLine(response.Content);


                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PlanePartnershipMemberDto>>(response.Content);
                    var partnership = responseContent.result;
                    id = partnership.Id; //запишем id новой записи в БД
                    maleId = partnership.MailId;////запишем maleId новой записи в БД
                    phoneId = partnership.PhoneId;// запишем phoneId новой записи в БД

                   // int find = createPartnershipMemberDto.Mail.IndexOf("@");
                  

                    assest = partnership.Name != ""
                             && partnership.Inn == createPartnershipMemberDto.Inn
                             && partnership.Ogrn == createPartnershipMemberDto.Ogrn
                             && partnership.Address == createPartnershipMemberDto.Address
                             && partnership.HeaderFio == createPartnershipMemberDto.HeaderFio
                             && partnership.Mail == createPartnershipMemberDto.Mail
                             && partnership.Login == createPartnershipMemberDto.Mail;  // логину контроллер присваивает значение maila
                    //    && person.Contacts.Any(x => x.Contact.ContactType == ContactTypes.Email);
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

           
            return assest;
        }
        // Get запрос по ИД. Получаем информацию из базы данных по ИД
        private static bool GetById()
        {
            bool assest = false;
            try
            {
                //Prepare
                var client = new RestClient(_baseUrl);
                var request = new RestRequest(Path.Combine(_resource, id.ToString()), Method.GET);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пустой
                if (response.Content != "")
                {
                    // ввыод в консоль
                   // Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PlanePartnershipMemberDto>>(response.Content);
                    var partnership = responseContent.result;
                    assest = partnership.Name == createPartnershipMemberDto.Name
                             && partnership.Inn == createPartnershipMemberDto.Inn
                             && partnership.Ogrn == createPartnershipMemberDto.Ogrn
                             && partnership.Address == createPartnershipMemberDto.Address
                             && partnership.HeaderFio == createPartnershipMemberDto.HeaderFio
                             && partnership.Mail == createPartnershipMemberDto.Mail
                             && partnership.Login == createPartnershipMemberDto.Mail;  // логину контроллер присваивает значение maila
                  
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
            return assest;

        }
        // Get запрос. Получаем все записи из базы данных
        private static bool Get()
        {
            bool assest = false;
            try
            {
                
                //Prepare
                var client = new RestClient(_baseUrl);
                var request = new RestRequest(_resource + "?VoteId=" + id, Method.GET);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пустой
                if (response.Content != "")
                {
                    // ввыод в консоль
                   Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PagedResultDto<PartnershipMemberShortDto>>>(response.Content);
                    var partnership = responseContent.result;
                    foreach (var items in partnership.Items)  // если в базе данных есть запись с нашим ИД, то тест пройден
                    {
                        if (items.Id == id)
                        {
                            assest = true;
                        }
                    }
                   

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
            return assest;

        }

        // Put запрос, обновляем данные в базе данных
        private static bool Put()
        {
         PlanePartnershipMemberDto planePartnershipMemberDto = new PlanePartnershipMemberDto()  // Обновляемые данные в БД
        {
            Name = "MMM11",
            Inn = "7866884722",
            Ogrn = "1011453259433",
            Address = "171244, г. Северск, ул. Досфлота Проезд, дом 63, квартира 163",
            HeaderFio = "Пиманов Игорь Петровичич",
            Mail = "uuu21570@ya.ru",
            MailId = maleId,
            Phone = "8 (912) 231-33-66",
            PhoneId = phoneId,
            //Login = "uuu21570@ya.ru",
            ContactorFio = "Королева Наталья Николаевнавна",
            IsAllowSmsNotification = true
        };
        bool assest = false;
            try
            {
                //Prepare
                var client = new RestClient(_baseUrl);
                var request = new RestRequest(Path.Combine(_resource, id.ToString()), Method.PUT, DataFormat.Json);
                request.AddJsonBody(planePartnershipMemberDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);
                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                   // Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PlanePartnershipMemberDto>>(response.Content);
                    var partnership = responseContent.result;
                    id = partnership.Id; //запишем id новой записи в БД

                    assest = partnership.Name==planePartnershipMemberDto.Name
                             && partnership.Inn == planePartnershipMemberDto.Inn
                             && partnership.Ogrn == planePartnershipMemberDto.Ogrn
                             && partnership.Address == planePartnershipMemberDto.Address
                             && partnership.HeaderFio == planePartnershipMemberDto.HeaderFio
                             && partnership.Mail == planePartnershipMemberDto.Mail
                        && partnership.Phone == planePartnershipMemberDto.Phone;
                    // && partnership.Login == planePartnershipMemberDto.Login;  // логину контроллер присваивает значение maila
                    //    && person.Contacts.Any(x => x.Contact.ContactType == ContactTypes.Email);
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


            return assest;
        }
        // Delete запрос, удаляем созданный ИД из базы данных
        private static bool Delete()
        {
            bool assest = false;
            try
            {
                //Prepare
                var client = new RestClient(_baseUrl);
                var request = new RestRequest(Path.Combine(_resource, id.ToString()), Method.DELETE);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);
                //Action
                IRestResponse response = client.Execute(request);
                // проверим статус код
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // ввыод в консоль
                   //Console.WriteLine(response.StatusCode);
                    assest = true;
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
            return assest;

        }
    }
}
