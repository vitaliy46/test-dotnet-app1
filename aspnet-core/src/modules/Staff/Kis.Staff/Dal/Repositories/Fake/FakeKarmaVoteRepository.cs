using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories.Fake
{
    public class FakeKarmaVoteRepository : IKarmaVoteRepository
    {
        private List<KarmaVote> listKarmaVotes = new List<KarmaVote>();        
       
        public FakeKarmaVoteRepository()
        {
            Karma karma = new Karma()
            {
                Id = Guid.Parse("58e3290d-ab00-4eee-b737-2442bbdc12e5"),
                KarmaType = new KarmaType() { Id = Guid.Parse("70e3290d-ab00-4eee-b737-2442bbdc09e3"), Name = "Помощь джуниору", Value = 10, Weight = 0.5 },
                Employee = new Employee { Id = Guid.Parse("60e3210d-ab00-4eee-b737-2442bbdc09e6") },
                CreatedBy = new Employee { Id = Guid.Parse("1a2f620c-9c4f-4417-8061-262809e867cc") }
            };

            listKarmaVotes.Add(new KarmaVote() {Id = Guid.Parse("11e3290d-ab00-4eee-b737-2442bbdc22e3"), Karma = karma });
        }
               

        public int Count(Expression<Func<KarmaVote, bool>> predicate)
        {
            return listKarmaVotes.Count(predicate.Compile());
           /* try
            {
                var t = listKarmaVotes.FirstOrDefault(predicate.Compile());
                return 1;
            }
            catch
            {
                return 0;
            }*/
        }


        public int Count()
        {
            throw new NotImplementedException();
        }


        public KarmaVote Get(Guid id)
        {
            return listKarmaVotes.Find(p => p.Id == id);
        }

        public KarmaVote FirstOrDefault(Guid id)
        {
            return listKarmaVotes.FirstOrDefault(p => p.Id == id);
        }


        public IQueryable<KarmaVote> GetAll()
        {
            return listKarmaVotes.AsQueryable();
        }

        public KarmaVote Insert(KarmaVote entity)
        {
            entity.Id = Guid.NewGuid();
            listKarmaVotes.Add(entity);
            return entity;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

       
        public KarmaVote FirstOrDefault(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> FirstOrDefaultAsync(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }



        public IQueryable<KarmaVote> GetAllIncluding(params Expression<Func<KarmaVote, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<KarmaVote> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<KarmaVote> GetAllList(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<KarmaVote>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<KarmaVote>> GetAllListAsync(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Guid InsertAndGetId(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> InsertAsync(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public KarmaVote InsertOrUpdate(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> InsertOrUpdateAsync(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public KarmaVote Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<KarmaVote>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public KarmaVote Single(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> SingleAsync(Expression<Func<KarmaVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public KarmaVote Update(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public KarmaVote Update(Guid id, Action<KarmaVote> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> UpdateAsync(KarmaVote entity)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaVote> UpdateAsync(Guid id, Func<KarmaVote, Task> updateAction)
        {
            throw new NotImplementedException();
        }
    }
}