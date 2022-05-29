using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kis.General.Api.Dao.Repositories;
using Kis.General.Api.Entity;

namespace Kis.Hr.Dao.Repositories.Fake
{
    public class FakeStateRepository : IStateRepository
    {
        List<State> _states = new List<State>();

        public FakeStateRepository()
        {            
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
            

            _states.AddRange(new List<State>() { _new, _firstContact, _sentDocuments, _providedResume, _readyToPrimaryInterview, _waitResultPrimaryInterview, _waitResultTechnicalInterview,
                _readyToTechnicalInterview, _denied, _deniedSelf, _reserve, _approved, _patronage, _offer, _accepted });
        }

        public State FirstOrDefault(Guid id)
        {
            return _states.FirstOrDefault(p => p.Id == id);
        }


        #region Not Implemented Methods
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(State entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(State entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }



        public State FirstOrDefault(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<State> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<State> FirstOrDefaultAsync(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public State Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<State> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<State> GetAllIncluding(params Expression<Func<State, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<State> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<State> GetAllList(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<State>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<State>> GetAllListAsync(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<State> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public State Insert(State entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertAndGetId(State entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(State entity)
        {
            throw new NotImplementedException();
        }

        public Task<State> InsertAsync(State entity)
        {
            throw new NotImplementedException();
        }

        public State InsertOrUpdate(State entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(State entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(State entity)
        {
            throw new NotImplementedException();
        }

        public Task<State> InsertOrUpdateAsync(State entity)
        {
            throw new NotImplementedException();
        }

        public State Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<State>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public State Single(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<State> SingleAsync(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public State Update(State entity)
        {
            throw new NotImplementedException();
        }

        public State Update(Guid id, Action<State> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<State> UpdateAsync(State entity)
        {
            throw new NotImplementedException();
        }

        public Task<State> UpdateAsync(Guid id, Func<State, Task> updateAction)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
