using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories.Fake
{
    /// <summary>
    /// Фейковый репозиторий для <see cref="Karma"/>
    /// </summary>
    public class FakeKarmaRepository : IKarmaRepository
    {
        private List<Karma> listKarma = new List<Karma>();        

        public FakeKarmaRepository()
        {
            listKarma.Add(new Karma { Id = Guid.Parse("58e3290d-ab00-4eee-b737-2442bbdc12e5"),
                KarmaType = new KarmaType() { Id = Guid.Parse("70e3290d-ab00-4eee-b737-2442bbdc09e3"), Name = "Помощь джуниору", Value = 10, Weight = 0.5 },
                Employee = new Employee { Id = Guid.Parse("98a5d943-ee2e-40fb-8889-7766f893b5da") },
                CreatedBy = new Employee { Id = Guid.Parse("1a2f620c-9c4f-4417-8061-262809e867cc") },
                KarmaVotes = new List<KarmaVote>() { new KarmaVote() { Id = Guid.Parse("11e3290d-ab00-4eee-b737-2442bbdc22e3") } }
            });
            listKarma.Add(new Karma
            {
                Id = Guid.Parse("33e3290d-ab00-4eee-b737-2442bbdc12e8"),
                KarmaType = new KarmaType { Id = Guid.Parse("9a5f620c-9c4f-4417-8061-262809e868cc"), Name = "Выступление на семинаре", Value = 100, Weight = 1.0 },
                Employee = new Employee { Id = Guid.Parse("98a5d943-ee2e-40fb-8889-7766f893b5da") },
                CreatedBy = new Employee { Id = Guid.Parse("56d33707-d2c9-47ab-b9cc-e6d783ed2b41") }
            });
            listKarma.Add(new Karma { Id = Guid.Parse("9a5f620c-9c4f-4417-8061-262809e868cc"),
                KarmaType = new KarmaType { Id = Guid.Parse("9a5f620c-9c4f-4417-8061-262809e868cc"), Name = "Выступление на семинаре", Value = 100, Weight = 1.0 },
                Employee = new Employee { Id = Guid.Parse("56d33707-d2c9-47ab-b9cc-e6d783ed2b41") },
                CreatedBy = new Employee { Id = Guid.Parse("98a5d943-ee2e-40fb-8889-7766f893b5da") }
            });
            listKarma.Add(new Karma { Id = Guid.Parse("c3fb6156-9c44-4f73-9e45-7ff8aa70df41"),
                KarmaType = new KarmaType() { Id = Guid.Parse("70e3290d-ab00-4eee-b737-2442bbdc09e3"), Name = "Помощь джуниору", Value = 10, Weight = 0.5 },
                Employee = new Employee { Id = Guid.Parse("bc1f78d8-11b9-43a6-994a-08a50f8c739c") },
                CreatedBy = new Employee { Id = Guid.Parse("98a5d943-ee2e-40fb-8889-7766f893b5da") }
            });
        }

        public int Count()
        {
            return listKarma.Count();
        }

        public int Count(Expression<Func<Karma, bool>> predicate)
        {
            return listKarma.Count(predicate.Compile());
            /*try
            {               
                var t = listKarma.FirstOrDefault(predicate.Compile());
                return 1;
            }
            catch
            {
                return 0;
            } */
        }
 
        public Karma Update(Karma entity)
        {
            int index = listKarma.FindIndex(p => p.Id == entity.Id);
            if (index == -1)
            {
                return null;
            }
            listKarma.RemoveAt(index);
            listKarma.Add(entity);
            return entity;
        }

        public void Delete(Guid id)
        {
            listKarma.RemoveAll(p => p.Id == id);            
        }

        public Karma Get(Guid id)
        {
            return listKarma.Find(p => p.Id == id);
        }

        public Karma FirstOrDefault(Guid id)
        {
            return listKarma.FirstOrDefault(p => p.Id == id);
        }
        public List<Karma> GetAllList()
        {
            return listKarma.ToList();
        }

        public Karma Insert(Karma entity)
        {
            entity.Id = Guid.NewGuid();
            listKarma.Add(entity);
            return entity;
        }

        public IQueryable<Karma> GetAll()
        {
            return listKarma.AsQueryable();
        }

        public IQueryable<Karma> GetAllIncluding(params Expression<Func<Karma, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public Task<List<Karma>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public List<Karma> GetAllList(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Karma>> GetAllListAsync(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<Karma>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public Task<Karma> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Karma Single(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Karma> SingleAsync(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        

        public Task<Karma> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Karma FirstOrDefault(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Karma> FirstOrDefaultAsync(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Karma Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Karma> InsertAsync(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertAndGetId(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Karma InsertOrUpdate(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Task<Karma> InsertOrUpdateAsync(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Task<Karma> UpdateAsync(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Karma Update(Guid id, Action<Karma> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<Karma> UpdateAsync(Guid id, Func<Karma, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Karma entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<Karma, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
