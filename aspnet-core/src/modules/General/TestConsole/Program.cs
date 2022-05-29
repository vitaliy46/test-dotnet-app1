using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Messenger;
using Kis.General.Services.Messenger;
using Kis.General.Services.Messenger.DeliveryProviders;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMail();

            Console.WriteLine("Сообщение отправлено. Press any key.");
            Console.ReadKey();
        }
        public static async void TestMail()
        {
            IIocResolver resolver = new FakeIIocResolver();
            var contact = new ContactDto
            {
                Value = "79089478984",
                ContactType = ContactTypes.Telegram
            };

            var messenger = new Messenger(new DelivaryProviderQualifier(resolver));

            var message = new Message()
            {
                Subject = "Регистрация в системе",
                Text = "Предлагаем перейти по <a href=\"http://ya.ru\">ссылке</a>",
                To = contact
            };

            messenger.Send(message);
        }
    }

    class FakeIIocResolver : IIocResolver
    {
        public object Resolve(Type type)
        {
            return new TelegramMessageDeliveryProvider();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

       

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public object[] ResolveAll(Type type)
        {
            throw new NotImplementedException();
        }

        public object[] ResolveAll(Type type, object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public void Release(object obj)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered<T>()
        {
            throw new NotImplementedException();
        }
    }



}
