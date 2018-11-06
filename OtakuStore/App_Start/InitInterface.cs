using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Data.Infrastructure;
using Service;
using Data;
using Data.Repository;
namespace OtakuStore.App_Start
{
    public static class InitInterface
    {
        public static void Run()
        {
            SetAutofacContainer();


        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(WishListService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(WishListRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(TypeService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(TypeRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(
            typeof(TagService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(TagRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(StatusService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(StatusRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ProductTagService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ProductTagRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ProductService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ProductRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(OrderProductService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(OrderProductRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(OrderService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(OrderRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(NotificationService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(NotificationRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ManufactorService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ManufactorRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ImageService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(ImageRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(DiscountService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(DiscountRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(CommentService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(CommentRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(BlogImageService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(BlogImageRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(BlogService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(BlogRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(AccountService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(AccountRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(CategoryService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(CategoryRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(AnimeService).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(
            typeof(AnimeRepository).Assembly)
            .AsImplementedInterfaces()
            .InstancePerHttpRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}