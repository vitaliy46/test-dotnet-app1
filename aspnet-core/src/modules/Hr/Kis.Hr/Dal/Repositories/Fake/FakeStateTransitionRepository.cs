using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kis.General.Api.Dao.Repositories;
using Kis.General.Api.Entity;

namespace Kis.Hr.Dao.Repositories.Fake
{
    /// <summary>
    /// Фейковая реализация репозитория переходов
    /// </summary>
    public class FakeStateTransitionRepository : IStateTransitionRepository
    {
        /// <summary>
        /// Список возможных переходов
        /// </summary>
        private List<StateTransition> _stateTransitions = new List<StateTransition>();

        private List<State> _states = new List<State>();

        public FakeStateTransitionRepository()
        {            
            State _initial = new State() { Id = Guid.Parse("00000000-0000-0000-0000-000000000000"), Name = "" , Description = ""};
            State _new = new State() { Id = Guid.Parse("f2a382f9-aab4-45c4-82b2-13825cee717a"), Name = "Новый", Description = "Новый" };
            State _firstContact = new State() { Id = Guid.Parse("da7603c4-e0fc-442b-b5f4-176ec66b6406"), Name = "Первый контакт", Description = "Первый контакт" };
            State _sentDocuments = new State() { Id = Guid.Parse("7bb80407-aee0-453e-9f08-57194cfd8ad3"), Name = "Высланы документы для заполнения", Description = "Высланы документы для заполнения" };
            State _providedResume = new State() { Id = Guid.Parse("69f171a9-9235-4b66-80bb-dcd06cf0b997"), Name = "Предоставил резюме лист и анкету", Description = "Предоставил резюме лист и анкету" };
            State _readyToPrimaryInterview = new State() { Id = Guid.Parse("56ae582b-62d3-43ca-a103-06d0958b1837"), Name = "Готовность к предварительному собеседованию", Description = "Готовность к предварительному собеседованию" };
            State _waitResultPrimaryInterview = new State() { Id = Guid.Parse("7b766d9a-56de-4503-9ca1-77cd2af7dc5d"), Name = "Ожидает результат предварительного собеседования", Description = "Ожидает результат предварительного собеседования" };
            State _readyToTechnicalInterview = new State() { Id = Guid.Parse("a73f35fd-1bbf-4d77-9403-6ca1697ecfd6"), Name = "Готовность к техническому cобеседованию с тимлидами", Description = "Готовность к техническому cобеседованию с тимлидами" };
            State _waitResultTechnicalInterview = new State() { Id = Guid.Parse("5fdd915a-101d-4b9d-aabd-b44c6f0b27c2"), Name = "Ожидает результат технического собеседования", Description = "Ожидает результат технического собеседования" };
            State _denied = new State() { Id = Guid.Parse("cfa73327-3888-4f6a-93e5-88fcf2f1b29f"), Name = "Отказали мы", Description = "Отказали мы" };
            State _deniedSelf = new State() { Id = Guid.Parse("f7a49a74-b93c-46de-bdcb-02a2ad29b515"), Name = "Отказался сам", Description = "Отказался сам" };
            State _reserve = new State() { Id = Guid.Parse("3a4ccfde-9963-448c-a41f-4bd53fb5d4b1"), Name = "В резерве", Description = "В резерве" };
            State _approved = new State() { Id = Guid.Parse("88b14292-c6e6-44a6-9dac-9cd778b00ad5"), Name = "Одобрен для принятия в сотрудники", Description = "Одобрен для принятия в сотрудники" };
            State _patronage = new State() { Id = Guid.Parse("d333d6a0-3852-41d4-b1d7-65c78a430603"), Name = "На доращивании", Description = "На доращивании" };
            State _offer = new State() { Id = Guid.Parse("7cc05191-152e-467c-855e-20d2c9711525"), Name = "Выставлен оффер для принятия кандидатом", Description = "Выставлен оффер для принятия кандидатом" };
            State _accepted = new State() { Id = Guid.Parse("b98a6fcd-e27b-4bd3-af1d-6d37d96cf26e"), Name = "Принят на работу", Description = "Принят на работу" };


            _states.AddRange(new List<State>() { _initial, _new, _firstContact, _sentDocuments, _providedResume, _readyToPrimaryInterview, _waitResultPrimaryInterview, _waitResultTechnicalInterview,
                _readyToTechnicalInterview, _denied, _deniedSelf, _reserve, _approved, _patronage, _offer, _accepted });

            //Переход из начального состояния в состояние "Новый"
            _stateTransitions.Add(new StateTransition() { Id = Guid.NewGuid(), StateFrom = _initial, StateTo = _new });

            //Переход из состояния "Новый" в состояние "Первый контакт"
            _stateTransitions.Add(new StateTransition() { Id = Guid.NewGuid(), StateFrom = _new, StateTo = _firstContact });

            //Переход из состояния "Первый контакт" в состояние "Высланы док-ты для заполнения", "Отказали мы", "Отказался сам"
            _stateTransitions.AddRange(
                  new List<StateTransition>(){
                      new StateTransition() { Id = Guid.NewGuid(), StateFrom = _firstContact, StateTo = _sentDocuments },
                      new StateTransition() { Id = Guid.NewGuid(), StateFrom = _firstContact, StateTo = _deniedSelf },
                      new StateTransition() { Id = Guid.NewGuid(), StateFrom = _firstContact, StateTo = _denied }
                });

            //Переход из состояния "Высланы док-ты для заполнения" в состояние "Предоставил резюме лист и анкету", "Отказали мы"            
            _stateTransitions.AddRange(
                new List<StateTransition>(){
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _sentDocuments, StateTo = _providedResume } ,
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _sentDocuments, StateTo = _deniedSelf }                    
                });

            //Переход из состояния "Предоставил резюме лист и анкету" в состояние "Готовность к предварительному собеседованию"
            _stateTransitions.Add(new StateTransition() { Id = Guid.NewGuid(), StateFrom = _providedResume, StateTo = _readyToPrimaryInterview });

            //Переход из состояния "Готовность к предварительному собеседованию" в состояние "Ожидает результат предварительного собеседования", "В резерве", "Отказали мы", "Отказался сам"
            _stateTransitions.AddRange( 
                new List<StateTransition>(){
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _readyToPrimaryInterview, StateTo = _waitResultPrimaryInterview} ,
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _readyToPrimaryInterview, StateTo = _deniedSelf },
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _readyToPrimaryInterview, StateTo = _denied }
                });

            //Переход из состояния "В резерве" в состояние "Готовность к предварительному собеседованию"
            _stateTransitions.Add(new StateTransition() { Id = Guid.NewGuid(), StateFrom = _reserve, StateTo = _readyToPrimaryInterview });

            //Переход из состояния "Ожидает результат предварительного собеседования" в состояние "Готовность к техническому cобеседованию с тимлидами", "В резерве",  "В резерве", "Отказался сам"
            _stateTransitions.AddRange(
                new List<StateTransition>(){
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _waitResultPrimaryInterview, StateTo = _readyToTechnicalInterview} ,
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _waitResultPrimaryInterview, StateTo = _deniedSelf },
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _waitResultPrimaryInterview, StateTo = _reserve }
                });

            //Переход из состояния "Готовность к техническому cобеседованию с тимлидами" в состояние "Ожидает результат технического собеседования", "В резерве" 
            _stateTransitions.AddRange(
                new List<StateTransition>(){
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _readyToTechnicalInterview, StateTo = _waitResultTechnicalInterview } ,
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _readyToTechnicalInterview, StateTo = _reserve }
                });


            //Переход из состояния "Ожидает результат технического собеседования" в состояние "Одобрен для принятия в сотрудники", "Отказали мы", "Отказался сам", "На доращивании" 
            _stateTransitions.AddRange(
                new List<StateTransition>(){
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _waitResultTechnicalInterview, StateTo = _approved } ,                   
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _waitResultTechnicalInterview, StateTo = _denied },
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _waitResultTechnicalInterview, StateTo = _deniedSelf },
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _waitResultTechnicalInterview, StateTo = _patronage }
                });
                        

            //Переход из состояния "На доращивании" в состояние "Одобрен для принятия в сотрудники", "Отказали мы", "Отказался сам", "Готовность к техническому cобеседованию с тимлидами"
            _stateTransitions.AddRange(
                new List<StateTransition>(){
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _patronage, StateTo = _approved } ,
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _patronage, StateTo = _readyToTechnicalInterview },
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _patronage, StateTo = _deniedSelf },
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _patronage, StateTo = _denied }
                });

            //Переход из состояния "Одобрен для принятия в сотрудники" в состояние "Выставлен оффер для принятия кандидатом"
            _stateTransitions.Add(new StateTransition() { Id = Guid.NewGuid(), StateFrom = _approved, StateTo = _offer });

            //Переход из состояния "Выставлен оффер для принятия кандидатом" в состояние "Отказался сам", "Принят на работу"
            _stateTransitions.AddRange(
                new List<StateTransition>(){
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _offer, StateTo = _deniedSelf } ,                    
                    new StateTransition() { Id = Guid.NewGuid(), StateFrom = _offer, StateTo = _accepted }
                });
        }

        public List<StateTransition> GetAllList(Expression<Func<StateTransition, bool>> predicate)
        {
            return _stateTransitions.Where(predicate.Compile()).ToList();
        }

        public int Count()
        {
            return _stateTransitions.Count();
        }

        #region Not Implemented Methods
        public int Count(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public StateTransition FirstOrDefault(Guid id)
        {
            throw new NotImplementedException();
        }

        public StateTransition FirstOrDefault(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> FirstOrDefaultAsync(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public StateTransition Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<StateTransition> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<StateTransition> GetAllIncluding(params Expression<Func<StateTransition, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<StateTransition> GetAllList()
        {
            throw new NotImplementedException();
        }


        public Task<List<StateTransition>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StateTransition>> GetAllListAsync(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public StateTransition Insert(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertAndGetId(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> InsertAsync(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public StateTransition InsertOrUpdate(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> InsertOrUpdateAsync(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public StateTransition Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<StateTransition>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public StateTransition Single(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> SingleAsync(Expression<Func<StateTransition, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public StateTransition Update(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public StateTransition Update(Guid id, Action<StateTransition> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> UpdateAsync(StateTransition entity)
        {
            throw new NotImplementedException();
        }

        public Task<StateTransition> UpdateAsync(Guid id, Func<StateTransition, Task> updateAction)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
