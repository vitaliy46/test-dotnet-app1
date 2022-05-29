using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Extensions;
using JetBrains.Annotations;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Newtonsoft.Json;

namespace Kis.Voting.Services.Bl
{
    public class MajorityVoteCalculator : IVoteCalculator
    {

        private readonly IBulletinCrudAppService _bulletinCrudAppService;

        public MajorityVoteCalculator([NotNull] IBulletinCrudAppService bulletinCrudAppService)
        {
            _bulletinCrudAppService = bulletinCrudAppService ?? throw new ArgumentNullException(nameof(bulletinCrudAppService));
        }

        public VoteResultDto Calculate(VoteDto vote, float factQuorumPct)
        {
            var result = new VoteResultDto {VoteId = vote.Id};

            var bulletins = _bulletinCrudAppService.GetAll(new PagedBulletinResultRequestDto{ VoteId = vote.Id }).Result.Items;

            //Каждый бюллетень может содержать несколько вариантов ответов если голосование 
            //это предусматривает
            var votedSelectedOptions = bulletins.SelectMany(b => b.BulletinSelectedOptions).ToList();
               
            //Группируем все отмеченные в бюллетенях позиции по вариантам ответов из голосования
            var groupedOptions = votedSelectedOptions.GroupBy(bso => bso.SelectedOptionId)
                .OrderByDescending(x=> x.Count()).ToList();//отсортировали  по убыванию количесва голосов 

            //SignedVoteResult signedVoteResult = new SignedVoteResult();
            var signedVoteResult = new List<(uint quantity, VoteOptionDto option)>();
            foreach (var item in groupedOptions)
            {
                //signedVoteResult.Add(item.Count().To<uint>(), vote.Options.First(x => x.Id == item.Key));
                signedVoteResult.Add((item.Count().To<uint>(), vote.Options.First(x => x.Id == item.Key)));
            }

            var serializedResult = JsonConvert.SerializeObject(signedVoteResult);

            //TODO Подписать результат эл. подписью
            result.SignedResult = serializedResult;

            if (vote.QuorumPct > factQuorumPct)
            {
                //сформировать и записать результат в котором будет указано, что
                //голосование не состоялось по причине отсутсвия кворума
                result.TextResult = $"голосование {vote.Theme} не состоялось, т.к. процент проголосовавших {factQuorumPct}% менее {vote.QuorumPct}%";

                return result;
            }

            var totalVotes = votedSelectedOptions.Count;
            var countMaxVotes = groupedOptions.FirstOrDefault()?.Count();
            var countMaxVotesPercent =(double)countMaxVotes/(double)totalVotes*100;

            // найдем вариант ответа, с наибольшим количеством голосов
            // TODO а что если два варианта набрали одинаковое количество голосов?
            Guid voteOptionId = groupedOptions.FirstOrDefault().Key;
            var voteOption = vote.Options.First(x => x.Id == voteOptionId);

            // выясним набрал ли необходимый процент самый популярный вариант ответа
            if (vote.DecisionMakersPct > countMaxVotesPercent)
            {
                //сформировать и записать результат в котором будет указано, что
                //что процент голосов за победный результат не превысил минимально установленный
                result.TextResult = $"голосование {vote.Theme}: решение не принято, вариант: {voteOption.Text} с наибольшим количеством голосов: {countMaxVotes}";
            }
            else
            {
                result.TextResult = $"голосование {vote.Theme}: решение принято с вариантом: {voteOption.Text}, количество голосов: {countMaxVotes}";
            }

            return result;
        }
    }
}
