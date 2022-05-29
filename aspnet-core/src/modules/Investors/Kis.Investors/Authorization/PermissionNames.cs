namespace Kis.Investors.Authorization
{
    public static class PermissionNames
    {
        // Просмотр списка инвестиционных проектов
        public const string InvestedProjectList = "InvestedProjectList";
        // Просмотр информации об инвестиционном проекте
        public const string InvestedProjectDetails = "InvestedProjectDetails";
        // Право на создание, изменение, удаление инвестиционного проекта
        public const string InvestedProjectManagement = "InvestedProjectManagement";

        // Право на создание, изменение, удаление инвестора
        public const string InvestorManagement = "InvestorManagement";
        // Просмотр списка инвесторов в инвестиционном проекте
        public const string InvestorForProject = "InvestorForProject";

        // Право на создание, изменение, удаление товарищества
        public const string PartnershipManagement = "PartnershipManagement";

        // Право на создание, изменение, удаление члена товарищества
        public const string PartnershipMemberManagement = "PartnershipMemberManagement";
    }
}
