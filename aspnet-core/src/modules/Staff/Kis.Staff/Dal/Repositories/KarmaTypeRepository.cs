using System;
using Abp.EntityFrameworkCore;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="KarmaType"/>
    /// </summary>
    public class KarmaTypeRepository : StaffRepositoryBase<KarmaType>, IKarmaTypeRepository
    {
        /// <summary>
        /// Репозиторий для <see cref="KarmaType"/>
        /// </summary>
        public KarmaTypeRepository(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        { }

        public override KarmaType Insert(KarmaType entity)
        {
            var insertedEntity = base.Insert(entity);
            Context.SaveChanges();

            return insertedEntity;
        }

        public override KarmaType Update(KarmaType entity)
        {
            var updatedEntity = base.Update(entity);
            Context.SaveChanges();

            return updatedEntity;
        }

        public override void Delete(Guid id)
        {
            base.Delete(id);
            Context.SaveChanges();
        }
    }
}
