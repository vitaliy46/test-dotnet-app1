using Abp.Application.Navigation;
using Abp.Localization;

namespace It2g.Reporter.Web
{
        public class ReporterNavigationProvider : Abp.Application.Navigation.NavigationProvider
        {
            public override void SetNavigation(INavigationProviderContext context)
            {
                context.Manager.MainMenu.AddItem(
                    new MenuItemDefinition("Reference", new FixedLocalizableString("Кадры"),
                        "fa fa-lemon-o", order: 1)

                        .AddItem(new MenuItemDefinition("Reports", new FixedLocalizableString("Отчетьность"),
                            "fa fa-lemon-o", "Reports/Index", order: 0))

                        .AddItem(new MenuItemDefinition("ReferenceBook", new FixedLocalizableString("По задачам"),
                            "fa fa-lemon-o", "ReferenceBook/Index", order: 1))
                        .AddItem(new MenuItemDefinition("ReferenceBook", new FixedLocalizableString("По найму"),
                            "fa fa-lemon-o", "ReferenceBook/Index", order: 2)));
            }
        }
    
}