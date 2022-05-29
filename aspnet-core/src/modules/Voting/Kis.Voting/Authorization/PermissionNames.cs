namespace Kis.Voting.Authorization
{
    public static class PermissionNames
    {
        // Vote

        // Просмотр списка голосований
        public const string VoteList = "VoteList";
        // Просмотр информации о голосовании
        public const string VoteDetails = "VoteDetails";
        // Право на создание, изменение, публикацию голосования
        public const string VoteManagement = "VoteManagement";
        // Право на участие в голосовании
        public const string Voting = "Voting";

        // VoteMember
        public const string VoteMemberGetCurrentForVote = "VoteMemberGetCurrentForVote";

        // VoteMedia
        // Право на создание, удаление материалов голосования
        public const string VoteMediaManagement = "VoteMediaManagement";
        // Получение материалов голосования
        public const string VoteMediaGet = "VoteMediaGet";

        // Bulletin
        // Получение бюллетеня текущего пользователя для голосования
        public const string BulletinForVote = "BulletinForVote";
    }
}
