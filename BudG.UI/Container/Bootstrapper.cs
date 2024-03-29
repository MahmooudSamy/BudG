using Autofac;
using BudG.DataAccess;
using BudG.DataAccess.Repositories.Classes;
using BudG.DataAccess.Repositories.Interface;
using BudG.DataAccess.Repositories.Lookups;
using BudG.UI.Interface;
using BudG.UI.ViewModels;
using Prism.Events;

namespace BudG.UI.Container
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var bulider = new ContainerBuilder();
            bulider.RegisterType<SplashScreen>().AsSelf();
            bulider.RegisterType<BudGDbContext>().AsSelf();
            bulider.RegisterType<AouthraizationWindow>().AsSelf();
            bulider.RegisterType<MainWindow>().AsSelf();
            bulider.RegisterType<MainViewModel>().AsSelf();

            //services
            bulider.RegisterType<LookupDataServices>().AsImplementedInterfaces();
            bulider.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            
            //services

            //repo
            bulider.RegisterType<UserReposetry>().As<IUserReposetry>();
            bulider.RegisterType<QuestionsReposetry>().As<IQuestionsReposetry>();
            bulider.RegisterType<AnswerReposetry>().As<IAnswerReposetry>();
            //repo

            //ViewModel
            bulider.RegisterType<UserViewModel>().As<IUserViewModel>();
           
            bulider.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            //ViewModel
            return bulider.Build();
        }
       
    }
}
