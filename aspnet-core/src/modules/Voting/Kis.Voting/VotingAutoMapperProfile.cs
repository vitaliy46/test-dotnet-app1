using System;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.BulletinSelectedOption;
using Kis.Voting.Api.Entity;

namespace Kis.Voting
{
    public class VotingAutoMapperProfile : AutoMapper.Profile
    {
        public VotingAutoMapperProfile()
        {
            CreateMap<BulletinDto, Bulletin>()
                .ForMember(x => x.BulletinSelectedOptions, x => x.Ignore());
            CreateMap<CreateBulletinDto, BulletinDto>();
            CreateMap<Bulletin, BulletinDto>();
            CreateMap<BulletinSelectedOptionDto, BulletinSelectedOption>();
            CreateMap<BulletinSelectedOption, BulletinSelectedOptionDto>();
            CreateMap<CreateBulletinSelectedOptionDto, BulletinSelectedOptionDto>();
            CreateMap<NoticeReceiptConfimationDto, NoticeReceiptConfimation>();
            CreateMap<NoticeReceiptConfimation, NoticeReceiptConfimationDto>();
            CreateMap<CreateVoteDto, VoteDto>()
                .ForMember(x => x.Medias, x => x.Ignore())
                .ForMember(x => x.Links, x => x.Ignore());
            CreateMap<UpdateVoteDto, VoteDto>()
                .ForMember(x => x.Medias, x => x.Ignore())
                .ForMember(x => x.Links, x => x.Ignore());
            CreateMap<VoteDto, GetVoteDto>();
            CreateMap<VoteDto, VoteShortDto>()
                .ForMember(x => x.VoteStateName, x=> x.MapFrom(d=>
                    d.NoteSendingDateTime > DateTime.Now ? "В подготовке":
                    d.BeginDateTime > DateTime.Now ? "Объявлено" :
                    d.EndDateTime > DateTime.Now ? "Запущено" :"Завершено"
                ));
            CreateMap<VoteDto, Vote>()
                .ForMember(x => x.Options, x => x.Ignore());
            CreateMap<Vote, VoteDto>();
            CreateMap<VoteLinkDto, VoteLink>();
            CreateMap<VoteLink, VoteLinkDto>();
            CreateMap<VoteMediaDto, VoteMedia>();
            CreateMap<VoteMedia, VoteMediaDto>();
            CreateMap<CreateVoteMediaDto, VoteMediaDto>();
            CreateMap<VoteMemberDto, VoteMember>()
                .ForMember(x => x.VoteMemberContact, x => x.Ignore());
            CreateMap<VoteMember, VoteMemberDto>();
            CreateMap<VoteMemberContactDto, VoteMemberContact>();
            CreateMap<VoteMemberContact, VoteMemberContactDto>();
            CreateMap<VoteNoticeDto, VoteNotice>();
            CreateMap<VoteNotice, VoteNoticeDto>();
            CreateMap<CreateVoteOptionDto, VoteOptionDto>();
            CreateMap<UpdateVoteOptionDto, VoteOptionDto>();
            CreateMap<VoteOptionDto, VoteOption>();
            CreateMap<VoteOption, VoteOptionDto>();
            CreateMap<VoteReportDto, VoteReport>();
            CreateMap<VoteReport, VoteReportDto>();
            CreateMap<VoteReportMediaDto, VoteReportMedia>();
            CreateMap<VoteReportMedia, VoteReportMediaDto>();
            CreateMap<VoteSettingsDto, VoteSettings>();
            CreateMap<VoteSettings, VoteSettingsDto>();
            CreateMap<VoteResultDto, VoteResult>();
            CreateMap<VoteResult, VoteResultDto>();
        }
    }
}
