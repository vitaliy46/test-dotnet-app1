using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using JetBrains.Annotations;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Bl;
using Kis.General.Api.Services.Crud;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Kis.General.Services.Bl
{
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IMediaCrudAppService _mediaCrudAppService;

        private readonly string _uploadFolder;

        public FileAppService([NotNull] IHostingEnvironment appEnvironment, [NotNull] IConfiguration configuration, [NotNull] IMediaCrudAppService mediaCrudAppService)
        {
            _appEnvironment = appEnvironment ?? throw new ArgumentNullException(nameof(appEnvironment));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediaCrudAppService = mediaCrudAppService ?? throw new ArgumentNullException(nameof(mediaCrudAppService));

            _uploadFolder = Path.Combine(_appEnvironment.WebRootPath, _configuration.GetValue<string>("App:UploadFolder"));
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        public async Task<byte[]> GetFile(Guid mediaId)
        {
            var media = await _mediaCrudAppService.Get(mediaId);

            var fullPath = Path.Combine(_uploadFolder, $"{media.Id}.{media.Label}");

            return File.ReadAllBytes(fullPath);
        }

        /// <summary>
        /// Метод сохраняет файл на сервере и создает для него запись в БД
        /// Файлу в хранилище присваивается уникальное имя на основании идентификатора записи Media
        /// При загрузке файла с сервера, необходимо восстановить исходное имя файла из поля Media.FileName
        /// </summary>
        /// <param name="fileBytes"></param>
        /// <param name="filename"></param>
        /// <param name="contentType"></param>
        /// <param name="createMediaDto"></param>
        /// <returns></returns>
        /// TODO !!! Временно закомментировано, не удалять!
        //public async Task<Guid> AddFile(byte[] fileBytes, string filename, string contentType, CreateMediaDto createMediaDto = null)
        //{
        //    MediaDto media;

        //    var extension = GetFIleExtensions(filename);

        //    if (createMediaDto != null)
        //    {
        //        media = await _mediaCrudAppService.Create(createMediaDto.MapTo<MediaDto>());
        //    }
        //    else
        //    {
        //        media = new MediaDto(){ FileName = filename, Description = contentType, Label = extension.Substring(1) };
        //        media = await _mediaCrudAppService.Create(media);
        //    }

        //    var fullPath = Path.Combine(_uploadFolder, media.Id + extension);

        //    File.WriteAllBytes(fullPath, fileBytes);

        //    return media.Id;
        //}

        public async Task<string> AddFile(byte[] fileBytes, string filename, string contentType, CreateMediaDto createMediaDto = null)
        {
            var fileNameToSave = Guid.NewGuid().ToString() + GetFIleExtensions(filename);

            var fullPath = Path.Combine(_uploadFolder, fileNameToSave);

            File.WriteAllBytes(fullPath, fileBytes);

            // путь к файлу для фронтенда
            var url = Path.Combine(_configuration.GetValue<string>("App:UploadFolder"), fileNameToSave);

            return url;
        }

        private string GetFIleExtensions(string fileName)
        {
            var extensionPointPosition = fileName.LastIndexOf(".");

            return fileName.Substring(extensionPointPosition);
        }
    }
}
