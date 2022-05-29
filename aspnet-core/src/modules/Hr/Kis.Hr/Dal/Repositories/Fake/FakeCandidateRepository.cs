using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kis.Hr.Api.Dao.Repositories;
using Kis.Hr.Api.Entity;

namespace Kis.Hr.Dao.Repositories.Fake
{
    
    public class FakeCandidateRepository : ICandidateRepository
    {
        private List<Candidate> _candidates = new List<Candidate>();

        public FakeCandidateRepository()
        {
            _candidates.Add(new Candidate() { Id = Guid.Parse("4b4772c6-3c70-479c-940c-7aaae9b84880") });
        }

        public Candidate FirstOrDefault(Guid id)
        {
            return _candidates.FirstOrDefault(p => p.Id == id);
        }


        public Candidate Get(Guid id)
        {
            return _candidates.FirstOrDefault(p => p.Id == id);
        }

        public Candidate FirstOrDefault(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        

      

        public Task<Candidate> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> FirstOrDefaultAsync(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Candidate> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Candidate> GetAllIncluding(params Expression<Func<Candidate, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllList(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Candidate>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Candidate>> GetAllListAsync(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Candidate Insert(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertAndGetId(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> InsertAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Candidate InsertOrUpdate(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> InsertOrUpdateAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Candidate Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<Candidate>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public Candidate Single(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> SingleAsync(Expression<Func<Candidate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Candidate Update(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Candidate Update(Guid id, Action<Candidate> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> UpdateAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> UpdateAsync(Guid id, Func<Candidate, Task> updateAction)
        {
            throw new NotImplementedException();
        }
    }
    
}
