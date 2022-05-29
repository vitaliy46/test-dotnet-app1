using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using FakeItEasy;
using Kis.General.Api.Dao.Repositories;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services;
using Kis.Hr.Api.Dao.Repositories;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Hr.Services;
using Kis.Hr.Services.Crud;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kis.Hr.Tests
{
    [TestClass]
    public class CandidateStateAppServiceTest
    {
        private IStateMachine _stateMachine;
        private ICandidateRepository _candidateRepository;
        private IStateRepository _stateRepository;
        private CandidateStateAsyncCrudAppService _appService;
        private IRepository<CandidateState, Guid> _repository;
        private Exception _exception;

        //Метод вызываемый перед каждым тестом
        [TestInitialize()]
        public void Initialize()
        {            
            _repository = A.Fake<IRepository<CandidateState, Guid>>();
            _candidateRepository = A.Fake<ICandidateRepository>();
            //_stateMachine = new StateMachine();
            _stateMachine = A.Fake<IStateMachine>();
            _stateRepository = A.Fake<IStateRepository>();
            
            //создание фэйкового сервиса
            _appService = new CandidateStateAsyncCrudAppService(_repository, _candidateRepository, _stateRepository,  _stateMachine);

            //настройка маппера            
            //_appService.ObjectMapper = AutoMapper.Mapper.Instance;
            //_appService.ObjectMapper = A.Fake<IObjectMapper>();

            /*A.CallTo(() => _appService.ObjectMapper.Map<CandidateDto>(A<CandidateDto>.Ignored)).Returns(A.Fake<CandidateDto>());
            A.CallTo(() => _appService.ObjectMapper.Map<StateDto>(A<StateDto>.Ignored)).Returns(A.Fake<StateDto>());
            A.CallTo(() => _appService.ObjectMapper.Map<List<StateDto>>(A<List<StateDto>>.Ignored)).Returns(A.Fake<List<StateDto>>());*/
            

            _exception = null;
        }


        /// <summary>
        /// Передаем методу GetAvailableStates null, должен вернуть не пустой список состояний
        /// </summary>
        [TestMethod]
        public void AvailableStatesDto_ArgumentNull_ReturnInitialStateDto()
        {
            // Arrange            
            A.CallTo(() => _stateMachine.GetAvailableStates(A<State>.Ignored)).Returns(new List<State>() { A.Fake<State>() });

            // Act
            var availableStatesDtoList = _appService.GetAvailableStates(null);

            // Assert            
            Assert.IsTrue(availableStatesDtoList.Count > 0, "Метод должен возвратить хотя бы одно начальное состояние");
        }


        /// <summary>
        /// Передаем методу GetAvailableStates пустой stateDto, должен вернуть не пустой список состояний
        /// </summary>
        [TestMethod]
        public void AvailableStatesDto_ArgumentEmpty_ReturnInitialStateDto()
        {
            // Arrange
            StateDto stateDto = new StateDto();
            A.CallTo(() => _stateMachine.GetAvailableStates(A<State>.Ignored)).Returns(new List<State>() { A.Fake<State>() });

            // Act
            var availableStatesDtoList = _appService.GetAvailableStates(stateDto);

            // Assert            
            Assert.IsTrue(availableStatesDtoList.Count > 0, "Метод должен возвратить хотя бы одно начальное состояние");
        }

        /// <summary>
        /// Передаем методу GetAvailableStates stateDto которого нет в машине состояний, должен вернуть пустой список состояний
        /// </summary>
        [TestMethod]
        public void AvailableStatesDto_ArgumentStateDtoNotExist_ReturnEmptyList()
        {
            // Arrange
            //Состояние с произвольным GUID , которого нет базе
            StateDto stateDto = new StateDto() { Id = Guid.Parse("af161341-773b-49f4-acbe-d9aed5cb54b5") };

            // Act
            var availableStatesDtoList = _appService.GetAvailableStates(stateDto);

            // Assert            
            Assert.IsTrue(availableStatesDtoList.Count == 0, "Метод должен возвратить пустой список состояний");
        }

        /// <summary>
        /// Передаем методу GetAvailableStates stateDto который есть в машине состояний, должен вернуть не пустой список состояний
        /// </summary>
        [TestMethod]
        public void AvailableStatesDto_ArgumentStateDtoExist_ReturnNotEmptyList()
        {
            // Arrange 
            A.CallTo(() => _stateMachine.GetAvailableStates(A<State>.Ignored)).Returns(new List<State>() { A.Fake<State>() });

            // Act
            var availableStatesDtoList = _appService.GetAvailableStates(A.Fake<StateDto>());

            // Assert            
            Assert.IsTrue(availableStatesDtoList.Count != 0, "Метод должен возвратить НЕ пустой список состояний");
        }

        /// <summary>
        /// Передаем методу ChangeState аргумент CandidateDto равный null, должен вернуть исключение
        /// </summary>
        [TestMethod]
        public void ChangeState_ArgumentCandidateDtoNull_ReturnException()
        {
            // Arrange            
            StateDto stateDto = new StateDto();

            // Act
            try
            {
                var newCandidateDto = _appService.ChangeState(null, stateDto);
            }
            catch (Exception e)
            {
                _exception = e;
            }

            // Assert
            Assert.IsNotNull(_exception, "Метод ChangeState не вызвал исключение");
            Assert.IsInstanceOfType(_exception, typeof(ArgumentException), "Неверный тип исключения");
        }

        /// <summary>
        /// Передаем методу ChangeState аргумент stateDto равный null, должен вернуть исключение
        /// </summary>
        [TestMethod]
        public void ChangeState_ArgumentStateDtoNull_ReturnException()
        {
            // Arrange            
            CandidateDto candidateDto = new CandidateDto();

            // Act
            try
            {
                var newCandidateDto = _appService.ChangeState(candidateDto, null);
            }
            catch (Exception e)
            {
                _exception = e;
            }

            // Assert
            Assert.IsNotNull(_exception, "Метод ChangeState не вызвал исключение");
            Assert.IsInstanceOfType(_exception, typeof(ArgumentException), "Неверный тип исключения");
        }

        /// <summary>
        /// Передаем методу ChangeState кандидата, которого нет в базе, должен вернуть исключение
        /// </summary>
        [TestMethod]
        public void ChangeState_CandidateNotExist_ReturnException()
        {
            // Arrange 
            A.CallTo(() => _candidateRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act
            try
            {
                var newCandidateDto = _appService.ChangeState(new CandidateDto(), new StateDto());
            }
            catch (Exception e)
            {
                _exception = e;
            }

            // Assert
            Assert.IsNotNull(_exception, "Метод ChangeState не вызвал исключение");
            Assert.IsInstanceOfType(_exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        /// <summary>
        /// Передаем методу ChangeState состояние, которого нет в базе, должен вернуть исключение
        /// </summary>
        [TestMethod]
        public void ChangeState_StateNotExist_ReturnException()
        {
            // Arrange
            A.CallTo(() => _candidateRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(new Candidate());
            A.CallTo(() => _stateRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act
            try
            {
                var newCandidateDto = _appService.ChangeState(new CandidateDto(), new StateDto());
            }
            catch (Exception e)
            {
                _exception = e;
            }

            // Assert
            Assert.IsNotNull(_exception, "Метод ChangeState не вызвал исключение");
            Assert.IsInstanceOfType(_exception, typeof(EntityNotFoundException), "Неверный тип исключения");
        }

        /// <summary>
        /// Передаем методу ChangeState состояние в который нельзя перейти из текущего состояния, должен вернуть исключение
        /// </summary>
        [TestMethod]
        public void ChangeState_StatesNotAvailable_ReturnException()
        {
            // Arrange
            A.CallTo(() => _candidateRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(new Candidate());
            A.CallTo(() => _stateRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(new State());            

            // Act
            try
            {
                var newCandidateDto = _appService.ChangeState(new CandidateDto(), A.Fake<StateDto>());
            }
            catch (Exception e)
            {
                _exception = e;
            }

            // Assert
            Assert.IsNotNull(_exception, "Метод ChangeState не вызвал исключение");
            Assert.IsInstanceOfType(_exception, typeof(KeyNotFoundException), "Неверный тип исключения");
        }

        /// <summary>
        /// Передаем методу ChangeState валидные аргументы, должно произойти событие записи в базу нового состояния
        /// </summary>
        [TestMethod]
        public void ChangeState_AllArgumentValid_WriteToDBMustHaveHappened()
        {
            // Arrange
            A.CallTo(() => _repository.Insert(A<CandidateState>.Ignored)).Returns(new CandidateState());
            A.CallTo(() => _candidateRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(new Candidate());
            A.CallTo(() => _stateRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(A.Fake<State>());
            A.CallTo(() => _stateMachine.GetAvailableStates(A<State>.Ignored)).Returns(new List<State>() { A.Fake<State>() });

            // Act
            try
            {
                var newCandidateDto = _appService.ChangeState(new CandidateDto(), new StateDto());
            }
            catch (Exception e)
            {
                _exception = e;
            }

            // Assert            
            //был ли вызов метода Insert     
            A.CallTo(() => _repository.Insert(A<CandidateState>.Ignored)).MustHaveHappened();
        }
    }
}
