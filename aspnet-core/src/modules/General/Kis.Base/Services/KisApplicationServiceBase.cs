using Abp.Application.Services;
using AutoMapper;

namespace Kis.Base.Services.Bl
{
    public abstract class KisApplicationServiceBase : ApplicationService
    {
        public IMapper Mapper { get; set; }
    }
}
