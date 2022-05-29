using System;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker
{
    /// <summary>
    /// Профиль, описывающий нестандартные мапинги объектов для AutoMapper
    /// </summary>
    public class TaskTrackerAutoMapperProfile : AutoMapper.Profile
    {

        public TaskTrackerAutoMapperProfile()
        {
            CreateMap<ProjectDto, Project>()
                .ForMember(d => d.ProjectState, x => x.Ignore());
            CreateMap<CreateProjectDto, ProjectDto>();
            CreateMap<UpdateProjectDto, ProjectDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, ProjectShortDto>()
             .ForMember(d=> d.StateName,x=> x.MapFrom(e=> e.ProjectState.State.Name));
            CreateMap<ProjectStateDto, ProjectState>();
            CreateMap<ProjectStateDto, ProjectStateShortDto>()
                .ForMember(d => d.StateName, x => x.MapFrom(e => e.State.Name)); ;
            CreateMap<ProjectState, ProjectStateDto>();
            CreateMap<CreateProjectStateDto, ProjectStateDto>()
                .ForMember(x=>x.Id, y=>y.MapFrom(x=> x.ProposedId != Guid.Empty?x.ProposedId : Guid.Empty));


        }


    }
}
