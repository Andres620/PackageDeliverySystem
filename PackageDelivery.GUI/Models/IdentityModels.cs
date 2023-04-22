using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PackageDelivery.GUI.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.DocumentTypeModel> DocumentTypeModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.PersonModel> PersonModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.TownModel> TownModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.DepartmentModel> DepartmentModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.AddressModel> AddressModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.HistoryModel> HistoryModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.OfficeModel> OfficeModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.PackageModel> PackageModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.ShipmentModel> ShipmentModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.ShipmentStateModel> ShipmentStateModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.TransportTypeModel> TransportTypeModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.WarehouseModel> WarehouseModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.VehicleModel> VehicleModels { get; set; }
    }
}