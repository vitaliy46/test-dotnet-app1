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
    /// Фейковый репозиторий для <see cref="KarmaType"/>
    /// </summary>
    public class FakeKarmaTypeRepository : IKarmaTypeRepository
    {
        private List<KarmaType> karmaTypes = new List<KarmaType>();

        public FakeKarmaTypeRepository()
        {
            karmaTypes.Add(new KarmaType { Id = Guid.Parse("70e3290d-ab00-4eee-b737-2442bbdc09e3"), Name = "Помощь джуниору", Value = 10, Weight = 0.5 });
            karmaTypes.Add(new KarmaType { Id = Guid.Parse("9a5f620c-9c4f-4417-8061-262809e868cc"), Name = "Выступление на семинаре", Value = 100, Weight = 1.0 });
            karmaTypes.Add(new KarmaType { Id = Guid.Parse("c3fb6156-9c44-4f73-9e45-7ff8aa70df41"), Name = "Выполнение поручения", Value = 50, Weight = 0.5 });
        }

        public int Count()
        {
            return karmaTypes.Count();
        }

        public KarmaType Update(KarmaType entity)
        {
            int index = karmaTypes.FindIndex(p => p.Id == entity.Id);
            if (index == -1)
            {
                return null;
            }
            karmaTypes.RemoveAt(index);
            karmaTypes.Add(entity);
            return entity;
        }

        public void Delete(Guid id)
        {
            karmaTypes.RemoveAll(p => p.Id == id);
            //throw new ArgumentException($"Невозможно удалить запись " + id + ". Имеются связаные с ней записи.");
        }

        public KarmaType Get(Guid id)
        {
            return karmaTypes.Find(p => p.Id == id);
        }

        public KarmaType FirstOrDefault(Guid id)
        {
            return karmaTypes.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<KarmaType> GetAll()
        {
            return karmaTypes.AsQueryable();
        }

        public List<KarmaType> GetAllList()
        {
            return karmaTypes.ToList();
        }

        public KarmaType Insert(KarmaType entity)
        {
            entity.Id = Guid.NewGuid();
            karmaTypes.Add(entity);
            return entity;
        }


        public int Count(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        

        public void Delete(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

       

        public KarmaType FirstOrDefault(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> FirstOrDefaultAsync(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

       

        public IQueryable<KarmaType> GetAllIncluding(params Expression<Func<KarmaType, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        

        public List<KarmaType> GetAllList(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<KarmaType>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<KarmaType>> GetAllListAsync(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        
        public Guid InsertAndGetId(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> InsertAsync(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public KarmaType InsertOrUpdate(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> InsertOrUpdateAsync(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public KarmaType Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<KarmaType>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public KarmaType Single(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> SingleAsync(Expression<Func<KarmaType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        

        public KarmaType Update(Guid id, Action<KarmaType> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> UpdateAsync(KarmaType entity)
        {
            throw new NotImplementedException();
        }

        public Task<KarmaType> UpdateAsync(Guid id, Func<KarmaType, Task> updateAction)
        {
            throw new NotImplementedException();
        }
    }
}
