using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FakeItEasy;
using Kis.General.Api.Dao.Repositories;
using Kis.General.Api.Entity;
using Kis.General.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kis.Hr.Tests
{
    [TestClass]
    public class StateMachineTest
    {
        private IStateTransitionRepository _stateTransitionRepository;
        private StateMachine _service;
        private Exception _exception;

        [TestInitialize()]
        public void Initialize()
        {
            _stateTransitionRepository = A.Fake<IStateTransitionRepository>();
            
            //создание фэйкового сервиса
            _service = new StateMachine(_stateTransitionRepository);

            _exception = null;
        }

        /// <summary>
        /// Передаем методу GetAvailableStates state который есть в машине состояний, должен вернуть не пустой список состояний
        /// </summary>
        [TestMethod]
        public void GetAvailableStates_ArgumentStateExist_ReturnNotEmptyList()
        {
            // Arrange 
            A.CallTo(() => _stateTransitionRepository.GetAllList(A<Expression<Func<StateTransition, bool>>>.Ignored)).Returns(new List<StateTransition>() { A.Fake<StateTransition>() });

            // Act
            var availableStatesList = _service.GetAvailableStates(A.Fake<State>());

            // Assert            
            Assert.IsTrue(availableStatesList.Count != 0, "Метод должен возвратить НЕ пустой список состояний");
        }

        /// <summary>
        /// Передаем методу GetAvailableStates state которого нет в машине состояний, должен вернуть пустой список состояний
        /// </summary>
        [TestMethod]
        public void GetAvailableStates_ArgumentStateNotExist_ReturnEmptyList()
        {
            // Arrange 
            A.CallTo(() => _stateTransitionRepository.GetAllList(A<Expression<Func<StateTransition, bool>>>.Ignored)).Returns(new List<StateTransition>());

            // Act
            var availableStatesList = _service.GetAvailableStates(A.Fake<State>());

            // Assert            
            Assert.IsTrue(availableStatesList.Count == 0, "Метод должен возвратить пустой список состояний");
        }

        /// <summary>
        /// Передаем методу GetAvailableStates null, должен вернуть исключение
        /// </summary>
        [TestMethod]
        public void GetAvailableStates_ArgumentNull_ReturnException()
        {
            // Act
            try
            {
                var availableStatesList = _service.GetAvailableStates(null);
            }
            catch (Exception e)
            {
                _exception = e;
            }

            // Assert
            Assert.IsNotNull(_exception, "Метод GetAvailableStates не вызвал исключение");
            Assert.IsInstanceOfType(_exception, typeof(ArgumentException), "Неверный тип исключения");
        }
    }
}
