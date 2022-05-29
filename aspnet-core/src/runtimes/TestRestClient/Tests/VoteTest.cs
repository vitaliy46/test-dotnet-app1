using Kis.Voting.Api.Dto;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Abp.Application.Services.Dto;
using Castle.MicroKernel.Registration;
using Kis.Base.Utilities;
using Kis.Users.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.BulletinSelectedOption;
using Microsoft.Win32.SafeHandles;
using TestRestClient.Tests;
using static Kis.Voting.Web.Controllers.VoteController;

namespace TestRestClient
{
    class VoteTest
    {
       
        private static readonly string _baseUrl = "http://localhost:21021";
        private static readonly string _resource = Path.Combine("api", "vote");
        
       

        private static RestClient client = new RestClient(_baseUrl);
        private static RestRequest request; // запрос
        private static IRestResponse response; // ответ
        private static string _accessToken;

        // TODO существующий ИД  из базы данных, для метода Get по ID
        private static Guid _id; //id нового Vote в базе данных после post()
     
        private static CreateVoteDto _createVoteDto = new CreateVoteDto()
        {
            Theme = "Сократить охрану?",
            ContextId = new Guid("6013ed7b-735b-4357-b8d0-a2f70db30a22"),
            QuorumPct = 60,
            DecisionMakersPct = 70,
            IsMultilieChoice = true,
            BeginDateTime = new DateTime(2019, 05, 31, 8, 0, 0),
            EndDateTime = new DateTime(2019, 06, 05, 8, 0, 0),
            NoteSendingDateTime = new DateTime(2019, 05, 31, 10, 0, 0),
            Options = new List<CreateVoteOptionDto>
            {
                new CreateVoteOptionDto()
                {
                    Text = "Сократить",
                    
                    

                },
                new CreateVoteOptionDto()
                {
                    Text = "Не сокращать"
                }
            }

        };
        private  static UpdateVoteDto _updateVoteDto = new UpdateVoteDto()
        {
            Theme = "Оптимизировать штат охраны?",
            ContextId = new Guid("49fd70ae-546e-48f7-9504-88f2457e1a0f"),
           
            QuorumPct = 60,
            DecisionMakersPct = 70,
            IsMultilieChoice = true,
            BeginDateTime = new DateTime(2019, 08, 08, 8, 0, 0),
            EndDateTime = new DateTime(2019, 08, 08, 8, 0, 0),
            NoteSendingDateTime = new DateTime(2019, 08, 08, 10, 0, 0),
            Options = new List<VoteOptionDto>
            {
                new VoteOptionDto()
                {
                    Text = "Оптимизировать",
                 
                },
                new VoteOptionDto()
                {
                    Text = "Не оптимизировать",
                 
                }
            },
          
        };

        public static void Run()
        {
           
            

            Console.WriteLine("Тестирование VoteTest - \n");

            //if (Post())
            //{
            //    Console.WriteLine("Post() //создание голосования -завершено успешно");
            //}
            //else
            //{
            //    Console.WriteLine("Post() //создание голосования -завершено с ошибкой");
            //}
            //Console.WriteLine("**************************************************");


            //if (GetById())
            //{
            //    Console.WriteLine("GetById(" + _id + ")" + " //получить голосования по ИД -завершено успешно");
            //}
            //else
            //{
            //    Console.WriteLine("GetById(" + _id + ")" + " //получить голосования по ИД -завершено с ошибкой");
            //}
            //Console.WriteLine("**************************************************");

            //if (Get())
            //{
            //    Console.WriteLine("Get()" + " //получить все голосования -завершено успешно");
            //}
            //else
            //{
            //    Console.WriteLine("Get()" + " //получить все голосования -завершено с ошибкой");
            //}
            //Console.WriteLine("**************************************************");

            //if (Put())
            //{
            //    Console.WriteLine("Put(" + _id + ")" + " //правка голосования по ИД -завершено успешно");
            //}
            //else
            //{
            //    Console.WriteLine("Put(" + _id + ")" + " //правка голосования по ИД -завершено с ошибкой");
            //}
            //Console.WriteLine("**************************************************");

            //if (PostPublish())
            //{
            //    Console.WriteLine("PostPublish() //публикация голосования -завершено успешно");
            //}
            //else
            //{
            //    Console.WriteLine("PostPublish() //публикация голосования -завершено с ошибкой");
            //}
            //Console.WriteLine("**************************************************");

            var votedResult = PostVoted();

            if (votedResult)
            {
                Console.WriteLine("PostVoted() //проголосовать -завершено успешно");
            }
            else
            {
                Console.WriteLine("PostVoted() //проголосовать -завершено с ошибкой");
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
              _accessToken = UserTest.PostCreate(new[] { "VOTEMANAGER" });  // создаем нового пользователя для этого метода с правами
                request = new RestRequest(Path.Combine(_resource), Method.POST, DataFormat.Json);

                request.AddJsonBody(_createVoteDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
              response = client.Execute(request);
            
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    Console.WriteLine(response.Content);


                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent =
                        JsonConvert.DeserializeObject<ResponseContent<GetVoteDto>>(response.Content);
                    var getVoteDto = responseContent.result;
                   _id = getVoteDto.Id; //Запишим все полученные ИД в _updateVoteDto
                    _updateVoteDto.Id = getVoteDto.Id;
                    _updateVoteDto.Options[0].Id = getVoteDto.Options[0].Id; // запомним ИД варианта ответа
                    _updateVoteDto.Options[0].VoteId = getVoteDto.Id;
                    _updateVoteDto.Options[1].Id = getVoteDto.Options[1].Id; // запомним ИД варианта ответа
                    _updateVoteDto.Options[1].VoteId = getVoteDto.Id;
                    assest = getVoteDto.Theme == _createVoteDto.Theme
                             && getVoteDto.ContextId == _createVoteDto.ContextId
                             && getVoteDto.QuorumPct == _createVoteDto.QuorumPct
                             && getVoteDto.DecisionMakersPct == _createVoteDto.DecisionMakersPct
                             && getVoteDto.IsMultilieChoice == _createVoteDto.IsMultilieChoice
                             && getVoteDto.BeginDateTime.AddHours(5) == _createVoteDto.BeginDateTime
                             && getVoteDto.EndDateTime.AddHours(5) == _createVoteDto.EndDateTime
                             && getVoteDto.NoteSendingDateTime.AddHours(5) == _createVoteDto.NoteSendingDateTime
                               && getVoteDto.Options.Count == _createVoteDto.Options.Count;
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
            UserTest.Delete(); //удалим созданного пользователя
            return assest;


        }

        // Get запрос по ИД. Получаем информацию из базы данных по ИД
        private static bool GetById()
        {
            bool assest = false;
            try
            {
                //Prepare
                 _accessToken = UserTest.PostCreate(new[] { "VOTEMANAGER" });  // создаем нового пользователя для этого метода с правами
                request = new RestRequest(Path.Combine(_resource, _id.ToString()), Method.GET);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
             response = client.Execute(request);
                // если ответ не пустой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    // Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<GetVoteDto>>(response.Content);
                    var getVoteDto = responseContent.result;
                    assest = getVoteDto.Theme == _createVoteDto.Theme
                             && getVoteDto.ContextId == _createVoteDto.ContextId
                             && getVoteDto.QuorumPct == _createVoteDto.QuorumPct
                             && getVoteDto.DecisionMakersPct == _createVoteDto.DecisionMakersPct
                             && getVoteDto.IsMultilieChoice == _createVoteDto.IsMultilieChoice
                             && getVoteDto.BeginDateTime.AddHours(5) == _createVoteDto.BeginDateTime
                             && getVoteDto.EndDateTime.AddHours(5) == _createVoteDto.EndDateTime
                             && getVoteDto.NoteSendingDateTime.AddHours(5) == _createVoteDto.NoteSendingDateTime
                             && getVoteDto.Options.Count == _createVoteDto.Options.Count;



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
            UserTest.Delete(); //удалим созданного пользователя
            return assest;

        }

        // Get запрос. Получаем все записи из базы данных
        private static bool Get()
        {
            bool assest = false;
            try
            {

                //Prepare
                _accessToken = UserTest.PostCreate(new[] { "VOTEMANAGER" });  // создаем нового пользователя для этого метода с правами
                request = new RestRequest(_resource + "?VoteId=" + _id, Method.GET);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
                 response = client.Execute(request);
                // если ответ не пустой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    //  Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent =
                        JsonConvert.DeserializeObject<ResponseContent<PagedResultDto<VoteShortDto>>>(response.Content);
                    var investedProjectShortDto = responseContent.result;
                    if (investedProjectShortDto.Items.Count>0)
                        {
                            assest = true;
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
            UserTest.Delete(); //удалим созданного пользователя
            return assest;

        }

        // Put запрос, обновляем данные в базе данных
        private static bool Put()
        {
           
            bool assest = false;
            try
            {
                //Prepare
                _accessToken = UserTest.PostCreate(new[] { "VOTEMANAGER" });  // создаем нового пользователя для этого метода с правами
                request = new RestRequest(Path.Combine(_resource, _id.ToString()), Method.PUT, DataFormat.Json);
                request.AddJsonBody(_updateVoteDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);
                //Action
             response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    // Console.WriteLine(response.Content);

                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent = JsonConvert.DeserializeObject<ResponseContent<GetVoteDto>>(response.Content);
                    var getVoteDto = responseContent.result;

                    assest = getVoteDto.Theme == _updateVoteDto.Theme
                             && getVoteDto.ContextId == _updateVoteDto.ContextId
                             && getVoteDto.QuorumPct == _updateVoteDto.QuorumPct
                             && getVoteDto.DecisionMakersPct == _updateVoteDto.DecisionMakersPct
                             && getVoteDto.IsMultilieChoice == _updateVoteDto.IsMultilieChoice
                             && getVoteDto.BeginDateTime.AddHours(5) == _updateVoteDto.BeginDateTime
                             && getVoteDto.EndDateTime.AddHours(5) == _updateVoteDto.EndDateTime
                             && getVoteDto.NoteSendingDateTime.AddHours(5) == _updateVoteDto.NoteSendingDateTime
                                && getVoteDto.Options.Count == _updateVoteDto.Options.Count;

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

            UserTest.Delete(); //удалим созданного пользователя
            return assest;
        }

        // PostPublish запрос, публикация голосования
        private static bool PostPublish()
        {
           
            bool assest = false;
            try
            {
                //Prepare
                 _accessToken = UserTest.PostCreate(new[] { "VOTEMANAGER" });  // создаем нового пользователя для этого метода с правами
                request = new RestRequest(Path.Combine(_resource, "publish"), Method.POST, DataFormat.Json);

                request.AddJsonBody(_updateVoteDto);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
              response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                   // Console.WriteLine(response.Content);


                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent =
                        JsonConvert.DeserializeObject<ResponseContent<GetVoteDto>>(response.Content);
                    var getVoteDto = responseContent.result;
                //    id = getVoteDto.Id; //запишем id новой записи в БД


                    assest = getVoteDto.Theme == _updateVoteDto.Theme
                             && getVoteDto.ContextId == _updateVoteDto.ContextId
                             && getVoteDto.QuorumPct == _updateVoteDto.QuorumPct
                             && getVoteDto.DecisionMakersPct == _updateVoteDto.DecisionMakersPct
                             && getVoteDto.IsMultilieChoice == _updateVoteDto.IsMultilieChoice
                             && getVoteDto.BeginDateTime.AddHours(5) == _updateVoteDto.BeginDateTime
                             && getVoteDto.EndDateTime.AddHours(5) == _updateVoteDto.EndDateTime
                             && getVoteDto.NoteSendingDateTime.AddHours(5) == _updateVoteDto.NoteSendingDateTime
                             && getVoteDto.Options.Count == _updateVoteDto.Options.Count;
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
            UserTest.Delete(); //удалим созданного пользователя
            return assest;


        }

        // PostVoted запрос, проголосовать
        private static bool PostVoted()
        {

            VotedInputViewModel votedInputViewModel = new VotedInputViewModel()
            {
                BulletinDto = new CreateBulletinDto()
                {
                    VoteMemberId = new Guid("2af2b4e7-470c-4289-9734-99710705398f"), //придуманный
                    VoteId = _id,
                    AuthoritiesConfirm = true,
                    BulletinSelectedOptions = new List<CreateBulletinSelectedOptionDto>()
                    {
                        new CreateBulletinSelectedOptionDto()
                        {
                            SelectedOptionId = _updateVoteDto.Options[0].Id
                        },
                    }
                }
            };
            bool assest = false;
            try
            {
                //Prepare
                _accessToken = UserTest.PostCreate(new[] { "VOTEMANAGER" });  // создаем нового пользователя для этого метода с правами
                request = new RestRequest(Path.Combine(_resource, "voted"), Method.POST, DataFormat.Json);

                request.AddJsonBody(votedInputViewModel);
                request.AddParameter("Authorization", "Bearer " + _accessToken, ParameterType.HttpHeader);

                //Action
              response = client.Execute(request);
                // если ответ не пусстой
                if (response.Content != "")
                {
                    // ввыод в консоль
                    Console.WriteLine(response.Content);


                    //данные десерелизуются из json в переменную с указанным типом
                    var responseContent =
                        JsonConvert.DeserializeObject<ResponseContent<VotedOutputViewModel>>(response.Content);
                    var result = responseContent.result;
                  //  id = result.Id; //запишем id новой записи в БД


                    assest =false;
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
            UserTest.Delete(); //удалим созданного пользователя
            return assest;


        }
    }
}
