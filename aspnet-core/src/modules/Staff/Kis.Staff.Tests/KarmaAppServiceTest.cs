namespace Kis.Staff.Tests
{
    // закоменчено, нужно переделывать, т.к. не стояло задачи писать логику сервиса Karma
    /*[TestClass]
    public class KarmaAppServiceTest
    {
        private IKarmaTypeRepository _karmaTypeRepository;
        private IKarmaRepository _karmaRepository;
        private IKarmaVoteRepository _karmaVoteRepository;
        private IEmployeeRepository _employeeRepository;
        private KarmaAppService service;        
        private Exception exception;

        //Метод вызываемый перед каждым тестом
        [TestInitialize()]
        public void Initialize()
        {
            //создание фэйкового сервиса
            _karmaTypeRepository = A.Fake<IKarmaTypeRepository>();
            _karmaRepository = A.Fake<IKarmaRepository>();
            _karmaVoteRepository = A.Fake<IKarmaVoteRepository>();
            _employeeRepository = A.Fake<IEmployeeRepository>();
            service = new KarmaAppService(_karmaRepository, _karmaTypeRepository, _karmaVoteRepository,_employeeRepository);

            //настройка маппера
            service.ObjectMapper = A.Fake<IObjectMapper>();            
            A.CallTo(() => service.ObjectMapper.Map<KarmaDto>(A<Karma>.Ignored)).Returns(A.Fake<KarmaDto>());
            

            exception = null;
        }


        [TestMethod]
        public void Create_ArgumentNull_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = null;

            // Act                      
            try
            {
                var newKarmaDto = service.Create(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Create не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(ArgumentException), "Неверный тип исключения");
            Assert.IsTrue(((ArgumentException)exception).ParamName == "karmaDto", "Ошибка не указывает на имя параметра \"karmaDto\"");
        }

        [TestMethod]
        public void Create_EmployeeNotExistWithSuchId_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = A.Fake<KarmaDto>();
            A.CallTo(() => _employeeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act                      
            try
            {
                var newKarmaDto = service.Create(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Create не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");            
        }

        [TestMethod]
        public void Create_KarmaTypeNotExistWithSuchId_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = A.Fake<KarmaDto>();
            A.CallTo(() => _karmaTypeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);            

            // Act                      
            try
            {
                var newKarmaDto = service.Create(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Create не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Create_CreatedByNotExistWithSuchId_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = A.Fake<KarmaDto>();            
            karmaDto.CreatedById = Guid.Parse("58e3290d-ab00-4eee-b737-2442bbdc12e5");            

            A.CallTo(() => _employeeRepository.FirstOrDefault(Guid.Parse("58e3290d-ab00-4eee-b737-2442bbdc12e5"))).Returns(null);

            // Act                      
            try
            {
                var newKarmaDto = service.Create(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Create не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Create_InsertToRepositoryReturnNull_ThrowException()
        {
            // Arrange             
            A.CallTo(() => _karmaRepository.Insert(A<Karma>.Ignored)).Returns(null);

            // Act           
            try
            {
                var newKarmaDto = service.Create(A.Fake<KarmaDto>());
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
        public void Create_InputDtoModelIsValid_ReturnNewKarmaDto()
        {
            // Arrange            
            A.CallTo(() => _karmaRepository.Insert(A<Karma>.Ignored)).Returns(A.Fake<Karma>());

            // Act
            var newKarmaDto = service.Create(A.Fake<KarmaDto>());

            // Assert
            Assert.IsNotNull(newKarmaDto, "Новая карма не создана");
            Assert.IsNotNull(newKarmaDto.Id, "Не присвоен идентификатор новой записи");
            //был ли вызов метода Insert     
            A.CallTo(() => _karmaRepository.Insert(A<Karma>.Ignored)).MustHaveHappened();
        }


        [TestMethod]
        public void Delete_KarmaNotExist_ThrowException()
        {
            // Arrange             
            A.CallTo(() => _karmaRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act           
            try
            {
                service.Delete(Guid.NewGuid());
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Delete не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Delete_KarmaHaveVote_ThrowException()
        {
            // Arrange             
            A.CallTo(() => _karmaVoteRepository.Count(A<Expression<Func<KarmaVote, bool>>>.Ignored)).Returns(1);           

            // Act          
            try
            {
                service.Delete(Guid.NewGuid());
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
        public void Delete_KarmaNotHaveVote_SuccessDelete()
        {
            // Arrange             
            A.CallTo(() => _karmaVoteRepository.Count(A<Expression<Func<KarmaVote, bool>>>.Ignored)).Returns(0);

            // Act          
            try
            {
                service.Delete(Guid.NewGuid());
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNull(exception);
            //был ли вызов метода Delete     
            A.CallTo(() => _karmaRepository.Delete(A<Guid>.Ignored)).MustHaveHappened();
        }


        [TestMethod]
        public void Get_KarmaNotExistWithSuchId_ThrowException()
        {
            // Arrange          
            A.CallTo(() => _karmaRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act           
            try
            {
                var newKarmaDto = service.Get(Guid.NewGuid());
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Get не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
            A.CallTo(() => _karmaRepository.FirstOrDefault(A<Guid>.Ignored)).MustHaveHappened();
        }

        [TestMethod]
        public void Get_KarmaExistWithSuchId_newKarmaDto()
        {
            // Arrange   
            A.CallTo(() => _karmaRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(A.Fake<Karma>());

            // Act
            var newKarmaDto = service.Get(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(newKarmaDto, "Метод Get не возвратил значение");            
            A.CallTo(() => _karmaRepository.FirstOrDefault(A<Guid>.Ignored)).MustHaveHappened();
        }


        [TestMethod]
        public void GetAll_TotalInPagedCollectionIsEqualsTotalInRepository()
        {
            // Arrange            
            Random rnd = new Random();
            int countElement = rnd.Next(50);

            var fakeCollection = A.CollectionOfFake<Karma>(countElement).ToList();            
            A.CallTo(() => _karmaRepository.GetAll()).Returns(fakeCollection.AsQueryable());
            
            Random skip = new Random();
            Random top = new Random();


            // Act
            var newPagedCollectionDto = service.GetAll(skip.Next(), top.Next());

            // Assert
            Assert.IsNotNull(newPagedCollectionDto, "Метод GetAll не возвратил значение");
            Assert.AreEqual(newPagedCollectionDto.Total, countElement, "Возвращаемое общее колличество не равно колличеству записей в базе");
        }

        [TestMethod]
        public void GetAllEmployeeKarms_EmployeeNotExistWithSuchId_ThrowException()
        {
            // Arrange          
            A.CallTo(() => _employeeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act           
            try
            {
                var newKarmaDto = service.GetAllEmployeeKarms(Guid.NewGuid(),1,1);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод GetAllEmployeeKarms не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
            A.CallTo(() => _employeeRepository.FirstOrDefault(A<Guid>.Ignored)).MustHaveHappened();
        }
               

        [TestMethod]
        public void Update_ArgumentNull_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = null;

            // Act                      
            try
            {
                var newKarmaDto = service.Update(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Update не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(ArgumentException), "Неверный тип исключения");
            Assert.IsTrue(((ArgumentException)exception).ParamName == "karmaDto", "Ошибка не указывает на имя параметра \"karmaDto\"");
        }

        [TestMethod]
        public void Update_EmployeeNotExistWithSuchId_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = A.Fake<KarmaDto>();
            A.CallTo(() => _employeeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act                      
            try
            {
                var newKarmaDto = service.Update(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Update не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Update_KarmaTypeNotExistWithSuchId_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = A.Fake<KarmaDto>();
            A.CallTo(() => _karmaTypeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act                      
            try
            {
                var newKarmaDto = service.Update(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Update не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Update_CreatedByNotExistWithSuchId_ThrowException()
        {
            // Arrange
            KarmaDto karmaDto = A.Fake<KarmaDto>();
            karmaDto.CreatedById = Guid.Parse("58e3290d-ab00-4eee-b737-2442bbdc12e5");

            A.CallTo(() => _employeeRepository.FirstOrDefault(Guid.Parse("58e3290d-ab00-4eee-b737-2442bbdc12e5"))).Returns(null);

            // Act                      
            try
            {
                var newKarmaDto = service.Update(karmaDto);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Update не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Update_UpdateInRepositoryReturnNull_ThrowException()
        {
            // Arrange             
            A.CallTo(() => _karmaRepository.Update(A<Karma>.Ignored)).Returns(null);

            // Act           
            try
            {
                var newKarmaDto = service.Update(A.Fake<KarmaDto>());
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsNotNull(exception, "Метод Update не вызвал исключение");
            Assert.IsInstanceOfType(exception, typeof(InvalidOperationException), "Неверный тип исключения");
        }

        [TestMethod]
        public void Update_InputDtoModelIsValid_ReturnNewKarmaDto()
        {
            // Arrange            
            A.CallTo(() => _karmaRepository.Update(A<Karma>.Ignored)).Returns(A.Fake<Karma>());

            // Act
            var newKarmaDto = service.Update(A.Fake<KarmaDto>());

            // Assert
            Assert.IsNotNull(newKarmaDto, "Новая карма не создана");
            Assert.IsNotNull(newKarmaDto.Id, "Не присвоен идентификатор новой записи");
            //был ли вызов метода Insert     
            A.CallTo(() => _karmaRepository.Update(A<Karma>.Ignored)).MustHaveHappened();
        }
    }*/
}