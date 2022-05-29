using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Dependency;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories.Fake
{
    public class FakeEmployeeRepository : IEmployeeRepository, ISingletonDependency
    {
        private List<Employee> listEmployee = new List<Employee>();

        public FakeEmployeeRepository()
        {
            listEmployee.Add(new Employee { Id = Guid.Parse("98a5d943-ee2e-40fb-8889-7766f893b5da") });
            listEmployee.Add(new Employee { Id = Guid.Parse("56d33707-d2c9-47ab-b9cc-e6d783ed2b41") });
            listEmployee.Add(new Employee { Id = Guid.Parse("bc1f78d8-11b9-43a6-994a-08a50f8c739c") });
            listEmployee.Add(new Employee { Id = Guid.Parse("1a2f620c-9c4f-4417-8061-262809e867cc") });
        }


        public Employee Get(Guid id)
        {
            return listEmployee.Find(p => p.Id == id);
        }

        public Employee FirstOrDefault(Guid id)
        {
            return listEmployee.FirstOrDefault(p => p.Id == id);
        }


        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

       
        public Employee FirstOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> FirstOrDefaultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> FirstOrDefaultAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetAllIncluding(params Expression<Func<Employee, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllList(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllListAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertAndGetId(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAndGetIdAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> InsertAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee InsertOrUpdate(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Guid InsertOrUpdateAndGetId(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertOrUpdateAndGetIdAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> InsertOrUpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<Employee>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public Employee Single(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> SingleAsync(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Guid id, Action<Employee> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Guid id, Func<Employee, Task> updateAction)
        {
            throw new NotImplementedException();
        }
    }
}