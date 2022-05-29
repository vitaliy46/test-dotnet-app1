using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp.Extensions;
using JetBrains.Annotations;
using Kis.Controllers;
using Kis.General.Api.Services.Bl;
using Kis.General.Api.Services.Crud;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Kis.General.Web.Controllers
{
    [Route("api/[controller]")]
    public class FileController : KisControllerBase
    {
        private readonly IFileAppService _fileAppService;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly string _uploadFolder;
        private readonly IMediaCrudAppService _mediaCrudAppService;

        public FileController([NotNull] IFileAppService fileAppService,
                                [NotNull] IHostingEnvironment appEnvironment,
                                [NotNull] IMediaCrudAppService mediaCrudAppService,
                                [NotNull] IConfiguration configuration)
        {
            _fileAppService = fileAppService ?? throw new ArgumentNullException(nameof(fileAppService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appEnvironment = appEnvironment ?? throw new ArgumentNullException(nameof(appEnvironment));
            _mediaCrudAppService = mediaCrudAppService ?? throw new ArgumentNullException(nameof(mediaCrudAppService));

            _uploadFolder = _configuration.GetValue<string>("App:FileUploadPath");
        }

        // TODO !!! Временно закомментировано пока используется метод AddFile ниже
        //[HttpPost, DisableRequestSizeLimit]
        //[Route("[action]")]
        //public Guid AddFile()
        //{
        //    var file = Request.Form.Files[0];

        //    Guid mediaId = Guid.Empty;

        //    if (file == null)
        //    {
        //        return mediaId;
        //    }

        //    if (file.Length > 0)
        //    {
        //        using (var ms = new MemoryStream())
        //        {
        //            file.CopyTo(ms);
        //            var fileBytes = ms.ToArray();
        //            mediaId = _fileAppService.AddFile(fileBytes, file.FileName, file.ContentType).Result;
        //        }
        //    }

        //    return mediaId;
        //}

        [HttpPost, DisableRequestSizeLimit]
        [Route("[action]")]
        public string AddFile()
        {
            var file = Request.Form.Files[0];

            string url = "";

            if (file == null)
            {
                return url;
            }

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    url = _fileAppService.AddFile(fileBytes, file.FileName, file.ContentType).Result;
                }
            }

            return url;
        }

        // TODO !!! Временно закомментировано пока используется метод Get ниже
        //[HttpGet("{mediaId}")]
        //public async Task<FileResult> Get([FromRoute]Guid mediaId)
        //{
        //    var media = await _mediaCrudAppService.Get(mediaId);

        //    var fileBytes = _fileAppService.GetFile(mediaId).Result;

        //    return File(fileBytes, media.Description, media.FileName);
        //}

        [HttpGet("{mediaId}")]
        public async Task<string> Get([FromRoute]Guid mediaId)
        {
            var media = await _mediaCrudAppService.Get(mediaId);

            //byte[] file = null;

            //string path = $"{_appEnvironment.WebRootPath}/Files/{fileName}";

            //if (!fileName.IsNullOrEmpty())
            //{
            //    file = await _fileAppService.GetFile(fileName);
            //}

            return Path.Combine(_uploadFolder, media.FileName);
        }
    }
}
