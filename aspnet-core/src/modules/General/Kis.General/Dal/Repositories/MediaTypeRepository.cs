using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="MediaType"/>
    /// </summary>
    public class MediaTypeRepository : GeneralRepositoryBase<MediaType>, IMediaTypeRepository
    {
        public MediaTypeRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}