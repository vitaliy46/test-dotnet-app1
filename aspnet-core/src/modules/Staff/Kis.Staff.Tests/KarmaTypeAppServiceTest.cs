namespace Kis.Staff.Tests
{  // закоменчено, нужно переделывать, т.к. не стояло задачи писать логику сервиса KarmaType
    /*
    [TestClass]
    public class KarmaTypeAppServiceTest
    {        
        private IKarmaTypeRepository karmaTypeRepository;
        private IKarmaRepository karmaRepository;
        private KarmaTypeAsyncCrudAppService service;
        private Exception exception;

        //Метод вызываемый перед каждым тестом
        [TestInitialize()]        
        public void Initialize()
        {
            //настройка маппера 
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<HrAutoMapperProfile>();
            });

            //создание фэйкового сервиса
            karmaTypeRepository = A.Fake<IKarmaTypeRepository>();
            karmaRepository = A.Fake<IKarmaRepository>();
            service = new KarmaTypeAsyncCrudAppService(karmaTypeRepository, karmaRepository, Mapper.Instance);

            exception = null;
        }

        
        [TestMethod]
        public void Create_ArgumentNull_ThrowException()
        {
            // Arrange
            KarmaTypeDto karmaTypeDto = null;

            // Act                      
            try
            {                
                var newKarmaTypeDto = service.Create(karmaTypeDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Create не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(ArgumentException), "Неверный тип исключения");
            Assert.IsTrue(((ArgumentException)exception).ParamName == "karmaTypeDto", "Ошибка не указывает на имя параметра \"karmaTypeDto\"");
        }

        [TestMethod]
        public void Create_InsertToRepositoryReturnNull_ThrowException()
        {
            // Arrange             
            A.CallTo(() => karmaTypeRepository.Insert(A<KarmaType>.Ignored)).Returns(null);

            // Act           
            try
            {
                var newKarmaTypeDto = service.Create(A.Fake<KarmaTypeDto>());
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Create не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException), "Неверный тип исключения");          
        }
        
        [TestMethod]
        public void Create_InputDtoModelIsValid_newKarmaTypeDto()
        {
            // Arrange            
            A.CallTo(() => karmaTypeRepository.Insert(A<KarmaType>.Ignored)).Returns(A.Fake<KarmaType>());
                      
            // Act
            var newKarmaTypeDto = service.Create(A.Fake<KarmaTypeDto>());

            // Assert
            Assert.IsNotNull(newKarmaTypeDto, "Новый тип кармы не создан");
            Assert.IsNotNull(newKarmaTypeDto.Id, "Не присвоен идентификатор новой записи");
            //был ли вызов метода Insert     
            A.CallTo(() => karmaTypeRepository.Insert(A<KarmaType>.Ignored)).MustHaveHappened();            
        }
        
       

        [TestMethod]
        public void Delete_KarmaTypeHaveChild_ThrowException()
        {
            // Arrange  
            //если метод Count возвращает значение больше 0, тогда запись имеет связаные с ней записи
            A.CallTo(() => karmaRepository.Count(A<Expression<Func<Karma, bool>>>.Ignored)).Returns(1);            
            Guid id = Guid.NewGuid();
            
            // Act          
            try
            {
                service.Delete(id);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException), "Неверный тип исключения");
        }


        [TestMethod]
        public void Get_KarmaTypeNotExistWithSuchId_ThrowException()
        {
            // Arrange          
            A.CallTo(() => karmaTypeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act           
            try
            {
                var newKarmaTypeDto = service.Get(Guid.NewGuid());
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Get не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
            A.CallTo(() => karmaTypeRepository.FirstOrDefault(A<Guid>.Ignored)).MustHaveHappened();
        }

        [TestMethod]
        public void Get_KarmaTypeExistWithSuchId_newKarmaTypeDto()
        {
            // Arrange   
            A.CallTo(() => karmaTypeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(A.Fake<KarmaType>());            

            // Act
            var newKarmaTypeDto = service.Get(Guid.NewGuid());
            
            // Assert
            Assert.IsNotNull(newKarmaTypeDto, "Метод Get не возвратил значение");           
            //был ли вызов метода Get     
            A.CallTo(() => karmaTypeRepository.FirstOrDefault(A<Guid>.Ignored)).MustHaveHappened();
        }

        [TestMethod]
        public void Update_ArgumentNull_ThrowException()
        {
            // Arrange         
            KarmaTypeDto karmaTypeDto = null;

            // Act            
            try
            {
                var newKarmaTypeDto = service.Update(karmaTypeDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Update не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(ArgumentException), "Неверный тип исключения");
            Assert.IsTrue(((ArgumentException)exception).ParamName == "karmaTypeDto", "Ошибка не указывает на имя параметра \"karmaTypeDto\"");
        }

        [TestMethod]
        public void Update_RepositoryReturnNull_ThrowException()
        {
            // Arrange 
            A.CallTo(() => karmaTypeRepository.Update(A<KarmaType>.Ignored)).Returns(null);

            // Act            
            try
            {
                var newKarmaTypeDto = service.Update(A.Fake<KarmaTypeDto>());
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Create не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Update_InputDtoModelIsValid_newKarmaTypeDto()
        {
            // Arrange           
            A.CallTo(() => karmaTypeRepository.Update(A<KarmaType>.Ignored)).Returns(A.Fake<KarmaType>());
            
            // Act
            var newKarmaTypeDto = service.Update(A.Fake<KarmaTypeDto>());

            // Assert
            Assert.IsNotNull(newKarmaTypeDto, "Тип кармы не обновлен");
            //был ли вызов метода Update     
            A.CallTo(() => karmaTypeRepository.Update(A<KarmaType>.Ignored)).MustHaveHappened();
        }

        

        [TestMethod]
        public void GetAll_TotalInPagedCollectionIsEqualsTotalInRepository()
        {
            // Arrange 
            Random rnd = new Random();
            int countElement = rnd.Next(50);

            var fakeCollection = A.CollectionOfFake<KarmaType>(countElement).ToList();
            var fakeCollectionDto = A.CollectionOfFake<KarmaTypeDto>(countElement).ToList();            

            A.CallTo(() => karmaTypeRepository.GetAll())
                .Returns(fakeCollection.AsQueryable());
            
            
            Random skip = new Random();
            Random top = new Random();                        


            // Act
            var newPagedCollectionDto = service.GetAll(new PagedAndSortedResultRequestDto());            


            // Assert
            Assert.IsNotNull(newPagedCollectionDto, "Метод GetAll не возвратил значение");
            Assert.AreEqual(newPagedCollectionDto.TotalCount, countElement,"Возвращаемое общее колличество не равно колличеству записей в базе");
        }
    }*/
}
