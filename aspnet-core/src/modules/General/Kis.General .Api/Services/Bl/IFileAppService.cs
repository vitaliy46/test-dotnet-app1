
using System;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.General.Api.Dto;
using Microsoft.AspNetCore.Http;

namespace Kis.General.Api.Services.Bl
{
    public interface IFileAppService : IApplicationService
    {
        Task<byte[]> GetFile(Guid mediaId);

        Task<string> AddFile(byte[] fileBytes, string filename, string contentType, CreateMediaDto createMediaDto = null);
    }
}
