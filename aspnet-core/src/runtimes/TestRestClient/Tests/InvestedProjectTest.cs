using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Dto.InvestedProject;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Net;
using Abp.Application.Services.Dto;

namespace TestRestClient
{
    class InvestedProjectTest
    {

        private static string _baseUrl = "http://localhost:21021";
        private static string _resource = Path.Combine("api", "InvestedProject");
        private static string _accessToken;

        // TODO существующий ИД  из базы данных, для метода Get по ID
        private static Guid id; //id нового partnershipMemberDto в базе данных после post()
        private static Guid maleId; // maleId нового investedProject в базе данных после post()
        private static Guid phoneId;// phoneId нового investedProject в базе данных после post()
        private static string randomMail; // переменная в которой сгенерированный email. date.Now+@ya.ru




        private static PlaneCreateInvestedProjectDto planeCreateInvestedProjectDto = new PlaneCreateInvestedProjectDto()
        {
            ProjectTitle = "Строительство завода теплоизоляционных материалов ЗАО «Алтайкровля",
            ProjectDescription =
                "Производство экологически чистых древесноволокнистых плит, являющихся высокоэффективным изоляционным материалом - СОФТБОРД, проектная мощность 500 тыс. м2мягкой плиты в месяц (предполагается частичное использование для собственных нужд строительства).",
            CompanyName = "ЗАО «Алтайкровля»",
            Inn = "7236884543",
            Ogrn = "2021453259433",
            Address = "658507, г. Идринское, ул. Казанский 1-й Просек, дом 71, квартира 72",
            HeaderFio = "Холодкова Ульяна Владиславовна",
            Phone = "8 (922) 870-74-35",
           // Mail = "HolodkovaUlyana269@ya.ru",
            ProjectStateId = new Guid("ff9dfcd4-8172-4d6a-bb64-b425c2f2f0ee")
        };


        public static void Run(string accessToken)
        {
            _accessToken = accessToken;
            Console.WriteLine("Тестирование InvestedProjectTest - \n");

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
                Console.WriteLine("Put(" + id + ")" + " -завершено успешно");
            }
            else
            {
                Console.WriteLine("Put(" + id + ")" + "-завершено с ошибкой");
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
                // генерация новго емайла
                randomMail = DateTime.Now.ToString(); 
                randomMail = randomMail.Replace(":", ""); //удаляем ненужные символы
                randomMail = randomMail.Replace(".", "");
                randomMail = randomMail.Replace(" ", "");
                planeCreateInvestedProjectDto.Mail = randomMail + "@ya.ru";

                request.AddJsonBody(planeCreateInvestedProjectDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    Console.WriteLine(response.Content);


                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent =
                        JsonConvert.DeserializeObject<ResponseContent<PlaneInvestedProjectDto>>(response.Content);
                    var investedProject = responseContent.result;
                    id = investedProject.Id; //запишем id новой записи в БД
                    maleId = investedProject.MailId;////запишем maleId новой записи в БД
                    phoneId = investedProject.PhoneId;// запишем phoneId новой записи в БД

                    assest = investedProject.Address == planeCreateInvestedProjectDto.Address
                             && investedProject.CompanyName == planeCreateInvestedProjectDto.CompanyName
                             && investedProject.HeaderFio == planeCreateInvestedProjectDto.HeaderFio
                             && investedProject.Inn == planeCreateInvestedProjectDto.Inn
                             && investedProject.Mail == planeCreateInvestedProjectDto.Mail
                             && investedProject.Ogrn == planeCreateInvestedProjectDto.Ogrn
                             && investedProject.Phone == planeCreateInvestedProjectDto.Phone
                             && investedProject.ProjectDescription == planeCreateInvestedProjectDto.ProjectDescription
                             && investedProject.ProjectTitle == planeCreateInvestedProjectDto.ProjectTitle;
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
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PlaneInvestedProjectDto>>(response.Content);
                    var investedProject = responseContent.result;
                    assest = investedProject.CompanyName == planeCreateInvestedProjectDto.CompanyName
                             && investedProject.Address == planeCreateInvestedProjectDto.Address
                             && investedProject.HeaderFio == planeCreateInvestedProjectDto.HeaderFio
                             && investedProject.ProjectDescription == planeCreateInvestedProjectDto.ProjectDescription
                             && investedProject.Inn == planeCreateInvestedProjectDto.Inn
                             && investedProject.Mail == planeCreateInvestedProjectDto.Mail
                             && investedProject.Ogrn == planeCreateInvestedProjectDto.Ogrn
                             && investedProject.Phone == planeCreateInvestedProjectDto.Phone
                             && investedProject.ProjectTitle == planeCreateInvestedProjectDto.ProjectTitle
                             && investedProject.ProjectStateId == planeCreateInvestedProjectDto.ProjectStateId;



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
                var request = new RestRequest(_resource, Method.GET);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пустой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    //Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PagedResultDto<InvestedProjectShortDto>>>(response.Content);
                    var investedProjectShortDto = responseContent.result;
                    foreach (var items in investedProjectShortDto.Items)  // если в базе данных есть запись с нашим ИД, то тест пройден
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
        PlaneInvestedProjectDto planeInvestedProjectDto = new PlaneInvestedProjectDto()
        {
            ProjectTitle = "Строительство завода теплоизоляционных материалов ООО Шляпа",
            ProjectDescription =
                "Производство экологически чистых шляп, являющихся высокоэффективным изоляционным материалом.",
            CompanyName = "ООО Шляпа",
            Inn = "7236884533",
            Ogrn = "2021453259444",
            Address = "658545, г. Пермь, ул. Москаовская, дом 11,",
            HeaderFio = "Жаркова Мария Ивановна",
            Phone = "8 (924) 875-76-37",
             Mail = "HolodkovaUlyana269@ya.ru",
            ProjectStateId = new Guid("ff9dfcd4-8172-4d6a-bb64-b425c2f2f0cf"),
            MailId = maleId,
            PhoneId = phoneId,
            Id = id


            
        };
        bool assest = false;
            try
            {
                //Prepare
                var client = new RestClient(_baseUrl);
                var request = new RestRequest(Path.Combine(_resource, id.ToString()), Method.PUT, DataFormat.Json);
                request.AddJsonBody(planeInvestedProjectDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);
                //Action
                IRestResponse response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    // Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<PlaneInvestedProjectDto>>(response.Content);
                    var investedProject = responseContent.result;
                    id = investedProject.Id; //запишем id новой записи в БД

                    assest = investedProject.CompanyName == planeInvestedProjectDto.CompanyName
                             && investedProject.Address == planeInvestedProjectDto.Address
                             && investedProject.HeaderFio == planeInvestedProjectDto.HeaderFio
                             && investedProject.Inn == planeInvestedProjectDto.Inn
                             && investedProject.Mail == planeInvestedProjectDto.Mail
                             && investedProject.Ogrn == planeInvestedProjectDto.Ogrn
                             && investedProject.Phone == planeInvestedProjectDto.Phone;


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
