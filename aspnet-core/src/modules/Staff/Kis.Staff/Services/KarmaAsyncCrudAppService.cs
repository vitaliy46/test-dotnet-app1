using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;
using Kis.Staff.Api.Services;

namespace Kis.Staff.Services
{
    public class KarmaAsyncCrudAppService : AsyncCrudAppServiceBase<Karma, KarmaDto, Guid>, IKarmaAsyncCrudAppService
    {
        private readonly IKarmaTypeRepository _karmaTypesRepository;
        private readonly IKarmaVoteRepository _karmaVoteRepository;
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Конструктор класса KarmaAsyncCrudAppService
        /// </summary>        
        /// <param name="karmaRepository">Репозиторий карм</param>
        /// <param name="karmaTypesRepository">Репозиторий типов кармы</param>
        /// <param name="karmaVoteRepository">Репозиторий голосов за карму</param>
        /// <param name="employeeRepository">Репозиторий сотрудников</param>
        public KarmaAsyncCrudAppService (IKarmaRepository karmaRepository, IKarmaTypeRepository karmaTypesRepository, 
            IKarmaVoteRepository karmaVoteRepository, IEmployeeRepository employeeRepository) : base(karmaRepository)
        {
            _karmaTypesRepository = karmaTypesRepository;            
            _karmaVoteRepository = karmaVoteRepository;
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Создает и возвращает новую карму
        /// </summary>        
        /// <param name="karmaDto"> DTO модель кармы</param>
        /// <returns>DTO модель сохраненной кармы</returns>
        public override async Task<KarmaDto> Create(KarmaDto karmaDto)
        {
            if (karmaDto == null)
                throw new ArgumentException($"Параметр {nameof(karmaDto)} не может быть NULL", nameof(karmaDto));            
            
            Employee employee = _employeeRepository.FirstOrDefault(karmaDto.EmployeeId);
            if (employee == null) throw new EntityNotFoundException($"Сотрудник с идентификатором  " + karmaDto.EmployeeId + " не существует.");

            KarmaType karmaType = _karmaTypesRepository.FirstOrDefault(karmaDto.KarmaTypeId);
            if (karmaType == null) throw new EntityNotFoundException($"Тип кармы с идентификатором  " + karmaDto.KarmaTypeId + " не существует.");

            Employee createdBy = _employeeRepository.FirstOrDefault(karmaDto.CreatedById);
            if (createdBy == null) throw new EntityNotFoundException($"Сотрудник с идентификатором  " + karmaDto.CreatedById + " не существует.");
            

            var newKarma = new Karma
            {
                CreatedBy = createdBy,
                Employee = employee,
                KarmaType = karmaType
            };

            newKarma = await  Task.Run(()=>Repository.Insert(newKarma));
            if (newKarma == null)
                throw new InvalidOperationException("Ошибка при сохранении в базу");

            karmaDto = ObjectMapper.Map<KarmaDto>(newKarma);

            return karmaDto;
        }

        /// <summary>
        /// Удаление кармы
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public override async Task Delete(Guid id)
        {
            Karma karma = Repository.FirstOrDefault(id);
            if (karma == null)
                throw new EntityNotFoundException($"Кармы с идентификатором " + id + " не существует");

            // Логика проверки:
            // Карму невозможно удалить если кто-то уже поставил свою оценку  
            int countVote = _karmaVoteRepository.Count(x => x.Karma.Id == id);
            if (countVote != 0)
                throw new InvalidOperationException($"Невозможно удалить запись " + id + ". Имеются голоса за эту карму.");

            Repository.Delete(id);
        }

        /// <summary>
        /// Список карм определенного сотрудника 
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        /// <param name="skip">skip = n - пропустить первые n элементов списка</param>
        /// <param name="top">top = m - вывести m элементов</param>
        /// <returns>Список DTO моделей кармы одного сотрудника</returns>
        public PagedCollectionDto<KarmaDto> GetEmployeeKarms(Guid employeeId, int skip, int top)
        {
            //Если сотрудника с заданым ID не существует, то вызываем исключение.
            //Если сотрудник есть, но с ним не связана ни одна Карма, то выдаем пустой массив

            var employee = _employeeRepository.FirstOrDefault(employeeId);
            if (employee == null)
                throw new EntityNotFoundException($"Сотрудника с идентификатором " + employeeId + " не существует.");

            var allEmployeeKarms = Repository.GetAll().Where(x => x.Employee.Id == employeeId);
            
            List<Karma> selectedKarma = allEmployeeKarms
                .OrderBy(x => x.CreatedDate)
                .Skip(skip)
                .Take(top)
                .ToList();

            var employeeKarmsDto = ObjectMapper.Map<List<KarmaDto>>(selectedKarma);

            var result = new PagedCollectionDto<KarmaDto>
            {
                Count = employeeKarmsDto.Count,
                Items = employeeKarmsDto,
                Total = allEmployeeKarms.Count()
            };

            return result;
        }

        /// <summary>
        /// Обновляет и возвращает карму
        /// </summary>
        /// <param name="karmaDto">DTO модель кармы</param>
        /// <returns>DTO модель обновленной кармы</returns>
        public override async Task<KarmaDto> Update(KarmaDto karmaDto)
        {
            if (karmaDto == null)
                throw new ArgumentException($"Параметр {nameof(karmaDto)} не может быть NULL", nameof(karmaDto));       
            

            Employee employee = _employeeRepository.FirstOrDefault(karmaDto.EmployeeId);
            if (employee == null) throw new EntityNotFoundException($"Сотрудник с идентификатором  " + karmaDto.EmployeeId + " не существует.");

            KarmaType karmaType = _karmaTypesRepository.FirstOrDefault(karmaDto.KarmaTypeId);
            if (karmaType == null) throw new EntityNotFoundException($"Тип кармы с идентификатором  " + karmaDto.KarmaTypeId + " не существует.");

            Employee createdBy = _employeeRepository.FirstOrDefault(karmaDto.CreatedById);
            if (createdBy == null) throw new EntityNotFoundException($"Сотрудник с идентификатором  " + karmaDto.CreatedById + " не существует.");
                                    

            var karma = new Karma()
            {
                Id = karmaDto.Id,
                Employee = employee,
                CreatedBy = createdBy,
                KarmaType = karmaType                
            };

            //Метод Update в репозиториях создает новую запись, в случае если записи с таким Id нет
            karma = await Task.Run(()=> Repository.Update(karma));
          
            if (karma == null)
                throw new InvalidOperationException($"Не удалось обновить или создать карму по идентификатору " + karmaDto.Id);

            KarmaDto newKarmaDto = ObjectMapper.Map<KarmaDto>(karma);
           
            return newKarmaDto;
        }

        /// <summary>
        /// Число карм определенного сотрудника 
        /// </summary>
        /// <param name="employeeId">>Идентификатор сотрудника</param>
        /// <returns>Колличество карм сотрудника</returns>
        public int CountEmployeeKarm(Guid employeeId)
        {
            return Repository.Count(x => x.Employee.Id == employeeId);
        }
    }
}