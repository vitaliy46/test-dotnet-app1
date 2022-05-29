using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Entity;

namespace Kis.Investors.Dao.Repositories.Fake
{
    
    public class FakeInvestorRepository : InvestorsRepositoryBase<Investor>, IInvestorRepository
    {
        private List<Investor> _Investors = new List<Investor>();

        public FakeInvestorRepository(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _Investors.Add(new Investor() { Id = Guid.Parse("4b4772c6-3c70-479c-940c-7aaae9b84880") });
        }
        

        public Investor FirstOrDefault(Guid id)
        {
            return _Investors.FirstOrDefault(p => p.Id == id);
        }


        public Investor Get(Guid id)
        {
            return _Investors.FirstOrDefault(p => p.Id == id);
        }

        public Investor FirstOrDefault(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(Investor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> FirstOrDefaultAsync(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Investor> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Investor> GetAllIncluding(params Expression<Func<Investor, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<Investor> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<Investor> GetAllList(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Investor>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Investor>> GetAllListAsync(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Investor Insert(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertAndGetId(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> InsertAsync(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Investor InsertOrUpdate(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> InsertOrUpdateAsync(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Investor Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<Investor>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public Investor Single(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> SingleAsync(Expression<Func<Investor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Investor Update(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Investor Update(Guid id, Action<Investor> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> UpdateAsync(Investor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Investor> UpdateAsync(Guid id, Func<Investor, Task> updateAction)
        {
            throw new NotImplementedException();
        }
    }
    
}
