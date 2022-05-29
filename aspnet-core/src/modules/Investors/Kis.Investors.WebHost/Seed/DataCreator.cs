using System;
using System.Collections.Generic;
using System.IO;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using JetBrains.Annotations;
using Kis.Base.Services.Crud;
using Newtonsoft.Json;

namespace Kis.Investors.WebHost.TestData
{
    /// <summary>
    /// Добавляет в БД данные на основе содержимого json файлов
    /// </summary>
    public  class DataCreator : ApplicationService
    {
        private readonly IIocResolver _iocResolver;
        
        public DataCreator([NotNull] IIocResolver iocResolver)
        {
            _iocResolver = iocResolver ?? throw new ArgumentNullException(nameof(iocResolver));
        }

        public  void Create<TCreateDto, TDto, TInputDto, TService, TRepo, TEntity>(string file)
            where TCreateDto : IShouldNormalize
            where TDto : IEntityDto<Guid>
            where TInputDto : PagedResultRequestDto, new()
            where TService : IAsyncCrudAppServiceBase<TDto, Guid, TInputDto, TDto, TDto, TDto, TDto>
            where TEntity : Entity<Guid>
            where TRepo : IRepository<TEntity,Guid>
        {
           var repo = _iocResolver.Resolve<TRepo>();

            //Если данные этого типа уже залиты в БД то тестовые данные не заливаются
            var countRecords = repo.GetAllListAsync().Result.Count;
            if ( countRecords > 0) return;

            Console.WriteLine($"Начата загрузка тестовых данных типа {typeof(TDto).Name}");

            //Считываются данные из указанного файла каталога TestData в строковую переменную
            string data = "";
            using (StreamReader sr = new StreamReader(file, System.Text.Encoding.UTF8))
            {
                data = sr.ReadToEnd();
            }

            if (data != "")
            {
                var service = _iocResolver.Resolve<TService>();

                //данные десерелизуются из json в переменную с указанным типом
                IList<TCreateDto> dtos = JsonConvert.DeserializeObject<IList<TCreateDto>>(data);

                foreach (var createDto in dtos)
                {
                    Console.Write(".");
                   var dto = createDto.MapTo<TDto>();

                    dto = service.Create(dto).Result;
                }

                //Логировать факт выгрузки данных
                Console.WriteLine();
                Console.WriteLine($"Данные типа {typeof(TDto).Name} выгружены в БД");
            }
        }

    }
}
