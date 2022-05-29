namespace Kis.Voting.Api.Constant
{
    public enum VotingCalculationTypes
    {
        /// <summary>
        /// мажоритарное (решение приниматься простым большинством),
        /// </summary>
        Majority = 0,
        /// <summary>
        /// альтернативное (выбираются несколько вариантов из предложенных)
        /// </summary>
        Alternavive = 1,

        /// <summary>
        /// рейтинговое (каждому варианту присваивается определённый «вес» в зависимости от его предпочтительности)
        /// </summary>
        Rating = 2
    }
}
