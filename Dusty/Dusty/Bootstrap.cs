using Autofac;
using Dusty.Services;
using Dusty.ViewModels;
using Dusty.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dusty
{
    public static class Bootstrap
    {
        // ===========================================================================
        // = Initialization
        // ===========================================================================
        
        public static void Run(App app)
        {
            // Register platform services.
            var builder = new ContainerBuilder();
            RegisterPlatform(builder);

            // Register app services.
            RegisterApp(builder);

            // Realise container.
            var container = builder.Build();

            // Register views.
            RegisterViews(container);

            // Set up navigation context.
            SetupNavigationContext(container);

            // Show initial view.
            ShowMainView<MainViewModel>(container, app);
        }

        // ===========================================================================
        // = Registration
        // ===========================================================================
        
        private static void RegisterPlatform(ContainerBuilder builder)
        {
            builder.RegisterType<ViewService>().As<IViewService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
        }

        private static void RegisterApp(ContainerBuilder builder)
        {
            // You can add your own app services, view models & view registrations here.
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<CellarViewModel>();
            builder.RegisterType<FeedViewModel>();
            builder.RegisterType<ProfileViewModel>();
            builder.RegisterType<SettingsViewModel>();

            builder.RegisterType<MainView>();
            builder.RegisterType<CellarView>();
            builder.RegisterType<FeedView>();
            builder.RegisterType<ProfileView>();
            builder.RegisterType<SettingsView>();
        }

        private static void RegisterViews(IContainer container)
        {
            var viewService = container.Resolve<IViewService>();

            // You can add your view model -> view registrations here.
            viewService.Register<MainViewModel, MainView>();
            viewService.Register<CellarViewModel, CellarView>();
            viewService.Register<FeedViewModel, FeedView>();
            viewService.Register<ProfileViewModel, ProfileView>();
            viewService.Register<SettingsViewModel, SettingsView>();
        }

        // ===========================================================================
        // = Application Startup
        // ===========================================================================
        
        private static void ShowMainView<T>(IContainer container, App app)
            where T : class, IViewModel
        {
            var viewService = container.Resolve<IViewService>();
            var view = (Page)viewService.Resolve<T>();

            // Feel free to tweak this to your liking, based on the layout of your app.
            if (view is NavigationPage)
            {
                app.MainPage = view;
            }
            else if (view is TabbedPage)
            {
                app.MainPage = view;
            }
            else if (view is ContentPage)
            {
                var nav = new NavigationPage(view);
                app.MainPage = nav;
            }
            else
                throw new NotSupportedException("Unsupported base view: " + view.GetType().Name);
        }

        // ===========================================================================
        // = Navigation Context
        // ===========================================================================
        
        private static void SetupNavigationContext(IContainer container)
        {
            var navigationService = container.Resolve<INavigationService>();

            navigationService.SetRootNavigationContext(GetRootNavigation);
            navigationService.SetScopedNavigationContext(GetScopedNavigation);
        }

        private static INavigation GetRootNavigation()
        {
            var mainPage = App.Current.MainPage;

            // Main page is a TabbedPage (not wrapped in a NavigationPage).
            if (mainPage is TabbedPage)
            {
                var selectedTabNav = TryGetSelectedTabNavigation((TabbedPage)mainPage);
                return selectedTabNav;
            }

            // Main page is a NavigationPage.
            if (mainPage is NavigationPage)
                return ((NavigationPage)mainPage).Navigation;

            return null;
        }

        private static INavigation GetScopedNavigation()
        {
            var mainPage = App.Current.MainPage;

            // Main page is a TabbedPage (not wrapped in a NavigationPage).
            if (mainPage is TabbedPage)
            {
                var selectedTabNav = TryGetSelectedTabNavigation((TabbedPage)mainPage);
                return selectedTabNav;
            }

            // Main page is a NavigationPage.
            if (mainPage is NavigationPage)
            {
                var navPage = (NavigationPage)mainPage;

                // Is there a TabbedPage in here that we can navigate with?
                if (navPage.CurrentPage is TabbedPage)
                {
                    var selectedTabNav = TryGetSelectedTabNavigation((TabbedPage)navPage.CurrentPage);

                    if (selectedTabNav != null)
                        return selectedTabNav;
                }

                // Nope. Let's just return this one.
                return ((NavigationPage)mainPage).Navigation;
            }

            return null;
        }

        private static INavigation TryGetSelectedTabNavigation(TabbedPage tabbedPage)
        {
            var selected = tabbedPage.CurrentPage;

            if (selected is NavigationPage)
                return ((NavigationPage)selected).Navigation;

            return null;
        }
    }
}
