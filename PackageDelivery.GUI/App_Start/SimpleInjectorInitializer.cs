[assembly: WebActivator.PostApplicationStartMethod(typeof(PackageDelivery.GUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace PackageDelivery.GUI.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
	using PackageDelivery.Application.Contracts.Interfaces.Core;
	using PackageDelivery.Application.Contracts.Interfaces.Parameters;
	using PackageDelivery.Application.Implementation.Implementation.Core;
	using PackageDelivery.Application.Implementation.Implementation.Parameters;
	using PackageDelivery.GUI.Controllers;
	using PackageDelivery.Repository.Contracts.Interfaces.Core;
	using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
	using PackageDelivery.Repository.Implementation.Implementation.Core;
	using PackageDelivery.Repository.Implementation.Implementation.Parameters;
	using PackageDelivery.Repository.Implementation.Parameters;
	using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);
           
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
			//#error Register your services here (remove this line).

			// For instance:
			// container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
			container.Register<IPersonRepository, PersonImpRepository>(Lifestyle.Scoped);
			container.Register<IDocumentTypeRepository, DocumentTypeImpRepository>(Lifestyle.Scoped);
			container.Register<ITownRepository, TownImpRepository>(Lifestyle.Scoped);
			container.Register<IDepartmentRepository, DepartmentImpRepository>(Lifestyle.Scoped);
			container.Register<IAddressRepository, AddressImpRepository>(Lifestyle.Scoped);
			container.Register<IWarehouseRepository, WarehouseImpRepository>(Lifestyle.Scoped);
			container.Register<IVehicleRepository, VehicleImpRepository>(Lifestyle.Scoped);
			container.Register<ITransportTypeRepository, TransportTypeImpRepository>(Lifestyle.Scoped);
			container.Register<IShipmentStateRepository, ShipmentStateImpRepository>(Lifestyle.Scoped);
			container.Register<IShipmentRepository, ShipmentImpRepository>(Lifestyle.Scoped);
			container.Register<IPackageRepository, PackageImpRepository>(Lifestyle.Scoped);
			container.Register<IOfficeRepository, OfficeImpRepository>(Lifestyle.Scoped);
			container.Register<IHistoryRepository, HistoryImpRepository>(Lifestyle.Scoped);

			container.Register<IPersonApplication, PersonImpApplication>(Lifestyle.Scoped);
			container.Register<IDocumentTypeApplication, DocumentTypeImpApplication>(Lifestyle.Scoped);
			container.Register<ITownApplication, TownImpApplication>(Lifestyle.Scoped);
			container.Register<IDepartmentApplication, DepartmentImpApplication>(Lifestyle.Scoped);
			container.Register<IAddressApplication, AddressImpApplication>(Lifestyle.Scoped);
			container.Register<IWarehouseApplication, WarehouseImpApplication>(Lifestyle.Scoped);
			container.Register<IVehicleApplication, VehicleImpApplication>(Lifestyle.Scoped);
			container.Register<ITransportTypeApplication, TransportTypeImpApplication>(Lifestyle.Scoped);
			container.Register<IShipmentStateApplication, ShipmentStateImpApplication>(Lifestyle.Scoped);
			container.Register<IShipmentApplication, ShipmentImpApplication>(Lifestyle.Scoped);
			container.Register<IPackageApplication, PackageImpApplication>(Lifestyle.Scoped);
			container.Register<IOfficeApplication, OfficeImpApplication>(Lifestyle.Scoped);
			container.Register<IHistoryApplication, HistoryImpApplication>(Lifestyle.Scoped);


			container.RegisterMvcControllers(System.Reflection.Assembly.Load("Microsoft.Owin.Security, Version=4.2.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"));
			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());


		}
	}
}