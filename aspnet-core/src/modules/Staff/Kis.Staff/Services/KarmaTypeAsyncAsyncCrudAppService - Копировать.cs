using System;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Kis.Base.Services.Bl;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;
using Kis.Staff.Api.Services;

namespace Kis.Staff.Services
{
    public class KarmaTypeAsyncAsyncCrudAppService : AsyncCrudAppServiceBase<KarmaType, KarmaTypeDto, Guid>, IKarmaTypeAsyncCrudAppService
    {
        private readonly IKarmaRepository _karmaRepository;

        public KarmaTypeAsyncAsyncCrudAppService (IKarmaTypeRepository karmaTypesRepository,
                                            IKarmaRepository karmaRepository) : base(karmaTypesRepository)
        {
            _karmaRepository = karmaRepository;
        }

        /// <summary>
        /// Удаление типа кармы
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public override async Task Delete(Guid id)
        {
            KarmaType karmaType = Repository.FirstOrDefault(id);
            if (karmaType == null)
                throw new EntityNotFoundException($"Невозможно удалить запись " + id + ". Не существует записи по заданному идентификатору.");

            // Логика проверки:
            // Тип кармы возможно удалить только в том случае, 
            // если с ним не связана ни одна карма сотрудников
            int countChild = _karmaRepository.Count(x => x.KarmaType.Id == id);
            if (countChild != 0)
                throw new InvalidOperationException($"Невозможно удалить запись " + id + ". Имеются связаные с ней записи.");
                        
            Repository.Delete(id);
        }

    }
}